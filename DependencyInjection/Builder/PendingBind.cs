using DependencyInjection.Builder.Scope;

namespace DependencyInjection.Builder
{
    public class PendingBind<TRequestedType>
    {
        private readonly ContainerBuilder _builder;

        internal PendingBind(ContainerBuilder builder)
        {
            _builder = builder;
        }

        public ContainerBuilder ToTransient<TActualType>() where TActualType : TRequestedType
        {
            var scope = new TransientScope<TActualType>(_builder.Container);
            return Register(scope);
        }

        public ContainerBuilder ToSingleton<TActualType>() where TActualType : TRequestedType
        {
            var scope = new SingletonScope<TActualType>(_builder.Container);
            return Register(scope);
        }

        public ContainerBuilder ToConstant<TActualType>(TActualType actualInstance) where TActualType : TRequestedType
        {
            var scope = new ConstantScope<TActualType>(actualInstance);
            return Register(scope);
        }
        
        private ContainerBuilder Register<TActualType>(IScope<TActualType> scope) where TActualType : TRequestedType
        {
            _builder.Container.Register<TRequestedType, TActualType>(scope);
            return _builder;
        }
    }
}