# Ninject.Extensions.MetadataRegistration
Component registering into Ninject container using attributes
## Simple steps
1. Mark implementation with attribute
```cs
    [As(typeof (INowProvider))]
    [SingleInstance]
    class NowProvider : INowProvider
    {
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
```
2. Create assembly registration
```cs
    using Ninject.Extensions.MetadataRegistration;
    using Ninject.Modules;
    
    namespace AssemblyNameSpace
    {
        public class AutoRegistrationNinjectModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.AutoRegistration(GetType().Assembly);
            }
        }
    }
```
3. Call all assemblies specific Ninject modules in the main assembly
```cs
    using Ninject.Extensions.MetadataRegistration;
    using Ninject.Modules;
    
    namespace MainAssemblyNameSpace
    {
        public class AutoRegistrationNinjectModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.AutoRegistration(GetType().Assembly);
                Kernel.Load(new NinjectModule[]
                {
                    new Assembly1.AutoRegistrationNinjectModule(),
                    new Assembly2.AutoRegistrationNinjectModule()
                });
            }
        }
    }
```
## Supported attributes
1. AsAttribute - The implementation class will be registred as specified type
```cs
    [As(typeof (ITemplateUserProvider))]
    class ExampleClass : ITemplateUserProvider
    {
        private readonly INowProvider _nowProvider;
    
        public ExampleClass(INowProvider nowProvider) 
        {
            _nowProvider = nowProvider;
        }
    
        public string CurrentDateTimeAsString()
        {
            _nowProvider.UtcNow().ToString();
        }
    }
```
2. SingleInstanceAttribute - The single instance of the implementation class will be shared across all consumers
