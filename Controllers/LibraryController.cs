using Microsoft.AspNetCore.Mvc;
using ProjecktC.Data;
using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;
using ProjecktC.Services;

namespace ProjecktC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LibraryController:ControllerBase
    {
        
        private ILibraryServices _libraryService;
        public LibraryController(ILibraryServices libraryService)
        {
            _libraryService = libraryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLibrarys()
        {
            var libraryDb = await _libraryService.GetLibrariesAsync();
            
            return Ok(libraryDb);
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibraryById(int id)
        {
            var libraryDb = await _libraryService.GetLibraryIdAsync(id);

            if(libraryDb == null)
            {
                return NotFound($"Library with id = {id} not found");
            } 
            else
            {
                return Ok(libraryDb);
            }
        }
        
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteLibraryById(int id)
        {
            await _libraryService.DeleteLibraryByIdAsync(id);
            
                return Ok($"Library with id = {id} was removed");
            }
        
    
        [HttpPost]
        public async Task<IActionResult> PostLibrary([FromBody]PostLibraryDto payload)
        {
            await _libraryService.PostLibraryAsync(payload);
            
            return Ok("New Book created");
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibraryById(int id, [FromBody]PutLibraryDto payload)
        {
           await _libraryService.UpdateLibraryAsync(id,payload);
           
                return Ok($"Library with id = {id} was updated");
            }
        }
    }
