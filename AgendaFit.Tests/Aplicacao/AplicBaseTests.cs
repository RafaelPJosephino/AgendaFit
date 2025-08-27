using Aplicacao.Base;
using Dominio.Cadastros.Alunos;
using Moq;
using Repositorio.Base;
using Xunit;

namespace AgendaFit.Tests.Aplicacao
{
    public class AplicBaseTests
    {
        private class AplicBaseFake : AplicBase<Aluno>
        {
            public AplicBaseFake(IRepBase<Aluno> repositorio) : base(repositorio) { }
        }

        [Fact]
        public void Inserir_DeveChamarRepositorioESalvar()
        {
            var repoMock = new Mock<IRepBase<Aluno>>();
            var aplicacao = new AplicBaseFake(repoMock.Object);
            var aluno = new Aluno { Nome = "Maria" };

            aplicacao.Inserir(aluno);

            repoMock.Verify(r => r.Inserir(aluno), Times.Once);
            repoMock.Verify(r => r.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Alterar_DeveChamarRepositorioESalvar()
        {
            var repoMock = new Mock<IRepBase<Aluno>>();
            var aplicacao = new AplicBaseFake(repoMock.Object);
            var aluno = new Aluno { Nome = "Maria" };

            aplicacao.Alterar(1, aluno);

            repoMock.Verify(r => r.Alterar(1, aluno), Times.Once);
            repoMock.Verify(r => r.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Remover_DeveChamarRepositorioESalvar()
        {
            var repoMock = new Mock<IRepBase<Aluno>>();
            var aplicacao = new AplicBaseFake(repoMock.Object);

            aplicacao.Remover(1);

            repoMock.Verify(r => r.Remover(1), Times.Once);
            repoMock.Verify(r => r.SaveChanges(), Times.Once);
        }
    }
}
