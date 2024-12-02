using Book_lazaredvin;
using System;
using System.Collections.Generic;

public class Program
{
    private static Random rnd = new Random();

    public static void Main()
    {
        var books = GenerateBooks();
        int initialStock = 0;
        foreach (var book in books) { initialStock += book.Stock; }

        int salesRevenue = 0;
        int outOfStockCount = 0;

        for (int i = 0; i < 100; i++)
        {
            var book = books[rnd.Next(books.Count)];

            if (book.Stock > 0)
            {
                initialStock--;
                salesRevenue += book.Price;
            }
            else
            {
                outOfStockCount++;
                if (rnd.Next(2) == 0)
                {
                    initialStock += rnd.Next(1, 11);
                }
                else
                {
                    books.Remove(book);
                }
            }
        }

        int finalStock = 0;
        foreach (var book in books){ finalStock += book.Stock; }

        Console.WriteLine("");
        Console.WriteLine($"Bruttó bevétel: {salesRevenue} Ft");
        Console.WriteLine($"Elfogyott könyvek a nagykerben: {outOfStockCount}");
        Console.WriteLine($"Készlet változás: {finalStock - initialStock} db (kezdő készlet: {initialStock} db, végső készlet: {finalStock} db)");
    }
    private static List<Book> GenerateBooks()
    {
        var books = new List<Book>();
        var authorNames = new[] { "Stephen Kings", "Will Smith", "Kevin Hart", "Dwayne Jhonsone", "Juhász Zoltán" };

        for (int i = 0; i < 15; i++)
        {
            var title = "Könyv " + i;
            var authorsCount = rnd.Next(1, 4);
            var authors = new List<Author>();

            for (int j = 0; j < authorsCount; j++)
            {
                var authorName = authorNames[rnd.Next(authorNames.Length)];
                authors.Add(new Author(authorName));
            }

            var isbn = GenerateRandomISBN();
            var stock = rnd.NextDouble() < 0.3 ? 0 : rnd.Next(5, 11);
            var price = (rnd.Next(90, 101) * 100) + 1000;
            var language = rnd.NextDouble() < 0.8 ? "magyar" : "angol";
            var publicationYear = rnd.Next(2007, DateTime.Now.Year + 1);

            books.Add(new Book(isbn, authors, title, publicationYear, language, stock, price));
            Console.WriteLine(title+"-"+publicationYear+"-"+language+"-"+stock+"-"+price);
        }
        return books;
    }
    private static long GenerateRandomISBN()
    {
        return rnd.Next(10000000, 999999999);
    }
}
