using AutoMapper;
using StorePay.Api.ViewModels;
using StorePay.Domain.Entities;

namespace StorePay.Api.Mappings
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel() 
        {
            CreateMap<Usuario, UsuarioVM>();
            CreateMap<Aplicativo, AplicativoVM>();
        }
    }
}
