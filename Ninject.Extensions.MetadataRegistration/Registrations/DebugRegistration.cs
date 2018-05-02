using System;
using Ninject.Activation;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    public class DebugRegistration : INinjectCustomRegistration
    {
        public void Register(Type type, IKernel kernel, Func<IContext, object> contextProvider)
        {
#if DEBUG
            kernel.AutoRegistrationSkipCustomRegistration(type, contextProvider);
#endif
        }
    }
}