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
    }
}
