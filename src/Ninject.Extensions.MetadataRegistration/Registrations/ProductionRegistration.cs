using System;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    public class ProductionRegistration : INinjectCustomRegistration
    {
        public void Register(Type type, IKernel kernel)
        {
#if Release
            builder.AutoRegistrationSkipCustomRegistration(type);
#endif
        }
    }
}