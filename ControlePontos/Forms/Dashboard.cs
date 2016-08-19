using ControlePontos.Dialog;
using ControlePontos.Exportacao;
using ControlePontos.Model;
using ControlePontos.Servicos;
using Newtonsoft.Json;
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
        private readonly IFormOpener formOpener;
        private readonly IConfiguracaoServico configuracaoServico;
        private readonly IMesTrabalhoServico mesTrabalhoServico;
        private readonly IRelatorioServico relatorioServico;
        private readonly IExportacaoServico exportacaoServico;
        private readonly IBackupServico backupServico;

        private MesTrabalho mesTrabalho;
        private ConfigApp config;
        private int ano, mes;

        public Dashboard(IFormOpener formOpener, IConfiguracaoServico configuracaoServico, IMesTrabalhoServico mesTrabalhoServico, IRelatorioServico relatorioServico, IExportacaoServico exportacaoServico, IBackupServico backupServico)
        {
            this.InitializeComponent();

            this.Text = Application.ProductName;
            this.lblVersao.Text = Application.ProductVersion;
            this.configuracaoServico = configuracaoServico;
            this.formOpener = formOpener;
            this.mesTrabalhoServico = mesTrabalhoServico;
            this.relatorioServico = relatorioServico;
            this.exportacaoServico = exportacaoServico;
            this.backupServico = backupServico;

            this.gridDias.CellValueChanged += (sender, e) =>
            {
                this.AtualizarTela();
            };
            this.configuracaoServico.ConfiguracaoMudou += novaConfiguracao =>
            {
                this.InitDashboard(this.ano, this.mes, novaConfiguracao);
            };

            this.InitDashboard(DateTime.Now.Year, DateTime.Now.Month);
        }

        private void InitDashboard(int ano, int mes, ConfigApp config = null)
        {
            if (config == null)
                this.config = this.configuracaoServico.ObterConfiguracao();
            else
                this.config = config;

            this.ano = ano;
            this.mes = mes;

            this.mesTrabalho = this.mesTrabalhoServico.ObterMesTrabalho(this.ano, this.mes);
            this.gridDias.BindDias(this.config, this.mesTrabalho.Dias);

            this.AtualizarTela();
        }

        private void AtualizarTela()
        {
            var data = new DateTime(this.ano, this.mes, 1);
            this.btnMesAno.Text = "{0} de {1}".FormatWith(data.ToString("MMMM").ToTitleCase(), data.ToString("yyyy"));

            this.lblCoeficiente.Text = Calculator.Coeficiente(this.config, this.mesTrabalho).Descricao();
            this.lblCoeficientePorDia.Text = Calculator.CoeficientePorDia(this.config, this.mesTrabalho).Descricao();
            this.lblMediaEntrada.Text = Calculator.MediaEntradaEmpresa(this.config, this.mesTrabalho).ToStringOr("----", @"hh\:mm");
            this.lblMediaSaida.Text = Calculator.MediaSaidaEmpresa(this.config, this.mesTrabalho).ToStringOr("----", @"hh\:mm");
            this.lblAlmocoSaida.Text = Calculator.MediaEntradaAlmoco(this.config, this.mesTrabalho).ToStringOr("----", @"hh\:mm");
            this.lblAlmocoRetorno.Text = Calculator.MediaSaidaAlmoco(this.config, this.mesTrabalho).ToStringOr("----", @"hh\:mm");
            this.lblMediaTempoAlmoco.Text = Calculator.MediaTempoAlmoco(this.config, this.mesTrabalho).ToStringOr("----", @"hh\:mm");

            this.lblMediaValorAlmoco.Text = Calculator.MediaValorAlmoco(this.config, this.mesTrabalho).ToStringOr("----", "c");
            this.lblValorIdealDiario.Text = Calculator.ValorIdealAlmoco(this.config, this.mesTrabalho).ToStringOr("----", "c");
            this.lblValorTotalTR.Text = Calculator.ValorAtualTr(this.config, this.mesTrabalho).ToString("c");

            this.txtSodexo.Text = this.mesTrabalho.ValorSodexo.ToString("F");
            this.txtOffset.Text = this.mesTrabalho.CoficienteOffset.ToString();
        }

        private void Salvar()
        {
            this.mesTrabalhoServico.SalvarMesTrabalho(this.ano, this.mes, this.mesTrabalho);
        }

        private void CarregarMenuRelatorios()
        {
            foreach (var relatorio in this.relatorioServico.ListarRelatorios().OrderBy(w => w.Name))
            {
                var item = new ToolStripMenuItem { Size = new Size(185, 22), Text = relatorio.Name };
                item.Click += (sender2, e2) =>
                {
                    var rel = relatorio.Execute(config, ano, mes, this.mesTrabalho);
                    rel.Execute();
                };

                this.menu_relatorio.DropDownItems.Add(item);
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

        #region Eventos

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Salvar();
        }

        private void txtOffset_Leave(object sender, EventArgs e)
        {
            if (this.txtOffset.Text.IsNullOrEmpty())
                this.txtOffset.Text = "0";

            int novoValor;
            if (int.TryParse(this.txtOffset.Text, out novoValor))
                this.mesTrabalho.CoficienteOffset = novoValor;

            this.AtualizarTela();
        }

        private void txtOffset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtOffset.Enabled = false;
                this.txtOffset.Enabled = true;
            }
        }

        private void txtSodexo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtSodexo.Enabled = false;
                this.txtSodexo.Enabled = true;
            }
        }

        private void txtSodexo_Leave(object sender, EventArgs e)
        {
            if (this.txtSodexo.Text.IsNullOrEmpty())
                this.txtSodexo.Text = "0";

            decimal novoValor;
            if (decimal.TryParse(this.txtSodexo.Text, out novoValor))
                this.mesTrabalho.ValorSodexo = novoValor;

            this.AtualizarTela();
        }

        private void btnMesAno_Click(object sender, EventArgs e)
        {
            using (var dialog = new MonthPicker(new DateTime(this.ano, this.mes, 1)))
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Salvar();
                    this.InitDashboard(dialog.DataSelecionada.Year, dialog.DataSelecionada.Month);
                }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.status.Text = "Salvando dados...";
            this.Salvar();
            this.status.Text = string.Empty;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.CarregarMenuRelatorios();
            this.RealizarBackupDiario();
        }

        #region Menu

        #region Dados

        #region Exportação

        private void menu_dados_exportar_zip_Click(object sender, EventArgs e)
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
                            Process.Start("explorer", "/e, /select, \"{0}\"".FormatWith(dialog.FileName));
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

        private void menu_dados_importarCoeficiente_Click(object sender, EventArgs e)
        {
            var scanner = new DataFileScanner(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName);
            var arquivos = scanner.FindAll();

            var anterior = new DateTime(this.ano, this.mes, 1).AddMonths(-1);

            var data = arquivos.FirstOrDefault(s => s.Ano == anterior.Year && s.Mes == anterior.Month);

            if (data == null)
                MessageBox.Show("Não foi possivel encontrar dados do mês anterior.");
            else
            {
                if (MessageBox.Show("Deseja realmente importar o coeficiente do mês anterior?", "Importação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var offset = 6 * 60;
                    if (MessageBox.Show("Deseja adicionar as 6 horas desse coeficiente?", "Importação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        offset = 0;

                    var mes = JsonConvert.DeserializeObject<MesTrabalho>(File.ReadAllText(Path.Combine(data.Diretorio, data.Nome)));
                    var coeficiente = (int)Math.Round(Calculator.Coeficiente(this.config, mes).TotalMinutes + offset, MidpointRounding.AwayFromZero);

                    this.txtOffset.Text = coeficiente.ToString();
                    this.mesTrabalho.CoficienteOffset = coeficiente;
                    this.AtualizarTela();
                }
            }
        }

        #endregion Dados

        private void Dashboard_Shown(object sender, EventArgs e)
        {
        }

        #endregion Menu

        private void menu_configuracoes_Click(object sender, EventArgs e)
        {
            this.formOpener.ShowModalForm<Configuracao>();
        }

        #endregion Eventos

        private void menu_dados_realizarBackup_Click(object sender, EventArgs e)
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
                            this.menu_dados_realizarBackup_Click(sender, e);
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
    }
}