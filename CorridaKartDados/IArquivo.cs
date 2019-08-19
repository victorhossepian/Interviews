using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorridaKart.Dados
{
    interface IArquivo
    {
        List<String[]> ObterLinhas();
    }
}
