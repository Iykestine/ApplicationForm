using ApplicationForm.Services.Implementation;
using ApplicationForm.Services.Interface;

namespace ApplicationForm.ServiceExtensionMethods
{
    public static class ApplicationServiceCollections
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IFormService, FormService>();

            return services;
        }
    }
}
