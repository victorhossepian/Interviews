using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorridaKart.Entidade
{
    public class Corrida
    {
        public List<Piloto> Piloto { get; set; }
        public List<Volta> Volta { get; set; }

        public Corrida()
        {
            Piloto = new List<Piloto>();
            Volta = new List<Volta>();
        }
    }
}
