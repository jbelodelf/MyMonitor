using Data.Repositories.Base;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class LembreteSenhaRepository : ILembreteSenhaRepository
    {
        public void Delete(int IdLembreteSenha)
        {
            Expression<Func<LembreteSenhaEntity, bool>> expressionFiltro = (a => a.IdLembreteSenha == IdLembreteSenha);

            using (var rep = new RepositoryBase<LembreteSenhaEntity>())
            {
                LembreteSenhaEntity lembreteSenha = rep.Select(expressionFiltro).FirstOrDefault();
                if (lembreteSenha != null)
                {
                    rep.Delete(lembreteSenha);
                }
            }
        }

        public LembreteSenhaEntity ObterByChave(Guid chave)
        {
            LembreteSenhaEntity lembreteSenha = null;
            Expression<Func<LembreteSenhaEntity, bool>> expressionFiltro = (a => a.Chave == chave && a.ChaveValida);

            using (var rep = new RepositoryBase<LembreteSenhaEntity>())
            {
                lembreteSenha = rep.Select(expressionFiltro).FirstOrDefault();
            }
            return lembreteSenha;
        }

        public void Insert(LembreteSenhaEntity lembreteSenhaEntity)
        {
            using (var rep = new RepositoryBase<LembreteSenhaEntity>())
            {
                rep.Insert(lembreteSenhaEntity);
            }
        }

        public void Update(LembreteSenhaEntity lembreteSenhaEntity)
        {
            using (var rep = new RepositoryBase<LembreteSenhaEntity>())
            {
                rep.Update(lembreteSenhaEntity);
            }
        }
    }
}
