namespace Melodify.EntityLayer.Entities
{
    public class ListeningHistory
    {
        public int ListeningHistoryId { get; set; }

        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; } = null!;

        public int SongId { get; set; }
        public Song Song { get; set; } = null!;

        public DateTime ListenDate { get; set; } = DateTime.Now;
    }
}