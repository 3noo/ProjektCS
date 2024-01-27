using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;

namespace ProjecktC.Services;

public interface IBookService
{
    Task<List<Books>> GetBooksAsync();
    Task<Books> GetBookByIdAsync(int id);
    Task PostBookAsync(PostBookDto books);
    Task<Books> UpdateBookAsync(int id, PutBookDto book);
    Task DeleteBookByIdAsync(int id);
}