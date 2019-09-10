using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.Services
{
    public class PessoaService : IPessoaService
    {

        IPessoaRepository _repository = null;

        public PessoaService (IPessoaRepository repository)
        {
            _repository = repository;
        }

        public void Deletar(int Id)
        {
            _repository.Deletar(Id);
        }

        public List<PessoaEntity> ListarPessoas()
        {
           return _repository.ListarPessoas();
        }

        public PessoaEntity ObterPessoaById(int Id)
        {
            return _repository.ObterPessoaById(Id);
        }

        public void Salvar(PessoaEntity pessoa)
        {
            _repository.Salvar(pessoa);
        }

        public List<PessoaEntity> ListarPessoasByUnidade(int IdUnidade)
        {
            return _repository.ListarPessoasByUnidade(IdUnidade);
        }

    }
}
