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


        public static Book SearchByAuthor()
        {
            string userInput;
            Console.Write("Which Author would you like to search for?: ");
            userInput = Console.ReadLine().Trim().ToLower();

            for (i=0; i<Books.count; i++)
            {

                if (Books.Author.contains(userInput))
                { Console.WriteLine(Books[i]); }
                else
                {
                    continue;
                }
            }

      

        }


    }
}
