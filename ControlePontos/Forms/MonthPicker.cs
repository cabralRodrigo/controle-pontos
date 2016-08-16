using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ControlePontos.Dialog
{
    public partial class MonthPicker : Form
    {
        public DateTime DataSelecionada { get; private set; }

        public MonthPicker()
        {
            this.InitializeComponent();
            this.DataSelecionada = DateTime.Now;
            this.InicializarDialog();
        }

        public MonthPicker(DateTime dataAtual)
            : this()
        {
            this.DataSelecionada = dataAtual;
            this.InicializarDialog();
        }

        private void InicializarDialog()
        {
            this.lstAnos.Items.Clear();
            Enumerable.Range(2014, 5).ToList().ForEach(ano =>
            {
                var item = new { Descricao = ano, Valor = ano };
                this.lstAnos.Items.Add(item);

                if (item.Valor == this.DataSelecionada.Year)
                    this.lstAnos.SelectedIndex = this.lstAnos.Items.IndexOf(item);
            });

            var ptBr = new CultureInfo("pt-br");
            this.lstMeses.Items.Clear();
            Enumerable.Range(1, 12).ToList().ForEach(mes =>
            {
                var item = new { Descricao = ptBr.DateTimeFormat.GetMonthName(mes).ToTitleCase(), Valor = mes };
                this.lstMeses.Items.Add(item);

                if (item.Valor == this.DataSelecionada.Month)
                    this.lstMeses.SelectedIndex = this.lstMeses.Items.IndexOf(item);
            });
        }

        #region Eventos

        private void MonthPicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void lstMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstMeses.SelectedIndex > -1)
            {
                var item = (dynamic)this.lstMeses.Items[this.lstMeses.SelectedIndex];
                this.DataSelecionada = new DateTime(this.DataSelecionada.Year, (int)item.Valor, 1);
            }
        }

        private void lstAnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstAnos.SelectedIndex > -1)
            {
                var item = (dynamic)this.lstAnos.Items[this.lstAnos.SelectedIndex];
                this.DataSelecionada = new DateTime((int)item.Valor, this.DataSelecionada.Month, 1);
            }
        }

        #endregion Eventos

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}