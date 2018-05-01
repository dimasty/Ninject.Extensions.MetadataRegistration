using System;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    public class ConsolidationRegistration : INinjectCustomRegistration
    {
        public void Register(Type type, IKernel kernel)
        {
#if Consolidation
            builder.AutoRegistrationSkipCustomRegistration(type);
#endif
        }
    }
}