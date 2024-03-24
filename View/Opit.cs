using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    internal class Opit
    {
        public Opit2 manager = new Opit2();

        public List<Book> GetAll() => manager.GetAll();

        public Book Get(int id) => manager.Get(id);

        public void Add(Book book) => manager.Add(book);

        public void Update(Book book) => manager.Update(book);

        public bool Delete(int id) => manager.Delete(id);
    }
}
