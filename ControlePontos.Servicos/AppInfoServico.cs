using ControlePontos.Dominio.Model;
using ControlePontos.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ControlePontos.Servicos
{
    public class AppInfoServico : IAppInfoServico
    {
        public IEnumerable<ChangelogInfo> CarregarChangelog(Stream streamChangelog)
        {
            var changelog = new List<ChangelogInfo>();

            using (var reader = new StreamReader(streamChangelog))
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
            return FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).FileDescription;
        }

        public Versao ObterVersaoAtual()
        {
            return new Versao(FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).FileVersion);
        }
    }
}