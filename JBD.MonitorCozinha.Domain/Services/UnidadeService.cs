using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.Services
{
    public class UnidadeService : IUnidadeService
    {
        IUnidadeRepository _repository = null;

        public UnidadeService(IUnidadeRepository repository)
        {
            _repository = repository;
        }

        public void Deletar(int Id)
        {
            _repository.Deletar(Id);
        }

        public List<UnidadeEntity> ListarUnidades()
        {
            return _repository.ListarUnidades();
        }

        public List<UnidadeEntity> ListarUnidadesByEmpresa(int IdEmpresa)
        {
            return _repository.ListarUnidadesByEmpresa(IdEmpresa);
        }

        public UnidadeEntity ObterUnidadeById(int Id)
        {
            return _repository.ObterUnidadeById(Id);
        }

        public UnidadeEntity Salvar(UnidadeEntity unidade)
        {
            return _repository.Salvar(unidade);
        }
    }
}
