namespace Library.Domain.Tests.BookTests;
using Library.Domain.Book;
using NUnit.Framework;
using FluentAssertions;

public class BookTest
{
    [Test]
    public void GivenNewBookIsCreated_ThenReturnNewBook()
    {
        //Arrange
        var bookName = "Nhetembo";
        var author = "Mako";
        var isbn ="NK980";
        var category = Category.Documentary;
        var publisher = "RUfaro";
        var edition = "First";
        //Act
        var book = Book.CreateNewBook(bookName, author, isbn, category, publisher, edition);
        //Assert
        book.Should().NotBeNull();
        book.Category.Should().Be(category);
        book.Available.Should().Be(Available.Yes);
    }
    
    [Test]
    public void GivenBookIsNoLongerAvailable_ShouldSetAvailableToFalse()
    {
        //Arrange
        var bookName = "Nhetembo";
        var author = "Mako";
        var isbn ="NK980";
        var category = Category.Documentary;
        var publisher = "RUfaro";
        var edition = "First";
        var id = Guid.NewGuid();
        var book = Book.CreateExistingBook(bookName, author, isbn, publisher, category, edition,id,Available.Yes);
        //Act
        book.SetNotAvailable();
        //Assert
        book.Should().NotBeNull();
        book.Category.Should().Be(category);
        book.Available.Should().Be(Available.No);
    }
}