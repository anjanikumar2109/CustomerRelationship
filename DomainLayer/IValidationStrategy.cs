namespace DomainLayer
{
    public interface IValidationStrategy<T>
    {
        void Validate(T obj);
    }
}
