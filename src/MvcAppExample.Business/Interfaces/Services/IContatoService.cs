using MvcAppExample.Business.ViewModels;
using System;
using System.Collections.Generic;

namespace MvcAppExample.Business.Interfaces.Services
{
    public interface IContatoService : IServiceBase<ContatoViewModel>
    {
        ContatoViewModel ObterPorEmail(string email);
        IEnumerable<ContatoViewModel> ObterAtivos();

        TelefoneViewModel AdicionarTelefone(TelefoneViewModel telefoneViewModel);
        TelefoneViewModel AtualizarTelefone(TelefoneViewModel telefoneViewModel);
        void RemoverTelefone(Guid id);
        TelefoneViewModel ObterTelefonePorId(Guid id);
    }
}
