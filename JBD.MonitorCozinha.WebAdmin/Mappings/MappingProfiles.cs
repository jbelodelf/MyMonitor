using AutoMapper;
using JBD.MonitorCozinha.Domain.DTOS;
using JBD.MonitorCozinha.WebAdmin.Models;

namespace JBD.MonitorCozinha.WebAdmin.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmpresaDTO, EmpresaViewModel>().ReverseMap();
            CreateMap<ControleAcessoDTO, ControleAcessoViewModel>().ReverseMap();
            CreateMap<NumeroPedidoDTO, NumeroPedidoViewModel>().ReverseMap();
            CreateMap<PessoaDTO, PessoaViewModel>().ReverseMap();
            CreateMap<StatusDTO, StatusViewModel>().ReverseMap();
            CreateMap<StatusPedidoDTO, StatusPedidoViewModel>().ReverseMap();
            CreateMap<TelefoneDTO, TelefoneViewModel>().ReverseMap();
            CreateMap<UnidadeDTO, UnidadeViewModel>().ReverseMap();
            CreateMap<UsuarioDTO, UsuarioViewModel>().ReverseMap();
            CreateMap<TipoUsuarioDTO, TipoUsuarioViewModel>().ReverseMap();

        }
    }
}
