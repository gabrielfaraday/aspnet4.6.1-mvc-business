using MvcAppExample.Business.Entities;
using MvcAppExample.Business.Interfaces.Repositories;
using MvcAppExample.Data.Contexts;

namespace MvcAppExample.Data.Repositories
{
    public class TelefoneRepository : RepositoryBase<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}
