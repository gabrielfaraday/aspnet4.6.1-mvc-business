using Moq;
using MvcAppExample.Business.Entities;
using MvcAppExample.Business.Interfaces;
using MvcAppExample.Business.Interfaces.Repositories;
using MvcAppExample.Business.Services;
using MvcAppExample.Business.ViewModels;
using NUnit.Framework;
using System;

namespace MvcAppExample.Business.Tests.Services
{
    [TestFixture]
    public class ContatoServiceTest
    {
        ContatoService _contatoService;
        Mock<IContatoRepository> _contatoRepositoryMock;
        Mock<ITelefoneRepository> _telefoneRepositoryMock;
        Mock<IUnitOfWork> _unitOfWork;

        [SetUp]
        public void Setup()
        {
            _contatoRepositoryMock = new Mock<IContatoRepository>();
            _telefoneRepositoryMock = new Mock<ITelefoneRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _contatoService = new ContatoService(_contatoRepositoryMock.Object, _unitOfWork.Object, _telefoneRepositoryMock.Object);
        }

        [Test]
        public void Contato_AdicionarContatoInvalido_NaoAdicionaContato()
        {
            var contato = new ContatoViewModel
            {
                Email = "contatoemail.com"
            };

            var resultado = _contatoService.Add(contato);

            _contatoRepositoryMock.Verify(x => x.Add(It.Is<Contato>(c => c.Email == "contatoemail.com")), Times.Never);
        }

        [Test]
        public void Contato_AdicionarContatoValido_AdicionaContato()
        {
            var contato = new ContatoViewModel
            {
                Email = "contato@email.com"
            };

            var resultado = _contatoService.Add(contato);

            _contatoRepositoryMock.Verify(x => x.Add(It.Is<Contato>(c => c.Email == "contato@email.com")), Times.Once);
        }

        [Test]
        public void Contato_AtualizarContatoInvalido_NaoAtualizaContato()
        {
            var contato = new ContatoViewModel
            {
                Email = "contatoemail.com"
            };

            var resultado = _contatoService.Update(contato);

            _contatoRepositoryMock.Verify(x => x.Update(It.Is<Contato>(c => c.Email == "contatoemail.com")), Times.Never);
        }

        [Test]
        public void Contato_AtualizarContatoValido_AtualizaContato()
        {
            var contato = new ContatoViewModel
            {
                Email = "contato@email.com"
            };

            var resultado = _contatoService.Update(contato);

            _contatoRepositoryMock.Verify(x => x.Update(It.Is<Contato>(c => c.Email == "contato@email.com")), Times.Once);
        }

        [Test]
        public void Contato_ObterContatosAtivos_ObtemAtivos()
        {
            var resultado = _contatoService.ObterAtivos();

            _contatoRepositoryMock.Verify(x => x.ObterAtivos(), Times.Once);
        }

        [Test]
        public void Contato_ObterTodos_ObtemTodos()
        {
            var resultado = _contatoService.GetAll();

            _contatoRepositoryMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void Contato_ObterObterPorEmail_ObtemPorEmail()
        {
            var resultado = _contatoService.ObterPorEmail("email");

            _contatoRepositoryMock.Verify(x => x.ObterPorEmail("email"), Times.Once);
        }

        [Test]
        public void Contato_ObterPorId_ObtemPorId()
        {
            var guid = Guid.NewGuid();

            var resultado = _contatoService.FindById(guid);

            _contatoRepositoryMock.Verify(x => x.FindById(guid), Times.Once);
        }

        [Test]
        public void Contato_Remover_RemoveContato()
        {
            var guid = Guid.NewGuid();

            _contatoService.Delete(guid);

            _contatoRepositoryMock.Verify(x => x.Delete(guid), Times.Once);
        }

        //////////////////////////////////////////////////////////////

        [Test]
        public void Contato_AdicionarTelefoneInvalido_NaoAdicionaTelefone()
        {
            var telefone = new TelefoneViewModel
            {
                DDD = "1"
            };

            var resultado = _contatoService.AdicionarTelefone(telefone);

            _telefoneRepositoryMock.Verify(x => x.Add(It.Is<Telefone>(c => c.DDD == 1)), Times.Never);
        }

        [Test]
        public void Contato_AdicionarTelefoneValido_AdicionaTelefone()
        {
            var telefone = new TelefoneViewModel
            {
                DDD  = "16",
                Numero = "33377788"
            };

            var resultado = _contatoService.AdicionarTelefone(telefone);

            _telefoneRepositoryMock.Verify(x => x.Add(It.Is<Telefone>(c => c.DDD == 16 && c.Numero == 33377788)), Times.Once);
        }

        [Test]
        public void Contato_AtualizarTelefoneInvalido_NaoAtualizaTelefone()
        {
            var telefone = new TelefoneViewModel
            {
                DDD = "1"
            };

            var resultado = _contatoService.AtualizarTelefone(telefone);

            _telefoneRepositoryMock.Verify(x => x.Update(It.Is<Telefone>(c => c.DDD == 1)), Times.Never);
        }

        [Test]
        public void Contato_AtualizarTelefoneValido_AtualizaTelefone()
        {
            var telefone = new TelefoneViewModel
            {
                DDD = "16",
                Numero = "33377788"
            };

            var resultado = _contatoService.AtualizarTelefone(telefone);

            _telefoneRepositoryMock.Verify(x => x.Update(It.Is<Telefone>(c => c.DDD == 16 && c.Numero == 33377788)), Times.Once);
        }

        [Test]
        public void Contato_ObterTelefonePorId_ObtemTelefonePorId()
        {
            var guid = Guid.NewGuid();

            var resultado = _contatoService.ObterTelefonePorId(guid);

            _telefoneRepositoryMock.Verify(x => x.FindById(guid), Times.Once);
        }

        [Test]
        public void Contato_RemoverTelefone_RemoveTelefone()
        {
            var guid = Guid.NewGuid();

            _contatoService.RemoverTelefone(guid);

            _telefoneRepositoryMock.Verify(x => x.Delete(guid), Times.Once);
        }
    }
}
