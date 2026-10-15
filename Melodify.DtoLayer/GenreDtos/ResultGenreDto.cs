using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.DtoLayer.GenreDtos
{
    public class ResultGenreDto
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
    }
}
