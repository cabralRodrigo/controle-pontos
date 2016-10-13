using ControlePontos.Extensions;
using ControlePontos.Forms.TeamServices;
using ControlePontos.Model;
using ControlePontos.Native;
using ControlePontos.Servicos;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ControlePontos.Forms
{
    internal partial class Dashboard : Form
    {
        private readonly IBackupServico backupServico;
        private readonly ICalculoServico calculoServico;
        private readonly IConfiguracaoServico configuracaoServico;
        private readonly IExportacaoServico exportacaoServico;
        private readonly IFormServico formServico;
        private readonly IMesTrabalhoServico mesTrabalhoServico;
        private readonly IRelatorioServico relatorioServico;
        private readonly IControlRenderer controlRenderer;
        private readonly IParserServico parserServico;
        private readonly IAppInfoServico appInfoServico;

        private MesTrabalho mesTrabalho;
        private ConfigApp config;
        private int ano, mes;

        public Dashboard(IFormServico formOpener, IConfiguracaoServico configuracaoServico, IMesTrabalhoServico mesTrabalhoServico, IRelatorioServico relatorioServico, IExportacaoServico exportacaoServico, IBackupServico backupServico, ICalculoServico calculoServico, IControlRenderer controlRenderer, IParserServico parserServico, IAppInfoServico appInfoServico)
        {
            this.InitializeComponent();

            this.configuracaoServico = configuracaoServico;
            this.formServico = formOpener;
            this.mesTrabalhoServico = mesTrabalhoServico;
            this.relatorioServico = relatorioServico;
            this.exportacaoServico = exportacaoServico;
            this.backupServico = backupServico;
            this.calculoServico = calculoServico;
            this.controlRenderer = controlRenderer;
            this.parserServico = parserServico;
            this.appInfoServico = appInfoServico;
        }

        private void InitDashboard(int ano, int mes, ConfigApp config = null)
        {
            this.ano = ano;
            this.mes = mes;

            var abrirConfiguracoes = false;
            if (config == null)
            {
                this.config = this.configuracaoServico.ObterConfiguracao();
                if (this.config == null)
                {
                    this.configuracaoServico.SalvarConfiguracao(this.configuracaoServico.GerarConfiguracaoPadrao());

                    abrirConfiguracoes = MessageBox.Show("Essa parece ser a primeira vez que você abre o Controle de Pontos.\nDeseja customizar as configurações padrões?", "Controle de Pontos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                }
            }
            else
                this.config = config;

            this.mesTrabalho = this.mesTrabalhoServico.ObterMesTrabalho(this.ano, this.mes);
            this.GridDias.CalculoServico = this.calculoServico;
            this.GridDias.ControlRenderer = this.controlRenderer;
            this.GridDias.ParserServico = this.parserServico;
            this.GridDias.BindDias(this.config, this.mesTrabalho.Dias);

            this.AtualizarTela();

            if (abrirConfiguracoes)
                this.Menu_Ajuda_Configuracoes_Click(this, EventArgs.Empty);
        }

        private void AtualizarTela()
        {
            var data = new DateTime(this.ano, this.mes, 1);
            this.ButtonMesAno.Text = $"{data.ToString("MMMM").ToTitleCase()} de {data.ToString("yyyy")}";

            this.LabelCoeficiente.Text = this.calculoServico.Coeficiente(this.config, this.mesTrabalho).Descricao();
            this.LabelCoeficientePorDia.Text = this.calculoServico.CoeficientePorDia(this.config, this.mesTrabalho).Descricao();
            this.LabelMediaEntrada.Text = this.calculoServico.MediaEntradaEmpresa(this.config, this.mesTrabalho)?.ToString(@"hh\:mm") ?? string.Empty;
            this.LabelMediaSaida.Text = this.calculoServico.MediaSaidaEmpresa(this.config, this.mesTrabalho)?.ToString(@"hh\:mm") ?? string.Empty;
            this.LabelAlmocoSaida.Text = this.calculoServico.MediaEntradaAlmoco(this.config, this.mesTrabalho)?.ToString(@"hh\:mm") ?? string.Empty;
            this.LabelAlmocoRetorno.Text = this.calculoServico.MediaSaidaAlmoco(this.config, this.mesTrabalho)?.ToString(@"hh\:mm") ?? string.Empty;
            this.LabelMediaTempoAlmoco.Text = this.calculoServico.MediaTempoAlmoco(this.config, this.mesTrabalho)?.ToString(@"hh\:mm") ?? string.Empty;
            this.LabelTotalHorasTfs.Text = this.calculoServico.TotalHorasTfs(this.config, this.mesTrabalho).Descricao();

            this.LabelMediaValorAlmoco.Text = this.calculoServico.MediaValorAlmoco(this.config, this.mesTrabalho)?.ToString("c") ?? "-----";
            this.LabelValorIdealDiario.Text = this.calculoServico.ValorIdealAlmoco(this.config, this.mesTrabalho)?.ToString("c") ?? "-----";
            this.LabelValorTotalTr.Text = this.calculoServico.ValorAtualTr(this.config, this.mesTrabalho).ToString("c");

            this.TextBoxSodexo.Text = this.mesTrabalho.ValorSodexo.ToString("F");
            this.TextBoxOffset.Text = this.mesTrabalho.CoficienteOffset.ToString();
        }

        private void Salvar()
        {
            this.mesTrabalhoServico.SalvarMesTrabalho(this.ano, this.mes, this.mesTrabalho);
        }

        private void CarregarMenuRelatorios()
        {
            foreach (var relatorio in this.relatorioServico.ListarRelatorios().OrderBy(w => w.Name))
            {
                var menu = new ToolStripMenuItem { Size = new Size(185, 22), Text = relatorio.Name };
                menu.Click += (sender, e) =>
                {
                    var resultado = relatorio.Execute(config, ano, mes, this.mesTrabalho);
                    resultado.Execute();
                };

                this.Menu_Relatorio.DropDownItems.Add(menu);
            }
        }

        private void RealizarBackupDiario(bool forcarBackup = false)
        {
            if (forcarBackup || !this.backupServico.BackupAgendadoRealizado())
            {
                var res = this.backupServico.RealizarBackup();

                if (res.Tipo == TipoMensagem.Aviso && res.Valor == BackupResultado.DriveNaoDisponivel)
                {
                    if (MessageBox.Show("O seguinte drive não esta disponível no momento: " + res.ValorMensagem + "\nDeseja tentar novamente?", "Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        this.RealizarBackupDiario(true);
                }
                else if (res.Tipo == TipoMensagem.Erro)
                {
                    if (res.Excecao != null)
                        MessageBox.Show("Erro ao realizar backup: " + res.Excecao.ToString(), "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Erro desconhecido ao realizar o backup.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PrepararSeparadores()
        {
            typeof(Dashboard).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(w => w.FieldType == typeof(Label)).Select(w => w.GetValue(this))
                .Cast<Label>()
                .Where(w => w.Text == "separator")
                .ToList()
                .ForEach(w => w.Text = string.Empty);
        }

        #region Eventos

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Salvar();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Timer.Enabled = true;
            this.GridDias.ValoresAtualizados += this.AtualizarTela;
            this.configuracaoServico.ConfiguracaoMudou += novaConfiguracao => this.InitDashboard(this.ano, this.mes, novaConfiguracao);

            this.InitDashboard(DateTime.Now.Year, DateTime.Now.Month);

            this.Text = this.appInfoServico.ObterNomeApp();
            this.Status_LabelVersao.Text = this.appInfoServico.ObterVersaoAtual().ToString();

            this.CarregarMenuRelatorios();
            this.RealizarBackupDiario();
            this.PrepararSeparadores();
        }

        private void TextBoxOffset_Leave(object sender, EventArgs e)
        {
            if (this.TextBoxOffset.Text.IsNullOrEmpty())
                this.TextBoxOffset.Text = "0";

            int novoValor;
            if (int.TryParse(this.TextBoxOffset.Text, out novoValor))
                this.mesTrabalho.CoficienteOffset = novoValor;

            this.AtualizarTela();
        }

        private void TextBoxOffset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.TextBoxOffset.Enabled = false;
                this.TextBoxOffset.Enabled = true;
            }
        }

        private void TextBoxSodexo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.TextBoxSodexo.Enabled = false;
                this.TextBoxSodexo.Enabled = true;
            }
        }

        private void TexBoxSodexo_Leave(object sender, EventArgs e)
        {
            if (this.TextBoxSodexo.Text.IsNullOrEmpty())
                this.TextBoxSodexo.Text = "0";

            decimal novoValor;
            if (decimal.TryParse(this.TextBoxSodexo.Text, out novoValor))
                this.mesTrabalho.ValorSodexo = novoValor;

            this.AtualizarTela();
        }

        private void ButtonMesAno_Click(object sender, EventArgs e)
        {
            using (var dialog = new MonthPicker(new DateTime(this.ano, this.mes, 1)))
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Salvar();
                    this.InitDashboard(dialog.DataSelecionada.Year, dialog.DataSelecionada.Month);
                }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Status.Text = "Salvando dados...";
            this.Salvar();
            this.Status.Text = string.Empty;
        }

        #region Menu

        #region Dados

        #region Exportação

        private void Menu_Dados_Exportar_Zip_Click(object sender, EventArgs e)
        {
            this.Salvar();

            using (var dialog = new SaveFileDialog())
            {
                dialog.AddExtension = true;
                dialog.DefaultExt = ".zip";
                dialog.FileName = string.Format("controle-pontos-backup {0:yyyy.MM.dd} {0:hh.mm.ss}.zip", DateTime.Now);
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dialog.Filter = "Arquivo Zip (*.zip)|*.zip";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var arquivo = new FileInfo(dialog.FileName);
                    var resultado = this.exportacaoServico.ExportarDados(arquivo.DirectoryName, arquivo.Name);

                    if (resultado.Tipo == TipoMensagem.Sucesso)
                    {
                        if (MessageBox.Show("Exportação realizada com sucesso.\nDeseja abrir a pasta onde o arquivo foi criado?", "Exportação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            Process.Start("explorer", $"/e, /select, \"{dialog.FileName}\"");
                    }
                    else if (resultado.Tipo == TipoMensagem.Aviso)
                    {
                        switch (resultado.Valor)
                        {
                            case ExportacaoResulado.NenhumDadoEncontrado:
                                MessageBox.Show("Nenhum dado foi encontrado para realizar a exportação.", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                break;

                            case ExportacaoResulado.DriveNaoDisponivel:
                                MessageBox.Show("Não foi possível acessar o drive onde o arquivo de exportação seria gravado.", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                break;
                        }
                    }
                }
            }
        }

        #endregion Exportação

        private void Menu_Dados_ImportarCoeficiente_Click(object sender, EventArgs e)
        {
            var anterior = new DateTime(this.ano, this.mes, 1).AddMonths(-1);
            var mesAnterior = this.mesTrabalhoServico.ObterMesTrabalho(anterior.Year, anterior.Month, false);

            if (mesAnterior != null)
            {
                if (MessageBox.Show("Deseja realmente importar o coeficiente do mês anterior?", "Importar Coeficiente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var minutosOffset = 6 * 60;
                    if (MessageBox.Show("Deseja adicionar 6 horas a esse coeficiente?", "Importar Coeficiente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        minutosOffset = 0;

                    var coeficiente = (int)Math.Round(this.calculoServico.Coeficiente(this.config, mesAnterior).TotalMinutes + minutosOffset, MidpointRounding.AwayFromZero);
                    this.TextBoxOffset.Text = coeficiente.ToString();
                    this.mesTrabalho.CoficienteOffset = coeficiente;

                    this.Salvar();
                    this.AtualizarTela();
                }
            }
            else
                MessageBox.Show("Não foi possível encontrar dados do mês anterior.", "Importar Coeficiente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Menu_Dados_RealizarBackup_Click(object sender, EventArgs e)
        {
            var res = this.backupServico.RealizarBackup();
            if (res.Tipo == TipoMensagem.Sucesso)
                MessageBox.Show("Backup realizado com sucesso!", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (res.Tipo == TipoMensagem.Aviso)
            {
                switch (res.Valor)
                {
                    case BackupResultado.NenhumDadoEncontrado:
                        MessageBox.Show("Não foi encontrado nenhum dado para realizar o backup.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case BackupResultado.NenhumDiretorioParaBackup:
                        MessageBox.Show("Não há nenhum diretório configurado no processo de backup.\nEntre no menu de configurações, na aba de Backup.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;

                    case BackupResultado.DriveNaoDisponivel:
                        if (MessageBox.Show("O seguinte drive não esta disponível no momento: " + res.ValorMensagem + "\nDeseja tentar novamente?", "Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            this.Menu_Dados_RealizarBackup_Click(sender, e);
                        break;
                }
            }
            else
            {
                if (res.Excecao != null)
                    MessageBox.Show("Erro ao realizar backup: " + res.Excecao.ToString(), "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Erro desconhecido ao realizar o backup.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Dados

        private void Menu_TeamService_Click(object sender, EventArgs e)
        {
            this.formServico.AbrirDialogo<TotalHorasIntegracaoAtual>();
        }

        #region Ajuda

        private void Menu_Ajuda_Changelog_Click(object sender, EventArgs e)
        {
            this.formServico.AbrirDialogo<Changelog>();
        }

        private void Menu_Ajuda_Sobre_Click(object sender, EventArgs e)
        {
            this.formServico.AbrirDialogo<Sobre>();
        }

        private void Menu_Ajuda_Configuracoes_Click(object sender, EventArgs e)
        {
            this.formServico.AbrirDialogo<Configuracao>();
        }

        #endregion

        #endregion Menu

        #endregion Eventos
    }
}