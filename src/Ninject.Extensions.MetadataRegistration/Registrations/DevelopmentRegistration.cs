using System;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    public class DevelopmentRegistration : INinjectCustomRegistration
    {
        public void Register(Type type, IKernel kernel)
        {
#if Development
            builder.AutoRegistrationSkipCustomRegistration(type);
#endif
        }
    }
}