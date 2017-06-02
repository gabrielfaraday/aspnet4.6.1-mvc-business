using System;
using System.Collections.Generic;
using MvcAppExample.Business.ViewModels;
using MvcAppExample.Business.Interfaces.Services;
using AutoMapper;
using MvcAppExample.Business.Entities;
using log4net;
using System.Reflection;
using MvcAppExample.CrossCutting.AsyncServices;
using MvcAppExample.Business.Interfaces.Repositories;
using MvcAppExample.Business.Validations.Contatos;
using MvcAppExample.Business.Interfaces;

namespace MvcAppExample.Business.Services
{
    public class ContatoService : ServiceBase<Contato, ContatoViewModel, IContatoRepository>, IContatoService
    {
        protected static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        ITelefoneRepository _telefoneRepository;

        public ContatoService(IContatoRepository contatoRepository, IUnitOfWork uow, ITelefoneRepository telefoneRepository) : base(uow, contatoRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        public override IEnumerable<ContatoViewModel> GetAll()
        {
            LoggingManager.InfoLog(_logger, "Carregou todos os contatos");
            return base.GetAll();
        }

        public override ContatoViewModel Add(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<Contato>(contatoViewModel);

            if (!contato.Validar())
                return Mapper.Map<ContatoViewModel>(contato);

            contato.ValidationResult = new ContatoAptoParaCadastroValidation(_repository).Validate(contato);

            contato.Ativo = true;

            var retorno = contato.ValidationResult.IsValid
                ? _repository.Add(contato)
                : contato;

            if (retorno.ValidationResult.IsValid)
            {
                retorno.ValidationResult.Message = "Contato criado com sucesso!";
                Commit();
            }

            return Mapper.Map<ContatoViewModel>(retorno);
        }

        public override ContatoViewModel Update(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<Contato>(contatoViewModel);

            if (!contato.Validar())
                return Mapper.Map<ContatoViewModel>(contato);

            contato.Ativo = true;

            var retorno = _repository.Update(contato);
            Commit();

            return Mapper.Map<ContatoViewModel>(retorno);
        }

        public IEnumerable<ContatoViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ContatoViewModel>>(_repository.ObterAtivos());
        }

        public ContatoViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ContatoViewModel>(_repository.ObterPorEmail(email));
        }

        public TelefoneViewModel AdicionarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = Mapper.Map<Telefone>(telefoneViewModel);

            if (!telefone.Validar())
                return Mapper.Map<TelefoneViewModel>(telefone);

            var retorno = _telefoneRepository.Add(telefone);
            Commit();

            return Mapper.Map<TelefoneViewModel>(telefone);
        }

        public TelefoneViewModel AtualizarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = Mapper.Map<Telefone>(telefoneViewModel);

            if (!telefone.Validar())
                return Mapper.Map<TelefoneViewModel>(telefone);

            var retorno = _telefoneRepository.Update(telefone);
            Commit();

            return Mapper.Map<TelefoneViewModel>(telefone);
        }

        public void RemoverTelefone(Guid id)
        {
            _telefoneRepository.Delete(id);
            Commit();
        }

        public TelefoneViewModel ObterTelefonePorId(Guid id)
        {
            return Mapper.Map<TelefoneViewModel>(_telefoneRepository.FindById(id));
        }

        public override void Dispose()
        {
            _telefoneRepository.Dispose();
            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}
