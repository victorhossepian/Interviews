using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorridaKart.Entidade
{
    public class Volta : Piloto
    {
        public int NumeroVolta { get; set; }
        public TimeSpan TempoVolta { get; set; }
        public decimal Velocidade { get; set; }
        public DateTime Hora { get; set; }
    }
}
