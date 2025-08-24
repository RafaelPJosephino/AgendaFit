using Dominio.Agendamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Agendamentos.Agendamentos
{
    public class AgendamentoConfig : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("agendafit_agendamento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id_agendamento")
                .IsRequired();

            builder.Property(x => x.CodigoAula)
                .HasColumnName("id_aula")
                .IsRequired();

            builder.Property(x => x.CodigoAluno)
                .HasColumnName("id_aluno")
                .IsRequired();

            builder.HasOne(x => x.Aula)
                .WithMany()
                .HasForeignKey(x => x.CodigoAula)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Aluno)
                .WithMany()
                .HasForeignKey(x => x.CodigoAluno)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}