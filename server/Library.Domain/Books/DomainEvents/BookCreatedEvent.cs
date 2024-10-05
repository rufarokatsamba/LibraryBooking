using MediatR;

namespace Library.Domain.Books.DomainEvents
{
    public class BookCreatedEvent : INotification
    {
        public Guid BookId { get; } //These are all get methods as an event is immutable and happened in the past
        // There's no way to update the object, you can only set values when you create it.
        //It's important to highlight here that if domain events were to be handled asynchronously,
        //using a queue that required serializing and deserializing the event objects,
        //the properties would have to be "private set" instead of read-only, so the deserializer would be able to
        //assign the values upon dequeuing. This is not an issue in the Book microservice,
        //as the domain event pub/sub is implemented synchronously using MediatR.
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
