using System.Diagnostics.CodeAnalysis;

namespace Library.Domain.Books.GetBook;

public interface ISuccessPresenter<in T>
{
    void SuccessFull([DisallowNull] T response);
}