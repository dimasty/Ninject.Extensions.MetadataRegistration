using System;
using Ninject.Activation;

namespace Ninject.Extensions.MetadataRegistration.RegistrationAttributes
{
    public interface INinjectRegistrationAttribute
    {
        IBindingBuilder Register(IBindingBuilder builder, Func<IContext, object> contextProvider);
    }
}