namespace OOAD2.Solutions;

public class EleventhSolution
{
    // В языке C# нет явного множественного наследования, но проблему с null/void можно решить с помощью 
    // паттерна Options из функционального подхода.  
    public void Show()
    {
        Option<int> a = Option<int>.Factory.Some(10);
        Option<int> b = Option<int>.Factory.None();

        Console.WriteLine(a is Option<int>.Some); // True
        Console.WriteLine(b is Option<int>.None); // True
    }
}


public abstract record Option<T>
{
    public static class Factory
    {
        public static Option<T> Some(T value) => new Some(value);
        public static Option<T> None() => new None();

    }
    public sealed record Some(T Value) : Option<T>;
    public sealed record None : Option<T>;
}
