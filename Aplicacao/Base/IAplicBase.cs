namespace Aplicacao.Base
{
    public interface IAplicBase<TEntidade>
    {
        void Alterar(int id ,TEntidade obj);
        void Inserir(TEntidade obj);
        TEntidade? RecuperarPorId(int id);
        void Remover(int id);
        void SaveChanges();
    }
}