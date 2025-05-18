using KitabhChautari.IServices;
using KitabhChautari.Models;

namespace KitabhChautari.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            var response = await _httpClient.GetAsync("api/authors");
            response.EnsureSuccessStatusCode();
            var authors = await response.Content.ReadFromJsonAsync<IEnumerable<AuthorDto>>();
            return authors ?? new List<AuthorDto>();
        }

        public async Task AddAuthorAsync(AuthorDto author)
        {
            var response = await _httpClient.PostAsJsonAsync("api/authors", author);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAuthorAsync(int authorId)
        {
            var response = await _httpClient.DeleteAsync($"api/authors/{authorId}");
            response.EnsureSuccessStatusCode();
        }
    }
}