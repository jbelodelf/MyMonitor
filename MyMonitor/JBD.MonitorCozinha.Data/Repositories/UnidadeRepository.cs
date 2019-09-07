using Data.Repositories.Base;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Enuns;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class UnidadeRepository : IUnidadeRepository
    {
        //Delete Unidade
        public void Deletar(int Id)
        {
            Expression<Func<UnidadeEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo && a.IdUnidade == (Int64)Id);

            using (var rep = new RepositoryBase<UnidadeEntity>())
            {
                UnidadeEntity unidade = rep.Select(expressionFiltro).FirstOrDefault();
                if (unidade != null)
                {
                    rep.Delete(unidade);
                }
            }
        }

        //List Unidades
        public List<UnidadeEntity> ListarUnidades()
        {
            List<UnidadeEntity> ListaUnidades = new List<UnidadeEntity>();
            string[] includes = new string[] { "Pessoas" };
            Expression<Func<UnidadeEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo);

            using (var rep = new RepositoryBase<UnidadeEntity>())
            {
                ListaUnidades = rep.Select(expressionFiltro, includes).ToList();
            }
            return ListaUnidades;
        }

        //List Unidades por empresa
        public List<UnidadeEntity> ListarUnidadesByEmpresa(int IdEmpresa)
        {
            List<UnidadeEntity> ListaUnidades = new List<UnidadeEntity>();
            string[] includes = new string[] { "Pessoas" };
            Expression<Func<UnidadeEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo && a.IdEmpresa == IdEmpresa);

            using (var rep = new RepositoryBase<UnidadeEntity>())
            {
                ListaUnidades = rep.Select(expressionFiltro, includes).ToList();
            }
            return ListaUnidades;
        }

        //Get Unidades By Id
        public UnidadeEntity ObterUnidadeById(int Id)
        {
            UnidadeEntity unidade = new UnidadeEntity();
            string[] includes = new string[] { "Pessoas" };
            Expression<Func<UnidadeEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo && a.IdUnidade == (Int64)Id);

            using (var rep = new RepositoryBase<UnidadeEntity>())
            {
                unidade = rep.Select(expressionFiltro, includes).FirstOrDefault();
            }
            return unidade;
        }

        public UnidadeEntity Salvar(UnidadeEntity unidade)
        {
            using (var rep = new RepositoryBase<UnidadeEntity>())
            {
                if (unidade.IdUnidade == 0)
                {
                    unidade.DataCadastro = DateTime.Now;
                    unidade = rep.Insert(unidade);
                }
                else
                {
                    rep.Update(unidade);
                    unidade = null;
                }
            }
            return unidade;
        }
    }
}
