namespace Melodify.EntityLayer.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public List<Song> Songs { get; set; } = new();
    }
}