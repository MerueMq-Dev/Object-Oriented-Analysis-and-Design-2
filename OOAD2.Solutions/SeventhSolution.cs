namespace OOAD2.Solutions;

public static class SeventhSolution
{
    public static void Show()
    {
        // Массив имеет тип базового класса Account

        Account[] accounts = [
            new SavingsAccount(), // фактически объект типа SavingsAccount
            new LoanAccount() // фактически объект типа SavingsAccount
        ];

        foreach (var acc in accounts)
        {
            // Здесь происходит динамическое связывание
            // Компилятор знает, что у acc есть метод CalculateInterest,
            // но какой именно вариант вызвать (Account, SavingsAccount или LoanAccount)
            // решается только во время выполнения (runtime).
            acc.CalculateInterest(1000m);
        }
    }
}

class Account
{
    // Метод помечен ключевым словом virtual и может быть переопределён в наследниках
    public virtual void CalculateInterest(decimal balance)
    {
        Console.WriteLine($"Базовый расчёт процентов для баланса {balance}");
    }
}

class SavingsAccount : Account
{
 
    // С помощью ключевого слова override переопределяем метод предка
    public override void CalculateInterest(decimal balance)
    {
        Console.WriteLine($"Сберегательный счёт: +{balance * 0.05m} процентов");
    }
}

class LoanAccount : Account
{
    // С помощью ключевого слова override переопределяем метод предка
    public override void CalculateInterest(decimal balance)
    {
        Console.WriteLine($"Кредитный счёт: начисляем долг {balance * 0.1m}");
    }
}