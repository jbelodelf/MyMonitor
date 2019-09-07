using Data.Repositories.Base;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Enuns;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        //Delete Telefone
        public void Deletar(int Id)
        {
            Expression<Func<TelefoneEntity, bool>> expressionFiltro = (a => a.IdTelefone == Id);

            using (var rep = new RepositoryBase<TelefoneEntity>())
            {
                TelefoneEntity telefone = rep.Select(expressionFiltro).FirstOrDefault();
                if (telefone != null)
                {
                    rep.Delete(telefone);
                }
            }
        }

        //List Telefones
        public List<TelefoneEntity> ListarTelefones()
        {
            List<TelefoneEntity> ListaTelefones = new List<TelefoneEntity>();
            Expression<Func<TelefoneEntity, bool>> expressionFiltro = (a => a.IdTelefone == (int)StatusEnum.Ativo);

            using (var rep = new RepositoryBase<TelefoneEntity>())
            {
                ListaTelefones = rep.Select(expressionFiltro).ToList();
            }

            return ListaTelefones;
        }

        //Get Telefone By Id
        public TelefoneEntity ObterTelefoneById(int Id)
        {
            TelefoneEntity telefone = new TelefoneEntity();
            Expression<Func<TelefoneEntity, bool>> expressionFiltro = (a => a.IdTelefone == Id);

            using (var rep = new RepositoryBase<TelefoneEntity>())
            {
                telefone = rep.Select(expressionFiltro).FirstOrDefault();
            }

            return telefone;
        }

        public void Salvar(TelefoneEntity telefone)
        {
            using (var rep = new RepositoryBase<TelefoneEntity>())
            {
                if (telefone.IdTelefone == 0)
                {
                    rep.Insert(telefone);
                }
                else
                {
                    rep.Update(telefone);
                }
            }
        }
    }
}
