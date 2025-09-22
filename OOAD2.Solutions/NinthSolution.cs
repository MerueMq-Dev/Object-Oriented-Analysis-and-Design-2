using System.Text.Json;

namespace OOAD2.Solutions;

public class NinthSolution
{
    
}


 // Базовый класс General
    public class General : object, ICloneable
    {
        // 1. Глубокое Копирование содержимого 
        public virtual void CopyFrom(General other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            
            string json = JsonSerializer.Serialize(other, other.GetType());
            var copy = JsonSerializer.Deserialize(json, this.GetType());

            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop.CanWrite)
                    prop.SetValue(this, prop.GetValue(copy));
            }
        }

        // 2. Клонирование объекта (создание нового и копирование в него)
        public virtual object Clone()
        {
            string json = JsonSerializer.Serialize(this, GetType());
            return JsonSerializer.Deserialize(json, GetType())!;
        }

        // 3. Глубокое сравнение объектов 
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            string thisJson = JsonSerializer.Serialize(this, GetType());
            string otherJson = JsonSerializer.Serialize(obj, obj.GetType());

            return thisJson == otherJson;
        }

        public override int GetHashCode()
        {
            return JsonSerializer.Serialize(this).GetHashCode();
        }

        // 4. Сериализация
        public virtual string Serialize()
        {
            return JsonSerializer.Serialize(this, GetType(),
                new JsonSerializerOptions { WriteIndented = true });
        }

        // 5. Десериализация
        public static T Deserialize<T>(string json) where T : General
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        // 6. Печать
        public override string ToString()
        {
            return Serialize();
        }

        // 7. Проверка типа и получение реального типа
        public bool IsTypeOf<T>()
        {
            return this is T;
        }

        public Type GetRealType()
        {
            return GetType();
        }
    }

    // Производный класс Any
    public class Any : General
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Any(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public Any() { }
    }