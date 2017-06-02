using MvcAppExample.Business.Validations;
using NUnit.Framework;

namespace MvcAppExample.Business.Tests.Validations
{
    [TestFixture]
    public class EmailValidationTest
    {
        [TestCase("123", false)]
        [TestCase("asda", false)]
        [TestCase("asda@", false)]
        [TestCase("@", false)]
        [TestCase("asda@sasad", false)]
        [TestCase("asda@asas", false)]
        [TestCase("asda@asas.", false)]
        [TestCase("asda@asas.br", true)]
        [TestCase("asda@asas.com.br", true)]
        [TestCase("122@123.pt", true)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void Email_Validar_ValidaEmail(string endereco, bool resultadoEsperado)
        {
            var resultado = EmailValidation.Validate(endereco);

            Assert.That(resultado, Is.EqualTo(resultadoEsperado));
        }
    }
}
