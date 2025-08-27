using System;
using Infra.Extensoes;
using Xunit;

namespace AgendaFit.Tests.Infra
{
    public class ExtensaoDateTimeTests
    {
        [Fact]
        public void PrimeiroDiaDoMes_RetornaPrimeiroDia()
        {
            var data = new DateTime(2024, 3, 15);
            var resultado = data.PrimeiroDiaDoMes();

            Assert.Equal(new DateTime(2024, 3, 1), resultado);
        }

        [Fact]
        public void UltimoDiaDoMes_RetornaUltimoDia()
        {
            var data = new DateTime(2024, 2, 15);
            var resultado = data.UltimoDiaDoMes();

            Assert.Equal(new DateTime(2024, 2, 29), resultado);
        }
    }
}
