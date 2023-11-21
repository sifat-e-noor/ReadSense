using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadSenseApi.Database.Entities;
using ReadSenseApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadSenseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(bookService.GetAll());
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return bookService.GetById(id) == null ? NotFound() : Ok(bookService.GetById(id));
        }

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return StatusCode(501);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return StatusCode(501);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(501);
        }

        // GET api/<BooksController>/GetBooksWithUserReadingHistory
        [HttpGet("GetBooksWithUserReadingHistory")]
        public IActionResult GetBooksWithUserReadingHistory()
        {
            HttpContext.Items.TryGetValue("User", out Object? userObj);
            if (userObj == null)
            {
                return BadRequest(new { message = "User is incorrect" });
            }

            int userId = ((User)userObj).Id;

            return Ok(bookService.GetAllBooksWithReadingHistoryByUserId(userId));
        }
    }
}
