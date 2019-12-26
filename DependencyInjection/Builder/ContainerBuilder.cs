using DependencyInjection.Builder.Scope;
using DependencyInjection.Container;

namespace DependencyInjection.Builder
{
    public class ContainerBuilder
    {
        internal readonly DependencyContainer Container = new DependencyContainer();

        public IReadonlyContainer Create()
        {
            return Container;
        }

        public PendingBind<TRequestedType> Bind<TRequestedType>()
        {
            return new PendingBind<TRequestedType>(this);
        }
    }
}