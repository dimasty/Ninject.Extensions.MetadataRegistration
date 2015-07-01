using System;
using System.Collections.Generic;
using Ninject.Activation;

namespace Ninject.Extensions.MetadataRegistration
{
    public interface IBindingBuilder
    {
        IList<Type> Services { get; }
        Func<IContext, object> ScopeCallback { get; set; }
    }
}