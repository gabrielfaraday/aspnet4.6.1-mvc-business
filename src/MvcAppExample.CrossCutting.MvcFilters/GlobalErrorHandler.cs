using log4net;
using MvcAppExample.CrossCutting.AsyncServices;
using System.Reflection;
using System.Web.Mvc;

namespace MvcAppExample.CrossCutting.MvcFilters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // MUITO CUIDADO AQUI - VOCÊ ESTÁ ENTRANDO NO MEIO DO PIPELINE DO ASP.NET, PODE IMPACTAR EM PERFORMANCE
            // FAÇA SEMPRE DE FORMA ASYNC
            // filterContext -> possui toda a informação do request

            //TODO: aqui você pode fazer um log de auditoria --> Tal usuario gravou X info na model Y

            if (filterContext.Exception != null)
            {
                // TODO: Manipular a EX
                // Injetar alguma LIB de tratamento de erro
                //  -> Gravar log do erro no BD
                //  -> Email para o admin
                //  -> Retornar cod de erro amigavel

                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var actionName = filterContext.ActionDescriptor.ActionName;
                var userName = filterContext.HttpContext.User.Identity.Name.ToString();
                var ex = filterContext.Exception;

                var message = $"UserName= {userName} | Controller= {controllerName} | Action= {actionName} | Exceção= {ex.Message} | \r\n StackTrace= \r\n {ex.StackTrace}";

                LoggingManager.ErrorLog(_logger, message);

                filterContext.Controller.TempData["ErrorMessage"] = ex.Message;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
