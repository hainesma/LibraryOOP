
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
        public string Date { get; set; }

        public Book(string title, string author, string status, string date)
        {
            Title = title;
            Author = author;
            Status = status;
            Date = date;
        }

        public void ReturnInfo()
        {
            Console.WriteLine($"Title {Title}");
            Console.WriteLine($"Author {Author}");
            Console.WriteLine($"Status {Status}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine(" ");
        }

        public virtual string DueDue()
        {
            string dueDate = DateTime.Now.AddDays(14).ToString("dd.MM.yy");
            Date = dueDate;
            return Date;
        }

        public virtual string Return()
        {
            string returnDate = "01.01.01";
            Date = returnDate;
            return Date;

        }

    }

}
