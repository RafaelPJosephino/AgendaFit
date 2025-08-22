
namespace Repositorio.Base
{
    public interface IRepBase<TEntidade>
    {
        void Alterar(int id , TEntidade obj);
        void Inserir(TEntidade obj);
        IQueryable<TEntidade> Recuperar();
        TEntidade? RecuperarPorId(int id);
        void Remover(int obj);
        void SaveChanges();
    }
}