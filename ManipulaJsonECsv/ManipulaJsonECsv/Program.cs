using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ManipulaJsonECsv
{
    static class Program
    {     
         static void Main()
        {
            var dados = BuscaICAO.ObtemListas();
            Task<string> resposta = new ();
            foreach (var item in dados)
            {

               resposta.Add( LoopIcao.GetICAOAsync(item));
            }

        }

        

    }
}

