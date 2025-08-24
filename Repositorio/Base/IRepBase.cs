

namespace Repositorio.Base
{
    public interface IRepBase<TEntidade>
    {
        void Alterar(int id , TEntidade obj);
        void Inserir(TEntidade obj);
        IQueryable<TEntidade> Recuperar();
        TEntidade? RecuperarPorId(int id);
        TEntidade RecuperarPorIdObrigatorio(int id);
        void Remover(int obj);
        void RemoverLista(List<TEntidade> objs);
        void SaveChanges();
    }
}