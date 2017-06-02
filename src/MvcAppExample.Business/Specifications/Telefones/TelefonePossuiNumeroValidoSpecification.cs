using DomainValidation.Interfaces.Specification;
using MvcAppExample.Business.Entities;

namespace MvcAppExample.Business.Specifications.Telefones
{
    public class TelefonePossuiNumeroValidoSpecification : ISpecification<Telefone>
    {
        public bool IsSatisfiedBy(Telefone telefone)
        {
            return telefone.ValidarNumero();
        }
    }
}
