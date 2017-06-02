using MvcAppExample.Business.Interfaces;
using MvcAppExample.Business.Services;
using MvcAppExample.Business.Interfaces.Repositories;
using MvcAppExample.Business.Interfaces.Services;
using MvcAppExample.Data;
using MvcAppExample.Data.Contexts;
using MvcAppExample.Data.Repositories;
using SimpleInjector;

namespace MvcAppExample.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            //Businness Layer
            container.Register<IContatoService, ContatoService>(Lifestyle.Scoped);

            //Data Layer
            container.Register<IContatoRepository, ContatoRepository>(Lifestyle.Scoped);
            container.Register<ITelefoneRepository, TelefoneRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<MainContext>(Lifestyle.Scoped);
        }
    }
}
