using System;

namespace DependencyInjection.Container
{
    public interface IReadonlyContainer
    {
        TRequestedType Get<TRequestedType>();
    }

    internal static class ReadonlyContainerExtensions
    {
        public static object Get(this IReadonlyContainer kernel, Type instanceType)
        {
            var instance = typeof(IReadonlyContainer)
                .GetMethod(nameof(IReadonlyContainer.Get))
                ?.MakeGenericMethod(instanceType)
                .Invoke(kernel, null);

            return instance;
        }
    }
}
