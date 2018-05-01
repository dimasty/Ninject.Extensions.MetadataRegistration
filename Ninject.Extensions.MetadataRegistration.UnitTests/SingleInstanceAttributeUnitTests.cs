using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject.Activation;
using Ninject.Extensions.MetadataRegistration.RegistrationAttributes;
using Ninject.Infrastructure;

namespace Ninject.Extensions.MetadataRegistration.UnitTests
{
    [TestClass]
    public class SingleInstanceAttributeUnitTests
    {
        [SingleInstanceAttribute]
        private class TestClass
        {
            
        }

        [TestMethod]
        public void RegistersAsSingleInstance()
        {
            var builderMock = new Mock<IBindingBuilder>();
            builderMock
                .SetupSet<Func<IContext, object>>(builder => builder.ScopeCallback = StandardScopeCallbacks.Singleton)
                .Verifiable();

            var singleInstanceAttributeInstance = typeof(TestClass)
                .GetCustomAttributes(typeof(SingleInstanceAttribute), false)
                .OfType<SingleInstanceAttribute>().Single();

            singleInstanceAttributeInstance.Register(builderMock.Object);

            builderMock.Verify();
        }       
    }
}