using Dominio.Base;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Base
{
    public class RepBase<TEntidade>(ContextoBanco contexto) : IRepBase<TEntidade> where TEntidade : Identificador
    {
        private readonly ContextoBanco _contexto = contexto;
        private ContextoBanco Entidades
        {
            get
            {
                if (_contexto == null)
                {
                    throw new InvalidOperationException("ContextoBanco não foi inicializado.");
                }
                return _contexto;
            }
        }

        public virtual IQueryable<TEntidade> Recuperar()
        {
            return Entidades.Set<TEntidade>().AsQueryable();
        }

        public TEntidade? RecuperarPorId(int id)
        {
            return Entidades.Set<TEntidade>().Find(id);
        }

        public virtual void Inserir(TEntidade obj)
        {
            Entidades.Set<TEntidade>().Add(obj);
        }

        public virtual void Alterar(int id ,TEntidade obj)
        {
            TEntidade? objExistente = RecuperarPorId(id);
            if (objExistente != null)
            {
                Entidades.Entry(objExistente).CurrentValues.SetValues(obj); 
            }
        }

        public virtual void Remover(int id)
        {
            TEntidade? obj = RecuperarPorId(id);
            if(obj != null) Entidades.Set<TEntidade>().Remove(obj);
        }
        public virtual void SaveChanges()
        {
            Entidades.SaveChanges();
        }
    }
}
