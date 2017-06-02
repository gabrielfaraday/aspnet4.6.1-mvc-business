using AutoMapper;
using MvcAppExample.Business.Entities;
using MvcAppExample.Business.ViewModels;

namespace MvcAppExample.Business.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Contato, ContatoViewModel>();
            CreateMap<Telefone, TelefoneViewModel>();
        }
    }
}
