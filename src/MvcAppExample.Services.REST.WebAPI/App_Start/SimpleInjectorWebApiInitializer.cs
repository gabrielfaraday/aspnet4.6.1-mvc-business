using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using MvcAppExample.CrossCutting.IoC;

[assembly: WebActivator.PostApplicationStartMethod(typeof(MvcAppExample.Services.REST.WebAPI.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace MvcAppExample.Services.REST.WebAPI.App_Start
{
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            BootStrapper.Register(container);
        }
    }
}