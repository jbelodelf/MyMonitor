using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace JBD.MonitorCozinha.Application.Repositories
{
    public class EmpresaRepositoryApp : IEmpresaApp
    {
        IEmpresaService _service = null;

        public EmpresaRepositoryApp(IEmpresaService sevice)
        {
            _service = sevice;
        }

        public void Deletar(int Id)
        {
            _service.Deletar(Id);
        }

        public List<EmpresaEntity> ListarEmpresas()
        {
            return _service.ListarEmpresas();
        }

        public List<EmpresaEntity> ListarEmpresas(string nome, string cnpjcpf)
        {
            return _service.ListarEmpresas(nome, cnpjcpf);
        }

        public EmpresaEntity ObterEmpresaById(int Id)
        {
            return _service.ObterEmpresaById(Id);
        }

        public EmpresaEntity Salvar(EmpresaEntity empresa)
        {
            var empresaEntity = _service.Salvar(empresa);
            return empresaEntity;
        }

        public bool VeficaDuplicidadeCnpjCpf(string cnpjcpf)
        {
            return _service.VeficaDuplicidadeCnpjCpf(cnpjcpf);
        }
    }
}
