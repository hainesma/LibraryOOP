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

        public virtual void DisplayMenu()
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

                // Get user's selection
                int choice = Program.GetInteger(5);


                if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("This is what we have in our Library!");
                    Console.WriteLine(" ");

                    PickABook(Books).DisplayBookMenu();

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
                    List<Book> searchResults = SearchByTitle();
                    foreach (Book result in searchResults)
                    {
                        Console.WriteLine(result.Title);
                    }
                    if (searchResults.Count > 1)
                    {
                        Console.WriteLine("Please select a book to proceed.");
                        for (int i = 0; i < searchResults.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {searchResults[i]}");
                        }
                        Book selection = searchResults[Program.GetInteger(searchResults.Count)];
                    }
                    else
                    {
                        Book selection = searchResults[0];
                    }
                }
                else if (choice == 4)
                {
                    
                }
                else if (choice == 5)
                {
                    // Exit the library
                    Console.Clear();
                    Console.WriteLine("Thank you for visiting the Library!");
                    goOn = false;
                }
            }
        }

        public virtual Book PickABook(List<Book> books)
        {
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {books[i].Title}");
            }
            Console.WriteLine("Please select a book to proceed.");
            Book selection = books[Program.GetInteger(books.Count) - 1];
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