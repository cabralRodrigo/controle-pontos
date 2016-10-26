using ControlePontos.Dominio.Servico;
using ControlePontos.Misc;
using ControlePontos.Util.Extensions;
using System;
using System.Linq;

namespace ControlePontos.Forms
{
    internal partial class Sobre : BaseForm
    {
        private readonly IAppInfoServico appInfoServico;

        public Sobre(IAppInfoServico appInfoServico)
        {
            this.InitializeComponent();
            this.appInfoServico = appInfoServico;
        }

        private void Sobre_Load(object sender, EventArgs e)
        {
            var versao = this.appInfoServico.ObterVersaoAtual();
            var changelog = this.appInfoServico.CarregarChangelog(Resources.Changelog());

            var logAtual = changelog.FirstOrDefault(w => w.Versao == versao);
            if (logAtual == null)
                logAtual = changelog.OrderBy(w => w.Versao).Last();

            this.labelProductName.Text = this.appInfoServico.ObterNomeApp();
            this.labelVersion.Text = $"Versão {versao}";

            var mudancas = logAtual.Mudancas.Select(s => $"{s.Tipo.ObterDescricao()}: {s.Descricao}").ToArray();
            var descricao = string.Join(Environment.NewLine + Environment.NewLine, mudancas);

            this.textBoxDescription.Text = $"Novidades da versão {logAtual.Versao}:{Environment.NewLine}{descricao}";
        }
    }
}