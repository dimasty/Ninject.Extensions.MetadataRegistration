using System;
using Ninject.Activation;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    public class ProductionRegistration : INinjectCustomRegistration
    {
        public void Register(Type type, IKernel kernel, Func<IContext, object> contextProvider)
        {
#if Release
            kernel.AutoRegistrationSkipCustomRegistration(type, contextProvider);
#endif
        }
    }
}