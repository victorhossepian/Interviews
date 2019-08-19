using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorridaKart.Util
{
    public static class Conversao
    {
        public static TimeSpan StringTimeSpan(String valor)
        {
            TimeSpan tempoVolta;
            TimeSpan.TryParseExact(valor, @"m\:ss\.fff", null, out tempoVolta);
            return tempoVolta;
        }
    }
}
