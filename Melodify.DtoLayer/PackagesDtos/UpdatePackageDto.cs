using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.DtoLayer.PackagesDtos
{
    public class UpdatePackageDto
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

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
