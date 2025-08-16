using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace LibraryManagemenrSystem
{
    public class LmsRepository
    {
        private static string connectionString = "Data source=lms.db";

        public void SetupDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var createCmd = connection.CreateCommand();
                createCmd.CommandText = @"CREATE TABLE IF NOT EXISTS Books(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT, 
                    Author TEXT)";
                createCmd.ExecuteNonQuery();
            }
        }

        public void AddBook(Book book)
        {
            using(var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = @"INSERT INTO Books 
                (Title , Author) VALUES ( $Title , $Author )";
                insertCmd.Parameters.AddWithValue("$Title" , book.Title);
                insertCmd.Parameters.AddWithValue("$Author" , book.Author);
                insertCmd.ExecuteNonQuery();
            }
        }
        public List<Book> DisplayBooks()
        {
            var books = new List<Book>();
            using(var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var displayCmd = connection.CreateCommand();
                displayCmd.CommandText = "SELECT * FROM Books";
                using(var reader = displayCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = reader.GetInt32(0).ToString(),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2)
                        });
                    }
                }
            }
            return books;
        }
        public int UpdateRecords(Book book)
        {
            using(var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var updateCmd = connection.CreateCommand();
                updateCmd.CommandText = @"UPDATE Books SET Title = $Title ,
            Author = $Author WHERE Id = $Id";
                updateCmd.Parameters.AddWithValue("$Id", book.Id);
                updateCmd.Parameters.AddWithValue("$Title" , book.Title);
                updateCmd.Parameters.AddWithValue("$Author", book.Author);
                return updateCmd.ExecuteNonQuery();

            }
        }
        public int RemoveBook(int Id)
        {
            using(var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var deleteCmd = connection.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Books WHERE Id = $Id";
                deleteCmd.Parameters.AddWithValue("$Id" ,Id);
                return deleteCmd.ExecuteNonQuery();
            }
        }
    }
}