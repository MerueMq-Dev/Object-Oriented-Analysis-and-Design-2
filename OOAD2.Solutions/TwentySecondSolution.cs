using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD2.Solutions
{
    public class TwentySecondSolution
    {
        public void Show()
        {
            var drink1 = new Drink(new Coffee(), new Large());
            drink1.PrintReceipt();

            var drink2 = new Drink(new Tea(), new Small());
            drink2.PrintReceipt();

            var drink3 = new Drink(new Juice(), new Medium());
            drink3.PrintReceipt();
        }

    }

    // Класс Drink реализует наследование вида, потому что напиток можно описать двумя разными способами — какой это напиток(кофе, чай, сок)
    // и какой у него размер(маленький, средний, большой). Оба способа важны, и ни один не главнее другого. Я создал две отдельные группы 
    // классов — одну для типов напитков, другую для размеров. Главный класс Drink берет по одному классу из каждой группы и объединяет их.
    // Так мы можем легко делать любые комбинации (большой кофе, маленький чай и так далее) без написания кучи одинаковых классов и без 
    // проверок типа "если это кофе и размер большой, то...". Если появится новый напиток или новый размер, просто добавим один класс, 
    // и всё заработает.


    // Тип напитка
    public abstract class DrinkType
    {
        public abstract string Name { get; }
        public abstract decimal BasePrice { get; }
    }

    public class Coffee : DrinkType
    {
        public override string Name => "Кофе";
        public override decimal BasePrice => 150m;
    }

    public class Tea : DrinkType
    {
        public override string Name => "Чай";
        public override decimal BasePrice => 100m;
    }

    public class Juice : DrinkType
    {
        public override string Name => "Сок";
        public override decimal BasePrice => 120m;
    }

    // Размер порции
    public abstract class PortionSize
    {
        public abstract string Name { get; }
        public abstract decimal PriceMultiplier { get; }
        public abstract int Volume { get; } // мл
    }

    public class Small : PortionSize
    {
        public override string Name => "Маленький";
        public override decimal PriceMultiplier => 1.0m;
        public override int Volume => 250;
    }

    public class Medium : PortionSize
    {
        public override string Name => "Средний";
        public override decimal PriceMultiplier => 1.5m;
        public override int Volume => 400;
    }

    public class Large : PortionSize
    {
        public override string Name => "Большой";
        public override decimal PriceMultiplier => 2.0m;
        public override int Volume => 600;
    }


    // Главный класс: Напиток (объединяет два признака)
    public class Drink
    {
        private readonly DrinkType _type;
        private readonly PortionSize _size;

        public Drink(DrinkType type, PortionSize size)
        {
            _type = type;
            _size = size;
        }

        public decimal GetPrice()
        {
            return _type.BasePrice * _size.PriceMultiplier;
        }

        public string GetDescription()
        {
            return $"{_size.Name} {_type.Name} ({_size.Volume} мл)";
        }

        public void PrintReceipt()
        {
            Console.WriteLine($"Заказ: {GetDescription()}");
            Console.WriteLine($"Цена: {GetPrice()} руб.");
            Console.WriteLine("-------------------");
        }
    }
}
