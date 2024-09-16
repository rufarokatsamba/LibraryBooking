namespace Library.Domain.Books
{
    public class Book
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
        public static Book Create(string bookName, string author, string isbn,Category category ,string publisher, string edition, Available available, Guid id)
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
                Id = id
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
