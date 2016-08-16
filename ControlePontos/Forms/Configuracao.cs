using ControlePontos.Configuracao;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ControlePontos.Forms
{
    public partial class Configuracao : Form
    {
        public Configuracao()
        {
            InitializeComponent();
        }

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

        private void Configuracao_Load(object sender, EventArgs e)
        {
            this.tab_backup_lstDiretorioBackup.Items.AddRange(ConfigBackup.Carregar().Diretorios.ToArray());
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ConfigBackup.Salvar(new ConfigBackup(this.tab_backup_lstDiretorioBackup.Items.Cast<string>().ToArray()));

            this.Close();
        }
    }
}