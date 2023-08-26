namespace Infrastructure.Common.Modules;

public abstract class ServiceModuleBase {
  private readonly List<(Type serviceType, Type implementationType)> _simpleTransient = new();

  protected void AddTransient<TService>() => this.AddTransient(typeof(TService));
  protected void AddTransient(Type type) => this.AddTransient(type, type);
  protected void AddTransient<TService, TImplementation>() => this.AddTransient(typeof(TService), typeof(TImplementation));
  protected void AddTransient(Type serviceType, Type implementationType) => _simpleTransient.Add((serviceType, implementationType));

  internal IReadOnlyCollection<(Type serviceType, Type implementationType)> GetSimpleTransients() => _simpleTransient.AsReadOnly();
}
