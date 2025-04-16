using System;
using System.Collections.Generic;
using System.IO;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsBorrowed { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, Status: {(IsBorrowed ? "Borrowed" : "Available")}";
    }
}

class Library
{
    private List<Book> books = [];
    private const string FilePath = "library.txt";

    public void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine() ?? "";
        Console.Write("Enter author name: ");
        string author = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("Invalid input. Title and author cannot be empty.");
            return;
        }

        books.Add(new Book { Title = title, Author = author, IsBorrowed = false });
        Console.WriteLine("Book added successfully.");
    }

    public void ViewBooks()
    {
        if (books.Count == 0) Console.WriteLine("No books available.");
        else
            foreach (var book in books)
                Console.WriteLine(book);
    }

    public void SearchBook()
    {
        Console.Write("Enter title to search: ");
        string query = Console.ReadLine() ?? "";
        var found = books.FindAll(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase));

        if (found.Count == 0) Console.WriteLine("No books found.");
        else foreach (var b in found) Console.WriteLine(b);
    }

    public void BorrowBook()
    {
        Console.Write("Enter title to borrow: ");
        string title = Console.ReadLine() ?? "";
        var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (book == null) Console.WriteLine("Book not found.");
        else if (book.IsBorrowed) Console.WriteLine("Book already borrowed.");
        else
        {
            book.IsBorrowed = true;
            Console.WriteLine("Book borrowed successfully.");
        }
    }

    public void ReturnBook()
    {
        Console.Write("Enter title to return: ");
        string title = Console.ReadLine() ?? "";
        var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (book == null) Console.WriteLine("Book not found.");
        else if (!book.IsBorrowed) Console.WriteLine("Book was not borrowed.");
        else
        {
            book.IsBorrowed = false;
            Console.WriteLine("Book returned successfully.");
        }
    }

    public void DisplayBorrowedBooks()
    {
        var borrowed = books.FindAll(b => b.IsBorrowed);
        if (borrowed.Count == 0) Console.WriteLine("No borrowed books.");
        else foreach (var b in borrowed) Console.WriteLine(b);
    }

    public void DeleteBook()
    {
        Console.Write("Enter title to delete: ");
        string title = Console.ReadLine() ?? "";
        var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (book == null) Console.WriteLine("Book not found.");
        else
        {
            books.Remove(book);
            Console.WriteLine("Book deleted.");
        }
    }

    public void SaveToFile()
    {
        using StreamWriter sw = new(FilePath);
        foreach (var b in books)
            sw.WriteLine($"{b.Title}|{b.Author}|{b.IsBorrowed}");
        Console.WriteLine("Data saved to file.");
    }

    public void LoadFromFile()
    {
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("No saved data found.");
            return;
        }

        books.Clear();
        foreach (var line in File.ReadAllLines(FilePath))
        {
            var parts = line.Split('|');
            if (parts.Length == 3)
            {
                books.Add(new Book
                {
                    Title = parts[0],
                    Author = parts[1],
                    IsBorrowed = bool.Parse(parts[2])
                });
            }
        }
        Console.WriteLine("Data loaded from file.");
    }
}

class Program
{
    static void Main()
    {
        Library lib = new();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Library Menu ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Search Book by Title");
            Console.WriteLine("4. Borrow Book");
            Console.WriteLine("5. Return Book");
            Console.WriteLine("6. Display Borrowed Books");
            Console.WriteLine("7. Delete Book");
            Console.WriteLine("8. Save to File");
            Console.WriteLine("9. Load from File");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1": lib.AddBook(); break;
                case "2": lib.ViewBooks(); break;
                case "3": lib.SearchBook(); break;
                case "4": lib.BorrowBook(); break;
                case "5": lib.ReturnBook(); break;
                case "6": lib.DisplayBorrowedBooks(); break;
                case "7": lib.DeleteBook(); break;
                case "8": lib.SaveToFile(); break;
                case "9": lib.LoadFromFile(); break;
                case "0": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}
