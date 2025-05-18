using KitabhChautari.Models;

namespace KitabhChautari.IServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        Task AddAuthorAsync(AuthorDto author);
        Task DeleteAuthorAsync(int authorId);
    }
}