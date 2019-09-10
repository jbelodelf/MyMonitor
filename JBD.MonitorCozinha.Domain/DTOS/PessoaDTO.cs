using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.DTOS
{
    public class PessoaDTO
    {
        public int IdPessoa { get; set; }
        public int IdEmpresa { get; set; }
        public int IdUnidade { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Cargo { get; set; }
        public string EmailPJ { get; set; }
        public string EmailPF { get; set; }
        public int IdStatus { get; set; }
        public int IdTipoContato { get; set; }
        public DateTime DataCadastro { get; set; }

        public string NomeUnidade { get; set; }
        public List<SelectListItem> TipoUsuarios { get; set; }


        //public List<TelefoneDTO> Telefones { get; set; }
    }
}
