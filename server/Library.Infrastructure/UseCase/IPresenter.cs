namespace Library.Domain.Books.GetBook;

public interface IPresenter<in T> : ISuccessPresenter<T>, IErrorPresenter
{
}