﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.DTOS
{
    public class UnidadeDTO
    {
        public int IdUnidade { get; set; }
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public int IdStatus { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public string ImageLogomarca { get; set; }
        public string UnidadeCor { get; set; }

        public List<PessoaDTO> Pessoas { get; set; }
        public List<NumeroPedidoDTO> NumeroPedidos { get; set; }
    }
}
