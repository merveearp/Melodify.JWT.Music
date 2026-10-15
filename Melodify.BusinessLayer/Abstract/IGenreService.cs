using Melodify.DtoLayer.GenreDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.BusinessLayer.Abstract
{
    public interface IGenreService :IGenericService<ResultGenreDto, CreateGenreDto, UpdateGenreDto>
    {
    }
}
