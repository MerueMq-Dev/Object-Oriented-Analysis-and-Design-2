using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD2.Solutions
{
    public class TwentyFirstSolution
    {

    }


    /// <summary>
    ///  1. Пример наследования реализации
    /// </summary>   

    // Базовый клиент с полностью реализованным механизмом повторных попыток.
    public class RetryableHttpClient
    {
        protected HttpClient httpClient;
        protected int maxRetries;
        protected int retryDelayMs;
        protected int totalRequests;
        protected int totalRetries;

        public RetryableHttpClient(int maxRetries = 3, int retryDelayMs = 1000)
        {
            httpClient = new HttpClient();
            this.maxRetries = maxRetries;
            this.retryDelayMs = retryDelayMs;
        }

        // Готовая реализация retry, которую используют потомки.
        protected async Task<string> ExecuteWithRetry(Func<Task<string>> action)
        {
            totalRequests++;
            int attempt = 0;

            while (attempt < maxRetries)
            {
                try
                {
                    return await action();
                }
                catch (HttpRequestException)
                {
                    attempt++;
                    if (attempt >= maxRetries)
                        throw;

                    totalRetries++;
                    await Task.Delay(retryDelayMs * attempt);
                }
            }

            throw new Exception("Max retries exceeded");
        }

        // Базовый GET использует механизм retry.
        public virtual async Task<string> GetAsync(string url)
        {
            return await ExecuteWithRetry(async () =>
                await httpClient.GetStringAsync(url));
        }
    }


    // Потомок использует реализацию retry родителя.
    public class AuthorizedApiClient : RetryableHttpClient
    {
        private string apiKey;
        private Dictionary<string, string> rateLimitInfo;

        public AuthorizedApiClient(string apiKey, int maxRetries = 3)
            : base(maxRetries)
        {
            this.apiKey = apiKey;
            rateLimitInfo = new Dictionary<string, string>();

            // Используем httpClient предка и добавляем авторизацию.
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }

        // Переопределяем GET, но retry остаётся от родителя.
        public override async Task<string> GetAsync(string url)
        {
            return await ExecuteWithRetry(async () =>
            {
                var response = await httpClient.GetAsync(url);

                if (response.Headers.Contains("X-RateLimit-Remaining"))
                {
                    rateLimitInfo["remaining"] =
                        response.Headers.GetValues("X-RateLimit-Remaining").First();
                }

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            });
        }

        public int GetRateLimitRemaining()
        {
            return rateLimitInfo.ContainsKey("remaining")
                ? int.Parse(rateLimitInfo["remaining"])
                : -1;
        }

        public int TotalRetries => totalRetries;
    }


    /// <summary>
    /// 2. Пример льготного наследования
    /// </summary>
    /// <param name="vehicleId"></param>

    // Конкретное исключение для случая, когда транспортное средство не найдено.
    // Использует готовую реализацию DomainException — это льготное наследование.
    public class VehicleNotFoundException(Guid vehicleId)
        : DomainException(ErrorCode.Gone, $"Vehicle with id {vehicleId} was not found");

    // Базовый класс для доменных исключений с готовым хранением кода ошибки и сообщения.
    // Потомки просто используют эту реализацию без изменений.
    public abstract class DomainException(ErrorCode errorCode, string message)
        : Exception(message)
    {
        public ErrorCode ErrorCode { get; set; } = errorCode;
    }

    // Коды ошибок.
    public enum ErrorCode
    {
        Gone = 410
    }
}
