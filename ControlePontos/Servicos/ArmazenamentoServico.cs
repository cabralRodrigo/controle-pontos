using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ControlePontos.Servicos
{
    public interface IArmazenamentoServico
    {
        string Carregar(string nome, string diretorio = null);

        IEnumerable<string> BuscarArquivos(Regex regex);

        void Salvar(string nome, string json, string diretorio = null);
    }

    public class ArmazenamentoServico : IArmazenamentoServico
    {
        private string Extensao { get { return ".json"; } }
        private string DiretorioArmazenamento { get { return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName; } }

        public IEnumerable<string> BuscarArquivos(Regex regex)
        {
            foreach (var arquivo in Directory.GetFiles(this.DiretorioArmazenamento, "*" + Extensao))
            {
                if (regex.IsMatch(new FileInfo(arquivo).Name))
                    yield return arquivo;
            }
        }

        public string Carregar(string nome, string diretorio = null)
        {
            var diretorioAtual = diretorio == null ? this.DiretorioArmazenamento : diretorio;

            var arquivo = Path.Combine(diretorioAtual, this.NomeArquivo(nome));
            if (File.Exists(arquivo))
            {
                return File.ReadAllText(arquivo);
            }
            else
                return null;
        }

        public void Salvar(string nome, string json, string diretorio = null)
        {
            var diretorioAtual = diretorio == null ? this.DiretorioArmazenamento : diretorio;

            File.WriteAllText(Path.Combine(diretorioAtual, this.NomeArquivo(nome)), json);
        }

        private string NomeArquivo(string nome)
        {
            return nome + this.Extensao;
        }
    }
}