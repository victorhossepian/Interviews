using CorridaKart.Dados;
using CorridaKart.Entidade;
using CorridaKart.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorridaKart.Negocio
{
    public class TratarCorrida
    {
        public CorridaKart.Entidade.Corrida DadosCorrida = new CorridaKart.Entidade.Corrida();

        public TratarCorrida(Arquivo arquivo)
        {
            PopularObjetosCorrida(arquivo);
        }

        public List<ResultadoCorridaPiloto> ObterEstatisticasPilotosCorrida()
        {
            List<ResultadoCorridaPiloto> resultado = new List<ResultadoCorridaPiloto>();
            EstatisticasPilotoCorrida estatisticaPilotoCorrida = new EstatisticasPilotoCorrida(DadosCorrida);

            int i = 1;

            foreach (Piloto piloto in DadosCorrida.Piloto)            
                resultado.Add(estatisticaPilotoCorrida.ObterEstatisticas(piloto.CodigoPiloto));            

            resultado.OrderBy(r => r.TempoTotalProva).ToList();

            foreach (var v in resultado)
            {
                v.PosicaoChegada = i;

                i += 1;
            }

            return resultado;
        }

        public List<ResultadoCorrida> ObterEstatisticasCorrida(List<ResultadoCorridaPiloto> listaResultadoPilotosCorrida)
        {
            EstatisticasCorrida estatisticaCorrida = new EstatisticasCorrida(listaResultadoPilotosCorrida);
            return estatisticaCorrida.ObterEstatisticas();
        }

        private void PopularObjetosCorrida(Arquivo arquivo)
        {
            List<String[]> linhasArquivo = arquivo.ObterLinhas();

            foreach (string[] campos in linhasArquivo)
                DadosCorrida.Volta.Add(ObterVolta(campos));

            DadosCorrida.Piloto = ObterListaPilotos(DadosCorrida.Volta);
        }

        private Volta ObterVolta(string[] campos)
        {
            Volta volta         = new Volta();
            volta.Hora          = Convert.ToDateTime(campos[(int) LayoutArquivo.Hora]);
            volta.NumeroVolta   = Convert.ToInt32(campos[(int) LayoutArquivo.Numero]);
            volta.TempoVolta    = TratarTempoVolta(campos[(int) LayoutArquivo.TempoVolta]);
            volta.Velocidade    = Convert.ToDecimal(campos[(int)LayoutArquivo.Velocidade]);
            volta.CodigoPiloto  = Convert.ToInt32(campos[(int) LayoutArquivo.CodigoPiloto]);
            volta.NomePiloto    = campos[(int) LayoutArquivo.NomePiloto];
            return volta;
        }

        private TimeSpan TratarTempoVolta(String campo)
        {
            return Conversao.StringTimeSpan(campo);
        }

        private List<Piloto> ObterListaPilotos(List<Volta> voltas)
        {
            var pilotos = DadosCorrida.Volta.ConvertAll(new Converter<Volta, Piloto>(ConverterVoltaPiloto));
            return pilotos.GroupBy(r => r.CodigoPiloto)
                          .Select(g => g.First())
                          .ToList();
        }

        private Piloto ConverterVoltaPiloto(Volta volta)
        {
            return new Piloto() { CodigoPiloto = volta.CodigoPiloto, NomePiloto = volta.NomePiloto };
        }
    }
}
