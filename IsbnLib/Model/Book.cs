using System;

namespace IsbnLib.model
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Publisher { get; set; }
        public string Isbn { get; set; }

        public Book() : this ("unknown", "unknown", "unknown", DateTime.Today, "unknown")
        { }
        public Book(string title, string author, string publisher, DateTime date, string isbn)
        {
            Title = title;
            Author = author;
            Date = date;
            Publisher = publisher;
            Isbn = isbn;
        }

        public override string ToString()
        {
            return String.Format("Title: {0}\nAuthor: {1}\nPublished: {2}\nPublisher: {3}\nIsbn: {4}", 
                Title, Author, Date.Year, Publisher, Isbn);
        }
    }
}