using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LMS
    {
    internal class Book
    {
        private string title;
        private string author;

        public required string Title { 
            get { return title; } 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Title cannot be empty.");
                title = value;
            }
        }
        public required string Author {
            get { return author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Author cannot be empty.");
                if(Regex.IsMatch(value, @"\d"))
                    throw new ArgumentException("Author name cannot contain numbers.");
                author = value;
            }
        }
        public bool IsBorrowed { get; set; }

    }
}
