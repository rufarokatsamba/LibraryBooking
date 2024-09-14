namespace Library.Domain.Books.DomainEvents
{
    public class BookCreatedEvent
    {
        public Guid BookId { get; }
        public string BookName { get; }
        public DateTime CreatedAt { get; }

        public BookCreatedEvent(Guid bookId, string bookName)
        {
            BookId = bookId;
            BookName = bookName;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
