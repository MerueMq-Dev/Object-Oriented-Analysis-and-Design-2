namespace OOAD2.Solutions;

public abstract class Car
{
    public abstract void Start();
    public abstract void Stop();
}

// Специализация класса Car: конкретизируем поведение запуска и остановки для бензинового автомобиля
public class FuelCar : Car
{
    public override void Start()
    {
        Console.WriteLine("Запуск машины с двигателем внутреннего сгорания");
    }
    
    public override void Stop()
    {
        Console.WriteLine("Остановка двигателя внутреннего сгорания");
    }
}

// Специализация + расширение класса Car: электромобиль имеет особую остановку с запуском и дополнительные возможности
// по зарядке аккумулятора.
public class ElectricCar : Car
{
    public override void Start()
    {
        Console.WriteLine("Запуск электромашины");
    }

    public override void Stop()
    {
        Console.WriteLine("Выключение электродвигателя");
    }

    // Расширение: электромобиль может заряжаться
    public void Charge()
    {
        Console.WriteLine("Заряжаем аккумулятор машины");
    }
}

// Расширение класса ElectricCar: добавляем новые возможности, не трогая базовый функционал
public class LongRangeElectricCar : ElectricCar
{
    //  Расширение: режим экономии батареи
    public void ActivateBatterySaver()
    {
        Console.WriteLine("Включаем режим экономии батареи");
    }
}