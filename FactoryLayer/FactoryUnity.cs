﻿using DomainLayer;
using Unity;
using Unity.Injection;

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
