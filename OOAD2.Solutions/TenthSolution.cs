namespace OOAD2.Solutions;

public class Vehicle
{ 
    public virtual void Start()
    {
        Console.WriteLine("Start Vehicle");
    }
}

public class SportCar : Vehicle
{
    // Ключевое слово sealed запрещает переопределение виртуального метода в наследнике.
    public sealed override void Start()
    {
        Console.WriteLine("Start Sport Car");
    }
}