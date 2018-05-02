using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject.Extensions.MetadataRegistration.RegistrationAttributes;

namespace Ninject.Extensions.MetadataRegistration.UnitTests
{
    [TestClass]
    public class AsAttributeUnitTests
    {
        [As(typeof (TestClass))]
        private class TestClass
        {
            
        }

        private interface IMultipleInterface
        {
            
        }

        [As(new[]{typeof (TestClass), typeof(IMultipleInterface)})]
        private class MultipleTestClass
        {
            
        }

        [TestMethod]
        public void RegistersAsType()
        {
            var listMock = new Mock<IList<Type>>();
            var builderMock = new Mock<IBindingBuilder>();
            builderMock.Setup(builder => builder.Services).Returns(listMock.Object);

            var asAttributeInstance = typeof(TestClass)
                    .GetCustomAttributes(typeof(AsAttribute), false)
                    .OfType<AsAttribute>().Single();

            asAttributeInstance.Register(builderMock.Object, null);

            listMock.Verify(list => list.Add(typeof(TestClass)), Times.Once);
        }       
        
        [TestMethod]
        public void RegistersAsMultipleTypes()
        {
            var listMock = new Mock<IList<Type>>();
            var builderMock = new Mock<IBindingBuilder>();
            builderMock.Setup(builder => builder.Services).Returns(listMock.Object);

            var asAttributeInstance = typeof(MultipleTestClass)
                    .GetCustomAttributes(typeof(AsAttribute), false)
                    .OfType<AsAttribute>().Single();

            asAttributeInstance.Register(builderMock.Object, null);

            listMock.Verify(list => list.Add(typeof(TestClass)), Times.Once);
            listMock.Verify(list => list.Add(typeof(IMultipleInterface)), Times.Once);

        }
    }
}