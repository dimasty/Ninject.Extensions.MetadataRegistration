using System;
using Ninject.Infrastructure;

namespace Ninject.Extensions.MetadataRegistration.RegistrationAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SingleInstanceAttribute : Attribute, INinjectRegistrationAttribute
    {
        public IBindingBuilder Register(IBindingBuilder builder)
        {
            builder.ScopeCallback = StandardScopeCallbacks.Singleton;
            return builder;
        }
    }
}