namespace ControlePontos.Forms
{
    partial class Configuracao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tab_backup = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tab_backup_lstDiretorioBackup = new System.Windows.Forms.ListBox();
            this.tab_backup_lblBackup = new System.Windows.Forms.Label();
            this.tab_backup_btnAdd = new System.Windows.Forms.Button();
            this.tab_backup_btnRemove = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tab_backup.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnSalvar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabs, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(627, 367);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalvar.Location = new System.Drawing.Point(549, 340);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tab_backup);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(3, 3);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(621, 331);
            this.tabs.TabIndex = 1;
            // 
            // tab_backup
            // 
            this.tab_backup.Controls.Add(this.tableLayoutPanel2);
            this.tab_backup.Location = new System.Drawing.Point(4, 22);
            this.tab_backup.Name = "tab_backup";
            this.tab_backup.Padding = new System.Windows.Forms.Padding(3);
            this.tab_backup.Size = new System.Drawing.Size(613, 305);
            this.tab_backup.TabIndex = 0;
            this.tab_backup.Text = "Backup";
            this.tab_backup.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tab_backup_lstDiretorioBackup, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tab_backup_lblBackup, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tab_backup_btnAdd, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tab_backup_btnRemove, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(607, 299);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tab_backup_lstDiretorioBackup
            // 
            this.tab_backup_lstDiretorioBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_backup_lstDiretorioBackup.FormattingEnabled = true;
            this.tab_backup_lstDiretorioBackup.Location = new System.Drawing.Point(3, 23);
            this.tab_backup_lstDiretorioBackup.Name = "tab_backup_lstDiretorioBackup";
            this.tableLayoutPanel2.SetRowSpan(this.tab_backup_lstDiretorioBackup, 2);
            this.tab_backup_lstDiretorioBackup.Size = new System.Drawing.Size(565, 273);
            this.tab_backup_lstDiretorioBackup.TabIndex = 0;
            // 
            // tab_backup_lblBackup
            // 
            this.tab_backup_lblBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tab_backup_lblBackup.AutoSize = true;
            this.tab_backup_lblBackup.Location = new System.Drawing.Point(3, 7);
            this.tab_backup_lblBackup.Name = "tab_backup_lblBackup";
            this.tab_backup_lblBackup.Size = new System.Drawing.Size(366, 13);
            this.tab_backup_lblBackup.TabIndex = 1;
            this.tab_backup_lblBackup.Text = "Inclua na lista abaixo os diretórios onde o backup diário dos dados será feito";
            // 
            // tab_backup_btnAdd
            // 
            this.tab_backup_btnAdd.BackgroundImage = global::ControlePontos.Properties.Resources.add;
            this.tab_backup_btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tab_backup_btnAdd.Location = new System.Drawing.Point(574, 23);
            this.tab_backup_btnAdd.Name = "tab_backup_btnAdd";
            this.tab_backup_btnAdd.Size = new System.Drawing.Size(30, 30);
            this.tab_backup_btnAdd.TabIndex = 2;
            this.tab_backup_btnAdd.UseVisualStyleBackColor = true;
            this.tab_backup_btnAdd.Click += new System.EventHandler(this.tab_backup_btnAdd_Click);
            // 
            // tab_backup_btnRemove
            // 
            this.tab_backup_btnRemove.BackgroundImage = global::ControlePontos.Properties.Resources.delete;
            this.tab_backup_btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tab_backup_btnRemove.Location = new System.Drawing.Point(574, 61);
            this.tab_backup_btnRemove.Name = "tab_backup_btnRemove";
            this.tab_backup_btnRemove.Size = new System.Drawing.Size(30, 30);
            this.tab_backup_btnRemove.TabIndex = 3;
            this.tab_backup_btnRemove.UseVisualStyleBackColor = true;
            this.tab_backup_btnRemove.Click += new System.EventHandler(this.tab_backup_btnRemove_Click);
            // 
            // Configuracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 367);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Configuracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.Configuracao_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tab_backup.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tab_backup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox tab_backup_lstDiretorioBackup;
        private System.Windows.Forms.Label tab_backup_lblBackup;
        private System.Windows.Forms.Button tab_backup_btnAdd;
        private System.Windows.Forms.Button tab_backup_btnRemove;
    }
}