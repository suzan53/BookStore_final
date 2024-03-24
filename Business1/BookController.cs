using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class BookController1
    {
        public BookBusiness manager = new BookBusiness();

        public List<Book> GetAll() => manager.GetAll();

        public Book Get(int id) => manager.Get(id);

        public void Add(Book book) => manager.Add(book);

        public void Update(Book book) => manager.Update(book);

        public bool Delete(int id) => manager.Delete(id);

    }
}
