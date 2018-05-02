using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject.Activation;
using Ninject.Extensions.MetadataRegistration.RegistrationAttributes;

namespace Ninject.Extensions.MetadataRegistration.UnitTests
{
    [TestClass]
    public class ScopeInstanceAttributeUnitTests
    {
        [ScopeInstanceAttribute]
        private class TestClass
        {
            
        }

        [TestMethod]
        public void RegistersAsScopeInstance()
        {
            var builderMock = new Mock<IBindingBuilder>();
            Func<IContext, object> contextProvider = context => null;
            
            builderMock
                .SetupSet<Func<IContext, object>>(builder => builder.ScopeCallback = contextProvider)
                .Verifiable();

            var scopeInstanceAttribute = typeof(TestClass)
                .GetCustomAttributes(typeof(ScopeInstanceAttribute), false)
                .OfType<ScopeInstanceAttribute>().Single();

            scopeInstanceAttribute.Register(builderMock.Object, contextProvider);

            builderMock.Verify();
        }       
    }
}