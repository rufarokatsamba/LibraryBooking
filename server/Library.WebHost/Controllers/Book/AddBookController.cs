using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WebHost.Controllers.Book
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddBookController : ControllerBase
    {
        // POST api/<AddBookController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
