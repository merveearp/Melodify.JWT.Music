using Mapster;
using Melodify.DtoLayer.SongDtos;
using Melodify.EntityLayer.Entities;

namespace Melodify.BusinessLayer.Mappings
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Song, ResultSongDto>
                .NewConfig()
                .Map(
                    destination => destination.ArtistName,
                    source => source.Artist.ArtistName
                )
                .Map(
                    destination => destination.PackageName,
                    source => source.Package.PackageName
                    )
                .Map(
                    destination => destination.GenreName,
                    source => source.Genre.GenreName);

        }
    }
}
