using System;
using Ninject.Activation;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    public class ConsolidationRegistration : INinjectCustomRegistration
    {
        public void Register(Type type, IKernel kernel, Func<IContext, object> contextProvider)
        {
#if Consolidation
            kernel.AutoRegistrationSkipCustomRegistration(type, contextProvider);
#endif
        }
    }
}