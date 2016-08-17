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

            this.Backup_Load(config);
            this.Feriados_Load(config);
            this.Ferias_Load(config);
        }

        private void ButtonSalvar_Click(object sender, EventArgs e)
        {
            var config = new ConfigApp();

            this.Backup_Save(config);
            this.Feriados_Save(config);
            this.Ferias_Save(config);

            this.configuracaoServico.SalvarConfiguracao(config);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region Backup

        private void Backup_Load(ConfigApp config)
        {
            this.Backup_ListBoxDiretorios.Items.AddRange(config.Backup.Diretorios.ToArray());
        }

        private void Backup_Save(ConfigApp config)
        {
            config.Backup = new ConfigBackup(this.Backup_ListBoxDiretorios.Items.Cast<string>().ToArray());
        }

        private void Backup_ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var folderDiaglog = new FolderBrowserDialog())
            {
                if (folderDiaglog.ShowDialog() == DialogResult.OK)
                    this.Backup_ListBoxDiretorios.Items.Add(folderDiaglog.SelectedPath);
            }
        }

        private void Backup_ButtonRemove_Click(object sender, EventArgs e)
        {
            var index = this.Backup_ListBoxDiretorios.SelectedIndex;
            if (index > -1)
            {
                this.Backup_ListBoxDiretorios.Items.RemoveAt(index--);
                if (index > -1)
                    this.Backup_ListBoxDiretorios.SelectedIndex = index;
            }
        }

        #endregion

        #region Feriados & Férias

        #region Feriados

        private void Feriados_Load(ConfigApp config)
        {
            Configuracao.FeriadosFerias_Load(this.Feriados_ListBoxFeriados, this.Feriados_Calendar, config.Feriados.Feriados.ToArray());
        }

        private void Feriados_Save(ConfigApp config)
        {
            config.Feriados = new ConfigFeriados(this.Feriados_ListBoxFeriados.Items.Cast<DateTime>().ToArray());
        }

        private void Feriados_ButtonAdd_Click(object sender, EventArgs e)
        {
            Configuracao.FeriadosFerias_BtnAdd_Click(this.Feriados_ListBoxFeriados, this.Feriados_Calendar);
        }

        private void Feriados_ButtonRemove_Click(object sender, EventArgs e)
        {
            Configuracao.FeriadosFerias_BtnRemove_Click(this.Feriados_ListBoxFeriados, this.Feriados_Calendar);
        }

        private void Feriados_ListBoxFeriados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configuracao.FeriadosFerias_Lista_SelectedIndexChanged(this.Feriados_ListBoxFeriados, this.Feriados_Calendar);
        }

        private void Feriados_Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            Configuracao.FeriadosFerias_Calendario_DateSelected(this.Feriados_ListBoxFeriados, this.Feriados_Calendar);
        }

        #endregion

        #region Férias

        private void Ferias_Load(ConfigApp config)
        {
            Configuracao.FeriadosFerias_Load(this.Ferias_ListBoxFerias, this.Ferias_Calendar, config.Ferias);
        }

        private void Ferias_Save(ConfigApp config)
        {
            config.Ferias = this.Ferias_ListBoxFerias.Items.Cast<DateTime>().ToArray();
        }

        private void Ferias_ButtonAdd_Click(object sender, EventArgs e)
        {
            Configuracao.FeriadosFerias_BtnAdd_Click(this.Ferias_ListBoxFerias, this.Ferias_Calendar);
        }

        private void Ferias_ButtonRemove_Click(object sender, EventArgs e)
        {
            Configuracao.FeriadosFerias_BtnRemove_Click(this.Ferias_ListBoxFerias, this.Ferias_Calendar);
        }

        private void Ferias_ListBoxFerias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configuracao.FeriadosFerias_Lista_SelectedIndexChanged(this.Ferias_ListBoxFerias, this.Ferias_Calendar);
        }

        private void Ferias_Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            Configuracao.FeriadosFerias_Calendario_DateSelected(this.Ferias_ListBoxFerias, this.Ferias_Calendar);
        }

        #endregion

        #region Lógica

        private static void FeriadosFerias_Load(ListBox lista, MonthCalendar calendario, DateTime[] datas)
        {
            foreach (var data in datas.OrderBy(w => w))
            {
                calendario.AddBoldedDate(data);
                lista.Items.Add(data);
            }
            lista.SortBy<DateTime, DateTime>(w => w);
            calendario.UpdateBoldedDates();
        }

        private static void FeriadosFerias_BtnAdd_Click(ListBox lista, MonthCalendar calendario)
        {
            var novas = calendario.SelectionRange.AllInRange().ToList();
            var antigas = lista.Items.Cast<DateTime>().ToList();

            var datas = novas.Where(w => !antigas.Contains(w));

            foreach (var data in datas)
            {
                lista.Items.Add(data);
                calendario.AddBoldedDate(data);
            }

            if (datas.Any())
            {
                calendario.UpdateBoldedDates();
                lista.SortBy<DateTime, DateTime>(w => w);

                if (datas.Count() == 1)
                    lista.SelectedIndex = lista.Items.IndexOf(datas.Single());
            }
        }

        private static void FeriadosFerias_BtnRemove_Click(ListBox lista, MonthCalendar calendario)
        {
            var index = lista.SelectedIndex;
            if (index > -1)
            {
                var data = (DateTime)lista.SelectedItem;

                lista.Items.RemoveAt(index--);
                if (index > -1)
                    lista.SelectedIndex = index;
                else if (lista.Items.Count > 0)
                    lista.SelectedIndex = 0;

                calendario.RemoveBoldedDate(data);
                calendario.UpdateBoldedDates();
            }
        }

        private static void FeriadosFerias_Lista_SelectedIndexChanged(ListBox lista, MonthCalendar calendario)
        {
            var index = lista.SelectedIndex;
            if (index > -1)
            {
                var data = (DateTime)lista.SelectedItem;
                calendario.SelectionStart = data;
                calendario.SelectionEnd = data;
            }
        }

        private static void FeriadosFerias_Calendario_DateSelected(ListBox lista, MonthCalendar calendario)
        {
            var datas = calendario.SelectionRange.AllInRange();
            if (datas.Count() == 1)
            {
                var data = datas.Single();
                if (lista.Items.Cast<DateTime>().Contains(data))
                    lista.SelectedItem = data;
            }
        }

        #endregion

        #endregion
    }
}