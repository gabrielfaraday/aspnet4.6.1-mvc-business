using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcAppExample.Business.ViewModels
{
    public class TelefoneViewModel
    {
        public TelefoneViewModel()
        {
            TelefoneId = Guid.NewGuid();
        }

        [Key]
        public Guid TelefoneId { get; set; }

        [Required(ErrorMessage = "Informe o DDD do telefone")]
        [StringLength(2, ErrorMessage = "Deve ter 2 caracteres")]
        public string DDD { get; set; }

        [Required(ErrorMessage = "Informe o número do telefone")]
        [MaxLength(9, ErrorMessage = "Máximo 9 caracteres")]
        [MinLength(8, ErrorMessage = "Minimo 8 caracteres")]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [ScaffoldColumn(false)]
        public Guid ContatoId { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
