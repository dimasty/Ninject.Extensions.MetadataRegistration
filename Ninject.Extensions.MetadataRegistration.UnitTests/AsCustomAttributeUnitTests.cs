using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject.Activation;
using Ninject.Activation.Providers;
using Ninject.Extensions.MetadataRegistration.Registrations;
using Ninject.Planning.Bindings;

namespace Ninject.Extensions.MetadataRegistration.UnitTests
{
    [TestClass]
    public class AsCustomAttributeUnitTests
    {
        private class TestRegistration: INinjectCustomRegistration
        {
            public void Register(Type type, IKernel kernel, Func<IContext, object> contextProvider)
            {
                var binding = new Binding(type);
                binding.BindingConfiguration.ScopeCallback = contextProvider;
                binding.BindingConfiguration.Target = BindingTarget.Type;
                kernel.AddBinding(binding);
            }
        }

        [AsCustom(typeof(TestRegistration))]
        private class TestClass
        {
            
        }

        [TestMethod]
        public void InvokesRegistar()
        {
            var kernelMock = new Mock<IKernel>();
            Func<IContext, object> contextProvider = context => null;

            var prototype = typeof(TestClass);
            var customAttribute = prototype
                .GetCustomAttributes(typeof(AsCustomAttribute), false)
                .OfType<AsCustomAttribute>().Single();

            customAttribute.Register(prototype, kernelMock.Object, contextProvider);

            var binding = new Binding(prototype);
            binding.BindingConfiguration.ScopeCallback = contextProvider;
            binding.BindingConfiguration.ProviderCallback = StandardProvider.GetCreationCallback(prototype);
            binding.BindingConfiguration.Target = BindingTarget.Type;
            kernelMock.Verify(kernel => kernel.AddBinding(It.Is<Binding>(value =>
            value.BindingConfiguration.ScopeCallback == contextProvider
                       && value.BindingConfiguration.Target == BindingTarget.Type
            )), Times.Once);
        }       
    }
}