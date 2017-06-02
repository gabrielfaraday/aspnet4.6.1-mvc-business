using DomainValidation.Validation;
using MvcAppExample.Business.Validations.Telefones;
using System;
using System.Text.RegularExpressions;

namespace MvcAppExample.Business.Entities
{
    public class Telefone : EntityBase
    {
        public Telefone()
        {
            TelefoneId = Guid.NewGuid();
        }

        public Guid TelefoneId { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }
        public Guid ContatoId { get; set; }
        public virtual Contato Contato { get; set; }
        
        public virtual bool Validar()
        {
            ValidationResult = new TelefoneEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public virtual bool ValidarDDD()
        {
            return Regex.IsMatch(DDD.ToString(), @"\A[0-9]{2}\Z");
        }

        public virtual bool ValidarNumero()
        {
            return Regex.IsMatch(Numero.ToString(), @"\A9?[0-9]{8}\Z");
        }
    }
}
