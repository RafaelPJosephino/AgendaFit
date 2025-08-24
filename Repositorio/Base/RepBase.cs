using Dominio.Base;
using Repositorio.Contexto;

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

        public TEntidade RecuperarPorIdObrigatorio(int id)
        {

            var obj = Entidades.Set<TEntidade>().Find(id) ??
                throw new Exception($"{typeof(TEntidade).Name} não encontrado");

            return obj;
        }
        public virtual void Inserir(TEntidade obj)
        {
            Entidades.Set<TEntidade>().Add(obj);
        }

        public virtual void Alterar(int id, TEntidade obj)
        {
            TEntidade? objExistente = RecuperarPorId(id);
            if (objExistente != null)
            {
                obj.Id = objExistente.Id;
                Entidades.Entry(objExistente).CurrentValues.SetValues(obj);
            }
            else
            {
                throw new Exception($"{typeof(TEntidade).Name} não encontrado");
            }
        }

        public virtual void Remover(int id)
        {
            TEntidade? obj = RecuperarPorId(id);
            if (obj != null) Entidades.Set<TEntidade>().Remove(obj);
        }
        public virtual void RemoverLista(List<TEntidade> objs)
        {
            if (objs != null && objs.Count != 0) Entidades.Set<TEntidade>().RemoveRange(objs);
        }
        public virtual void SaveChanges()
        {
            Entidades.SaveChanges();
        }
    }
}
