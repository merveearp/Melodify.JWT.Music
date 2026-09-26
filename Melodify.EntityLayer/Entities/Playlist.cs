namespace Melodify.EntityLayer.Entities
{
    public class Playlist
    {
        public int PlaylistId { get; set; }

        public string PlaylistName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; } = null!;

        public List<PlaylistSong> PlaylistSongs { get; set; } = new();
    }
}