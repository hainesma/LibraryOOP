using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOOP
{
    public enum Status
    {
        OnShelf,
        CheckedOut
    }
    
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }

        public Book(string title, string author, DateTime dueDate, Status status)
        {
            Title = title;
            Author = author;
            DueDate = dueDate;
            Status = status;
        }
    }
}
