using System.Net.Http.Json;
using KitabhChautari.Maui.Models;

namespace KitabhChautari.Maui.Services
{
    public class ApiHandlerService
    {
        private readonly HttpClient _http;
        private List<BookDto> _books = new();

        public ApiHandlerService(HttpClient http)
        {
            _http = http;
        }

        public IReadOnlyList<BookDto> Books => _books.AsReadOnly();

        // Existing methods (from Index.razor)
        public async Task<List<BookDto>> GetTopSellerBooksAsync(int count = 4)
        {
            try
            {
                var books = await _http.GetFromJsonAsync<List<BookDto>>($"api/books/top-sellers?count={count}");
                return books ?? new List<BookDto>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to fetch top seller books from API.", ex);
            }
        }

        public async Task<List<BookDto>> GetLatestBooksAsync(int count = 4)
        {
            try
            {
                var books = await _http.GetFromJsonAsync<List<BookDto>>($"api/books/latest?count={count}");
                return books ?? new List<BookDto>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to fetch latest books from API.", ex);
            }
        }

        public async Task AddToCartAsync(int bookId, int quantity = 1)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/cart", new { BookId = bookId, Quantity = quantity });
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to add book to cart.", ex);
            }
        }

        // New methods for Books.razor
        public async Task LoadBooksAsync()
        {
            try
            {
                _books = await _http.GetFromJsonAsync<List<BookDto>>("api/books") ?? new List<BookDto>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to load books from API.", ex);
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/books/{bookId}");
                response.EnsureSuccessStatusCode();
                _books.RemoveAll(b => b.BookId == bookId);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to delete book.", ex);
            }
        }

        public async Task AddDiscountAsync(int bookId, decimal discountPercentage)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"api/books/{bookId}/discount", new { DiscountPercentage = discountPercentage });
                response.EnsureSuccessStatusCode();
                var book = _books.Find(b => b.BookId == bookId);
                if (book != null)
                {
                    book.IsOnSale = true;
                    book.DiscountPercentage = discountPercentage;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to add discount.", ex);
            }
        }
    }
}