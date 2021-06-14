﻿
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
        public DateTime Date { get; set; }

        public Book(string title, string author, string status, DateTime date)
        {
            Title = title;
            Author = author;
            Status = status;
            Date = date;
        }


        public virtual void DisplayBookMenu()
        {
            bool goOn = true;
            while (goOn == true)
            {
                // Display options
                Console.WriteLine($"{Title}");
                Console.WriteLine("1) Display book info");
                Console.WriteLine("2) Check out book");
                Console.WriteLine("3) Return to search results");
                Console.WriteLine("4) Return to main menu");
                Console.WriteLine();

                // Get user's selection
                int choice = Program.GetInteger(4);

                // If statements to route choices
                if (choice == 1)
                {
                    ReturnInfo();
                }
                else if (choice == 2)
                {
                    Checkout();
                }
                else if (choice == 3)
                {
                    // Return to search results
                    goOn = false;
                }
                else if (choice == 4)
                {
                    // Exit the library
                    Console.WriteLine("Thank you for visiting the Library!");
                    goOn = false;
                }
            }
        }

        public void ReturnInfo()
        {
            Console.WriteLine($"Title {Title}");
            Console.WriteLine($"Author {Author}");
            Console.WriteLine($"Status {Status}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine(" ");
        }

        public virtual string Checkout()
        {
            checkStatus();
            string checkingOut;
            if (Status == "OnShelf")
            {
                Date = DueDate();
                checkingOut = $"You have checked out {Title}, Please Return it by {Date}.";

            }
            else if (Status == "CheckedOut")
            {
                checkingOut=$"Sorry, this book is currently check out, it should be available after {Date}";

            }
            else
            {
                checkingOut = $"Sorry, this book is currently overdue! Please choose another one and check back later for this book";
            }
            return checkingOut;

        }

        public virtual DateTime DueDate()
        {
            DateTime dueDate = DateTime.Now.AddDays(14);
            Date = dueDate;
            return Date;
        }

        public virtual DateTime Return()
        {
            checkStatus();
            if (Status == "CheckedOut")
            {
                Console.WriteLine("Thank you for returning your book");
                DateTime returnDate = new DateTime(0001, 01, 01);
                Date = returnDate; 
            }
            else if (Status == "Overdue!")
            {
                DateTime current = DateTime.Now;
                String diff = (current - Date).TotalDays.ToString();
                double diffNum = Convert.ToInt64(Math.Round(Convert.ToDouble(diff)));
                Console.WriteLine($"The book that you are returning is overdue by {diff} days!");
                //int fines = diffNum * 5;

                DateTime returnDate = new DateTime(0001, 01, 01);
                Date = returnDate;

            }

            else
            {
                Console.WriteLine("This book is not currently Checked out!");
            }
          
            return Date;

        }

        public virtual string checkStatus()
        {
            DateTime current = DateTime.Now;
            DateTime returnDate = new DateTime(0001, 01, 01);
            if (Date > current)
            {
                Status = "CheckedOut";
            }
            else if (Date < current && Date != returnDate)
            {
                Status = "Overdue!";
            }
            else
            {
                Status = "OnShelf";
            }

            return Status;
        }

    }

}
