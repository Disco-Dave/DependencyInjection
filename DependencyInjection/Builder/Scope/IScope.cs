using DependencyInjection.Container;

namespace DependencyInjection.Builder.Scope
{
    internal interface IScope<out TActualType>
    {
        TActualType Get();
    }
}