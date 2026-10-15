using Melodify.EntityLayer.Enums;

namespace Melodify.DtoLayer.PackagesDtos
{
    public class ResultPackageDto
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string? Description { get; set; }
        public PackageLevel Level { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
