using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManipulaJsonECsv
{
    static class Program
    {
        static async Task Main()
        {
            var dados = BuscaICAO.ObtemListas();
            List<Aeroporto> respostas = new();
            foreach (var item in dados)
            {
                respostas.Add(await LoopIcao.GetICAOAsync(item));
            }

            var importaExporta = new ImportaExporta();
            importaExporta.ExportarICAO(respostas);
        }



    }
}

