using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                Console.WriteLine("2) Search by author");
                Console.WriteLine("3) Search by title");
                Console.WriteLine("4) Return books");
                Console.WriteLine("5) Julius Caesar");
                Console.WriteLine("6) Exit the library");
                Console.WriteLine();

                // Get user's selection
                int choice = Program.GetInteger(6);


                if (choice == 1)
                {
                    Console.Clear();

                    PickABook(Books, "This is what we have in our Library!").DisplayBookMenu();

                }
                else if (choice == 2)
                {
                    // Search by author
                    List<Book> searchResults = SearchByAuthor();
                    PickABook(searchResults, "Here is a list of search results by title:").DisplayBookMenu();
                }
                else if (choice == 3)
                {
                    // Search by title
                    List<Book> searchResults = SearchByTitle();
                    if (searchResults.Count > 0)
                    {
                        Console.WriteLine("Please select a book to proceed.");
                        for (int i = 0; i < searchResults.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {searchResults[i]}");
                        }
                        Book selection = searchResults[Program.GetInteger(searchResults.Count)];
                    }
                    PickABook(searchResults, "Here is a list of search results by author:").DisplayBookMenu();
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    DisplayReturnMenu();
                }
                else if (choice == 5)
                {
                    DeleteData();
                    goOn = false;

                }
                else if (choice == 6)
                {
                    // Exit the library
                    Console.Clear();
                    AddData(Books);
                    Console.WriteLine("Thank you for visiting the Library!");
                    goOn = false;
                }
            }
        }

        public virtual void DisplayReturnMenu()
        {
            bool goOn = true;
            while (goOn == true)
            {


                // Display a list of books that are checked out
                // Use a lambda expression to select Book objects with status "Checked Out"
                List<Book> checkedOut = Books.Where(book => book.CheckStatus() == "CheckedOut").ToList();
                //Console.WriteLine($"Test: ");
                foreach (Book checkedOutBook in checkedOut)
                {
                    Console.WriteLine($"{checkedOutBook.Title}");
                }
                Book selection = PickABook(checkedOut, "Here is a list of books that are checked out:");
                DateTime outputDate = selection.Return();
                Console.WriteLine(outputDate);
                Console.WriteLine();
                Console.WriteLine("Return to main menu: Press Enter");
                string input = Console.ReadLine();
                if (input == "")
                {
                    Console.Clear();
                    goOn = false;
                }
            }
        }
        
        public virtual Book PickABook(List<Book> books, string message)
        {
            Console.WriteLine(message);
            Book selection = new Book("null", "null", "null", new DateTime(01, 01, 01));
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {books[i].Title}");
            }
            Console.WriteLine("Please select a book to proceed.");
            selection = books[Program.GetInteger(books.Count) - 1];
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
            }
            if (authorMatch.Count < 1)
            {
                return SearchByAuthor();
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
                if (titleMatch.Count < 1)
                {
                    return SearchByTitle();
                }
            }
            return titleMatch;
        }

        public static void AddData(List<Book> books)
        {
            string filePath = @"../../../Books.txt";
            StreamWriter writer = new StreamWriter(filePath);
            string booksData = "";

            for (int i = 0; i < books.Count; i++)
            {
                string title = books[i].Title;
                string author = books[i].Author;
                string status = books[i].Status;
                DateTime dueDate = books[i].Date;
                booksData += $"{title}, {author}, {status}, {dueDate} \n";

            }

            // Have to get the library into a string 
            writer.Write(booksData);
            writer.Close();

        }

        public static void DeleteData()

        {
            string path=@"../../../Books.txt";
            var fi1 = new FileInfo(path);
            fi1.Delete();


            Console.WriteLine("You have burned down the Library and set human Civilization back by a few hundred years");
      
        }

    }

}