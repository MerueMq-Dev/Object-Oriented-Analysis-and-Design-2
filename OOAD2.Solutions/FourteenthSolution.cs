using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OOAD2.Solutions
{
    public class FourteenthSolution
    {

    }

    public interface IAddable<T> where T : class
    {
        T Add(T other);
    }

    public class Vector<T> : General, IAddable<Vector<T>> where T : General, IAddable<T>
    {
        [JsonInclude]
        public List<T> Elements { get; private set; }

        public int Length => Elements.Count;

        public Vector(int capacity = 0)
        {
            Elements = new List<T>(capacity);
        }

        public Vector(params T[] items)
        {
            Elements = new List<T>(items);
        }

        public Vector(List<T> items)
        {
            Elements = new List<T>(items);
        }
     
        public void Add(T item)
        {
            Elements.Add(item);
        }

        public T Get(int index)
        {
            return Elements[index];
        }

        public void Set(int index, T value)
        {
            Elements[index] = value;
        }

       
        public Vector<T> Add(Vector<T> other)
        {            
            if (other == null || other.Length != this.Length)
                return null;

            Vector<T> result = new Vector<T>();

            for (int i = 0; i < this.Length; i++)
            {         
                T element = this.Elements[i].Add(other.Elements[i]);
                if (element == null)
                    return null;
                result.Add(element);
            }

            return result;
        }

        public override string ToString()
        {
            string items = string.Join(", ", Elements.Select(e => e.ToString()));
            return $"Vector[{Length}] {{ {items} }}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Vector<T> other)
                return false;
            if (this.Length != other.Length)
                return false;
            return this.Elements.SequenceEqual(other.Elements);
        }

        public override int GetHashCode()
        {
            return Elements.GetHashCode();
        }
    }
}
