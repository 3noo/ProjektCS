using Microsoft.AspNetCore.Mvc;
using ProjecktC.Data;
using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;
using ProjecktC.Services;

namespace ProjecktC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookController:ControllerBase
    {
        
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var booksDb = await _bookService.GetBooksAsync();

            return Ok(booksDb);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooksById(int id)
        {
            var booksDb = await _bookService.GetBookByIdAsync(id);

            if(booksDb == null)
            {
                return NotFound($"Book with id = {id} not found");
            } else
            {
                return Ok(booksDb);
            }
        }
        
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBooksById(int id)
        {
            await _bookService.DeleteBookByIdAsync(id);

            return Ok("Deleted");
        }        
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody]PostBookDto payload)
        {
            await _bookService.PostBookAsync(payload);
            
            return Ok("New Book created");
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookById(int id, [FromBody]PutBookDto payload)
        { 
            await _bookService.UpdateBookAsync(id, payload);
            
                return Ok($"Book with id = {id} was updated");
            }
        }
    }
