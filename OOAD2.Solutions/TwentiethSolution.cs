using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OOAD2.Solutions;

public class TwentiethSolution
{

    public void Show()
    {
        // Структурное наследование 
        // Класс SearchableDocument реализует интерфейс ISearchable,
        // добавляя новое свойство — возможность поиска по тексту.
        SearchableDocument doc = new SearchableDocument("Inheritance is a key OOP concept.");
        Console.WriteLine($"Содержит 'key'? {doc.Contains("key")}");

        // Наследование вариаций 
        // Переопределение метода Move() (функциональная вариация)
        new FlyingRobot().Move();
        new SwimmingRobot().Move();
        // Перегрузка метода Move(int speed) (вариация типа)
        new SwimmingRobot().Move(10);

        // Наследование с конкретизацией
        // Абстрактный класс Operation реализован конкретными классами Addition и Multiplication
        Operation op1 = new Addition();
        Operation op2 = new Multiplication();
        Console.WriteLine(op1.Execute(3, 4)); // 7
        Console.WriteLine(op2.Execute(3, 4)); // 12
    }

}

// НАСЛЕДОВАНИЕ ВАРИАЦИЙ
// Родительский класс определяет базовое поведение (Move),
// а наследники изменяют или дополняют его.
class Robot
{
    public virtual void Move()
    {
        Console.WriteLine("Робот движется по прямой.");
    }
}

class FlyingRobot : Robot
{
    // Переопределение: робот теперь летит по воздуху
    public override void Move()
    {
        Console.WriteLine("Робот летит по воздуху.");
    }
}

class SwimmingRobot : Robot
{
    // Переопределение: робот теперь плывёт
    public override void Move()
    {
        Console.WriteLine("Робот плывёт по воде.");
    }

    // Перегрузка: теперь можно указать скорость
    public void Move(int speed)
    {
        Console.WriteLine($"Робот плывёт со скоростью {speed} км/ч.");
    }
}


// НАСЛЕДОВАНИЕ С КОНКРЕТИЗАЦИЕЙ
// Абстрактный класс задаёт общий интерфейс (Execute),
// а наследники реализуют конкретные операции.
abstract class Operation
{
    public abstract double Execute(double a, double b);
}

class Addition : Operation
{
    // Конкретизация: теперь операция скаладывает аргументы
    public override double Execute(double a, double b) => a + b;
}

class Multiplication : Operation
{
    // Конкретизация: теперь операция перемножает аргументы
    public override double Execute(double a, double b) => a * b;
}

// СТРУКТУРНОЕ НАСЛЕДОВАНИЕ
// Базовый класс описывает документ, а интерфейс ISearchable добавляет новое свойство — поисковость.
class Document
{
    public string Content { get; set; }
    public Document(string text) => Content = text;
}

// Структурное свойство: возможность поиска
interface ISearchable
{
    bool Contains(string keyword);
}

class SearchableDocument : Document, ISearchable
{
    // Реализация интерфейса добавляет новую возможность — поиск по содержимому
    public SearchableDocument(string text) : base(text) { }

    public bool Contains(string keyword)
    {
        return Content.Contains(keyword, StringComparison.OrdinalIgnoreCase);
    }
}
