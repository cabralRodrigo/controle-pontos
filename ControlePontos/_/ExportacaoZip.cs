using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace ControlePontos.Exportacao
{
    internal class ExportacaoZip
    {
        public ExportacaoResultado RealizarBackup(string diretorioData, string caminhoZip)
        {
            var backupkey = DateTime.Now.ToString("yyyy.MM.dd hh.mm.ss.ffff");
            var dirTemp = Path.Combine(Path.GetTempPath(), "ControlePontos", backupkey);

            if (!Directory.Exists(dirTemp))
                Directory.CreateDirectory(dirTemp);

            if (File.Exists(caminhoZip))
                File.Delete(caminhoZip);

            var datas = new DataFileScanner(diretorioData).FindAll().OrderBy(s => s.Ano).ThenBy(s => s.Mes);

            using (var zip = ZipFile.Open(caminhoZip, ZipArchiveMode.Create))
                foreach (var data in datas)
                    zip.CreateEntryFromFile(Path.Combine(data.Diretorio, data.Nome), data.Nome, CompressionLevel.Optimal);

            if (datas.Count() > 0)
            {
                var ultimo = datas.Last();
                var primeiro = datas.First();

                return new ExportacaoResultado
                {
                    AnoFim = ultimo.Ano,
                    AnoInicio = primeiro.Ano,
                    ArquivoZip = caminhoZip,
                    MesFim = ultimo.Mes,
                    MesInicio = primeiro.Mes,
                    QuantidadeArquivos = datas.Count()
                };
            }
            else
                return new ExportacaoResultado
                {
                    ArquivoZip = caminhoZip,
                    QuantidadeArquivos = 0
                };
        }
    }
}