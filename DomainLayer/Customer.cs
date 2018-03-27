using System;

namespace DomainLayer
{
    public class Customer : CustomerBase
    {
        public Customer(IValidationStrategy<CustomerBase> obj)
            : base(obj)
        {

        }

        public override CustomerBase Clone()
        {
            return (CustomerBase)this.MemberwiseClone();
        }
    }

    public class CustomerValidation : IValidationStrategy<CustomerBase>
    {

        public void Validate(CustomerBase obj)
        {
            if (obj.CustomerName.Length == 0)
            {
                throw new Exception("Customer Name is required");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("Phone number is required");
            }
            if (obj.Address.Length == 0)
            {
                throw new Exception("Address is required");
            }
        }
    }
}
