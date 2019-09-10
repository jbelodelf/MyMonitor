using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Application.Repositories
{
    public class PessoaRepositoryApp : IPessoaApp
    {
        IPessoaService _service = null;

        public PessoaRepositoryApp(IPessoaService service)
        {
            _service = service;
        }

        public void Deletar(int Id)
        {
            _service.Deletar(Id);
        }

        public List<PessoaEntity> ListarPessoas()
        {
            return _service.ListarPessoas();
        }

        public PessoaEntity ObterPessoaById(int Id)
        {
            return _service.ObterPessoaById(Id);
        }

        public void Salvar(PessoaEntity pessoa)
        {
            _service.Salvar(pessoa);
        }

        public List<PessoaEntity> ListarPessoasByUnidade(int IdUnidade)
        {
            return _service.ListarPessoasByUnidade(IdUnidade);
        }

    }
}
