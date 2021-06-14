
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOOP
{

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }

        public Book(string title, string author, string status)
        {
            Title = title;
            Author = author;
            Status = status;
        }

        public void ReturnInfo()
        {
            Console.WriteLine($"Title {Title}");
            Console.WriteLine($"Author {Author}");
            Console.WriteLine($"Status {Status}");
            Console.WriteLine(" ");
        }

    }

}
