using KitabhChautari.Models;

namespace KitabhChautari.IServices
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublisherDto>> GetAllPublishersAsync();
        Task AddPublisherAsync(PublisherDto publisher);
        Task DeletePublisherAsync(int publisherId);
    }
}