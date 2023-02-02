using System;
using System.IO;

class CSVThings
{
    class Book
    {
        public string title;
        public int year;
        public double price;
    }

    static void Bookie()
    {
        Book book;
        List<Book> books = new List<Book>();
        StreamReader sr = new StreamReader(@"C:\Users\OliverDixon\Downloads\somedata.csv");
        
        while(!sr.EndOfStream)
        {
            string line = sr.ReadLine()!;
            string[] data = line.Split(',');

            book = new Book();
            book.title = data[0];
            book.year = int.Parse(data[1]);
            book.price = double.Parse(data[2]);
            books.Add(book);
        }

        Console.WriteLine(books);

        Console.ReadLine();
    }
}