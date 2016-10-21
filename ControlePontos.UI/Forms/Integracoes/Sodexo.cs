using ControlePontos.Dominio.Model.Integracoes;
using ControlePontos.Dominio.Servico;
using ControlePontos.Extensions;
using ControlePontos.Servicos;
using ControlePontos.Util.Extensions;
using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace ControlePontos.Forms.Integracoes
{
    internal partial class Sodexo : BaseForm
    {
        private static class Colunas
        {
            public const int Data = 0;
            public const int Tipo = Data + 1;
            public const int Descricao = Tipo + 1;
            public const int Valor = Descricao + 1;
            public const int ColunaEstatisticas = Valor + 1;
        }

        private readonly IConfiguracaoServico configuracaoServico;
        private readonly ProgressoCarregamento progressoForm;
        private readonly ISodexoServico sodexoServico;
        private readonly CancellationTokenSource tokenSource;
        private readonly IFormServico formServico;

        public Sodexo(ISodexoServico sodexoServico, IConfiguracaoServico configuracaoServico, ProgressoCarregamento progressoForm, IFormServico formServico)
        {
            this.InitializeComponent();

            this.sodexoServico = sodexoServico;
            this.configuracaoServico = configuracaoServico;
            this.progressoForm = progressoForm;
            this.formServico = formServico;
            this.tokenSource = new CancellationTokenSource();
        }

        private bool CarregarDadosSodexo()
        {
            var config = this.configuracaoServico.ObterConfiguracao();
            var cartao = config.Sodexo?.NumeroCartao;
            var cpf = config.Sodexo?.NumeroCpf;

            if (!cartao.IsNullOrEmpty() && !cpf.IsNullOrEmpty())
            {
                this.sodexoServico.ConsultarSaldoAsync(cartao, cpf, this.tokenSource.Token).Continue(historico =>
                {
                    this.AtualizarTela(historico);
                    this.progressoForm.Close();
                }, ex =>
                {
                    if (!this.tokenSource.IsCancellationRequested)
                    {
                        MessageBox.Show("Ocorreu um erro carregar os dados do servidor do sodexo.\nErro: " + ex.Message, "Sodexo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.progressoForm.Close();
                        this.Close();
                    }
                });

                return true;
            }
            else
            {
                if (MessageBox.Show("As configurações do sodexo não foram informadas.\nDeseja configurar agora?", "Configurações", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.formServico.AbrirDialogo<Configuracao>();

                this.Close();
                return false;
            }
        }

        private void AtualizarTela(SodexoHistorioUsoModel historico)
        {
            this.PrepararSeparadores();

            this.DataDadosLabel.Text = historico.DataAtualizacao.ToString("dd/MM/yyyy");
            this.NomeLabel.Text = historico.NomeAssociado;
            this.EmpresaLabel.Text = historico.NomeEmpresa;
            this.NumeroCartaoLabel.Text = this.FormatarNumeroCartaoSodexo(historico.NumeroCartao);
            this.NumeroCpfLabel.Text = this.FormatarCPF(historico.Cpf);
            this.ServicoLabel.Text = historico.Servico;
            this.StatusLabel.Text = historico.Status;
            this.SaldoLabel.Text = historico.SaldoAtual.ToString("c");

            foreach (var grupo in historico.Transacoes.GroupBy(s => s.Data))
            {
                foreach (var transacao in grupo.OrderByDescending(w => w.Tipo).ThenBy(w => w.Historico))
                    this.GridSodexo.Rows.Add(new object[] {
                        transacao.Data.ToString("dd/MM/yyyy"),
                        transacao.Tipo.ToString(),
                        transacao.Historico,
                        transacao.Valor.ToString("c"),
                        transacao
                    });

                this.GridSodexo.Rows.Add(new object[] {
                    $"Total gasto no dia {grupo.Key.ToString("dd/MM/yyyy")}",
                    string.Empty,
                    string.Empty,
                    grupo.Where(w => w.Tipo == SodexoTipoTransacao.Débito).Sum(s => s.Valor).ToString("c"),
                    null
                });
            }
        }

        private void PrepararSeparadores()
        {
            typeof(Sodexo).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(w => w.FieldType == typeof(Label))
                .Select(w => w.GetValue(this))
                .Cast<Label>()
                .Where(w => w.Text == "separador")
                .ToList()
                .ForEach(w => w.Text = string.Empty);
        }

        private string FormatarNumeroCartaoSodexo(string numeroCartao)
        {
            var masked = new MaskedTextBox("0000,0000,0000,0000");
            masked.Text = numeroCartao;

            return masked.Text;
        }

        private string FormatarCPF(string cpf)
        {
            var masked = new MaskedTextBox("000,000,000-00");
            masked.Text = cpf;

            return masked.Text;
        }

        #region Eventos

        private void Sodexo_Load(object sender, EventArgs e)
        {
            this.progressoForm.Titulo = "Carregando...";
            this.progressoForm.Mensagem = "Carregando dados do sodexo...";
            this.progressoForm.TipoBarraCarregamento = ProgressBarStyle.Marquee;
            this.progressoForm.OnCancel(() =>
            {
                this.tokenSource.Cancel();
                this.progressoForm.Close();
                this.Close();
            });

            this.GridSodexo.CellPainting += GridSodexo_CellPainting;

            if (this.CarregarDadosSodexo())
                this.progressoForm.ShowDialogAsync(this);
        }

        private void GridSodexo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.RowIndex == this.GridSodexo.Rows.Count - 1)
                e.AdvancedBorderStyle.Bottom = this.GridSodexo.AdvancedCellBorderStyle.Bottom;

            var transacao = this.GridSodexo.Rows[e.RowIndex].Cells[Colunas.ColunaEstatisticas].Value as SodexoTransacaoModel;
            if (transacao == null)
            {
                e.CellStyle.BackColor = Color.FromArgb(229, 211, 245);

                if (e.ColumnIndex != Colunas.Valor)
                    e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                if (transacao.Tipo == SodexoTipoTransacao.Crédito)
                    e.CellStyle.BackColor = Color.FromArgb(227, 245, 211);
                else
                    e.CellStyle.BackColor = Color.FromArgb(245, 212, 211);
            }
        }

        #endregion Eventos
    }
}