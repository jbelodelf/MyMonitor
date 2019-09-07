using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace JBD.MonitorCozinha.WebAdmin.Models
{
    public class UnidadeViewModel
    {
        public int IdUnidade { get; set; }
        [DisplayName("Empresa")]
        public int IdEmpresa { get; set; }
        [DisplayName("Nome Unidade")]
        public string Nome { get; set; }
        [DisplayName("CEP")]
        public string CEP { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        [DisplayName("Bairro")]
        public string Bairro { get; set; }
        [DisplayName("Numero")]
        public string Numero { get; set; }
        [DisplayName("Cidade")]
        public string Cidade { get; set; }
        [DisplayName("Estado")]
        public string Estado { get; set; }
        [DisplayName("Pais")]
        public string Pais { get; set; }
        public int IdStatus { get; set; }
        [DisplayName("Nome contato")]
        public string NomeContato { get; set; }
        [DisplayName("Telefone")]
        public string Telefone { get; set; }
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        [DisplayName("Logomarca")]
        public string ImageLogomarca { get; set; }

        public string NomeEmpresa { get; set; }

        // Para List Index
        public List<PessoaViewModel> Pessoas { get; set; }
        public List<NumeroPedidoViewModel> NumeroPedidos { get; set; }
    }
}
