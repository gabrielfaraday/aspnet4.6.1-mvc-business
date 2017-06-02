using MvcAppExample.Business.Entities;
using NUnit.Framework;
using System.Linq;

namespace MvcAppExample.Business.Tests.Entities
{
    [TestFixture]
    public class TelefoneTest
    {
        [Test]
        public void Telefone_AutoValidacao_Valido()
        {
            var telefone = new Telefone
            {
                DDD = 11,
                Numero = 988776655
            };

            var resultado = telefone.Validar();

            Assert.IsTrue(resultado);

            Assert.IsFalse(telefone.ValidationResult.Erros.Any());
        }

        [Test]
        public void Telefone_AutoValidacao_Invalido()
        {
            var telefone = new Telefone
            {
                DDD = 1,
                Numero = 776655
            };

            var resultado = telefone.Validar();

            Assert.IsFalse(resultado);

            Assert.IsTrue(telefone.ValidationResult.Erros.Any(e => e.Message == "DDD do telefone não é válido."));
            Assert.IsTrue(telefone.ValidationResult.Erros.Any(e => e.Message == "Número do telefone não é válido."));
        }

        [TestCase(1, false)]
        [TestCase(11, true)]
        [TestCase(111, false)]
        public void Telefone_ValidarDDD_RetornaSeDDDValido(int ddd, bool retornoEsperado)
        {
            var telefone = new Telefone
            {
                DDD = ddd
            };

            var retorno = telefone.ValidarDDD();

            Assert.That(retorno, Is.EqualTo(retornoEsperado));
        }

        [TestCase(1, false)]
        [TestCase(11, false)]
        [TestCase(111, false)]
        [TestCase(1111, false)]
        [TestCase(11111, false)]
        [TestCase(111111, false)]
        [TestCase(1111111, false)]
        [TestCase(11111111, true)]
        [TestCase(111111111, false)]
        [TestCase(911111111, true)]
        public void Telefone_ValidarNumero_RetornaSeNumeroValido(int numero, bool retornoEsperado)
        {
            var telefone = new Telefone
            {
                Numero = numero
            };

            var retorno = telefone.ValidarNumero();

            Assert.That(retorno, Is.EqualTo(retornoEsperado));
        }
    }
}
