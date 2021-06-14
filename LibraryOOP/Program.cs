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
            List<Book> bookList = new List<Book>(ReadInBooks());
            Library ourLibrary = new Library(bookList);
            ourLibrary.DisplayMenu();
        }

        public static List<Book> ReadInBooks()
        {
            string filePath = @"../../../Books.txt";

            // pulling in the info from student.txt document
            StreamReader reader = new StreamReader(filePath);
            string output = reader.ReadToEnd();

            // splitting each line and putting them in a list
            string[] lines = output.Split('\n');

            //creating a list to store objects 
            List<Book> loadedBooks = new List<Book>();

            //adding book objects to a list 
            foreach (string line in lines)
            {
                Book book = ConvertToBookObj(line);
                if (book != null)
                {
                    loadedBooks.Add(book);
                }
            }
            return loadedBooks;
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

        public static int GetInteger(int maxChoices)
        {
            string input = "";
            int output = 0;
            try
            {
                input = Console.ReadLine();
                Console.WriteLine($"input: {input}");
                output = int.Parse(input);
                Console.WriteLine($"output: {output}");
                if (output > maxChoices|| output < 1 )
                {
                    throw new Exception("That number is out of range.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("That was not a valid input.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }
    }
}