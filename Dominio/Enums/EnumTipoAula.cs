using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Enums
{
    public enum EnumTipoAula
    {
        [Description("Cross")]
        Cross = 1,
        [Description("Funcional")]
        Funcional = 2,
        [Description("Pilates")]
        Pilates = 3,
    }
}
