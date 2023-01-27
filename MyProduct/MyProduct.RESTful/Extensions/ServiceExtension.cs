using MyProduct.AppServices.Contracts;
using MyProduct.AppServices.Services;
using MyProduct.Domain.Contracts;
using MyProduct.Persistence.Contracts;
using MyProduct.Persistence.Repositories;
using MyProduct.AppServices.Mappings;
using MyProduct.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MyProduct.RESTful.Extensions
{
    public static class ServiceExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        public static void AddServicesApplication(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile));
        }

        public static void AddOracleDB(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:Oracle"];

            services.AddDbContext<MyDbContext>(opt => opt.UseOracle(connectionString));
        }
    }
}
