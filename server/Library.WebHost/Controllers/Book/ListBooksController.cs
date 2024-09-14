using Library.Domain.Books.GetBook;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WebHost.Controllers.Book
{
    [Route("api/get-books")]
    [ApiController]
    public class ListBooksController : ControllerBase
    {
        private readonly IGetBookUseCase _getBookUseCase;
        private readonly IUseCaseExecutor _useCaseExecutor;
        private readonly IActionResultPresenter<GetBookResponse> _presenter;
        // GET: api/<AddBookController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
