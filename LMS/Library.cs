using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LMS
{
    public class Library
    {
        public Library() { }
        public List<Book> books = [];

        public void AddBook()
        {
            Console.Write("enter book title: ");
            string? title = Console.ReadLine();
            Console.Write("enter author name: ");
            string? author = Console.ReadLine();
            
            books.Add(new Book { Title = title, Author = author, IsBorrowed = false });
            Console.WriteLine("book added successfully.");
        }

        public void DeleteBook()
        {
            Console.Write("enter book title: ");
            string? title = Console.ReadLine() ?? throw new ArgumentNullException("title cannot be null");
            Book? bookToRemove = books.FirstOrDefault(b => b.Title.Equals(title));
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine("book removed successfully.");
            }
            else
            {
                Console.WriteLine("book not found.");
            }
        }

        public void ViewBooks()
        {
            if(books.Count==0) Console.WriteLine("library is having no books.");
            else
                foreach (var book in books)
                    Console.WriteLine(book);
        }

        public void SearchBook()
        {
            Console.Write("enter which book to search: ");
            string? query = Console.ReadLine() ?? throw new ArgumentNullException("query cannot be null");
            var found = books.FindAll(books => books.Title.Contains(query, StringComparison.OrdinalIgnoreCase));
            if(found.Count == 0) Console.WriteLine("no books found.");
            else foreach (var book in found) Console.WriteLine(book);
        }

        public void BorrowBook()
        {
            Console.Write("enter book title to borrow: ");
            string? title = Console.ReadLine() ?? throw new ArgumentNullException("title cannot be null");
            Book? bookToBorrow = books.FirstOrDefault(book => book.Title.Equals(title));
            if(bookToBorrow != null)
            {
                if (bookToBorrow.IsBorrowed)
                {
                    Console.WriteLine("book is already borrowed.");
                }
                else
                {
                    bookToBorrow.IsBorrowed = true;
                    Console.WriteLine("book borrowed successfully.");
                }
            }
            else
            {
                Console.WriteLine("book not found.");
            }
        }

        public void ReturnBook()
        {
            Console.Write("enter book title to return: ");
            string? title = Console.ReadLine() ?? throw new ArgumentNullException("title cannot be null");
            Book? bookToReturn = books.FirstOrDefault(book => book.Title.Equals(title));
            if (bookToReturn != null)
            {
                if (!bookToReturn.IsBorrowed)
                {
                    Console.WriteLine("book is not borrowed.");
                }
                else
                {
                    bookToReturn.IsBorrowed = false;
                    Console.WriteLine("book returned successfully.");
                }
            }
            else
            {
                Console.WriteLine("book not found!!");
            }
        }

        private readonly string file = "library.csv";

        public void SaveLib()
        {
            using StreamWriter sw = new(file);
            try
            {
                {
                    foreach (var book in books)
                    {
                        sw.WriteLine($"{book.Title},{book.Author},{book.IsBorrowed}");
                    }
                }
                Console.WriteLine("library has been saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving library: {ex.Message}");
            }
        }

        public void LoadLib()
        {
            try
            {
                if (File.Exists(file))
                {
                    StreamReader sr = new(file);
                    {
                        string? line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 3)
                            {
                                string title = parts[0];
                                string author = parts[1];
                                bool isBorrowed = bool.Parse(parts[2]);
                                books.Add(new Book { Title = title, Author = author, IsBorrowed = isBorrowed });
                            }
                        }
                    }
                    Console.WriteLine("library has been loaded.");
                }
                else
                {
                    Console.WriteLine("file not found!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading library: {ex.Message}");
            }
        }

    }
}
