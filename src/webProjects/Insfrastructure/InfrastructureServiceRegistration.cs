using Application.Services.ImagesServices;
using Insfrastructure.Adapters.ImageService;
using Microsoft.Extensions.DependencyInjection;

namespace Insfrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ImageServiceBase, CloudinaryImageServiceAdapter>();

            return services;
        }
    }
}
