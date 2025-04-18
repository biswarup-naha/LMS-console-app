using System;
using System.Collections.Generic;
using System.IO;

namespace LMS
{
    class Program
    {
        static void Main()
        {
            Library lib = new();
            bool open = true;

            while (open)
            {
                Console.WriteLine("\n--- Library Menu ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Search Book by Title");
                Console.WriteLine("4. Borrow Book");
                Console.WriteLine("5. Return Book");
                Console.WriteLine("6. Delete Book");
                Console.WriteLine("7. Save books to File");
                Console.WriteLine("8. Load books from File");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "0": open = false; break;
                    case "1": lib.AddBook(); break;
                    case "2": lib.ViewBooks(); break;
                    case "3": lib.SearchBook(); break;
                    case "4": lib.BorrowBook(); break;
                    case "5": lib.ReturnBook(); break;
                    case "6": lib.DeleteBook(); break;
                    case "7": lib.SaveLib(); break;
                    case "8": lib.LoadLib(); break;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }
    }
}
