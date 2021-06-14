using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryOOP

// to update your branch to main 'git rebase main'
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"../../../Books.txt";

            // pulling in the info from student.txt document
            StreamReader reader = new StreamReader(filePath);
            string output = reader.ReadToEnd();

            // splitting each line and putting them in a list
            string[] lines = output.Split('\n');

            //creating a list to store objects 
            List<Book> bookList = new List<Book>();

            //adding book objects to a list 
            foreach (string line in lines)
            {
                Book book = ConvertToBookObj(line);
                if (book != null)
                {
                    bookList.Add(book);
                }
            }


            Console.WriteLine("This is what we have in our Library!");
            Console.WriteLine(" ");


            foreach (Book bookObj in bookList)
            {
                Console.WriteLine(bookObj.Title);

            }

            Console.WriteLine();

            //Console.WriteLine("Would you like to search for a book");
            //string userInput = Console.ReadLine();

            Library ourLibrary = new Library(bookList);

            List<Book> searchResults = ourLibrary.SearchByAuthor();
            foreach (Book result in searchResults)
            {
                Console.WriteLine(result.Title);
                result.ReturnInfo();
            }

            Book b1 = new Book("title", "author", "status", new DateTime(0001, 01, 01));


            b1.DueDate();

            b1.ReturnInfo();

            b1.checkStatus();

            b1.ReturnInfo();

        }

        public static Book ConvertToBookObj(string line)
        {
            string[] properties = line.Split(',');
            Book bookObj = new Book("null", "null", "null", new DateTime(01, 01, 01));

            if (properties.Length == 4)
            {
                bookObj.Title = properties[0];
                bookObj.Author = properties[1];
                bookObj.Status = properties[2];
                return bookObj;
            }
            else
            {
                return null;
            }
        }


        

        public static string BookObjToString(Book bookobj)
        {
            string output = $"{bookobj.Title}, {bookobj.Author}, {bookobj.Status} \n";
            return output;
        }
    }
}