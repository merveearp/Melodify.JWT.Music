using Melodify.DtoLayer.ArtistDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.BusinessLayer.Abstract
{
    public interface IArtistService:IGenericService<ResultArtistDto, CreateArtistDto, UpdateArtistDto>
    {
    }
}
