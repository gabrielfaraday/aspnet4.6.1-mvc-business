using DomainValidation.Validation;
using MvcAppExample.Business.Entities;
using MvcAppExample.Business.Interfaces.Repositories;
using MvcAppExample.Business.Specifications.Contatos;

namespace MvcAppExample.Business.Validations.Contatos
{
    public class ContatoAptoParaCadastroValidation : Validator<Contato>
    {
        public ContatoAptoParaCadastroValidation(IContatoRepository contatoRepository)
        {
            var emailSpecification = new ContatoPossuiEmailUnicoSpecification(contatoRepository);

            base.Add("contatoEmailUnico", new Rule<Contato>(emailSpecification, "E-mail informado já cadastrado."));
        }
    }
}