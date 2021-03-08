using AutoMapper;
using StorePay.Api.ViewModels;
using StorePay.Domain.Entities;

namespace StorePay.Api.Mappings
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<UsuarioVM, Usuario>();
            CreateMap<AplicativoVM, Aplicativo>();
        }
    }
}
