using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ControlePontos.Dominio.Servico
{
    public interface IArmazenamentoServico
    {
        string Carregar(string nome, string diretorio = null);

        IEnumerable<string> BuscarArquivos(Regex regex);

        void Salvar(string nome, string json, string diretorio = null);
    }
}
