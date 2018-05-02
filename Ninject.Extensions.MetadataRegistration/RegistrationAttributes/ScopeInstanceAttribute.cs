using System;
using Ninject.Activation;
using Ninject.Infrastructure;

namespace Ninject.Extensions.MetadataRegistration.RegistrationAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ScopeInstanceAttribute : Attribute, INinjectRegistrationAttribute
    {
        public IBindingBuilder Register(IBindingBuilder builder, Func<IContext, object> contextProvider)
        {
            builder.ScopeCallback = contextProvider;
            return builder;
        }
    }
}