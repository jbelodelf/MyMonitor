using JBD.MonitorCozinha.Domain.Entitys;
using System.Collections.Generic;

namespace JBD.MonitorCozinha.Domain.Interfaces.Service
{
    public interface IEmpresaService
    {
        List<EmpresaEntity> ListarEmpresas();
        List<EmpresaEntity> ListarEmpresas(string nome, string cnpjcpf);
        EmpresaEntity ObterEmpresaById(int Id);
        bool VeficaDuplicidadeCnpjCpf(string cnpjcpf);
        EmpresaEntity Salvar(EmpresaEntity empresa);
        void Deletar(int Id);
    }
}
