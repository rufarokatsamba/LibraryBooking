using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WebHost.Controllers.Book
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookController : ControllerBase
    { 
        // GET api/<AddBookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
