namespace Task2;

using System;

class Program
{
    // Універсальний метод для пошуку максимального і мінімального елемента в масиві
    public static (T min, T max) FindMinMax<T>(T[] array) where T : IComparable<T>
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Масив не може бути порожнім.");

        T min = array[0];
        T max = array[0];

        foreach (var item in array)
        {
            if (item.CompareTo(min) < 0)  // item < min
                min = item;

            if (item.CompareTo(max) > 0)  // item > max
                max = item;
        }

        return (min, max);
    }
    
    static void Main(string[] args)
    {
        // Масив цілих чисел
        int[] intArray = { 10, 5, 30, -10, 0, 25 };
        var (intMin, intMax) = FindMinMax(intArray);
        Console.WriteLine($"Мінімум (int): {intMin}, Максимум (int): {intMax}");

        // Масив дійсних чисел (тип double)
        double[] doubleArray = { 10.5, 25.3, -3.6, 100.1, 0.0, 9.8 };
        var (doubleMin, doubleMax) = FindMinMax(doubleArray);
        Console.WriteLine($"Мінімум (double): {doubleMin}, Максимум (double): {doubleMax}");
    }
}