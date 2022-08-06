using Grocery.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Grocery.UI.Configurations;

public static class Configuration
{
    public static IServiceCollection AddGroceryUIServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IConfirmService, ConfirmService>();
        return serviceCollection;
    }
}