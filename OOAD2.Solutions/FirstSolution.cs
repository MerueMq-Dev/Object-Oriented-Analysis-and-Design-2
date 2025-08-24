namespace OOAD2.Solutions;

public static class FirstSolution
{
    public static void Show()
    {
        Person owner = new("Дмитрий", 32);
        
        // Создаём питомцев (наследование + композиция).
        Dog dog = new("Шарик", owner);
        Cat cat = new("Мурлытик", owner);
        
        // Полиморфизм: один вызов — разные результаты.
        List<Animal> animals = [cat, dog];
        foreach (Animal animal in animals)
        {
            animal.Speak();
        }
    }
}

// Абстрактный класс — базовый для всех животных (наследование).
public abstract class Animal
{
    // Абстрактный метод — разные животные будут реализовывать его по-разному (полиморфизм).
    public abstract void Speak();
}

// "Домашний питомец" — тоже животное, но с дополнительным свойством Owner.
public abstract class Pet : Animal
{
    public string Name { get; }  
    public Person Owner { get; } // Композиция: Pet "содержит" Person.

    public Pet(string name, Person owner)
    {
        Name = name;
        Owner = owner;
    }

}

public class Dog : Pet
{
    public Dog(string name, Person owner) : base(name, owner)
    {
    }
    
    public override void Speak()
    {
        // Собака говорит по своему (полиморфизм)
        Console.WriteLine($"{Name}: Гав-гав");
    }
}

public class Cat : Pet
{
    public Cat(string name, Person owner) : base(name, owner)
    {
    }

    // Кошка/Кот говорит по своему (полиморфизм)
    public override void Speak()
    {
        Console.WriteLine($"{Name}: Мяу-Мяу");
    }
}

// Класс-владелец питомцев.
public record Person(string Name, int Age);