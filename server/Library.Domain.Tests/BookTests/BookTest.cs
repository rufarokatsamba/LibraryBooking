using System;
using NUnit.Framework;
using FluentAssertions;
using Library.Domain.Books;

namespace Library.Domain.Tests.BookTests
{
    public class BookTest
    {
        [Test]
        public void GivenNewBookIsCreated_ThenReturnNewBook()
        {
            // Arrange
            var bookName = "Nhetembo";
            var author = "Mako";
            var isbn = "NK980";
            var category = Category.Documentary;
            var publisher = "RUfaro";
            var edition = "First";
            
            // Act
            var book = new BookBuilder()
                .CreateNew()
                .WithBookName(bookName)
                .WithAuthor(author)
                .WithIsbn(isbn)
                .WithCategory(category)
                .WithPublisher(publisher)
                .WithEdition(edition)
                .WithId(Guid.NewGuid())
                .WithAvailable(Available.Yes)
                .Build();
                
            // Assert
            book.Should().NotBeNull();
            book.BookName.Should().Be(bookName);
            book.Author.Should().Be(author);
            book.Isbn.Should().Be(isbn);
            book.Category.Should().Be(category);
            book.Publisher.Should().Be(publisher);
            book.Edition.Should().Be(edition);
            book.Available.Should().Be(Available.Yes);
        }
        
        [Test]
        public void GivenBookIsNoLongerAvailable_ShouldSetAvailableToFalse()
        {
            // Arrange
            var bookName = "Nhetembo";
            var author = "Mako";
            var isbn = "NK980";
            var category = Category.Documentary;
            var publisher = "RUfaro";
            var edition = "First";
            var id = Guid.NewGuid();
            
            // Act
            var book = new BookBuilder()
                .CreateExisting(id)
                .WithBookName(bookName)
                .WithAuthor(author)
                .WithIsbn(isbn)
                .WithPublisher(publisher)
                .WithCategory(category)
                .WithEdition(edition)
                .WithAvailable(Available.Yes)
                .Build();
            
            // Set the book as not available
            book.SetNotAvailable();
            
            // Assert
            book.Should().NotBeNull();
            book.BookName.Should().Be(bookName);
            book.Author.Should().Be(author);
            book.Isbn.Should().Be(isbn);
            book.Category.Should().Be(category);
            book.Publisher.Should().Be(publisher);
            book.Edition.Should().Be(edition);
            book.Available.Should().Be(Available.No);
        }
    }
}
