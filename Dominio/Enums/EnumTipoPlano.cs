using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Enums
{
    public enum EnumTipoPlano
    {
        [Description("Mensal")]
        Mensal = 1,
        [Description("Trimestral")]
        Trimestral = 2,
        [Description("Anual")]
        Anual = 3,
    }
}
