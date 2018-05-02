using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ninject.Activation;
using Ninject.Activation.Providers;
using Ninject.Extensions.MetadataRegistration.RegistrationAttributes;
using Ninject.Extensions.MetadataRegistration.Registrations;
using Ninject.Planning.Bindings;

namespace Ninject.Extensions.MetadataRegistration
{
    public static class KernelExtensions
    {
        public static void AutoRegistration(this IKernel kernel, Assembly[] assemblies, Func<IContext, object> contextProvider = null)
        {
            var types = from assembly in assemblies
                        from type in assembly.GetTypes()
                        select type;

            kernel.AutoRegistration(types.ToArray(), contextProvider);
        }

        public static void AutoRegistration(this IKernel kernel, Type[] types, Func<IContext, object> contextProvider = null)
        {
            foreach (Type type in types)
            {
                var customRegistrations = type
                    .GetCustomAttributes(typeof(INinjectCustomRegistrationAttribute), false)
                    .OfType<INinjectCustomRegistrationAttribute>().ToArray();

                if (customRegistrations.Any())
                {
                    foreach (var registration in customRegistrations)
                    {
                        registration.Register(type, kernel, contextProvider);
                    }
                }
                else
                {
                    AutoRegistrationSkipCustomRegistration(kernel, type, contextProvider);
                }
            }
        }

        public static void AutoRegistrationSkipCustomRegistration(this IKernel kernel, Type type, Func<IContext, object> contextProvider = null)
        {
            var attributes = type
                .GetCustomAttributes(typeof(INinjectRegistrationAttribute), false)
                .OfType<INinjectRegistrationAttribute>()
                .ToArray();

            if (attributes.Any() == false) return;
            RegisterType(kernel, type, attributes, contextProvider);
        }

        private static void RegisterType(IKernel kernel, Type type, IEnumerable<INinjectRegistrationAttribute> attributes, Func<IContext, object> contextProvider = null)
        {
            var builder = new BindingBuilder() as IBindingBuilder;

            foreach (INinjectRegistrationAttribute attribute in attributes)
            {
                builder = attribute.Register(builder, contextProvider);
            }

            foreach (var service in builder.Services)
            {
                var binding = new Binding(service);
                binding.BindingConfiguration.ScopeCallback = builder.ScopeCallback;
                binding.BindingConfiguration.ProviderCallback = StandardProvider.GetCreationCallback(type);
                binding.BindingConfiguration.Target = BindingTarget.Type;
                kernel.AddBinding(binding);
            }
        }
    }
}