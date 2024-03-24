using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Book
    {

        private int id;
        private string title;
        private string author;
        private string genre;
        private double price;
        public Book()
        {

        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price should be a positive number!");
                }
                else
                {
                    price = value;
                }
            }
        }


        public Book(int id, string title, string author, string genre, double price)
        {
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.Price = price;
        }
        public override string ToString()
        {
            return $"Title: {title}\nAuthor: {author}\nGenre: {genre}\nPrice: {price}\n";
        }
    }

}
