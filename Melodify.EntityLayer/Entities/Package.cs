using Melodify.EntityLayer.Enums;

namespace Melodify.EntityLayer.Entities
{
    public class Package
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string? Description { get; set; }
        public PackageLevel Level { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;


        public List<AppUser> Users { get; set; } 
        

        public int? MonthlyListeningLimit { get; set; }
        public int? HourlySkipLimit { get; set; }
        public int? PlaylistLimit { get; set; }
        public int? SongsPerPlaylistLimit { get; set; }
        public int? HistoryVisibleDays { get; set; }

        public bool HasAds { get; set; }
        public int? AdInterval { get; set; }

        public int? PreviewSecondsAfterLimit { get; set; }
    }
}
