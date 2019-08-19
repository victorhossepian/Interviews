using CorridaKart.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorridaKart
{
    public class EstatisticasPilotoCorrida
    {
        private CorridaKart.Entidade.Corrida _corridaRealizada;
        private DateTime _tempoVencedorCorrida;

        public EstatisticasPilotoCorrida(CorridaKart.Entidade.Corrida corridaRealizada)
        {
            _corridaRealizada = corridaRealizada;

            int ultimaVolta = corridaRealizada.Volta.Max(r => r.NumeroVolta);
            _tempoVencedorCorrida = corridaRealizada.Volta.Where(r => r.NumeroVolta == ultimaVolta).Min(r => r.Hora);
        }

        public ResultadoCorridaPiloto ObterEstatisticas(Int32 codigoPiloto)
        {
            ResultadoCorridaPiloto resultado = new ResultadoCorridaPiloto();

            resultado.CodigoPiloto = codigoPiloto;
            resultado.NomePiloto = _corridaRealizada.Volta.Where(r => r.CodigoPiloto == codigoPiloto).Select(c => c.NomePiloto).First();
            resultado.MelhorVolta = _corridaRealizada.Volta.Where(r => r.CodigoPiloto == codigoPiloto).Select(c => c.TempoVolta).Min();
            resultado.TempoTotalProva = _corridaRealizada.Volta.Where(r => r.CodigoPiloto == codigoPiloto).Select(c => c.TempoVolta).Aggregate(TimeSpan.Zero, (subTotal, t) => subTotal.Add(t));
            resultado.VelocidadeMedia = (_corridaRealizada.Volta.Where(r => r.CodigoPiloto == codigoPiloto).Select(c => c.Velocidade)).Average();
            resultado.QtdVoltasCompletas = _corridaRealizada.Volta.Where(r => r.CodigoPiloto == codigoPiloto).Count();            
            resultado.TempoPosVencedor = _corridaRealizada.Volta.Where(r => r.NumeroVolta == resultado.QtdVoltasCompletas && r.CodigoPiloto == resultado.CodigoPiloto).Min(r => r.Hora).Subtract(_tempoVencedorCorrida);

            return resultado;
        }
    }
}
