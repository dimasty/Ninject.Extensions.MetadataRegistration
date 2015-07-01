using System;

namespace Ninject.Extensions.MetadataRegistration.RegistrationAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class AsAttribute : Attribute, INinjectRegistrationAttribute
    {
        private readonly Type[] _asTypes;

        public AsAttribute(Type asType)
        {
            _asTypes = new[] { asType };
        }

        public AsAttribute(Type[] asTypes)
        {
            _asTypes = asTypes;
        }

        public IBindingBuilder Register(IBindingBuilder builder)
        {
            foreach (var type in _asTypes)
            {
                builder.Services.Add(type);
            }
            return builder;
        }
    }
}