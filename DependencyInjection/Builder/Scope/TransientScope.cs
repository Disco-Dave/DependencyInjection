using DependencyInjection.Builder.Helpers;
using DependencyInjection.Container;

namespace DependencyInjection.Builder.Scope
{
    public class TransientScope<TActualType> : IScope<TActualType>
    {
        private readonly IReadonlyContainer _container;

        public TransientScope(IReadonlyContainer container)
        {
            _container = container;
        }

        public TActualType Get()
        {
            return ConstructorHelper.Construct<TActualType>(_container);
        }
    }
}