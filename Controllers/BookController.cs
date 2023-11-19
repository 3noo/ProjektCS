using Microsoft.AspNetCore.Mvc;
using ProjecktC.Data;
using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;

namespace ProjecktC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookController:ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var BooksDb = FDB.BooksDb.ToList();

            return Ok(BooksDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooksById(int id)
        {
            var BooksDb = FDB.BooksDb.FirstOrDefault(x => x.Id == id);

            if(BooksDb == null)
            {
                return NotFound($"Book with id = {id} not found");
            } else
            {
                return Ok(BooksDb);
            }
        }
        
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteBooksById(int id)
        {
            var BooksDb = FDB.BooksDb.FirstOrDefault(x => x.Id == id);
            if(BooksDb == null)
            {
                return NotFound($"Books with id = {id} not found");
            } 
            else
            {
                FDB.BooksDb.Remove(BooksDb);
                return Ok($"Books with id = {id} was removed");
            }
        }        
        [HttpPost]
        public IActionResult PostBook([FromBody]PostBookDto payload)
        {
            var newBook = new Books()
            {
                Id = new Random().Next(10, 100),
                Title = payload.Title,
                Author = payload.Author,
                Genre = payload.Genre,
            };

            FDB.BooksDb.Add(newBook);
            
            return Ok("New Book created");
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]PutBookDto payload)
        {
            var BooksDb = FDB.BooksDb.FirstOrDefault(x => x.Id == id);

            if(BooksDb == null)
            {
                return NotFound($"Book with id = {id} not found");
            } else
            {
                BooksDb.Title = payload.Title;
                BooksDb.Author = payload.Author;
                BooksDb.Genre = payload.Genre;
                

                return Ok($"Book with id = {id} was updated");
            }
        }
    }
}