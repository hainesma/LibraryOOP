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
        


        public virtual void SearchByAuthor(List<Book> Books)
        {
            string userInput;
            Console.Write("Which Author would you like to search for?: ");
            userInput = Console.ReadLine().Trim().ToLower();

            for (int i = 0; i < Books.Count; i++)
            {

                if (Books[i].Author.Contains(userInput))
                {
                    Console.WriteLine(Books[i]);
                    continue; 
                }
                else
                {
                    Console.WriteLine("There were no books found with that author");
                    continue;
                }
            }



        }
    }
        
}
