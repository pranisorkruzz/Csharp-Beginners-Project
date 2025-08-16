using System;
using System.Collections.Generic;
using System.Reflection;
using LibraryManagemenrSystem;
using Microsoft.Data.Sqlite;

class Program
{
    static LmsRepository lmsrepository = new LmsRepository();

    static void Main()
    {
        lmsrepository.SetupDatabase();
        GetUserInput();
    }

    static void GetUserInput()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("------LIBRARY MANAGEMENT SYSTEM-------");
            Console.WriteLine("1. ADD NEW BOOK");
            Console.WriteLine("2. DISPLAY ALL BOOKS");
            Console.WriteLine("3. UPDATE BOOK RECORDS");
            Console.WriteLine("4. REMOVE BOOK FROM LIBRARY");
            Console.WriteLine("5. EXITING THE PROGRAM");
            Console.WriteLine("Enter your choice:");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    DisplayBooks();
                    break;
                case "3":
                    UpdateRecords();
                    break;
                case "4":
                    RemoveBook();
                    break;
                case "5":
                    isRunning = false;
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static void AddBook()
    {
        Console.WriteLine("Enter book title:");
        string title = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(title) || int.TryParse(title, out _))
        {
            Console.WriteLine("cannot be empty or numbers");
            return;
        }
        Console.WriteLine("Enter Author name:");
        string author = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(author) || int.TryParse(title, out _))
        {
            Console.WriteLine("cannot be empty or numbers");
            return;
        }
        var newBook = new Book { Title = title, Author = author };
        lmsrepository.AddBook(newBook);
    }
    static void DisplayBooks()
    {
        var books = lmsrepository.DisplayBooks();
        if (books.Count == 0)
        {
            Console.WriteLine("THERE ARE NO BOOKS");
        }

        else
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Displaying all Books");
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}  TITLE: {book.Title}   AUTHOR:  {book.Author}");
            }
        }
        Console.WriteLine("enter any keywords to continue...");
        Console.ReadKey();
    }
    static void UpdateRecords()
    {
        Console.WriteLine("Enter an Id to update:");
        string id = Console.ReadLine();
        if (int.TryParse(id, out int bookId) || bookId > 0)
        {
            Console.WriteLine("Enter title:");
            string newTitle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newTitle) || int.TryParse(newTitle, out _))
            {
                Console.WriteLine("cannot be empty or numbers");
                return;
            }
            Console.WriteLine("Enter Author name:");
            string newAuthor = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newAuthor) || int.TryParse(newAuthor, out _))
            {
                Console.WriteLine("cannot be empty or numbers");
                return;
            }
            var updateBook = new Book { Id = id, Title = newTitle, Author = newAuthor };
            int rowsAffected = lmsrepository.UpdateRecords(updateBook);
            if (rowsAffected > 0)
            {
                Console.WriteLine("Records updated...");
            }
            else
            {
                Console.WriteLine("No records updated. Please check the Id.");
            }
        }
        else
        {
            Console.WriteLine("invalid ID");
        }
    }
    static void RemoveBook()
    {
        Console.WriteLine("Enter an Id for deletion:");
        string id = Console.ReadLine();
        if (int.TryParse(id, out int bookId) || bookId > 0)
        {

            var rowsAffected = lmsrepository.RemoveBook(bookId);

            if (rowsAffected > 0)
            {
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("No book found with the given ID.");
            }
        }
        else
        {
            Console.WriteLine("Invalid id");
        }


    }
}