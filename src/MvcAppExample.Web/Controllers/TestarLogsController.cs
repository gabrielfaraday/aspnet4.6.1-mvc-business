using log4net;
using MvcAppExample.Business.Interfaces.Services;
using System;
using System.Web.Mvc;

namespace MvcAppExample.Web.Controllers
{
    public class TestarLogsController : Controller
    {
        IContatoService _contatoService;

        public TestarLogsController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public ActionResult Index()
        {
            var teste = _contatoService.GetAll();

            var logger = LogManager.GetLogger(typeof(TestarLogsController));
            logger.Warn("Atenção ...vai dar erro");

            throw new Exception("Parabéns! Você gerou uma exceção");
        }
    }
}