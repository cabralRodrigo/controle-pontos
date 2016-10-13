using ControlePontos.Servicos;
using ControlePontos.Extensions;
using System.Linq;
using System.Windows.Forms;
using System;

namespace ControlePontos.Forms
{
    partial class Sobre : BaseForm
    {
        private readonly IAppInfoServico appInfoServico;

        public Sobre(IAppInfoServico appInfoServico)
        {
            this.InitializeComponent();
            this.appInfoServico = appInfoServico;
        }

        private void Sobre_Load(object sender, EventArgs e)
        {
            var log = this.appInfoServico.CarregarChangelog().OrderBy(w => w.Versao).Last();

            this.labelProductName.Text = this.appInfoServico.ObterNomeApp();
            this.labelVersion.Text = $"Versão {log.Versao}";

            var mudancas = log.Mudancas.Select(s => $"{s.Tipo.ObterDescricao()}: {s.Descricao}").ToArray();
            var descricao = string.Join(Environment.NewLine + Environment.NewLine, mudancas);

            this.textBoxDescription.Text = $"Novidades da versão {log.Versao}:{Environment.NewLine}{descricao}";
        }
    }
}