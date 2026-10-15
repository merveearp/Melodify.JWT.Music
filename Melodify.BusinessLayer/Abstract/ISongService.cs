using Melodify.DtoLayer.SongDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.BusinessLayer.Abstract
{
    public interface ISongService :IGenericService<ResultSongDto,CreateSongDto,UpdateSongDto>
    {
    }
}
