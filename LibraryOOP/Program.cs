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
            // Need to check if this file path works 
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

            Console.WriteLine("This is what we have in our Libary!");
            Console.WriteLine(" ");

            foreach (Book bookObj in bookList)
            {
                bookObj.ReturnInfo();
            }



        }

        public static Book ConvertToBookObj(string line)
        {
            string[] properties = line.Split(',');
            Book bookObj = new Book("null","null", "null");

            if (properties.Length == 3)
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
