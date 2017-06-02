//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace MvcAppExample.Services.REST.WebAPI.App_Start
//{
//    public class filters : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            try
//            {
//                if (!actionContext.Request.Headers.Any(x => x.Key == "imei") || !actionContext.Request.Headers.Any(x => x.Key == "cracha"))
//                    throw new Exception("Header inválido!");

//                var imei = actionContext.Request.Headers.Where(x => x.Key == "imei").FirstOrDefault().Value.FirstOrDefault();
//                var cracha = actionContext.Request.Headers.Where(x => x.Key == "cracha").FirstOrDefault().Value.FirstOrDefault();

//                if (cracha != "sincronizacao")
//                {
//                    var usuarioService = new UsuarioAppService();
//                    var usuario = usuarioService.ObterPorCracha(cracha);
//                    if (usuario == null || usuario.rowId == null)
//                        throw new Exception("Usuário inválido!");
//                }

//                var smartphoneService = new SmartphoneAppService();
//                var smartphone = smartphoneService.ObterPorImei(imei);
//                if (smartphone == null || smartphone.rowId == null)
//                    throw new Exception("Imei inválido!");
//                if (smartphone.status == (byte)EnumsUtils.StatusAtivoInativoInt.Inativo)
//                    throw new Exception("Smartphone inativo!");
//            }
//            catch (Exception ex)
//            {
//                actionContext.Response = actionContext.Request.CreateResponse(
//                    HttpStatusCode.BadRequest,
//                    new { error = ex.Message },
//                    actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
//                );
//            }
//        }
//    }
//}