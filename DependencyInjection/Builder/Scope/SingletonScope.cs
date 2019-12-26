using System;
using DependencyInjection.Builder.Helpers;
using DependencyInjection.Container;

namespace DependencyInjection.Builder.Scope
{
    public class SingletonScope<TActualType> : IScope<TActualType>
    {
        private readonly Lazy<TActualType> _actualType;

        public SingletonScope(IReadonlyContainer container)
        {
            _actualType = new Lazy<TActualType>(() => ConstructorHelper.Construct<TActualType>(container));
        }
        
        public TActualType Get()
        {
            return _actualType.Value;
        }
    }
}