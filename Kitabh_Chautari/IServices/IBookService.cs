using KitabhChautari.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitabhChautari.IServices
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int id);
        Task AddBookAsync(BookDto book);
        Task UpdateBookAsync(BookDto book);
        Task DeleteBookAsync(int id);
    }
}