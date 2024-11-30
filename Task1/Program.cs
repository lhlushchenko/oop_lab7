namespace Task1;

using System;

public class GenericComparer<T> : IComparable<GenericComparer<T>>
{
    public T Value { get; set; }

    public GenericComparer(T value)
    {
        Value = value;
    }

    public int CompareTo(GenericComparer<T> other)
    {
        if (other == null) return 1; // Якщо інший об'єкт null, повертаємо більший

        // Порівняння для типу double
        if (Value is double && other.Value is double)
        {
            double thisValue = (double)(object)Value;
            double otherValue = (double)(object)other.Value;
            return thisValue.CompareTo(otherValue);
        }
        
        // Порівняння для типу string
        if (Value is string && other.Value is string)
        {
            string thisValue = (string)(object)Value;
            string otherValue = (string)(object)other.Value;
            return thisValue.CompareTo(otherValue);
        }

        throw new InvalidOperationException("Неможливе порівняння між різними типами.");
    }

    public override string ToString()
    {
        return $"Value: {Value}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Масив об'єктів для порівняння типів double
        GenericComparer<double>[] doubleValues = new GenericComparer<double>[]
        {
            new GenericComparer<double>(45.6),
            new GenericComparer<double>(12.3),
            new GenericComparer<double>(89.5)
        };

        // Сортуємо масив типів double
        Array.Sort(doubleValues);
        Console.WriteLine("Сортування для типу double:");
        foreach (var value in doubleValues)
        {
            Console.WriteLine(value);
        }

        // Масив об'єктів для порівняння типів string
        GenericComparer<string>[] stringValues = new GenericComparer<string>[]
        {
            new GenericComparer<string>("Banana"),
            new GenericComparer<string>("Apple"),
            new GenericComparer<string>("Orange")
        };

        // Сортуємо масив типів string
        Array.Sort(stringValues);
        Console.WriteLine("\nСортування для типу string:");
        foreach (var value in stringValues)
        {
            Console.WriteLine(value);
        }
    }
}