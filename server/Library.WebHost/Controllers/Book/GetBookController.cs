using Library.Domain.Books.GetBook;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WebHost.Controllers.Book
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookController : ControllerBase
    {
        private readonly IGetBookUseCase _getBookUseCase;
        public GetBookController(IGetBookUseCase getBookUseCase)
        {
            _getBookUseCase = getBookUseCase;
        }
        // GET api/<AddBookController>/5
        [HttpGet("{id}")]
        public async Task<GetBookResponse?> Get(GetBookRequest request)
        {
            if (await _getBookUseCase.CanExecute())
            {
                return await _getBookUseCase.Execute(request);
            }
            return await Task.FromResult<GetBookResponse?>(null);
        }
    }
}
