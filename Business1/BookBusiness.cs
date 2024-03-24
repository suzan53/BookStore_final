using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class BookBusiness : BookController1
    {
        public List<Book> GetAll()
        {
            var bookList = new List<Book>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM orderabook", connection);
                var command1 = new SqlCommand("SELECT price FROM bookprice", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var book = new Book
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetDouble(4)
                            );
                        bookList.Add(book);
                    }
                }
                // Нямам за втората таблица (да се има предвид ако не работи)
            }
            return bookList;
        }

        public Book Get(int id)
        {
            Book book = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM orderabook", connection);
                var command1 = new SqlCommand("SELECT price FROM bookprice", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        book = new Book
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetDouble(4)
                            );
                    }
                }
            }
            return book;
        }
        public void Add(Book book)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO orderabook (Id, Title, Author, Genre) VALUES (@id, @title, @author, @genre)", connection);
                command.Parameters.AddWithValue("@id", book.Id);
                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@author", book.Author);
                command.Parameters.AddWithValue("@genre", book.Genre);
                connection.Open();
                command.ExecuteNonQuery();

                var command1 = new SqlCommand("INSERT INTO bookprice (Id, Title, Price) VALUES (@id, @title, @price)", connection);
                command1.Parameters.AddWithValue("@id", book.Id);
                command1.Parameters.AddWithValue("@title", book.Title);
                command1.Parameters.AddWithValue("@price", book.Price);
                connection.Open();
                command1.ExecuteNonQuery();
            }
        }

        public void Update(Book book)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("UPDATE orderabook SET Title=@title, Author=@author, Genre=@genre WHERE Id=@id", connection);
                command.Parameters.AddWithValue("@id", book.Id);
                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@author", book.Author);
                command.Parameters.AddWithValue("@genre", book.Genre);
                connection.Open();
                command.ExecuteNonQuery();

                var command1 = new SqlCommand("UPDATE bookprice SET Title=@title, Price=@price WHERE Id=@id", connection);
                command1.Parameters.AddWithValue("@id", book.Id);
                command1.Parameters.AddWithValue("@title", book.Title);
                command1.Parameters.AddWithValue("@price", book.Price);
                connection.Open();
                command1.ExecuteNonQuery();
            }


        }

        public bool Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("DELETE FROM orderabook WHERE Id=@id", connection);
                command.Parameters.AddWithValue("@id", id.ToString());
                connection.Open();
                return command.ExecuteNonQuery() > 0;

                var command1 = new SqlCommand("DELETE FROM bookprice WHERE Id=@id", connection);
                command1.Parameters.AddWithValue("@id", id.ToString());
                connection.Open();
                return command1.ExecuteNonQuery() > 0;
            }
        }
        public void Order(int id, string title, double price)
        {



        }
    }
}
