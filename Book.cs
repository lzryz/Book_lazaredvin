using Book_lazaredvin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_lazaredvin
{
    internal class Book
    {
        public long ISBN { get; private set; }
        public List<Author> Authors { get; private set; }
        public string Title { get; private set; }
        public int PublicationYear { get; private set; }
        public string Language { get; private set; }
        public int Stock { get; private set; }
        public int Price { get; private set; }

        private static Random rnd = new Random();

        public Book(long isbn, List<Author> authors, string title, int publicationYear, string language, int stock, int price)
        {
            ISBN = isbn;
            Authors = authors;
            Title = title;
            PublicationYear = publicationYear;
            Language = language;
            Stock = stock;
            Price = price;
        }

        public Book(string title, string authorName)
        {
            ISBN = GenerateRandomISBN();
            Authors = new List<Author> { new Author(authorName) };
            Title = title;
            PublicationYear = 2024;
            Language = "magyar";
            Stock = 0;
            Price = 4500;
        }

        private long GenerateRandomISBN()
        {
            return rnd.Next(1000000000, 999999999);
        }

        public override string ToString()
        {
            string authorText = Authors.Count == 1 ? "szerző: " : "szerzők: ";
            string stockText = Stock == 0 ? "beszerzés alatt" : $"{Stock} db";
            return $"{Title}, {authorText}{string.Join(", ", Authors.ConvertAll(a => a.Name))}, {PublicationYear}, {Language}, {stockText}, {Price} Ft";
        }
    }
}


