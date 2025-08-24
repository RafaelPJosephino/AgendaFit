using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Cadastros.Aulas.Dtos
{
    public class EditarAulaDto
    {
        public DateTime DataHora { get; set; }
        public EnumTipoAula TipoAula { get; set; }
        public int QuantidadeParticipante { get; set; }
    }
}
