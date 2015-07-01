using System;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    public interface INinjectCustomRegistration
    {
        void Register(Type type, IKernel kernel);
    }
}