using DomainValidation.Validation;
using MvcAppExample.Business.Entities;
using MvcAppExample.Business.Specifications.Contatos;

namespace MvcAppExample.Business.Validations.Contatos
{
    public class ContatoEstaConsistenteValidation : Validator<Contato>
    {
        public ContatoEstaConsistenteValidation()
        {
            var emailSpecification = new ContatoPossuiEmailValidoSpecification();

            base.Add("contatoEmailValido", new Rule<Contato>(emailSpecification, "E-mail informado não é válido."));
        }
    }
}