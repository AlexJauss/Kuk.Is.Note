namespace Infrastructure;
public abstract class Module {
  private readonly List<(Type, Type)> _transient = new();

  protected Module() {
  }

  protected AddTransient<>
}