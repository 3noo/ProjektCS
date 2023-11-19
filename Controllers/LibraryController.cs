using Microsoft.AspNetCore.Mvc;
using ProjecktC.Data;
using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;

namespace ProjecktC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LibraryController:ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllLibrarys()
        {
            var LibraryDb = FDB.LibraryDb.ToList();
            
            return Ok(LibraryDb);
        }
        
        
        [HttpGet("{id}")]
        public IActionResult GetLibraryById(int id)
        {
            var LibraryDb = FDB.LibraryDb.FirstOrDefault(x => x.Id == id);

            if(LibraryDb == null)
            {
                return NotFound($"Library with id = {id} not found");
            } 
            else
            {
                return Ok(LibraryDb);
            }
        }
        
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteLibraryById(int id)
        {
            var LibraryDb = FDB.LibraryDb.FirstOrDefault(x => x.Id == id);
            if(LibraryDb == null)
            {
                return NotFound($"Library with id = {id} not found");
            } 
            else
            {
                FDB.LibraryDb.Remove(LibraryDb);
                return Ok($"Library with id = {id} was removed");
            }
        }
        [HttpPost]
        public IActionResult PostLibrary([FromBody]PostLibraryDto payload)
        {
            var newLibrary = new Library()
            {
                Id = new Random().Next(10, 100),
                City = payload.City,
                OH = payload.OH,
                CH = payload.CH,
            };

            FDB.LibraryDb.Add(newLibrary);
            
            return Ok("New Book created");
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateLibraryById(int id, [FromBody]PutLibraryDto payload)
        {
            var LibraryDb = FDB.LibraryDb.FirstOrDefault(x => x.Id == id);

            if(LibraryDb == null)
            {
                return NotFound($"Library with id = {id} not found");
            } else
            {
                LibraryDb.City = payload.City;
                LibraryDb.OH = payload.OH;
                LibraryDb.CH = payload.CH;
                

                return Ok($"Library with id = {id} was updated");
            }
        }

       
        


    }
}