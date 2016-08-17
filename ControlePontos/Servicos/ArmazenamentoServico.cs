using System.IO;
using System.Reflection;

namespace ControlePontos.Servicos
{
    public interface IArmazenamentoServico
    {
        string DiretorioArmazenamento { get; }

        string Carregar(string nome);
        void Salvar(string nome, string json);
    }

    public class ArmazenamentoServico : IArmazenamentoServico
    {
        public string DiretorioArmazenamento { get { return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName; } }

        public string Carregar(string nome)
        {
            var arquivo = Path.Combine(this.DiretorioArmazenamento, this.NomeArquivo(nome));
            if (File.Exists(arquivo))
            {
                return File.ReadAllText(arquivo);
            }
            else
                return null;
        }

        public void Salvar(string nome, string json)
        {
            File.WriteAllText(Path.Combine(this.DiretorioArmazenamento, this.NomeArquivo(nome)), json);
        }

        private string NomeArquivo(string nome)
        {
            return nome + ".json";
        }
    }
}