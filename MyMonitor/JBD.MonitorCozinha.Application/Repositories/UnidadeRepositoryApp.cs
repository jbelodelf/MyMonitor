using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Application.Repositories
{
    public class UnidadeRepositoryApp : IUnidadeApp
    {
        IUnidadeService _service = null;

        public UnidadeRepositoryApp(IUnidadeService service)
        {
            _service = service;
        }
    
        public void Deletar(int Id)
        {
            _service.Deletar(Id);
        }

        public List<UnidadeEntity> ListarUnidades()
        {
            return _service.ListarUnidades();
        }

        public List<UnidadeEntity> ListarUnidadesByEmpresa(int IdEmpresa)
        {
            return _service.ListarUnidadesByEmpresa(IdEmpresa);
        }

        public UnidadeEntity ObterUnidadeById(int Id)
        {
            return _service.ObterUnidadeById(Id);
        }

        public UnidadeEntity Salvar(UnidadeEntity unidade)
        {
            return _service.Salvar(unidade);
        }
    }
}
