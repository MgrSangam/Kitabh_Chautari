using Kitabh_Chautari.IServices;
using KitabhChautari.Models;

namespace Kitabh_Chautari.Services
{
    public class GenreService : IGenreService
    {
        private readonly HttpClient _httpClient;

        public GenreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<GenreDto>>("api/Genres") ?? new List<GenreDto>();
        }

        public async Task AddGenreAsync(GenreDto genre)
        {
            await _httpClient.PostAsJsonAsync("api/Genres", genre);
        }

        public async Task DeleteGenreAsync(int genreId)
        {
            await _httpClient.DeleteAsync($"api/Genres/{genreId}");
        }
    }
}