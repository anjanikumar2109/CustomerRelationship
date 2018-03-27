using System;
using System.Collections.Generic;
using DomainLayer;

namespace FactoryLayer
{
    public static class Factory
    {
        private static Lazy<Dictionary<string, CustomerBase>> customers;

        static Factory()
        {
            customers = new Lazy<Dictionary<string, CustomerBase>>(() => LoadCustomers());
        }

        static Dictionary<string, CustomerBase> LoadCustomers() 
        {
            var custs = new Dictionary<string, CustomerBase>();
            custs.Add("Lead", new Lead(new LeadValidation()));
            custs.Add("Customer", new Customer(new CustomerValidation()));
            return custs;
        }
        
        public static CustomerBase Create(string type)
        {
            return customers.Value[type].Clone();
        }
    }
}
