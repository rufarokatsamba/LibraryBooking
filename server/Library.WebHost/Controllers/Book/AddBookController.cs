using Library.Domain.Books.AddBook;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WebHost.Controllers.Book
{
    [Route("api/add-book")]
    [ApiController]
    public class AddBookController : ControllerBase
    {
        private readonly IAddBookUseCase _addBookUseCase;
        private readonly IUseCaseExecutor _useCaseExecutor;
        private readonly IActionResultPresenter<AddBookResponse> _presenter;
        public AddBookController(IAddBookUseCase getBookUseCase, IUseCaseExecutor useCaseExecutor, IActionResultPresenter<AddBookResponse> presenter)
        {
            _addBookUseCase = getBookUseCase;
            _useCaseExecutor = useCaseExecutor;
            _presenter = presenter;
        }
        // POST api/<AddBookController>
        [HttpPost]
        public async Task<IActionResult> Post(AddBookRequest request)
        {
            await _useCaseExecutor.Execute(_addBookUseCase, request,_presenter);
            return _presenter.Render();
        }
    }
}
