using DomainValidation.Interfaces.Specification;
using MvcAppExample.Business.Entities;
using MvcAppExample.Business.Interfaces.Repositories;

namespace MvcAppExample.Business.Specifications.Contatos
{
    public class ContatoPossuiEmailUnicoSpecification : ISpecification<Contato>
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoPossuiEmailUnicoSpecification(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public bool IsSatisfiedBy(Contato contato)
        {
            return _contatoRepository.ObterPorEmail(contato.Email) == null;
        }
    }
}