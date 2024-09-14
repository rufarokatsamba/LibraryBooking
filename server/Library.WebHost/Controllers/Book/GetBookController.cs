using Library.Domain.Books.GetBook;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WebHost.Controllers.Book
{
    [Route("api/get-book")]
    [ApiController]
    public class GetBookController : ControllerBase
    {
        private readonly IGetBookUseCase _getBookUseCase;
        private readonly IUseCaseExecutor _useCaseExecutor;
        private readonly IActionResultPresenter<GetBookResponse> _presenter;
        public GetBookController(IGetBookUseCase getBookUseCase, IUseCaseExecutor useCaseExecutor, IActionResultPresenter<GetBookResponse> presenter)
        {
            _getBookUseCase = getBookUseCase;
            _useCaseExecutor = useCaseExecutor;
            _presenter = presenter;
        }
        // GET api/<AddBookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var request = new GetBookRequest(id);
            await _useCaseExecutor.Execute(_getBookUseCase, request,_presenter);
            return _presenter.Render();
        }
    }
     
}
