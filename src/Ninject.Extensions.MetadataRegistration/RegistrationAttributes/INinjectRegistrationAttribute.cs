namespace Ninject.Extensions.MetadataRegistration.RegistrationAttributes
{
    public interface INinjectRegistrationAttribute
    {
        IBindingBuilder Register(IBindingBuilder builder);
    }
}