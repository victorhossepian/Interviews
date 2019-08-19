using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorridaKart.Entidade
{
    public class ResultadoCorridaPiloto : Piloto
    {
        public int PosicaoChegada { get; set; }
        public int QtdVoltasCompletas { get; set; }
        public TimeSpan TempoTotalProva { get; set; }
        public TimeSpan MelhorVolta { get; set; }
        public decimal VelocidadeMedia { get; set; }
        public TimeSpan TempoPosVencedor { get; set; }
    }
}
