using Library.Domain.Books.DomainEvents;

namespace Library.Domain.Books
{
    public class Book : Entity
    {
        public string BookName { get; private set; } = null!;
        public string Author { get; private set; } = null!;
        public string Isbn { get; private set; } = null!;
        public string Publisher { get; init; } = null!;
        public Category Category { get; init; }
        public string Edition { get; init; } = null!;
        public Guid Id { get; init; }
        public Available Available { get; private set; }

        public static Book CreateNewBook(string bookName, string author, string isbn,Category category ,string publisher, string edition)
        {
            var book = new Book
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
            var bookCreatedEvent = new BookCreatedEvent(book.Id, bookName);
            book.DomainEvents.Add(bookCreatedEvent);

            return book;
        }
        public static Book Create(string bookName, string author, string isbn,Category category ,string publisher, string edition, Available available, Guid id)
        {
            var book =  new Book
            {
                BookName = bookName,
                Author = author,
                Available = available,
                Isbn = isbn,
                Publisher = publisher,
                Category = category,
                Edition = edition,
                Id = id
            };
            book.DomainEvents.Add(new BookCreatedEvent(id,bookName));

            return book;
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
