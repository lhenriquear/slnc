using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulaJsonECsv
{
   public class BuscaICAO
    {
        public static List<string> ObtemListas()
        {
            var importaExporta = new ImportaExporta();
            var dados = importaExporta.ImportarICAO();

            var b = dados.Select(x => new { Destino = x.ICAOAeródromoDestino, Origem = x.ICAOAeródromoOrigem} ).Distinct().ToList();


            var distinctDestino = dados.Select(x => new { Destino = x.ICAOAeródromoDestino }).Distinct().ToList();
            var distinctOrigem = dados.Select(x => new { Origem = x.ICAOAeródromoOrigem }).Distinct().ToList();

            List<string> distintasDestino = dados.Select(x =>  x.ICAOAeródromoDestino ).Distinct().ToList();
            List<string> distintasOrigem = dados.Select(x => x.ICAOAeródromoOrigem).Distinct().ToList();

            List<string> distinct = distintasDestino.Concat(distintasOrigem).Distinct().ToList();

            return distinct;

            Console.WriteLine(distinct);

            //var destinos = distinctDestino.Except(distinctOrigem).ToList();
            //var origens = distinctOrigem.Where(i => !distinctDestino.Contains(i.Origem)).ToList();

            Console.WriteLine(dados[0].ICAOAeródromoDestino);
        }

        internal class ICAO
        {
        }
    }
}
