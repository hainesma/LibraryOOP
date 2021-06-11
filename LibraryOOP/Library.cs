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
