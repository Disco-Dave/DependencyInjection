namespace DependencyInjection.Builder.Scope
{
    internal class ConstantScope<TActualType> : IScope<TActualType>
    {
        private readonly TActualType _actualInstance;

        public ConstantScope(TActualType actualInstance)
        {
            _actualInstance = actualInstance;
        }
        
        public TActualType Get()
        {
            return _actualInstance;
        }
    }
}