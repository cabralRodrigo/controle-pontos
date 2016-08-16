﻿using ControlePontos.Dialog;
using ControlePontos.Exportacao;
using ControlePontos.Model;
using ControlePontos.Report;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ControlePontos.Forms
{
    internal partial class Dashboard : Form
    {
        public ConfiguracaoDias config = new ConfiguracaoDias
        {
            HoraInicio = new TimeSpan(9, 0, 0),
            HoraFim = new TimeSpan(18, 0, 0),
            DiasTrabalho = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
            Feriados = new DateTime[]
            {
                new DateTime(2016, 4, 21),
                new DateTime(2016, 5, 26),

                new DateTime(2016, 8, 4),
                new DateTime(2016, 8, 5),
                new DateTime(2016, 8, 18),
                new DateTime(2016, 8, 22),

                new DateTime(2016, 9, 7),
                new DateTime(2016, 10, 12),
                new DateTime(2016, 11, 2),
                new DateTime(2016, 11, 15),
                new DateTime(2016, 12, 25)
            },
            Ferias = new DateTime[]
            {
                new DateTime(2016, 4, 1),
                new DateTime(2016, 4, 4),
                new DateTime(2016, 4, 5),
                new DateTime(2016, 4, 6),
                new DateTime(2016, 4, 7),
                new DateTime(2016, 4, 8)
            }
        };

        public ConfiguracaoApp configApp = new ConfiguracaoApp
        {
            DiretorioBackup = @"C:\controle-pontos-backup",
        };

        private MesTrabalho mesTrabalho;
        private int ano, mes;

        public Dashboard()
        {
            this.InitializeComponent();
            this.Text = Application.ProductName;
            this.lblVersao.Text = Application.ProductVersion;
            this.gridDias.CellValueChanged += (sender, e) =>
            {
                this.AtualizarTela();
            };
            this.InitDashboard(DateTime.Now.Year, DateTime.Now.Month);
        }

        private void InitDashboard(int ano, int mes)
        {
            this.ano = ano;
            this.mes = mes;

            this.mesTrabalho = Dias(this.ano, this.mes);
            this.gridDias.BindDias(this.config, this.mesTrabalho.Dias);

            this.AtualizarTela();
        }

        private static string BuildFileName(int ano, int mes)
        {
            var path = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            var file = string.Format("horarios-{0}-{1}.json", ano, mes);

            return Path.Combine(path, file);
        }

        private static MesTrabalho Dias(int ano, int mes)
        {
            var file = BuildFileName(ano, mes);
            return File.Exists(file) ? JsonConvert.DeserializeObject<MesTrabalho>(File.ReadAllText(file)) : MesTrabalho.Gerar(ano, mes);
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
            File.WriteAllText(BuildFileName(this.ano, this.mes), JsonConvert.SerializeObject(this.mesTrabalho, Formatting.Indented));
        }

        private void CarregarMenuRelatorios()
        {
            var tipo = typeof(IReport);

            var relatorios = (from type in AppDomain.CurrentDomain.GetAssemblies().Select(w => w.GetTypes()).SelectMany(s => s).Distinct().ToList()
                              where tipo.IsAssignableFrom(type) && tipo != type
                              select Activator.CreateInstance(type) as IReport).ToList();

            foreach (var relatorio in relatorios)
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

        private void RealizerBackupDiario()
        {
            if (!Directory.Exists(this.configApp.DiretorioBackup))
                Directory.CreateDirectory(this.configApp.DiretorioBackup);

            var jsonbackup = Path.Combine(this.configApp.DiretorioBackup, "backup.json");

            IEnumerable<DateTime> datas;
            using (var file = new StreamReader(File.Open(jsonbackup, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)))
            {
                var json = file.ReadToEnd();

                if (string.IsNullOrEmpty(json))
                    datas = new List<DateTime>();
                else
                    datas = JsonConvert.DeserializeObject<DateTime[]>(json);
            }

            if (!datas.Any(w => w.Date == DateTime.Now.Date))
            {
                var resultado = new ExportacaoZip().RealizarBackup(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, Path.Combine(this.configApp.DiretorioBackup, DateTime.Now.ToString("yyyy.MM.dd hh.mm.ss") + ".zip"));

                if (resultado.QuantidadeArquivos == 0)
                {
                    MessageBox.Show("Não foi possivel encontrar nenhum arquivo para fazer o backup diario. Look into that please...");
                    return;
                }

                var novasDatas = datas.ToList();
                novasDatas.Add(DateTime.Now);

                File.WriteAllText(jsonbackup, JsonConvert.SerializeObject(novasDatas));
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
            this.RealizerBackupDiario();
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
                dialog.Filter = "Zip File (*.zip)|*.zip";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var resultado = new ExportacaoZip().RealizarBackup(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, dialog.FileName);

                    bool abrir;
                    if (resultado.QuantidadeArquivos == 0)
                        abrir = MessageBox.Show("Exportação foi executada com sucesso porém não foi possivel localizar as arquivos com os dados atuais.\nDeseja abrir a pasta onde foi criado o backup?", "Exportação", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                    else
                    {
                        var inicio = new DateTime(resultado.AnoInicio, resultado.MesInicio, 1);
                        var fim = new DateTime(resultado.AnoFim, resultado.MesFim, 1);

                        var mesInicio = CultureInfo.CurrentUICulture.DateTimeFormat.GetMonthName(inicio.Month).ToTitleCase();
                        var mesFim = CultureInfo.CurrentUICulture.DateTimeFormat.GetMonthName(fim.Month).ToTitleCase();

                        var mensagem = "Exportação foi executada com sucesso com dados entre {0} de {1:yyyy} a {2} de {3:yyyy}.\nDeseja abrir a pasta onde foi criado o arquivo de exportação ?".FormatWith(mesInicio, inicio, mesFim, fim);
                        abrir = MessageBox.Show(mensagem, "Exportação", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                    }

                    if (abrir)
                        Process.Start("explorer", "/e, /select, \"{0}\"".FormatWith(resultado.ArquivoZip));
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

        #endregion Eventos
    }
}