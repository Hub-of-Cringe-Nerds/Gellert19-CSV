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

    static void Main()
    {
        const string CSVFILE = @"C:\Users\OliverDixon\Downloads\somedata.csv";
        const string BINFILE = @"C:\Users\OliverDixon\Downloads\books.bin";
        
        Book book;
        List<Book> books = new List<Book>();
        StreamReader sr = new StreamReader(CSVFILE);
        BinaryWriter bw = new BinaryWriter(File.Open(BINFILE, FileMode.Create));

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine()!;
            string[] data = line.Split(',');

            book = new Book();
            book.title = data[0];
            book.year = int.Parse(data[1]);
            book.price = double.Parse(data[2]);
            books.Add(book);
        }

        sr.Close();

        Console.WriteLine("{0}                        {1}    {2}", "Title", "Year", "Price");
        Console.WriteLine();

        foreach (var b in books)
        {
            Console.WriteLine("{0}    {1}    {2}", b.title.PadRight(25), b.year, b.price);
            Console.WriteLine();
        }

        foreach (var o in books)
        {
            bw.Write(o.title);
            bw.Write(o.year);
            bw.Write(o.price);
        }

        bw.Close();

    }
}