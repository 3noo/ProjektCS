using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;

namespace ProjecktC.Services;

public interface ILibraryServices
{
    Task<List<Library>> GetLibrariesAsync();
    Task<Library> GetLibraryIdAsync(int id);
    Task PostLibraryAsync(PostLibraryDto library);
    Task<Library> UpdateLibraryAsync(int id, PutLibraryDto library);
    Task DeleteLibraryByIdAsync(int id);
}