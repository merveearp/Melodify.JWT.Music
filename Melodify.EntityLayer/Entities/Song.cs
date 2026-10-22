namespace Melodify.EntityLayer.Entities
{
    public class Song
    {
        public int SongId { get; set; }

        public string SongName { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }
        public string AudioUrl { get; set; } = string.Empty;
        public string? Lyrics { get; set; }

        public TimeSpan Duration { get; set; }
        public long ListenCount { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; } = null!;

        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        
        public List<PlaylistSong> PlaylistSongs { get; set; } = new();
        public List<SongLike> SongLikes { get; set; } = new();
        public List<ListeningHistory> ListeningHistories { get; set; } = new();
    }
}