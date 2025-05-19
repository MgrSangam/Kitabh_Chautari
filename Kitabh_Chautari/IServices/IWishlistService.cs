using Kitabh_Chautari.Dto;

namespace Kitabh_Chautari.IServices
{
    public interface IWishlistService
    {
        Task<WishlistDto> GetWishlistAsync(int memberId);
        Task AddToWishlistAsync(int memberId, WishlistItemDto wishlistItem);
        Task RemoveFromWishlistAsync(int memberId, int wishlistItemId);
    }
}