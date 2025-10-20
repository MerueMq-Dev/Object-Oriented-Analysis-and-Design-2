using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD2.Solutions
{
    public class FifteenthSolution
    {
        public void Show()
        {
            // Создаём массив различных платежей
            Payment[] payments =
            [
             new CashPayment(1000, "Покупка товара"),
             new CardPayment(2500, "Оплата услуг", "1234567890123456", "Ivan Petrov"),
             new OnlinePayment(5000, "Онлайн-заказ", "user@example.com")
            ];

            Console.WriteLine("=== ОБРАБОТКА ПЛАТЕЖЕЙ ===");

            // Полиморфная обработка всех платежей
            foreach (var payment in payments)
            {
                Console.WriteLine(payment.GetPaymentInfo());
                payment.Process();
                Console.WriteLine($"Итого к оплате: {payment.Amount + payment.CalculateFee():C}");
                Console.WriteLine("---");
            }

            Console.WriteLine("=== СТАТИСТИКА ===");
            decimal totalAmount = 0;
            decimal totalFees = 0;

            foreach (var payment in payments)
            {
                totalAmount += payment.Amount;
                totalFees += payment.CalculateFee();
            }

            Console.WriteLine($"Общая сумма платежей: {totalAmount:C}");
            Console.WriteLine($"Общая сумма комиссий: {totalFees:C}");
            Console.WriteLine($"Итого: {totalAmount + totalFees:C}");
        }
    }

    public abstract class Payment
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        protected Payment(decimal amount, string description)
        {
            Amount = amount;
            Description = description;
            Date = DateTime.Now;
        }

        public abstract void Process();

        public abstract decimal CalculateFee();

        public abstract string GetPaymentInfo();
    }
    
    public class CashPayment : Payment
    {
        public CashPayment(decimal amount, string description)
            : base(amount, description) { }

        public override void Process()
        {
            Console.WriteLine("Обработка наличного платежа...");
            Console.WriteLine("Выдача чека покупателю");
        }

        public override decimal CalculateFee()
        {         
            return 0;
        }

        public override string GetPaymentInfo()
        {
            return $"Наличный платёж: {Amount:C}, комиссия: {CalculateFee():C}";
        }
    }
    
    public class CardPayment : Payment
    {
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }

        public CardPayment(decimal amount, string description, string cardNumber, string cardHolder)
            : base(amount, description)
        {
            CardNumber = cardNumber;
            CardHolder = cardHolder;
        }

        public override void Process()
        {
            Console.WriteLine("Обработка платежа по карте...");
            Console.WriteLine($"Подключение к банку-эквайеру");
            Console.WriteLine($"Авторизация карты {MaskCardNumber()}");
            Console.WriteLine("Проведение транзакции");
        }

        public override decimal CalculateFee()
        {
            // Комиссия 2% за платёж картой
            return Amount * 0.02m;
        }

        public override string GetPaymentInfo()
        {
            return $"Платёж картой {MaskCardNumber()}: {Amount:C}, комиссия: {CalculateFee():C}";
        }

        private string MaskCardNumber()
        {
            if (CardNumber.Length >= 4)
                return "**** **** **** " + CardNumber.Substring(CardNumber.Length - 4);
            return "****";
        }
    }

    public class OnlinePayment : Payment
    {
        public string Email { get; set; }
        public string TransactionId { get; set; }

        public OnlinePayment(decimal amount, string description, string email)
            : base(amount, description)
        {
            Email = email;
            TransactionId = Guid.NewGuid().ToString();
        }

        public override void Process()
        {
            Console.WriteLine("Обработка онлайн-платежа...");
            Console.WriteLine($"Отправка запроса на email: {Email}");
            Console.WriteLine($"ID транзакции: {TransactionId}");
            Console.WriteLine("Ожидание подтверждения от платёжной системы");
        }

        public override decimal CalculateFee()
        {
            // Фиксированная комиссия 30 руб. + 3%
            return 30 + Amount * 0.03m;
        }

        public override string GetPaymentInfo()
        {
            return $"Онлайн-платёж ({Email}): {Amount:C}, комиссия: {CalculateFee():C}";
        }
    }
}
