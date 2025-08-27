using System;
using Dominio.Cadastros.Alunos;
using Microsoft.EntityFrameworkCore;
using Repositorio.Base;
using Repositorio.Contexto;
using Xunit;

namespace AgendaFit.Tests.Repositorio
{
    public class RepBaseTests
    {
        private RepBase<Aluno> CriarRepositorio(string nomeDb)
        {
            var options = new DbContextOptionsBuilder<ContextoBanco>()
                .UseInMemoryDatabase(nomeDb)
                .Options;
            var contexto = new ContextoBanco(options);
            return new RepBase<Aluno>(contexto);
        }

        [Fact]
        public void RecuperarPorIdObrigatorio_QuandoExiste_RetornaEntidade()
        {
            var repositorio = CriarRepositorio(nameof(RecuperarPorIdObrigatorio_QuandoExiste_RetornaEntidade));
            var aluno = new Aluno { Nome = "Joao" };
            repositorio.Inserir(aluno);
            repositorio.SaveChanges();

            var resultado = repositorio.RecuperarPorIdObrigatorio(aluno.Id);

            Assert.Equal("Joao", resultado.Nome);
        }

        [Fact]
        public void RecuperarPorIdObrigatorio_QuandoNaoExiste_DisparaExcecao()
        {
            var repositorio = CriarRepositorio(nameof(RecuperarPorIdObrigatorio_QuandoNaoExiste_DisparaExcecao));

            Assert.Throws<Exception>(() => repositorio.RecuperarPorIdObrigatorio(999));
        }

        [Fact]
        public void Alterar_AtualizaValores()
        {
            var repositorio = CriarRepositorio(nameof(Alterar_AtualizaValores));
            var aluno = new Aluno { Nome = "Antigo" };
            repositorio.Inserir(aluno);
            repositorio.SaveChanges();

            var atualizado = new Aluno { Nome = "Novo" };
            repositorio.Alterar(aluno.Id, atualizado);
            repositorio.SaveChanges();

            var recuperado = repositorio.RecuperarPorId(aluno.Id);
            Assert.NotNull(recuperado);
            Assert.Equal("Novo", recuperado!.Nome);
        }
    }
}
