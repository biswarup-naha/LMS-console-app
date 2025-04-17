using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    internal class Library
    {
        public Library() { }
        public List<Book> books = [];

        private const string FilePath = "library.txt";
        public void AddBook()
        {
            Console.Write("enter book title: ");
            string? title = Console.ReadLine();
            Console.Write("enter author name: ");
            string? author = Console.ReadLine();
            
            books.Add(new Book { Title = title, Author = author, IsBorrowed = false });
            Console.WriteLine("book added successfully.");
        }

        public void RemoveBook()
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
            Console.Write("enter title to borrow: ");
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

        public void DeleteBook()
        {
            Console.Write("enter title to delete: ");
            string? title = Console.ReadLine() ?? throw new ArgumentNullException("title cannot be null");
            Book? bookToDelete = books.FirstOrDefault(book => book.Title.Equals(title));
            if(bookToDelete != null)
            {
                books.Remove(bookToDelete);
                Console.WriteLine("book deleted successfully.");
            }
            else
            {
                Console.WriteLine("book not found.");
            }
        }
    }
}
