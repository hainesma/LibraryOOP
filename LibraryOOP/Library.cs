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
                List<Book> authorMatch = new List<Book>();

                if (Books[i].Author.ToLower().Trim().Contains(userInput))
                {
                    authorMatch.Add(Books[i]);
                }
                else
                {
                    continue;
                }
                foreach (Book bookObj in authorMatch)
                {
                    Console.WriteLine(bookObj.Title);
                }
            }
        }

        public virtual void SearchByATitle(List<Book> Books)
        {
            string userInput;
            Console.Write("What Book would you like to search for?: ");
            userInput = Console.ReadLine().Trim().ToLower();
            List<Book> titleMatch = new List<Book>();

            for (int i = 0; i < Books.Count; i++)
            {
            
                if (Books[i].Title.ToLower().Trim().Contains(userInput))
                {
                    titleMatch.Add(Books[i]);
                }
                else
                {
                    continue;
                }

         
            }
            if (titleMatch.Count > 1)
            {
                foreach (Book bookObj in titleMatch)

                { Console.WriteLine(bookObj.Title); }

            }
            else
            {
                Console.WriteLine("sorry, no match");
            }
        }


    }
        
}
