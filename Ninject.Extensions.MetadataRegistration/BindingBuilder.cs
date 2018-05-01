using System;
using System.Collections.Generic;
using Ninject.Activation;
using Ninject.Infrastructure;

namespace Ninject.Extensions.MetadataRegistration
{
    public class BindingBuilder : IBindingBuilder
    {
        public BindingBuilder()
        {
            Services = new List<Type>();
            ScopeCallback = StandardScopeCallbacks.Transient;
        }
        public IList<Type> Services { get; private set; }
        public Func<IContext, object> ScopeCallback { get; set; }
    }
}