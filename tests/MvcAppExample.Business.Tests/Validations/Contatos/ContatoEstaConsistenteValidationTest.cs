using Moq;
using MvcAppExample.Business.Entities;
using MvcAppExample.Business.Validations.Contatos;
using NUnit.Framework;
using System.Linq;

namespace MvcAppExample.Business.Tests.Validations.Contatos
{
    [TestFixture]
    public class ContatoEstaConsistenteValidationTest
    {
        [TestCase("email@valido.com", true)]
        [TestCase("emailinvalido.com", false)]
        public void ContatoEmailValidoSpecification_IsValid_ValidaEmail(string email, bool resultadoEsperado)
        {
            var contato = new Contato
            {
                Email = email
            };

            var resultado = new ContatoEstaConsistenteValidation().Validate(contato);

            Assert.That(resultado.IsValid, Is.EqualTo(resultadoEsperado));

            if (resultadoEsperado == false)
                Assert.IsTrue(resultado.Erros.Any(e => e.Message == "E-mail informado não é válido."));
        }
    }
}
