using System;

namespace DependencyInjection.Container
{
    public class RequestedDependencyNotFoundException : Exception
    {
        public Type RequestedType { get; }
        
        internal RequestedDependencyNotFoundException(Type requestedType) : base($"The type, {requestedType}, was not found.")
        {
            this.RequestedType = requestedType;
        }
    }
}