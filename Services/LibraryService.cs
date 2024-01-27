using Microsoft.EntityFrameworkCore;
using ProjecktC.Data;
using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;

namespace ProjecktC.Services;

public class LibraryService:ILibraryServices
{
    private AppDbContext _dbContext;
    
    public LibraryService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Library>> GetLibrariesAsync()
    {
        var allLibraries = await _dbContext.Librarys.ToListAsync();
        return allLibraries;
    }

    public async Task<Library> GetLibraryIdAsync(int id)
    {
        var libraryFromDb = await _dbContext.Librarys.FirstOrDefaultAsync(x => x.Id == id);
        return libraryFromDb;
    }

    public async Task PostLibraryAsync(PostLibraryDto library)
    {
        var newLibrary = new Library()
        {
            City = library.City,
            OH = library.OH,
            CH = library.CH
        };

        await _dbContext.Librarys.AddAsync(newLibrary);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Library> UpdateLibraryAsync(int id, PutLibraryDto library)
    {
        var libraryFromDb = await _dbContext.Librarys.FirstOrDefaultAsync(x => x.Id == id);

        if(libraryFromDb != null)
        {
            libraryFromDb.City = library.City;
            libraryFromDb.OH = library.OH;
            libraryFromDb.CH = library.CH;

            await _dbContext.SaveChangesAsync();
        }

        return libraryFromDb;
    }

    public async Task DeleteLibraryByIdAsync(int id)
    {
        var libraryFromDb = await _dbContext.Librarys.FirstOrDefaultAsync(x => x.Id == id);

        if (libraryFromDb != null)
        {
            _dbContext.Librarys.Remove(libraryFromDb);
            await _dbContext.SaveChangesAsync();
        }
    }
}