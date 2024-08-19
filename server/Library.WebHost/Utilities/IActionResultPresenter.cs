using System.Diagnostics.CodeAnalysis;
using Library.Domain.Books.GetBook;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebHost.Controllers.Book;

public interface IActionResultPresenter<in T> : IPresenter<T>
{
    IActionResult Render();
}

public class ActionResultPresenter<T> : IActionResultPresenter<T>
{
    public T? _response;
    public InvalidOperationException? _ErrResponse;
    public Exception _errorResponse;
    public void SuccessFull([DisallowNull] T response)
    {
        if (response != null)
        {
            _response = response;
        }
        else
        {
            _ErrResponse = new InvalidOperationException("Response is null");
        }
    }

    public IActionResult Render()
    {
        //To update here for all proper responses
        return new OkObjectResult(_response);
    }

    public void GeneralException(Exception exception)
    {
        _errorResponse = exception;
    }
}
