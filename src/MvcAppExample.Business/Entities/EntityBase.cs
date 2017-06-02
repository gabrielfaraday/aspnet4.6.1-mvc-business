using DomainValidation.Validation;

namespace MvcAppExample.Business.Entities
{
    public abstract class EntityBase
    {
        public ValidationResult ValidationResult { get; set; }
    }
}
