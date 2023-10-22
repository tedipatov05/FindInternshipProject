using FindInternship.Core.Contracts;
using FindInternship.Core.Services;
using FindInternship.Data.Repository;

namespace FindInternship.Web.Extensions
{
    public static class FindInternshipServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IStatisticService, StatisticService>();

            return services;

        }
    }
}
