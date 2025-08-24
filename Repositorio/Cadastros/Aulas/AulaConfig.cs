using Dominio.Agendamentos;
using Dominio.Cadastros.Alunos;
using Dominio.Cadastros.Aulas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Cadastros.Aulas
{
    public class AulaConfig : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
        {
            builder.ToTable("agendafit_aula");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id_aula")
                .IsRequired();

            builder.Property(x => x.QuantidadeParticipante)
                .HasColumnName("quantidade_participante")
                .IsRequired();

            builder.Property(x => x.TipoAula)
                .HasColumnName("tipo_aula")
                .IsRequired();

            builder.Property(x => x.DataHora)
                .HasColumnName("data_hora")
                .IsRequired();
            
        }
    }
}
