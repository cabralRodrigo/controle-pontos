using ControlePontos.Dominio.Model;
using System.Text.RegularExpressions;

namespace ControlePontos.Dominio.Servico
{
    public interface IExportar
    {
        Regex RegexArquivos();
    }

    public interface IExportacaoServico
    {
        Resultado<ExportacaoResulado> ExportarDados(string diretorio, string nomeArquivo);
    }
}