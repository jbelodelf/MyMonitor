using Data.Repositories.Base;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Enuns;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Reositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public void Deletar(int Id)
        {
            Expression<Func<EmpresaEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo && a.IdEmpresa == (Int64)Id);

            using (var rep = new RepositoryBase<EmpresaEntity>())
            {
                EmpresaEntity empresa = rep.Select(expressionFiltro).FirstOrDefault();
                if(empresa != null)
                {
                    rep.Delete(empresa);
                }
            }
        }

        //public List<EmpresaEntity> ListarEmpresas()
        public List<EmpresaEntity> ListarEmpresas()
        {
            List<EmpresaEntity> ListaEmpresas = new List<EmpresaEntity>();
            string[] includes = new string[] { "Unidades" };
            Expression<Func<EmpresaEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo);

            using (var rep = new RepositoryBase<EmpresaEntity>())
            {
                ListaEmpresas = rep.Select(expressionFiltro, includes).ToList();
            }

            return ListaEmpresas;
        }

        public List<EmpresaEntity> ListarEmpresas(string nome, string cnpjcpf)
        {
            List<EmpresaEntity> ListaEmpresas = new List<EmpresaEntity>();
            string[] includes = new string[] { "Unidades" };
            Expression<Func<EmpresaEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo);

            using (var rep = new RepositoryBase<EmpresaEntity>())
            {
                ListaEmpresas = rep.Select(expressionFiltro, includes).ToList();
            }

            return ListaEmpresas;
        }

        public EmpresaEntity ObterEmpresaById(int Id)
        {
            EmpresaEntity empresa = new EmpresaEntity();
            string[] includes = new string[] { "Unidades" };
            Expression<Func<EmpresaEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo && a.IdEmpresa == (Int64)Id);

            using (var rep = new RepositoryBase<EmpresaEntity>())
            {
                empresa = rep.Select(expressionFiltro, includes).FirstOrDefault();
            }

            return empresa;
        }

        public EmpresaEntity Inserir(EmpresaEntity empresa)
        {
            using (var rep = new RepositoryBase<EmpresaEntity>())
            {
                return empresa = rep.Insert(empresa);
            }
        }

        public void Alterar(EmpresaEntity empresa)
        {
            using (var rep = new RepositoryBase<EmpresaEntity>())
            {
                rep.Update(empresa);
            }
        }

        public bool VeficaDuplicidadeCnpjCpf(string cnpjcpf)
        {
            bool retorno = false;
            Expression<Func<EmpresaEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo && a.CNPJ.Trim() == cnpjcpf.Trim());

            using (var rep = new RepositoryBase<EmpresaEntity>())
            {
               var empresa = rep.Select(expressionFiltro).FirstOrDefault();
               if ( empresa != null)
               {
                    retorno = true;
               }
            }
            return retorno;
        }
    }
}
