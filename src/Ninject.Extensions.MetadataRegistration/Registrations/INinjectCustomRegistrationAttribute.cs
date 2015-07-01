using System;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    public interface INinjectCustomRegistrationAttribute
    {
        void Register(Type type, IKernel kernel);
    }
}