using KitabhChautari.Models;

namespace Kitabh_Chautari.IServices
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDto>> GetAllGenresAsync();
        Task AddGenreAsync(GenreDto genre);
        Task DeleteGenreAsync(int genreId);
    }
}