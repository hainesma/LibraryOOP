using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibraryOOP

// to update your branch to main 'git rebase main'
{
    class Program
    {
        static void Main(string[] args)
        {
            Library ourLibrary = new Library(new List<Book>(ReadInBooks()));
            ourLibrary.DisplayMenu();
        }

        public static List<Book> ReadInBooks()
        {
            try
            {
                string filePath = @"../../../Books.txt";

                // pulling in the info from student.txt document
                StreamReader reader = new StreamReader(filePath);
                string output = reader.ReadToEnd();
                reader.Close();

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

            catch (FileNotFoundException)
            {
               
                Console.WriteLine("The Library has been burned down, but we have some new books for you" );
                string filePath = @"../../../Books.txt";

                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine("The Vanishing Half, Brit Bennett, OnShelf, 1/1/0001 12:00:00 AM ");
                    writer.WriteLine("Caste: The origins of Our Discontents, Isabel Wikerson, OnShelf, 1/1/0001 12:00:00 AM ");
                    writer.WriteLine("Deacon King Kong, James McBride, OnShelf, 1/1/0001 12:00:00 AM");
                    writer.WriteLine("Hamnet, Maggie O Farrell, CheckedOut, 6/29/2021 10:02:15 AM ");
                    writer.WriteLine("Leave The World Behind, RuMaan Alam, OnShelf, 1/1/0001 12:00:00 AM ");
                    writer.WriteLine("The Glass Hotel, Emily St. John Mandel, OnShelf, 1/1/0001 12:00:00 AM ");
                    writer.WriteLine("Uncanny Vall, Anna Wiener, OnShelf, 1/1/0001 12:00:00 AM ");
                    writer.WriteLine("Homeland Elegies, Ayad Akhtar, OnShelf, 1/1/0001 12:00:00 AM ");
                    writer.WriteLine("Weather, Jenny Offill, OnShelf, 1/1/0001 12:00:00 AM ");
                    writer.WriteLine("The Mirror and The Light, Hilary Mantel, OnShelf, 1/1/0001 12:00:00 AM ");
                    writer.WriteLine("Real Life, Brandon Taylor, OnShelf, 1/1/0001 12:00:00 AM ");
                    writer.WriteLine("A Promised Land, Barack Obama, OnShelf, 1/1/0001 12:00:00 AM ");

                }
                StreamReader reader = new StreamReader(filePath);
                string output = reader.ReadToEnd();
                reader.Close();

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
        }

        public static Book ConvertToBookObj(string line)
        {
            string[] properties = line.Split(',');
            Book bookObj = new Book("null", "null", "null", new DateTime (01,01,01));
            if (properties.Length == 4)
            {
                bookObj.Title = properties[0].Trim(); ;
                bookObj.Author = properties[1].Trim();
                bookObj.Status = properties[2].Trim();
                bookObj.Date = DateTime.Parse(properties[3]);
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
                output = int.Parse(input);
                if (output > maxChoices|| output < 1 )
                {
                    throw new Exception("That number is out of range.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("That was not a valid input.");
                output = GetInteger(maxChoices);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                output = GetInteger(maxChoices);
            }
            return output;
        }

        
    }
}