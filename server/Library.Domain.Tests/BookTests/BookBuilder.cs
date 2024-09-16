using System;
using Library.Domain.Books;

namespace Library.Domain.Tests.BookTests
{
    public class BookBuilder
    {
        private string _bookName = "";
        private string _author = "";
        private string _isbn = "";
        private string _publisher = "";
        private Category _category = Category.Non;
        private string _edition = "";
        private Guid _id = Guid.Empty;
        private Available _available = Available.No;

        public BookBuilder CreateNew()
        {
            _id = Guid.NewGuid();
            return this;
        }

        public BookBuilder CreateExisting(Guid id)
        {
            if (id == Guid.Empty)
                throw new InvalidOperationException("ID must be set for existing books");
            return this;
        }

        public BookBuilder WithBookName(string bookName)
        {
            _bookName = bookName;
            return this;
        }

        public BookBuilder WithAuthor(string author)
        {
            _author = author;
            return this;
        }

        public BookBuilder WithIsbn(string isbn)
        {
            _isbn = isbn;
            return this;
        }

        public BookBuilder WithPublisher(string publisher)
        {
            _publisher = publisher;
            return this;
        }

        public BookBuilder WithCategory(Category category)
        {
            _category = category;
            return this;
        }

        public BookBuilder WithEdition(string edition)
        {
            _edition = edition;
            return this;
        }

        public BookBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public BookBuilder WithAvailable(Available available)
        {
            _available = available;
            return this;
        }

        public Book Build()
        {
            if (string.IsNullOrWhiteSpace(_bookName))
                throw new InvalidOperationException("BookName cannot be null or empty");
            if (string.IsNullOrWhiteSpace(_author))
                throw new InvalidOperationException("Author cannot be null or empty");
            if (string.IsNullOrWhiteSpace(_isbn))
                throw new InvalidOperationException("Isbn cannot be null or empty");
            if (string.IsNullOrWhiteSpace(_publisher))
                throw new InvalidOperationException("Publisher cannot be null or empty");
            if (string.IsNullOrWhiteSpace(_edition))
                throw new InvalidOperationException("Edition cannot be null or empty");

            if (_id == Guid.Empty)
            {
                return Book.CreateNewBook(_bookName, _author, _isbn, _category, _publisher, _edition);
            }
            else
            {
                return Book.CreateExistingBook(_bookName, _author, _isbn, _publisher, _category, _edition, _id, _available);
            }
        }
    }
}
