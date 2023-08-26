using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Modules;

public static class IServiceCollectionExt {
  public static IServiceCollection AddModule(this IServiceCollection serviceCollection, ServiceModuleBase serviceModuleBase) {
    foreach (var (serviceType, implementationType) in serviceModuleBase.GetSimpleTransients()) {
      _ = serviceCollection.AddTransient(serviceType, implementationType);
    }

    return serviceCollection;
  }
}