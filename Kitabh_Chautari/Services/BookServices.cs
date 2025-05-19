using KitabhChautari.IServices;
using KitabhChautari.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KitabhChautari.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var queryString = "";
            return await _httpClient.GetFromJsonAsync<IEnumerable<BookDto>>($"api/books{queryString}")
                   ?? new List<BookDto>();
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BookDto>($"api/books/{id}");
        }

        public async Task AddBookAsync(BookDto book)
        {
            await _httpClient.PostAsJsonAsync("api/books", book);
        }

        public async Task UpdateBookAsync(BookDto book)
        {
            await _httpClient.PutAsJsonAsync($"api/books/{book.BookId}", book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/books/{id}");
        }
    }
}