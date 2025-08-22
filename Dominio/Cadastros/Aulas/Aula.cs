using Dominio.Base;
using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Cadastros.Aulas
{
    public class Aula: Identificador
    {
        public DateTime DataHora { get; set; }
        public EnumTipoAula TipoAula { get; set; }
        public int QuantidadeParticipante { get; set; }
    }
}
