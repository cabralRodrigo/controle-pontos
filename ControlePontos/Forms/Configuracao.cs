using ControlePontos.Configuracao;
using ControlePontos.Servicos;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ControlePontos.Forms
{
    public partial class Configuracao : Form
    {
        private readonly IConfiguracaoServico configuracaoServico;

        public Configuracao(IConfiguracaoServico configuracaoServico)
        {
            this.InitializeComponent();
            this.configuracaoServico = configuracaoServico;
        }

        private void Configuracao_Load(object sender, EventArgs e)
        {
            var config = this.configuracaoServico.ObterConfiguracao();

            this.tab_backup_lstDiretorioBackup.Items.AddRange(config.Backup.Diretorios.ToArray());

            var datas = config.Feriados.Feriados;
            foreach (var data in datas.OrderBy(w => w))
            {
                this.tab_feriados_calendar.AddBoldedDate(data);
                this.tab_feriados_lstFeriados.Items.Add(data);
            }
            this.tab_feriados_lstFeriados.SortBy<DateTime, DateTime>(w => w);
            this.tab_feriados_calendar.UpdateBoldedDates();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var config = new ConfigApp
            {
                Backup = new ConfigBackup(this.tab_backup_lstDiretorioBackup.Items.Cast<string>().ToArray()),
                Feriados = new ConfigFeriados(this.tab_feriados_lstFeriados.Items.Cast<DateTime>().ToArray())
            };

            this.configuracaoServico.SalvarConfiguracao(config);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region Backup

        private void tab_backup_btnAdd_Click(object sender, EventArgs e)
        {
            using (var folderDiaglog = new FolderBrowserDialog())
            {
                if (folderDiaglog.ShowDialog() == DialogResult.OK)
                    this.tab_backup_lstDiretorioBackup.Items.Add(folderDiaglog.SelectedPath);
            }
        }

        private void tab_backup_btnRemove_Click(object sender, EventArgs e)
        {
            var index = this.tab_backup_lstDiretorioBackup.SelectedIndex;
            if (index > -1)
            {
                this.tab_backup_lstDiretorioBackup.Items.RemoveAt(index--);
                if (index > -1)
                    this.tab_backup_lstDiretorioBackup.SelectedIndex = index;
            }
        }

        #endregion

        #region Feriados

        private void tab_feriados_btnAdd_Click(object sender, EventArgs e)
        {
            var novas = this.tab_feriados_calendar.SelectionRange.AllInRange().ToList();
            var antigas = this.tab_feriados_lstFeriados.Items.Cast<DateTime>().ToList();

            var datas = novas.Where(w => !antigas.Contains(w));

            foreach (var data in datas)
            {
                this.tab_feriados_lstFeriados.Items.Add(data);
                this.tab_feriados_calendar.AddBoldedDate(data);
            }

            if (datas.Any())
            {
                this.tab_feriados_calendar.UpdateBoldedDates();
                this.tab_feriados_lstFeriados.SortBy<DateTime, DateTime>(w => w);
            }
        }

        private void tab_feriados_btnRemove_Click(object sender, EventArgs e)
        {
            var index = this.tab_feriados_lstFeriados.SelectedIndex;
            if (index > -1)
            {
                var data = (DateTime)this.tab_feriados_lstFeriados.SelectedItem;

                this.tab_feriados_lstFeriados.Items.RemoveAt(index--);
                if (index > -1)
                    this.tab_feriados_lstFeriados.SelectedIndex = index;
                else if (this.tab_feriados_lstFeriados.Items.Count > 0)
                    this.tab_feriados_lstFeriados.SelectedIndex = 0;

                this.tab_feriados_calendar.RemoveBoldedDate(data);
            }
        }

        private void tab_feriados_lstFeriados_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = this.tab_feriados_lstFeriados.SelectedIndex;
            if (index > -1)
            {
                var data = (DateTime)this.tab_feriados_lstFeriados.SelectedItem;
                this.tab_feriados_calendar.SelectionStart = data;
                this.tab_feriados_calendar.SelectionEnd = data;
            }
        }

        private void tab_feriados_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            var datas = this.tab_feriados_calendar.SelectionRange.AllInRange();
            if (datas.Count() == 1)
            {
                var data = datas.Single();
                if (this.tab_feriados_lstFeriados.Items.Cast<DateTime>().Contains(data))
                    this.tab_feriados_lstFeriados.SelectedItem = data;
            }
        }

        #endregion
    }
}