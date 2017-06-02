using Moq;
using MvcAppExample.Business.Entities;
using MvcAppExample.Business.Validations.Telefones;
using NUnit.Framework;
using System.Linq;

namespace MvcAppExample.Business.Tests.Validations.Telefones
{
    [TestFixture]
    public class TelefoneEstaConsistenteValidationTest
    {
        [TestCase(true)]
        [TestCase(false)]
        public void TelefoneConsistenteValidation_IsValid_ValidaDDD(bool resultadoEsperado)
        {
            var telefoneMock = new Mock<Telefone>();

            telefoneMock.Setup(x => x.ValidarDDD()).Returns(resultadoEsperado);
            telefoneMock.Setup(x => x.ValidarNumero()).Returns(true);

            var resultado = new TelefoneEstaConsistenteValidation().Validate(telefoneMock.Object);

            Assert.That(resultado.IsValid, Is.EqualTo(resultadoEsperado));
            telefoneMock.Verify(x => x.ValidarDDD(), Times.Once);

            if (resultadoEsperado == false)
                Assert.IsTrue(resultado.Erros.Any(e => e.Message == "DDD do telefone não é válido."));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TelefoneConsistenteValidation_IsValid_ValidaNumero(bool resultadoEsperado)
        {
            var telefoneMock = new Mock<Telefone>();

            telefoneMock.Setup(x => x.ValidarDDD()).Returns(true);
            telefoneMock.Setup(x => x.ValidarNumero()).Returns(resultadoEsperado);

            var resultado = new TelefoneEstaConsistenteValidation().Validate(telefoneMock.Object);

            Assert.That(resultado.IsValid, Is.EqualTo(resultadoEsperado));
            telefoneMock.Verify(x => x.ValidarNumero(), Times.Once);

            if (resultadoEsperado == false)
                Assert.IsTrue(resultado.Erros.Any(e => e.Message == "Número do telefone não é válido."));
        }
    }
}
