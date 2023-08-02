using System;
using System.Collections.Generic;

class Library
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Book> Books { get; } = new List<Book>();
    public List<MediaItem> MediaItems { get; } = new List<MediaItem>();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item)
    {
        MediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        Console.WriteLine($"Library Name: {Name}");
        Console.WriteLine($"Library Address: {Address}");
        
        Console.WriteLine("\nBooks:");
        foreach (var book in Books)
        {
            Console.WriteLine($"{book.Title} by {book.Author}, ISBN: {book.ISBN}, Year: {book.PublicationYear}");
        }
        
        Console.WriteLine("\nMedia Items:");
        foreach (var item in MediaItems)
        {
            Console.WriteLine($"{item.Title} ({item.MediaType}), Duration: {item.Duration} minutes");
        }
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }
}

class MediaItem
{
    public string Title { get; set; }
    public string MediaType { get; set; }
    public int Duration { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library
        {
            Name = "My Library",
            Address = "123 Main St"
        };

        Book book1 = new Book
        {
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            ISBN = "978-0316769488",
            PublicationYear = 1951
        };

        Book book2 = new Book
        {
            Title = "To Kill a Mockingbird",
            Author = "Harper Lee",
            ISBN = "978-0061120084",
            PublicationYear = 1960
        };

        MediaItem media1 = new MediaItem
        {
            Title = "Inception",
            MediaType = "DVD",
            Duration = 148
        };

        MediaItem media2 = new MediaItem
        {
            Title = "Abbey Road",
            MediaType = "CD",
            Duration = 47
        };

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddMediaItem(media1);
        library.AddMediaItem(media2);

        library.PrintCatalog();
    }
}

