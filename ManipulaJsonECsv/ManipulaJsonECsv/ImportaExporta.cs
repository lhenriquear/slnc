using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft;

namespace ManipulaJsonECsv
{
    class ImportaExporta
        
    {
        //public string dirBDO = @"C:\\Users\\luiz.hrodrigues.MRVBH\\Desktop\\eleflow\\data_engineer_test\\VRA\\";
        public string dirBDO = @"C:\\Users\\jwisl\\source\\repos\\slnc\\db\\data_engineer_test\\VRA\\";
        public string arquivoVar = "VRA_20211.json";
        //Exportar Base de Dados 
        public void ExportarICAO(List<Aeroporto> vra)
        {
            using var streamWriter = new System.IO.StreamWriter(Path.Combine(dirBDO, "output.json"));
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vra);
            streamWriter.Write(json);
        }

        // Importar Base de Dados
        public List<VRA> ImportarICAO()
        {
            if (System.IO.File.Exists(Path.Combine(dirBDO, arquivoVar)))
            {
                var json = System.IO.File.ReadAllText(Path.Combine(dirBDO, arquivoVar));
                var correcao = "["+json+"]";
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<VRA>>(correcao);
            }
            else
            {
                return null;
            }
        }
    }
}
