namespace DomainLayer
{
    public abstract class CustomerBase
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public abstract CustomerBase Clone();

        public CustomerBase(IValidationStrategy<CustomerBase> _Validate)
        {
            ValidationType = _Validate;
        }
        public IValidationStrategy<CustomerBase> ValidationType { get; } = null;

        public void Validate()
        {
            ValidationType.Validate(this);
        }
    }
}

