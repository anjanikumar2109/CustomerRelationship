using System;

namespace DomainLayer
{
    public abstract class CustomerBase
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public abstract CustomerBase Clone();
        private IValidationStrategy<CustomerBase> _ValidationType = null;
        public CustomerBase(IValidationStrategy<CustomerBase> _Validate)
        {
            _ValidationType = _Validate;
        }
        public IValidationStrategy<CustomerBase> ValidationType
        {
            get
            {
                return _ValidationType;
            }
        }
        public void Validate()
        {
            ValidationType.Validate(this);
        }
    }
}

