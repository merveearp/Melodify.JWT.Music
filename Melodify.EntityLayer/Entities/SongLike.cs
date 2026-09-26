namespace Melodify.EntityLayer.Entities
{
    public class SongLike
    {
        public int SongLikeId { get; set; }

        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; } = null!;

        public int SongId { get; set; }
        public Song Song { get; set; } = null!;

        public DateTime LikedDate { get; set; } = DateTime.Now;
    }
}