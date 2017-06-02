using MvcAppExample.Business.Interfaces;
using MvcAppExample.Business.Interfaces.Services;
using MvcAppExample.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MvcAppExample.Services.REST.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class ContatosController : ApiController
    {
        IContatoService _contatoService;

        public ContatosController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        [Route("contatos")]
        public IEnumerable<ContatoViewModel> ObterAtivos()
        {
            return _contatoService.ObterAtivos();
        }

        [HttpGet]
        [Route("contatos/{id:guid}")]
        public ContatoViewModel ObterPorId(Guid id)
        {
            return _contatoService.FindById(id);
        }

        [HttpPost]
        [Route("contatos")]
        public void Adicionar([FromBody]ContatoViewModel contato)
        {
            _contatoService.Add(contato);
        }

        [HttpPut]
        [Route("contatos")]
        public void Atualizar([FromBody]ContatoViewModel contato)
        {
            _contatoService.Update(contato);
        }

        [HttpDelete]
        [Route("contatos")]
        public void Remover(Guid id)
        {
            _contatoService.Delete(id);
        }
    }
}
