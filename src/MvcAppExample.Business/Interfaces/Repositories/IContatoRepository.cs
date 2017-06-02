using MvcAppExample.Business.Entities;
using System.Collections.Generic;

namespace MvcAppExample.Business.Interfaces.Repositories
{
    public interface IContatoRepository : IRepositoryBase<Contato>
    {
        Contato ObterPorEmail(string email);
        ICollection<Contato> ObterAtivos();
    }
}
