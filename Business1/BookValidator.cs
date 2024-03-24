using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    internal class BookValidator
    {
        public static List<string> Validate(string enteredTitle, string enteredAuthor, int enteredPrice, string enteredGenre)
        {
            List<String> errors = new List<string>();

            if (String.IsNullOrWhiteSpace(enteredTitle))
            {
                errors.Add("Няма книги с това заглавие!");
            }

            if (String.IsNullOrWhiteSpace(enteredAuthor))
            {
                errors.Add("Няма книги от този автор!");
            }

            if (enteredPrice < 0)
            {
                errors.Add("Моля въведете коректна цена!");
            }

            if (String.IsNullOrWhiteSpace(enteredGenre))
            {
                errors.Add("Няма книги от този жанр!");
            }

            return errors;
        }
    }
}
