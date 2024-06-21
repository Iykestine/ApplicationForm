using ApplicationForm.Repositories.Implementations;
using ApplicationForm.Repositories.Interfaces;

namespace ApplicationForm.ServiceExtensionMethods
{
    public static class RepositoryServiceCollections
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IFormRepository, FormRepository>();

            return services;
        }
    }
}
