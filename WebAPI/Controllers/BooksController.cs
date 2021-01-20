using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get/all")]
        [Authorize(Roles = UserRoles.Admin)]
        [Authorize]
        public IActionResult GetList()
        {
            return Ok(_bookService.GetAll());
        }

        [HttpPost("add")]
        public void Add(Book book)
        {
            _bookService.Add(book);
        }
        
        [HttpPut("update")]
        public void Update(Book book)
        {
            _bookService.Update(book);
        }
        
        [HttpGet("get/by/authorId")]
        public IActionResult GetByAuthorId(int id)
        {
            return Ok(_bookService.GetByAuthorId(id));
        }
    }
}