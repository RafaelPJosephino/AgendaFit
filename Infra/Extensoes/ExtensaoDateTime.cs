using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Extensoes
{
    public static class ExtensaoDateTime
    {
        public static DateTime PrimeiroDiaDoMes(this DateTime data)
        {
            return new DateTime(data.Year, data.Month, 1);
        }

        public static DateTime UltimoDiaDoMes(this DateTime data)
        {
            return new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
        }

    }
}
