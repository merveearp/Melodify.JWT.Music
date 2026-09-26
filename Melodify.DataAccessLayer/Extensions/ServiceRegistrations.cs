using Melodify.DataAccessLayer.Abstract;
using Melodify.DataAccessLayer.Concrete;
using Melodify.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Melodify.DataAccessLayer.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddDataAccessServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<MusicContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
