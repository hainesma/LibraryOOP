using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOOP
{
    class Library
    {
        List<Book> Books = new List<Book>();

        public Library(List<Book> Books)
        {
            this.Books = Books;
        }

        public virtual void DisplayMenu(List<Book> bookList)
        {
            bool goOn = true;
            while (goOn == true)
            {



                Console.WriteLine("Library Menu:");
                Console.WriteLine("1) Display list of books");
                Console.WriteLine("2) Search by title");
                Console.WriteLine("3) Search by author");
                Console.WriteLine("4) Return books");
                Console.WriteLine("5) Exit the library");
                Console.WriteLine();

                string input = Console.ReadLine();
                int choice = int.Parse(input);

                if (choice == 1)
                {
                    Console.WriteLine("This is what we have in our Library!");
                    Console.WriteLine(" ");
                    foreach (Book bookObj in bookList)
                    {
                        Console.WriteLine(bookObj.Title);
                    }
                }
                else if (choice == 2)
                {
                    // Search by author
                    List<Book> searchResults = SearchByAuthor();
                    foreach (Book result in searchResults)
                    {
                        Console.WriteLine(result.Title);
                    }

                }
                else if (choice == 3)
                {
                    // Search by title
                }
                else if (choice == 4)
                {
                    // Return books
                }
                else if (choice == 5)
                {
                    // Exit the library
                    Console.WriteLine("Thank you for visiting the Library!");
                    goOn = false;
                }
            }
        }

        public virtual Book PickABook(List<Book> books)
        {
            Console.WriteLine("Please select a book to proceed.");
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {books[i]}");
            }
            Book selection = books[Program.GetInteger(books.Count)];
            return selection;
        }

        public virtual List<Book> SearchByAuthor()
        {
            string userInput;
            Console.Write("Which Author would you like to search for?: ");
            userInput = Console.ReadLine().Trim().ToLower();
            List<Book> authorMatch = new List<Book>();
            for (int i = 0; i < Books.Count; i++)
            {


                if (Books[i].Author.ToLower().Contains(userInput))
                {
                    authorMatch.Add(Books[i]);
                }
                else
                {
                    continue;
                }
            }
            return authorMatch;
        }


        public virtual List<Book> SearchByTitle()
        {
            string userInput;
            Console.Write("Which Title would you like to search for?: ");
            userInput = Console.ReadLine().Trim().ToLower();
            List<Book> titleMatch = new List<Book>();
            for (int i = 0; i < Books.Count; i++)
            {


                if (Books[i].Title.ToLower().Contains(userInput))
                {
                    titleMatch.Add(Books[i]);
                }
                else
                {
                    continue;
                }

            }
            return titleMatch;
        }

 
    }

}