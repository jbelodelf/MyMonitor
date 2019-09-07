using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace JBD.MonitorCozinha.WebAdmin.Models
{
    public class EmpresaViewModel
    {
        public EmpresaViewModel()
        {
            Unidades = new List<UnidadeViewModel>();
        }

        public int IdEmpresa { get; set; }
        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }
        [DisplayName("Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }
        [DisplayName("Inscrição Municipal")]
        public string InscricaoMunicipal { get; set; }
        public int IdStatus { get; set; }
        [DisplayName("Nome contato")]
        public string NomeContato { get; set; }
        [DisplayName("Telefone")]
        public string Telefone { get; set; }
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        public DateTime dataNow = DateTime.Today;
        public List<UnidadeViewModel> Unidades { get; set; }
    }
}
