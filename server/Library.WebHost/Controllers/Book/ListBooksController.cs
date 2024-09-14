using Library.Domain.Books.GetBook;
using Library.Domain.Books.ListBooks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WebHost.Controllers.Book
{
    [Route("api/get-books")]
    [ApiController]
    public class ListBooksController : ControllerBase
    {
        private readonly IListBooksUseCase _listBooksUse;
        private readonly IUseCaseExecutor _useCaseExecutor;
        private readonly IActionResultPresenter<ListBooksResponse> _presenter;

        public ListBooksController(IListBooksUseCase listBooksUse, IUseCaseExecutor useCaseExecutor, IActionResultPresenter<ListBooksResponse> presenter)
        {
            _listBooksUse = listBooksUse;
            _useCaseExecutor = useCaseExecutor;
            _presenter = presenter;
        }
        // GET: api/<AddBookController>
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int pageSize = 10,int skip = 0)
        {
            var request = new ListBooksRequest(page, pageSize, skip);
            await _useCaseExecutor.Execute(_listBooksUse, request,_presenter);
            return _presenter.Render();
        }
    }
}
