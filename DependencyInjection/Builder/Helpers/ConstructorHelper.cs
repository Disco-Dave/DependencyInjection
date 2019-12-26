using System;
using System.Linq;
using DependencyInjection.Container;

namespace DependencyInjection.Builder.Helpers
{
    internal static class ConstructorHelper
    {
        public static T Construct<T>(IReadonlyContainer readonlyContainer)
        {
            var constructor = typeof(T).GetConstructors().FirstOrDefault();

            if (constructor == null)
            {
                // TODO: Find a better way to deal with this or add a better exception.
                throw new Exception("Unable to find any constructors!");
            }

            var ctorParams = constructor
                .GetParameters()
                .Select(p => readonlyContainer.Get(p.ParameterType))
                .ToArray();

            return (T) constructor.Invoke(ctorParams);
        }
    }
}