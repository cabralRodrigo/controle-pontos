using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ControlePontos.Exportacao
{
    internal class DataFileScanner
    {
        private static readonly Regex filePattern = new Regex(@"^horarios-(?<ano>[0-9]{4})-(?<mes>[0-9]{1,2})\.json$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private readonly string Diretorio;

        public DataFileScanner(string diretorio)
        {
            this.Diretorio = diretorio;
        }

        public IEnumerable<DataFile> FindAll()
        {
            if (Directory.Exists(this.Diretorio))
            {
                var arquivos = Directory.GetFiles(this.Diretorio, "*.json", SearchOption.TopDirectoryOnly);
                foreach (var arquivo in arquivos)
                {
                    DataFile data;
                    if (this.TryParse(arquivo, out data))
                        yield return data;
                }
            }
        }

        private bool TryParse(string arquivo, out DataFile data)
        {
            data = default(DataFile);

            if (!File.Exists(arquivo))
                return false;

            var info = new FileInfo(arquivo);

            var match = DataFileScanner.filePattern.Match(info.Name);

            if (!match.Groups["ano"].Success || !match.Groups["mes"].Success)
                return false;

            int ano;
            if (!int.TryParse(match.Groups["ano"].Value, out ano))
                return false;

            if (ano < DateTime.MinValue.Year || ano > DateTime.MaxValue.Year)
                return false;

            int mes;
            if (!int.TryParse(match.Groups["mes"].Value, out mes))
                return false;

            if (mes <= 0 || mes >= 13)
                return false;

            data =  new DataFile(info.Directory.FullName, info.Name, ano, mes);
            return true;
        }
    }
}