using System;
using Ninject.Activation;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    public class DevelopmentRegistration : INinjectCustomRegistration
    {
        public void Register(Type type, IKernel kernel, Func<IContext, object> contextProvider)
        {
#if Development
            kernel.AutoRegistrationSkipCustomRegistration(type, contextProvider);
#endif
        }
    }
}