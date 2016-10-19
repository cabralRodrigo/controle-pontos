using ControlePontos.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ControlePontos.Servicos
{
    internal interface IAppInfoServico
    {
        IEnumerable<ChangelogInfo> CarregarChangelog();
        Versao ObterVersaoAtual();
        string ObterNomeApp();
    }

    internal class AppInfoServico : IAppInfoServico
    {
        public IEnumerable<ChangelogInfo> CarregarChangelog()
        {
            var changelog = new List<ChangelogInfo>();

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ControlePontos.changelog.txt"))
            using (var reader = new StreamReader(stream))
            {
                var atual = new ChangelogInfo { Mudancas = new List<MudancaInfo>() };
                var linha = reader.ReadLine();

                while (linha != null)
                {
                    if (linha == string.Empty)
                    {
                        changelog.Add(atual);
                        atual = new ChangelogInfo { Mudancas = new List<MudancaInfo>() };
                    }
                    else
                    {
                        if (linha[0] == '\t')
                            atual.Mudancas.Add(new MudancaInfo
                            {
                                Descricao = linha.Substring(3),
                                Tipo = this.BuscarTipoMudancaPorChar(linha[1])
                            });

                        else
                        {
                            var partes = linha.Split(' ');
                            var data = partes[0];
                            var versao = partes[1].Remove(partes[1].Length - 1);

                            atual.Data = DateTime.ParseExact(data, "dd/MM/yyyy", null);
                            atual.Versao = new Versao(versao);
                        }
                    }

                    linha = reader.ReadLine();
                }

                changelog.Add(atual);
            }

            return changelog;
        }

        private TipoMudanca BuscarTipoMudancaPorChar(char tipoMudanca)
        {
            switch (tipoMudanca)
            {
                case '+':
                    return TipoMudanca.AdicaoFuncionalidade;
                case '!':
                    return TipoMudanca.CorrecaoBug;
                case '*':
                    return TipoMudanca.MelhoramentoCodigo;
                case '@':
                    return TipoMudanca.MudancaFuncionalidade;
                default:
                    throw new InvalidOperationException($"Código do tipo de mudança inválido: {tipoMudanca}");
            }
        }

        public string ObterNomeApp()
        {
            return Application.ProductName;
        }

        public Versao ObterVersaoAtual()
        {
            return new Versao(Application.ProductVersion);
        }
    }
}