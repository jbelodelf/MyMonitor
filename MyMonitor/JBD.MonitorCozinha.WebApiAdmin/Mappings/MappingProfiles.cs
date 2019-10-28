using AutoMapper;
using JBD.MonitorCozinha.Domain.DTOS;
using JBD.MonitorCozinha.Domain.Entitys;

namespace JBD.MonitorCozinha.WebApiAdmin.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmpresaEntity, EmpresaDTO>().ReverseMap();
            CreateMap<ControleAcessoEntity, ControleAcessoDTO>().ReverseMap();
            CreateMap<NumeroPedidoEntity, NumeroPedidoDTO>().ReverseMap();
            CreateMap<PessoaEntity, PessoaDTO>().ReverseMap();
            CreateMap<StatusEntity, StatusDTO>().ReverseMap();
            CreateMap<StatusPedidoEntity, StatusPedidoDTO>().ReverseMap();
            CreateMap<TelefoneEntity, TelefoneDTO>().ReverseMap();
            CreateMap<UnidadeEntity, UnidadeDTO>().ReverseMap();
            CreateMap<UsuarioEntity, UsuarioDTO>().ReverseMap();
            CreateMap<TipoUsuarioEntity, TipoUsuarioDTO>().ReverseMap();
            CreateMap<LembreteSenhaEntity, LembreteSenhaDTO>().ReverseMap();
        }

    }
}
