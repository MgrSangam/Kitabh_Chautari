namespace Kitabh_Chautari.Dto
{
    public class WishlistDto
    {
        public int WishlistId { get; set; }
        public int MemberId { get; set; }
        public List<WishlistItemDto> WishlistItems { get; set; } = new List<WishlistItemDto>();
    }
}
