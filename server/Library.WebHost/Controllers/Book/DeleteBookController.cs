using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WebHost.Controllers.Book
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteBookController : ControllerBase
    {
        // DELETE api/<AddBookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
