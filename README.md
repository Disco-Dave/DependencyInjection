## Example usage
```csharp
using System;
using DependencyInjection.Builder;

namespace Example
{
    public interface IOther
    {
        int Double(int x);
    }

    public class Other : IOther
    {
        public int Double(int x)
        {
            return x * 2;
        }
    }
    
    public interface ISomething
    {
        int Foo();
    }

    public class Something : ISomething
    {
        private readonly IOther _other;

        public Something(IOther other)
        {
            _other = other;
        }
        
        public int Foo()
        {
            return _other.Double(123);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            var container = containerBuilder
                .Bind<IOther>().ToTransient<Other>()
                .Bind<ISomething>().ToTransient<Something>()
                .Create();

            var something = container.Get<ISomething>();
            var foo = something.Foo(); // = 246
        }
    }
}
```
