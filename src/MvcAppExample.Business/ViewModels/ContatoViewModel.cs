using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcAppExample.Business.ViewModels
{
    public class ContatoViewModel
    {
        public ContatoViewModel()
        {
            ContatoId = Guid.NewGuid();
            Telefones = new List<TelefoneViewModel>();
        }

        [Key]
        public Guid ContatoId { get; set; }

        [Required(ErrorMessage = "Informe o nome do contato")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do contato")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        //[Display(Name = "Data de Nascimento")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        //public DateTime DataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        public ICollection<TelefoneViewModel> Telefones { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
