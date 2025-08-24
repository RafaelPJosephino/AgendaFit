using Dominio.Agendamentos;
using Dominio.Cadastros.Alunos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Cadastros.Alunos
{
    public class AlunoConfig : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("agendafit_aluno");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id_aluno")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(x => x.TipoPlano)
                .HasColumnName("tipo_plano")
                .IsRequired();
        }
    }
}
