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
        public List<Book> books = new List<Book>();

        private const string FilePath = "library.txt";
        public void AddBook()
        {
            Console.Write("enter book title: ");
            string title = Console.ReadLine() ?? "";
            Console.Write("enter author name: ");
            string author = Console.ReadLine() ?? "";
            
            books.Add(new Book { Title = title, Author = author, IsBorrowed = false });
            Console.WriteLine("book added successfully.");
        }
    }
}
