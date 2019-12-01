using JBD.MonitorCozinha.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBD.MonitorCozinha.WebAdmin.Models
{
    public class ControleAcessoViewModel
    {
        public int IdControleAcesso { get; set; }
        public int IdUsuario { get; set; }
        public TipoUsuarioEnum IdTipo { get; set; }

        public int IdUnidade { get; set; }
        public int IdEmpresa { get; set; }
        public string Unidade { get; set; }
        public string IP { get; set; }
        public DateTime DataLogin { get; set; }
        public DateTime DataLogoff { get; set; }
        public bool ConexaoAtiva { get; set; }
    }

    public class PerfilUserViewModel
    {
        public int IdPerfilUser { get; set; }
        public string Nome { get; set; }

        public PerfilPFuncionalidadeViewModel perfilPFuncionalidade { get; set; }
    }

    public class PerfilPFuncionalidadeViewModel
    {
        public int IdFuncionalidade { get; set; }
        public string Nome { get; set; }

        // MONITOR TV
        // CADASTRAR SENHAS
        // CADASTRAR SENHAS - MOTOBOY
        // MONITOR ADMINISTRATIVO


        // Cadastro
        // MonitorTV
        // MonitorTVAdmin
        // MonitorAdmin
        // Cozinha
    }

    public class MonitorCozinhaViewModel
    {
        public int IdUnidade { get; set; }
        public int QuantidePedidosFazendo { get; set; }
        public int QuantidePedidosPronto { get; set; }
        public bool Carregado { get; set; }
        public bool beep { get; set; }
        public List<NumeroPedidoViewModel> numerosPedidoCache = new List<NumeroPedidoViewModel>();
    }

    public static class Controle
    {
        public static ControleAcessoViewModel ControleAcesso { get; set; } = new ControleAcessoViewModel();
        public static PerfilPFuncionalidadeViewModel PerfilPFuncionalidade { get; set; } = new PerfilPFuncionalidadeViewModel();
        public static MonitorCozinhaViewModel monitorCozinhaViewModel { get; set; } = new MonitorCozinhaViewModel();

        public static void AtualzarAcesso(UsuarioViewModel usuario)
        {
            ControleAcesso.IdEmpresa = usuario.IdEmpresa;
            ControleAcesso.IdUnidade = usuario.IdUnidade;
            ControleAcesso.IdUsuario = usuario.IdUsuario;
            ControleAcesso.IdTipo = usuario.IdTipo;
            if (usuario.Unidade != null)
            {
                ControleAcesso.Unidade = usuario.Unidade.Nome;
            }
            ControleAcesso.ConexaoAtiva = true;
            ControleAcesso.DataLogin = DateTime.Now;
        }

        public static bool ValidarUsuarioLogado()
        {
            bool valido = false;
            if (ControleAcesso.ConexaoAtiva)
            {
                valido = true;
            }
            return valido;
        }

    }
}
