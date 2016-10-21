using ControlePontos.Dominio.Model;
using ControlePontos.Dominio.Servico;
using ControlePontos.Util.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ControlePontos.Forms
{
    internal partial class Changelog : BaseForm
    {
        private readonly IAppInfoServico appInfoServico;

        public Changelog(IAppInfoServico appInfoServico)
        {
            this.InitializeComponent();
            this.appInfoServico = appInfoServico;
        }

        private void CarregarChangelog(IEnumerable<ChangelogInfo> changelog)
        {
            this.TreeView_Changelog.Nodes.Clear();

            foreach (var log in changelog)
            {
                var node = new TreeNode($"{log.Versao} - {log.Data.ToString("dd/MM/yyyy")}");
                foreach (var alteracao in log.Mudancas.OrderBy(w => w.Tipo).ThenBy(w => w.Descricao))
                    node.Nodes.Add(new TreeNode { Text = alteracao.Descricao, ForeColor = this.ObterCorParaTipoMudanca(alteracao.Tipo) });

                this.TreeView_Changelog.Nodes.Add(node);
            }

            this.TreeView_Changelog.ExpandAll();
            this.TreeView_Changelog.Nodes[0].EnsureVisible();
        }

        private void CarregarLegenda()
        {
            foreach (var tipo in Enum.GetValues(typeof(TipoMudanca)).Cast<TipoMudanca>().OrderBy(w => w))
                this.GroupBox_Legenda_Layout.Controls.Add(new Label
                {
                    Text = tipo.ObterDescricao(),
                    ForeColor = this.ObterCorParaTipoMudanca(tipo),
                    AutoSize = true
                });
        }

        private void CarregarEstatisticas(IEnumerable<ChangelogInfo> changelog)
        {
            var mapa = new Dictionary<TipoMudanca, int>();

            foreach (var log in changelog)
                foreach (var mudanca in log.Mudancas)
                {
                    if (!mapa.ContainsKey(mudanca.Tipo))
                        mapa.Add(mudanca.Tipo, 0);

                    mapa[mudanca.Tipo]++;
                }

            var total = mapa.Sum(s => s.Value);

            foreach (var tipo in mapa.OrderBy(w => w.Key))
            {
                this.GroupBox_Estatisticas_Layout.Controls.AddRange(new[] {
                    new Label { Text = tipo.Key.ObterDescricao(), AutoSize = true },
                    new Label { Text = $"   Ocorrências: {tipo.Value}", AutoSize = true },
                    new Label { Text = $"   Porcentagem: {((float)tipo.Value / total).ToString("0.00%")}", AutoSize = true },
                    new Label()
                });
            }

            this.GroupBox_Estatisticas_Layout.Controls.AddRange(new[] {
                new Label { AutoSize = true, Text = "Total" },
                new Label { AutoSize = true, Text = $"   Ocorrências: {total}"}
            });
        }

        private Color ObterCorParaTipoMudanca(TipoMudanca tipo)
        {
            switch (tipo)
            {
                case TipoMudanca.CorrecaoBug:
                    return Color.Red;
                case TipoMudanca.AdicaoFuncionalidade:
                    return Color.Green;
                case TipoMudanca.MudancaFuncionalidade:
                    return Color.Orange;
                case TipoMudanca.MelhoramentoCodigo:
                    return Color.Gray;
                default:
                    return Color.Black;
            }
        }

        #region Eventos

        private void Changelog_Load(object sender, EventArgs e)
        {
            var changelog = this.appInfoServico.CarregarChangelog();

            this.CarregarLegenda();
            this.CarregarEstatisticas(changelog);
            this.CarregarChangelog(changelog);
        }

        #endregion
    }
}