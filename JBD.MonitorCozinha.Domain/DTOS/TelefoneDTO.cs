using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.DTOS
{
    public class TelefoneDTO
    {
        public int IdTelefone { get; set; }
        public int IdPessoa { get; set; }
        public int IdUnidade { get; set; }
        public int IdEmpresa { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
