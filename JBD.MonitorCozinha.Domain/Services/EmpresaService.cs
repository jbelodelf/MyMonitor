using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Enuns;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JBD.MonitorCozinha.Domain.Services
{
    public class EmpresaService : IEmpresaService
    {
        IEmpresaRepository _repository = null;

        public EmpresaService(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        public void Deletar(int Id)
        {
            _repository.Deletar(Id);
        }

        public List<EmpresaEntity> ListarEmpresas()
        {
            List<EmpresaEntity> empresas = _repository.ListarEmpresas();
            if (empresas.Count > 0)
            {
                foreach (var empresa in empresas)
                {
                    if (empresa.Unidades.Count > 0)
                    {
                        var unidades = empresa.Unidades.Where(u => u.IdStatus == (int)StatusEnum.Ativo).ToList();
                        empresa.Unidades = new List<UnidadeEntity>();
                        if (unidades.Count > 0)
                        {
                            empresa.Unidades.AddRange(unidades);
                        }
                    }
                }
            }
            return empresas;
        }

        public List<EmpresaEntity> ListarEmpresas(string nome, string cnpjcpf)
        {
            return _repository.ListarEmpresas(nome, cnpjcpf);
        }

        public EmpresaEntity ObterEmpresaById(int Id)
        {
            EmpresaEntity empresa = _repository.ObterEmpresaById(Id);
            if (empresa != null)
            {
                if (empresa.Unidades.Count > 0)
                {
                    var unidades = empresa.Unidades.Where(u => u.IdStatus == (int)StatusEnum.Ativo).ToList();
                    empresa.Unidades = new List<UnidadeEntity>();
                    if (unidades.Count > 0)
                    {
                        empresa.Unidades.AddRange(unidades);
                    }
                }
            }
            return empresa;
        }

        public EmpresaEntity Salvar(EmpresaEntity empresaEntity)
        {
            EmpresaEntity empresa = null;
            
            if (empresaEntity.IdEmpresa > 0)
            {
                _repository.Alterar(empresaEntity);
            }
            else
            {
                empresa = _repository.Inserir(empresaEntity);
            }
            return empresa;
        }

        public bool VeficaDuplicidadeCnpjCpf(string cnpjcpf)
        {
            return _repository.VeficaDuplicidadeCnpjCpf(cnpjcpf);
        }
    }
}
