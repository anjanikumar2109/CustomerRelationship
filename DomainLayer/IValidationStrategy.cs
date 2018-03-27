using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public interface IValidationStrategy<T>
    {
        void Validate(T obj);
    }
}
