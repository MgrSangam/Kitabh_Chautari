using System.Net.Http.Json;
using Kitabh_Chautari.Dto;
using Kitabh_Chautari.IServices;

namespace Kitabh_Chautari.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly HttpClient _httpClient;

        public WishlistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WishlistDto> GetWishlistAsync(int memberId)
        {
            var response = await _httpClient.GetAsync($"api/Wishlists/{memberId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<WishlistDto>();
        }

        public async Task AddToWishlistAsync(int memberId, WishlistItemDto wishlistItem)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Wishlists/{memberId}/items", wishlistItem);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveFromWishlistAsync(int memberId, int wishlistItemId)
        {
            var response = await _httpClient.DeleteAsync($"api/Wishlists/{memberId}/items/{wishlistItemId}");
            response.EnsureSuccessStatusCode();
        }
    }
}