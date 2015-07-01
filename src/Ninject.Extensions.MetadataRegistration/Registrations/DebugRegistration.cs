using System;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    public class DebugRegistration : INinjectCustomRegistration
    {
        public void Register(Type type, IKernel kernel)
        {
#if DEBUG
            kernel.AutoRegistrationSkipCustomRegistration(type);
#endif
        }
    }
}