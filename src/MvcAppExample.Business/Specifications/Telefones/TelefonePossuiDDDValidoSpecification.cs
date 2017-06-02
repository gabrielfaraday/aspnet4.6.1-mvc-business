using DomainValidation.Interfaces.Specification;
using MvcAppExample.Business.Entities;

namespace MvcAppExample.Business.Specifications.Telefones
{
    public class TelefonePossuiDDDValidoSpecification : ISpecification<Telefone>
    {
        public bool IsSatisfiedBy(Telefone telefone)
        {
            return telefone.ValidarDDD();
        }
    }
}
