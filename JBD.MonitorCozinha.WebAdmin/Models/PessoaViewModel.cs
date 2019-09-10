using JBD.MonitorCozinha.Domain.Enuns;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JBD.MonitorCozinha.WebAdmin.Models
{
    public class PessoaViewModel
    {      
        public int IdPessoa { get; set; }
        public int IdEmpresa { get; set; }
        public int IdUnidade { get; set; }
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("CPF")]
        public string CPF { get; set; }
        [DisplayName("RG")]
        public string RG { get; set; }
        [DisplayName("Cargo")]
        public string Cargo { get; set; }
        [DisplayName("Email Primário")]
        public string EmailPJ { get; set; }
        [DisplayName("Email Secundário")]
        public string EmailPF { get; set; }
        [DisplayName("Status")]
        public int IdStatus { get; set; }
        [DisplayName("Tipo de Usuário")]
        public int IdTipoContato { get; set; }
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        public string NomeUnidade { get; set; }
        public List<SelectListItem> TipoUsuarios { get; set; }


        public PessoaViewModel()
        {
            var listaTipoUsuario = from TipoUsuarioEnum pn in Enum.GetValues(typeof(TipoUsuarioEnum))
                                   select new SelectListItem
                                   {
                                       Value = ((int)pn).ToString(),
                                       Text = Enum.GetName(typeof(TipoUsuarioEnum), pn),
                                       Selected = IdTipoContato == (int)pn ? true : false
                                   };
            TipoUsuarios = listaTipoUsuario.ToList();

        }

        //public string TipoUsuarioName { get; set; }
        //public IEnumerable<TipoUsuarioViewModel> TipoUsuario { get; set; }

        //public List<TelefoneViewModel> Telefones { get; set; }

    }
}
