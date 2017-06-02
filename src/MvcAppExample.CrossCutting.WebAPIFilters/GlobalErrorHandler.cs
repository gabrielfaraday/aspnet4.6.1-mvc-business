using log4net;
using MvcAppExample.CrossCutting.AsyncServices;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http.Filters;

namespace MvcAppExample.CrossCutting.WebAPIFilters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // MUITO CUIDADO AQUI - VOCÊ ESTÁ ENTRANDO NO MEIO DO PIPELINE DO ASP.NET, PODE IMPACTAR EM PERFORMANCE
            // FAÇA SEMPRE DE FORMA ASYNC
            // filterContext -> possui toda a informação do request

            //TODO: aqui você pode fazer um log de auditoria --> Tal usuario gravou X info na model Y

            if (actionExecutedContext.Exception != null)
            {
                // TODO: Manipular a EX
                // Injetar alguma LIB de tratamento de erro
                //  -> Gravar log do erro no BD
                //  -> Email para o admin
                //  -> Retornar cod de erro amigavel

                LoggingManager.ErrorLog(_logger, actionExecutedContext.Exception.Message);

                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new { error = "Ocorreu um erro! Tente novamente ou contate um administrador." },
                    actionExecutedContext.ActionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
