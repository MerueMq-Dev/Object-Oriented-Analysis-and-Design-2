namespace OOAD2.Solutions;

public class TwelfthSolution
{
}

// Базовый класс General
public partial class General {
    public static T? TryAssign<T>(General source) where T : General
    {
        return source as T;
    }
}

// Производный класс Any
public partial class Any : General
{
    public static T? TryAssign<T>(Any source) where T : General
    {
        return source as T;
    }
}