using Melodify.BusinessLayer.Abstract;
using Melodify.BusinessLayer.Concrete;
using Melodify.BusinessLayer.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Melodify.BusinessLayer.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
        {
            MapsterConfig.RegisterMappings();

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IArtistService,ArtistService>();
            services.AddScoped<ISongService,SongService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
