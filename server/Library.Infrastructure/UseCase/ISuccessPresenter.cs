namespace Library.Domain.Books.GetBook;

public interface ISuccessPresenter<in T>
{
    void SuccessFull(T request);
}