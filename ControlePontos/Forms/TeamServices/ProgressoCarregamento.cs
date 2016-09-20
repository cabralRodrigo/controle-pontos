using System;
using System.Windows.Forms;

namespace ControlePontos.Forms.TeamServices
{
    internal partial class ProgressoCarregamento : Form
    {
        private Action onCancel;

        public ProgressoCarregamento()
        {
            this.InitializeComponent();
            this.LabelMensagem.Text = string.Empty;
        }

        public string Mensagem
        {
            get
            {
                return this.LabelMensagem.Text;
            }
            set
            {
                this.LabelMensagem.Text = value;
            }
        }

        public string Titulo
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public int TotalPassos
        {
            get
            {
                return this.ProgressBar.Maximum;
            }
            set
            {
                this.ProgressBar.Maximum = value;
            }
        }

        public int PassoAtual
        {
            get
            {
                return this.ProgressBar.Value;
            }
            set
            {
                this.ProgressBar.Value = value;
            }
        }

        public void OnCancel(Action action)
        {
            this.onCancel = action;
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.onCancel?.Invoke();
            this.ButtonCancelar.Enabled = false;
        }
    }
}