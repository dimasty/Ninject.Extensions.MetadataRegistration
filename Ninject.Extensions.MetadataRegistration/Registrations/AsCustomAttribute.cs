using System;
using Ninject.Activation;

namespace Ninject.Extensions.MetadataRegistration.Registrations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class AsCustomAttribute : Attribute, INinjectCustomRegistrationAttribute
    {
        private readonly Type _customRegistrationHandler;

        public AsCustomAttribute(Type customRegistrationHandler)
        {
            _customRegistrationHandler = customRegistrationHandler;
        }

        public void Register(Type type, IKernel kernel, Func<IContext, object> contextProvider)
        {
            var registration = (INinjectCustomRegistration) Activator.CreateInstance(_customRegistrationHandler);
            registration.Register(type, kernel, contextProvider);
        }
    }
}