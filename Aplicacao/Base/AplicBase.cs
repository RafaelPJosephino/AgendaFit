using Dominio.Base;
using Repositorio.Base;

namespace Aplicacao.Base
{
    public class AplicBase<TEntidade> : IAplicBase<TEntidade> where TEntidade : Identificador
    {
        protected readonly IRepBase<TEntidade> _repositorio;

        protected AplicBase(IRepBase<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public TEntidade? RecuperarPorId(int id)
        {
            return _repositorio.RecuperarPorId(id);
        }

        public virtual void Alterar(int id, TEntidade obj)
        {
            _repositorio.Alterar(id, obj);
        }
        public virtual void Inserir(TEntidade obj)
        {
            _repositorio.Inserir(obj);
        }
        public virtual void Remover(int id)
        {
            _repositorio.Remover(id);
        }
        public void SaveChanges()
        {
            _repositorio.SaveChanges();
        }
    }
}
