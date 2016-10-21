using ControlePontos.Dominio.Model;
using System.Collections.Generic;

namespace ControlePontos.Dominio.Servico
{
    public interface IAppInfoServico
    {
        IEnumerable<ChangelogInfo> CarregarChangelog();
        Versao ObterVersaoAtual();
        string ObterNomeApp();
    }
}