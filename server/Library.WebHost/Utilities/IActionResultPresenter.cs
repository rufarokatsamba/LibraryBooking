using Library.Domain.Books.GetBook;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebHost.Controllers.Book;

public interface IActionResultPresenter<in T> : IPresenter<T>
{
    IActionResult Render();
}