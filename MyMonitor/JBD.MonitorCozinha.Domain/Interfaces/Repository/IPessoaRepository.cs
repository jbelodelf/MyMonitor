using JBD.MonitorCozinha.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.Interfaces.Repository
{
    public interface IPessoaRepository
    {
        List<PessoaEntity> ListarPessoas();
        PessoaEntity ObterPessoaById(int Id);
        List<PessoaEntity> ListarPessoasByUnidade(int IdUnidade);
        void Salvar(PessoaEntity pessoa);
        void Deletar(int Id);

    }
}
