using DependencyInjection.Container;

namespace DependencyInjection.Builder.Scope
{
    public interface IScope<out TActualType>
    {
        TActualType Get();
    }
}