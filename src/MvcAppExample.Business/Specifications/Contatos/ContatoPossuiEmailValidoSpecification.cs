using DomainValidation.Interfaces.Specification;
using MvcAppExample.Business.Entities;
using MvcAppExample.Business.Validations;

namespace MvcAppExample.Business.Specifications.Contatos
{
    public class ContatoPossuiEmailValidoSpecification : ISpecification<Contato>
    {
        public bool IsSatisfiedBy(Contato contato)
        {
            return EmailValidation.Validate(contato.Email);
        }
    }
}
