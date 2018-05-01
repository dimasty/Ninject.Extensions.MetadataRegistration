using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject.Extensions.MetadataRegistration.Registrations;

namespace Ninject.Extensions.MetadataRegistration.UnitTests
{
    [TestClass]
    public class AsCustomAttributeUnitTests
    {
        private class TestRegistration: INinjectCustomRegistration
        {
            public void Register(Type type, IKernel kernel)
            {
                kernel.Unbind(type);
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

            var customAttribute = typeof(TestClass)
                .GetCustomAttributes(typeof(AsCustomAttribute), false)
                .OfType<AsCustomAttribute>().Single();

            customAttribute.Register(typeof(TestClass), kernelMock.Object);

            kernelMock.Verify(kernel => kernel.Unbind(typeof(TestClass)), Times.Once);
        }       
    }
}