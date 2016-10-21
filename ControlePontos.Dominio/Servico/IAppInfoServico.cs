using ControlePontos.Dominio.Model;
using System.Collections.Generic;
using System.IO;

namespace ControlePontos.Dominio.Servico
{
    public interface IAppInfoServico
    {
        IEnumerable<ChangelogInfo> CarregarChangelog(Stream streamChangelog);
        Versao ObterVersaoAtual();
        string ObterNomeApp();
    }
}