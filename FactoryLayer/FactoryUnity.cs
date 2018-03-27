using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Unity;
using Unity.Injection;
using DomainLayer;

namespace FactoryLayer
{
    public static class FactoryUnity<T>
    {
        static IUnityContainer container = null;

        static FactoryUnity()
        {
            container = new UnityContainer();
            container.RegisterType<CustomerBase, Lead>("Lead", new InjectionConstructor(new LeadValidation()));
            container.RegisterType<CustomerBase, Customer>("Customer", new InjectionConstructor(new CustomerValidation()));
        }

        public static T Create(string type)
        {
            return container.Resolve<T>(type);
        }
    }
}
