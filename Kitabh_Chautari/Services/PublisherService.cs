using KitabhChautari.IServices;
using KitabhChautari.Models;

namespace KitabhChautari.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly HttpClient _httpClient;

        public PublisherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PublisherDto>> GetAllPublishersAsync()
        {
            var response = await _httpClient.GetAsync("api/publishers");
            response.EnsureSuccessStatusCode();
            var publishers = await response.Content.ReadFromJsonAsync<IEnumerable<PublisherDto>>();
            return publishers ?? new List<PublisherDto>();
        }

        public async Task AddPublisherAsync(PublisherDto publisher)
        {
            var response = await _httpClient.PostAsJsonAsync("api/publishers", publisher);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePublisherAsync(int publisherId)
        {
            var response = await _httpClient.DeleteAsync($"api/publishers/{publisherId}");
            response.EnsureSuccessStatusCode();
        }
    }
}