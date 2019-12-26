using System;

namespace DependencyInjection.Container
{
    public class DuplicateDependencyException : Exception
    {
        public Type DuplicatedType { get; }
        
        internal DuplicateDependencyException(Type duplicatedType) : base($"The type, {duplicatedType}, has already previously been mapped.")
        {
            this.DuplicatedType = duplicatedType;
        }
    }
}