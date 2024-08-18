namespace Library.Domain.Books.GetBook;

public interface IErrorPresenter
{
    void GeneralException(Exception exception);
    //Put all other error types here
}