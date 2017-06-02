using DomainValidation.Validation;
using MvcAppExample.Business.Validations.Contatos;
using System;
using System.Collections.Generic;

namespace MvcAppExample.Business.Entities
{
    public class Contato : EntityBase
    {
        public Contato()
        {
            ContatoId = Guid.NewGuid();
            Telefones = new List<Telefone>();
        }

        public Guid ContatoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }

        public virtual bool Validar()
        {
            ValidationResult = new ContatoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
