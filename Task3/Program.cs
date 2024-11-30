namespace Task3;

using System;

public class MinFinder<T> where T : IComparable<T>  // Клас з обмеженням, щоб T можна було порівнювати
{
    private T value;

    // Конструктор для ініціалізації значення
    public MinFinder(T value)
    {
        this.value = value;
    }

    // Метод для знаходження меншого з двох значень
    public T GetMin(T otherValue)
    {
        if (value.CompareTo(otherValue) < 0)
            return value;  // Якщо поточне значення менше, повертаємо його
        else
            return otherValue;  // Інакше повертаємо інше значення
    }

    // Для демонстрації можливості отримання значення
    public T GetValue()
    {
        return value;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення об'єкта для цілих чисел
        MinFinder<int> intFinder = new MinFinder<int>(10);
        Console.WriteLine($"Мінімум для чисел (10, 20): {intFinder.GetMin(20)}");

        // Створення об'єкта для дійсних чисел
        MinFinder<double> doubleFinder = new MinFinder<double>(25.5);
        Console.WriteLine($"Мінімум для чисел (25.5, 18.2): {doubleFinder.GetMin(18.2)}");

        // Створення об'єкта для рядків
        MinFinder<string> stringFinder = new MinFinder<string>("apple");
        Console.WriteLine($"Мінімум для рядків ('apple', 'banana'): {stringFinder.GetMin("banana")}");
    }
}