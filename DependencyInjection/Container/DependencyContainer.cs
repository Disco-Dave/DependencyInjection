using System;
using System.Collections.Generic;
using DependencyInjection.Builder.Scope;

namespace DependencyInjection.Container
{
    internal class DependencyContainer : IReadonlyContainer
    {
        private readonly IDictionary<Type, Func<dynamic>> _dependencies =
            new Dictionary<Type, Func<dynamic>>();

        public DependencyContainer()
        {
            Register<IReadonlyContainer, DependencyContainer>(new ConstantScope<DependencyContainer>(this));
        }

        public void Register<TRequestedType, TActualType>(IScope<TActualType> scopeContainer) where TActualType : TRequestedType
        {
            dynamic GetActualType() => scopeContainer.Get();
            if (!_dependencies.TryAdd(typeof(TRequestedType), GetActualType))
            {
                throw new DuplicateDependencyException(typeof(TRequestedType));
            }
        }

        public TRequestedType Get<TRequestedType>()
        {
            if (_dependencies.TryGetValue(typeof(TRequestedType), out var getActualType))
            {
                return getActualType();
            }
            
            throw new RequestedDependencyNotFoundException(typeof(TRequestedType));
        }
    }
}