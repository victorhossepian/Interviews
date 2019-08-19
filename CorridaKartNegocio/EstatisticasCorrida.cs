using CorridaKart.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorridaKart.Negocio
{
    public class EstatisticasCorrida
    {
        List<ResultadoCorridaPiloto> _resultadoCorridaPiloto;

        public EstatisticasCorrida(List<ResultadoCorridaPiloto> resultadoCorridaPiloto)
        {
            _resultadoCorridaPiloto = resultadoCorridaPiloto;
        }

        public List<ResultadoCorrida> ObterEstatisticas()
        {
            List<ResultadoCorrida> resultado = new List<ResultadoCorrida>();
            ResultadoCorrida resultadoCorrida = new ResultadoCorrida();
            var melhorVoltaProva = _resultadoCorridaPiloto.OrderBy(r => r.MelhorVolta).FirstOrDefault();
            resultadoCorrida.CodigoPiloto = melhorVoltaProva.CodigoPiloto;
            resultadoCorrida.NomePiloto = melhorVoltaProva.NomePiloto;
            resultadoCorrida.MelhorVoltaProva = melhorVoltaProva.MelhorVolta;
            resultado.Add(resultadoCorrida);
            return resultado;
        }
    }
}
