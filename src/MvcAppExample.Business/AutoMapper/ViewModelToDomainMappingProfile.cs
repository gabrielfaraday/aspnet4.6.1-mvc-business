using AutoMapper;
using MvcAppExample.Business.ViewModels;
using MvcAppExample.Business.Entities;

namespace MvcAppExample.Business.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ContatoViewModel, Contato>();
            CreateMap<TelefoneViewModel, Telefone>();
        }
    }
}
