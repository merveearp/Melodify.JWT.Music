using Melodify.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Song> Songs { get; set; } 
    }
}
