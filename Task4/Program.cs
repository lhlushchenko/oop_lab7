namespace Task4;

using System;
using System.Collections;
using System.Collections.Generic;

// Клас Друкарське Видання
public class Publication
{
    public string Title { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }

    public Publication(string title, int year, decimal price)
    {
        Title = title;
        Year = year;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Title}, {Year}, {Price:C}";
    }
}

// Універсальний клас GenericList<T>
public class GenericList<T> where T : Publication
{
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;

    public GenericList() // Конструктор
    {
        head = null;
    }

    // Метод для додавання елемента в початок списку
    public void AddHead(T item)
    {
        Node newNode = new Node(item);
        newNode.Next = head;
        head = newNode;
    }

    // Метод для перерахунку елементів списку
    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    // Метод для пошуку першого елемента за назвою видання
    public T FindFirstByTitle(string title)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null; // Якщо не знайдено
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення списку видань
        GenericList<Publication> publications = new GenericList<Publication>();

        // Додаємо видання в список
        publications.AddHead(new Publication("C# Programming", 2020, 500));
        publications.AddHead(new Publication("Java Programming", 2021, 450));
        publications.AddHead(new Publication("Python for Beginners", 2022, 350));

        // Перераховуємо всі видання
        Console.WriteLine("Перерахунок всіх видань:");
        foreach (var publication in publications)
        {
            Console.WriteLine(publication);
        }

        // Пошук видання за назвою
        string searchTitle = "Java Programming";
        var foundPublication = publications.FindFirstByTitle(searchTitle);

        if (foundPublication != null)
        {
            Console.WriteLine($"\nЗнайдено видання: {foundPublication}");
        }
        else
        {
            Console.WriteLine($"\nВидання з назвою '{searchTitle}' не знайдено.");
        }
    }
}