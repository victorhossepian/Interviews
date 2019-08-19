using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CorridaKart.Dados
{
    public class Arquivo : IArquivo
    {
        private String _caminhoArquivo;

        public Arquivo(String caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
        }

        public List<String[]> ObterLinhas()
        {
            List<String[]> linhasTratadas = new List<String[]>();
            string[] linhasArquivo = System.IO.File.ReadAllLines(_caminhoArquivo);

            foreach (string linha in linhasArquivo)
            {
                const string reduzir = @"[ ]{2,}";
                var linhaTratada = Regex.Replace(linha.Replace("\t", " "), reduzir, " ");
                linhasTratadas.Add(linhaTratada.Split((" ").ToCharArray()));
            }

            return linhasTratadas;
        }
    }
}
