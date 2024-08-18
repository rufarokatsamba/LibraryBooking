namespace Library.Domain.Books.GetBook;

public interface IErrorPresenter
{
    void ErrorFull(Exception exception);
}