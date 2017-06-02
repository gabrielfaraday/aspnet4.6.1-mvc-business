using MvcAppExample.Business.Entities;
using NUnit.Framework;
using System.Linq;

namespace MvcAppExample.Business.Tests.Entities
{
    [TestFixture]
    public class ContatoTest
    {
        [Test]
        public void Contato_AutoValidacao_Valido()
        {
            var contato = new Contato
            {
                Email = "contato@email.com"
            };

            var resultado = contato.Validar();

            Assert.IsTrue(resultado);

            Assert.IsFalse(contato.ValidationResult.Erros.Any());
        }

        [Test]
        public void Contato_AutoValidacao_Invalido()
        {
            var contato = new Contato
            {
                Email = "contatoemail.com"
            };

            var resultado = contato.Validar();

            Assert.IsFalse(resultado);

            Assert.IsTrue(contato.ValidationResult.Erros.Any(e => e.Message == "E-mail informado não é válido."));
        }
    }
}
