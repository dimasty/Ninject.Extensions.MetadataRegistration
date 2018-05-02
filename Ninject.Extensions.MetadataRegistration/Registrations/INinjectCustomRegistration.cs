using System;
using Ninject.Activation;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    public interface INinjectCustomRegistration
    {
        void Register(Type type, IKernel kernel, Func<IContext, object> contextProvider);
    }
}