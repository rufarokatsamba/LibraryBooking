using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Book
{
    public class Book
    {
        private string BookName { get; set; } = null!;
        private string Author { get; set; }= null!;
        private string Isbn { get; set; }= null!;
        private string Publisher { get; init; }= null!;
        public Category Category { get; init; }
        private string Edition { get; init; }= null!;
        private Guid Id { get; init; }
        public Available Available { get; set; }

        public static Book CreateNewBook(string bookName, string author, string isbn,Category category ,string publisher, string edition)
        {
            return new Book
            {
                BookName = bookName,
                Author = author,
                Available = Available.Yes,
                Isbn = isbn,
                Publisher = publisher,
                Category = category,
                Edition = edition,
                Id = Guid.NewGuid()
            };
        }
        public static Book CreateExistingBook(string bookName, string author, string isbn, string publisher, Category category, string edition, Guid id, Available available)
        {
            return new Book
            {
                BookName = bookName,
                Author = author,
                Available = available,
                Isbn = isbn,
                Publisher = publisher,
                Category = category,
                Edition = edition,
                Id = Guid.NewGuid()
            };
        }

        public void SetAvailable()
        {
            Available = Available.Yes;
        }
        public void SetNotAvailable()
        {
            Available = Available.No;
        }
    }
}
