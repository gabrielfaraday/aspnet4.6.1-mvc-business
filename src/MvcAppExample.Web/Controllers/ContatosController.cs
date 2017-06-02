using System;
using System.Net;
using System.Web.Mvc;
using MvcAppExample.Business.ViewModels;
using MvcAppExample.CrossCutting.MvcFilters;
using WebGrease.Css.Extensions;
using MvcAppExample.Business.Interfaces.Services;

namespace MvcAppExample.Web.Controllers
{
    [RoutePrefix("contato")]
    [Authorize]
    public class ContatosController : Controller
    {
        readonly IContatoService _contatoService;

        public ContatosController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [Route("listar")]
        [ClaimsAuthorize("ModuloContato", "CLst")]
        public ActionResult Index()
        {
            return View(_contatoService.ObterAtivos());
        }

        [Route("{id:guid}/telefones")]
        [ClaimsAuthorize("ModuloContato", "TLst")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var contatoViewModel = _contatoService.FindById(id.Value);

            if (contatoViewModel == null)
                return HttpNotFound();
            
            return View(contatoViewModel);
        }

        [Route("novo")]
        [ClaimsAuthorize("ModuloContato", "CInc")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("novo")]
        [ClaimsAuthorize("ModuloContato", "CInc")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContatoViewModel contatoViewModel)
        {
            if (!ModelState.IsValid)
                return View(contatoViewModel);

            var contatoRetorno = _contatoService.Add(contatoViewModel);

            if (contatoRetorno.ValidationResult.IsValid)
            {
                ViewBag.MensagemSucesso = contatoRetorno.ValidationResult.Message; //Essa mensagem poderia ser exibida na tela para o usuário
                return RedirectToAction("Index");
            }

            contatoRetorno
                .ValidationResult
                .Erros
                .ForEach(e => ModelState.AddModelError(string.Empty, e.Message));

            return View(contatoViewModel);
        }

        [Route("{id:guid}/alterar")]
        [ClaimsAuthorize("ModuloContato", "CEdt")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var contatoViewModel = _contatoService.FindById(id.Value);

            if (contatoViewModel == null)
                return HttpNotFound();

            return View(contatoViewModel);
        }

        [Route("{id:guid}/alterar")]
        [ClaimsAuthorize("ModuloContato", "CEdt")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContatoViewModel contatoViewModel)
        {
            if (!ModelState.IsValid)
                return View(contatoViewModel);

            var contatoRetorno = _contatoService.Update(contatoViewModel);

            if (contatoRetorno.ValidationResult.IsValid)
                return RedirectToAction("Index");

            contatoRetorno
                .ValidationResult
                .Erros
                .ForEach(e => ModelState.AddModelError(string.Empty, e.Message));

            return View(contatoViewModel);
        }

        [Route("{id:guid}/remover")]
        [ClaimsAuthorize("ModuloContato", "CRmv")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var contatoViewModel = _contatoService.FindById(id.Value);

            if (contatoViewModel == null)
                return HttpNotFound();

            return View(contatoViewModel);
        }

        [Route("{id:guid}/remover")]
        [ClaimsAuthorize("ModuloContato", "CRmv")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _contatoService.Delete(id);
            return RedirectToAction("Index");
        }

        [Route("{id:guid}/novo-fone")]
        [ClaimsAuthorize("ModuloContato", "TInc")]
        public ActionResult NovoFone(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var contatoViewModel = _contatoService.FindById(id.Value);

            if (contatoViewModel == null)
                return HttpNotFound();

            var telefoneViewModel = new TelefoneViewModel
            {
                ContatoId = contatoViewModel.ContatoId
            };

            return View(telefoneViewModel);
        }

        [Route("{id:guid}/novo-fone")]
        [ClaimsAuthorize("ModuloContato", "TInc")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoFone(TelefoneViewModel telefoneViewModel)
        {
            if (!ModelState.IsValid)
                return View(telefoneViewModel);

            var telefoneRetorno = _contatoService.AdicionarTelefone(telefoneViewModel);

            if (telefoneRetorno.ValidationResult.IsValid)
            {
                var contatoViewModel = _contatoService.FindById(telefoneViewModel.ContatoId);
                return View("Details", contatoViewModel);
            }

            telefoneRetorno
                .ValidationResult
                .Erros
                .ForEach(e => ModelState.AddModelError(string.Empty, e.Message));

            return View(telefoneViewModel);
        }

        [Route("{id:guid}/remover-telefone")]
        [ClaimsAuthorize("ModuloContato", "TRmv")]
        public ActionResult RemoverFone(Guid id)
        {
            var telefoneViewModel = _contatoService.ObterTelefonePorId(id);

            if (telefoneViewModel == null)
                return HttpNotFound();

            _contatoService.RemoverTelefone(id);

            var contatoViewModel = _contatoService.FindById(telefoneViewModel.ContatoId);

            return View("Details", contatoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _contatoService.Dispose();

            base.Dispose(disposing);
        }
    }
}
