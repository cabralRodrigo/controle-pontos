using System.Windows.Forms;

namespace ControlePontos.Forms
{
    internal class BaseForm : Form
    {
        public BaseForm()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}