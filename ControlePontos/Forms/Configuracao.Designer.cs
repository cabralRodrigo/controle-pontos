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
            this.Configuracao_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Configuracao_ButtonSalvar = new System.Windows.Forms.Button();
            this.Configuracao_TabControl = new System.Windows.Forms.TabControl();
            this.Feriados_Tab = new System.Windows.Forms.TabPage();
            this.Feriados_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Feriados_Calendar = new System.Windows.Forms.MonthCalendar();
            this.Feriados_ButtonAdd = new System.Windows.Forms.Button();
            this.Feriados_ListBoxFeriados = new System.Windows.Forms.ListBox();
            this.Feriados_ButtonRemove = new System.Windows.Forms.Button();
            this.Feriados_Label = new System.Windows.Forms.Label();
            this.Ferias_Tab = new System.Windows.Forms.TabPage();
            this.Ferias_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Ferias_Calendar = new System.Windows.Forms.MonthCalendar();
            this.Ferias_ButtonAdd = new System.Windows.Forms.Button();
            this.Ferias_ListBoxFerias = new System.Windows.Forms.ListBox();
            this.Ferias_ButtonRemove = new System.Windows.Forms.Button();
            this.Ferias_Label = new System.Windows.Forms.Label();
            this.Backup_Tab = new System.Windows.Forms.TabPage();
            this.Backup_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Backup_ListBoxDiretorios = new System.Windows.Forms.ListBox();
            this.Backup_Label = new System.Windows.Forms.Label();
            this.Backup_ButtonAdd = new System.Windows.Forms.Button();
            this.Backup_ButtonRemove = new System.Windows.Forms.Button();
            this.Configuracao_Layout.SuspendLayout();
            this.Configuracao_TabControl.SuspendLayout();
            this.Feriados_Tab.SuspendLayout();
            this.Feriados_Layout.SuspendLayout();
            this.Ferias_Tab.SuspendLayout();
            this.Ferias_Layout.SuspendLayout();
            this.Backup_Tab.SuspendLayout();
            this.Backup_Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // Configuracao_Layout
            // 
            this.Configuracao_Layout.ColumnCount = 1;
            this.Configuracao_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Configuracao_Layout.Controls.Add(this.Configuracao_ButtonSalvar, 0, 1);
            this.Configuracao_Layout.Controls.Add(this.Configuracao_TabControl, 0, 0);
            this.Configuracao_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Configuracao_Layout.Location = new System.Drawing.Point(0, 0);
            this.Configuracao_Layout.Name = "Configuracao_Layout";
            this.Configuracao_Layout.RowCount = 2;
            this.Configuracao_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Configuracao_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.Configuracao_Layout.Size = new System.Drawing.Size(541, 358);
            this.Configuracao_Layout.TabIndex = 0;
            // 
            // Configuracao_ButtonSalvar
            // 
            this.Configuracao_ButtonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Configuracao_ButtonSalvar.Location = new System.Drawing.Point(463, 331);
            this.Configuracao_ButtonSalvar.Name = "Configuracao_ButtonSalvar";
            this.Configuracao_ButtonSalvar.Size = new System.Drawing.Size(75, 23);
            this.Configuracao_ButtonSalvar.TabIndex = 0;
            this.Configuracao_ButtonSalvar.Text = "Salvar";
            this.Configuracao_ButtonSalvar.UseVisualStyleBackColor = true;
            this.Configuracao_ButtonSalvar.Click += new System.EventHandler(this.ButtonSalvar_Click);
            // 
            // Configuracao_TabControl
            // 
            this.Configuracao_TabControl.Controls.Add(this.Feriados_Tab);
            this.Configuracao_TabControl.Controls.Add(this.Ferias_Tab);
            this.Configuracao_TabControl.Controls.Add(this.Backup_Tab);
            this.Configuracao_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Configuracao_TabControl.Location = new System.Drawing.Point(3, 3);
            this.Configuracao_TabControl.Name = "Configuracao_TabControl";
            this.Configuracao_TabControl.SelectedIndex = 0;
            this.Configuracao_TabControl.Size = new System.Drawing.Size(535, 322);
            this.Configuracao_TabControl.TabIndex = 1;
            // 
            // Feriados_Tab
            // 
            this.Feriados_Tab.Controls.Add(this.Feriados_Layout);
            this.Feriados_Tab.Location = new System.Drawing.Point(4, 22);
            this.Feriados_Tab.Name = "Feriados_Tab";
            this.Feriados_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Feriados_Tab.Size = new System.Drawing.Size(527, 296);
            this.Feriados_Tab.TabIndex = 1;
            this.Feriados_Tab.Text = "Feriados";
            this.Feriados_Tab.UseVisualStyleBackColor = true;
            // 
            // Feriados_Layout
            // 
            this.Feriados_Layout.ColumnCount = 3;
            this.Feriados_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Feriados_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.Feriados_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.Feriados_Layout.Controls.Add(this.Feriados_Calendar, 1, 1);
            this.Feriados_Layout.Controls.Add(this.Feriados_ButtonAdd, 1, 2);
            this.Feriados_Layout.Controls.Add(this.Feriados_ListBoxFeriados, 0, 1);
            this.Feriados_Layout.Controls.Add(this.Feriados_ButtonRemove, 2, 2);
            this.Feriados_Layout.Controls.Add(this.Feriados_Label, 0, 0);
            this.Feriados_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Feriados_Layout.Location = new System.Drawing.Point(3, 3);
            this.Feriados_Layout.Name = "Feriados_Layout";
            this.Feriados_Layout.RowCount = 3;
            this.Feriados_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Feriados_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.Feriados_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Feriados_Layout.Size = new System.Drawing.Size(521, 290);
            this.Feriados_Layout.TabIndex = 0;
            // 
            // Feriados_Calendar
            // 
            this.Feriados_Calendar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Feriados_Layout.SetColumnSpan(this.Feriados_Calendar, 2);
            this.Feriados_Calendar.Location = new System.Drawing.Point(290, 29);
            this.Feriados_Calendar.MaxSelectionCount = 1;
            this.Feriados_Calendar.Name = "Feriados_Calendar";
            this.Feriados_Calendar.TabIndex = 0;
            this.Feriados_Calendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.Feriados_Calendar_DateSelected);
            // 
            // Feriados_ButtonAdd
            // 
            this.Feriados_ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Feriados_ButtonAdd.BackgroundImage = global::ControlePontos.Properties.Resources.add;
            this.Feriados_ButtonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Feriados_ButtonAdd.Location = new System.Drawing.Point(368, 197);
            this.Feriados_ButtonAdd.Name = "Feriados_ButtonAdd";
            this.Feriados_ButtonAdd.Size = new System.Drawing.Size(30, 30);
            this.Feriados_ButtonAdd.TabIndex = 3;
            this.Feriados_ButtonAdd.UseVisualStyleBackColor = true;
            this.Feriados_ButtonAdd.Click += new System.EventHandler(this.Feriados_ButtonAdd_Click);
            // 
            // Feriados_ListBoxFeriados
            // 
            this.Feriados_ListBoxFeriados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Feriados_ListBoxFeriados.FormattingEnabled = true;
            this.Feriados_ListBoxFeriados.Location = new System.Drawing.Point(3, 23);
            this.Feriados_ListBoxFeriados.Name = "Feriados_ListBoxFeriados";
            this.Feriados_Layout.SetRowSpan(this.Feriados_ListBoxFeriados, 2);
            this.Feriados_ListBoxFeriados.Size = new System.Drawing.Size(275, 264);
            this.Feriados_ListBoxFeriados.TabIndex = 4;
            this.Feriados_ListBoxFeriados.SelectedIndexChanged += new System.EventHandler(this.Feriados_ListBoxFeriados_SelectedIndexChanged);
            // 
            // Feriados_ButtonRemove
            // 
            this.Feriados_ButtonRemove.BackgroundImage = global::ControlePontos.Properties.Resources.delete;
            this.Feriados_ButtonRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Feriados_ButtonRemove.Location = new System.Drawing.Point(404, 197);
            this.Feriados_ButtonRemove.Name = "Feriados_ButtonRemove";
            this.Feriados_ButtonRemove.Size = new System.Drawing.Size(30, 30);
            this.Feriados_ButtonRemove.TabIndex = 5;
            this.Feriados_ButtonRemove.UseVisualStyleBackColor = true;
            this.Feriados_ButtonRemove.Click += new System.EventHandler(this.Feriados_ButtonRemove_Click);
            // 
            // Feriados_Label
            // 
            this.Feriados_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Feriados_Label.AutoSize = true;
            this.Feriados_Label.Location = new System.Drawing.Point(3, 7);
            this.Feriados_Label.Name = "Feriados_Label";
            this.Feriados_Label.Size = new System.Drawing.Size(267, 13);
            this.Feriados_Label.TabIndex = 6;
            this.Feriados_Label.Text = "Use o calendário para adicionar feriados na lista abaixo";
            // 
            // Ferias_Tab
            // 
            this.Ferias_Tab.Controls.Add(this.Ferias_Layout);
            this.Ferias_Tab.Location = new System.Drawing.Point(4, 22);
            this.Ferias_Tab.Name = "Ferias_Tab";
            this.Ferias_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Ferias_Tab.Size = new System.Drawing.Size(527, 296);
            this.Ferias_Tab.TabIndex = 2;
            this.Ferias_Tab.Text = "Férias";
            this.Ferias_Tab.UseVisualStyleBackColor = true;
            // 
            // Ferias_Layout
            // 
            this.Ferias_Layout.ColumnCount = 3;
            this.Ferias_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Ferias_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.Ferias_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.Ferias_Layout.Controls.Add(this.Ferias_Calendar, 1, 1);
            this.Ferias_Layout.Controls.Add(this.Ferias_ButtonAdd, 1, 2);
            this.Ferias_Layout.Controls.Add(this.Ferias_ListBoxFerias, 0, 1);
            this.Ferias_Layout.Controls.Add(this.Ferias_ButtonRemove, 2, 2);
            this.Ferias_Layout.Controls.Add(this.Ferias_Label, 0, 0);
            this.Ferias_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ferias_Layout.Location = new System.Drawing.Point(3, 3);
            this.Ferias_Layout.Name = "Ferias_Layout";
            this.Ferias_Layout.RowCount = 3;
            this.Ferias_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Ferias_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.Ferias_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Ferias_Layout.Size = new System.Drawing.Size(521, 290);
            this.Ferias_Layout.TabIndex = 1;
            // 
            // Ferias_Calendar
            // 
            this.Ferias_Calendar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Ferias_Layout.SetColumnSpan(this.Ferias_Calendar, 2);
            this.Ferias_Calendar.Location = new System.Drawing.Point(290, 29);
            this.Ferias_Calendar.MaxSelectionCount = 31;
            this.Ferias_Calendar.Name = "Ferias_Calendar";
            this.Ferias_Calendar.TabIndex = 0;
            this.Ferias_Calendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.Ferias_Calendar_DateSelected);
            // 
            // Ferias_ButtonAdd
            // 
            this.Ferias_ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ferias_ButtonAdd.BackgroundImage = global::ControlePontos.Properties.Resources.add;
            this.Ferias_ButtonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Ferias_ButtonAdd.Location = new System.Drawing.Point(368, 197);
            this.Ferias_ButtonAdd.Name = "Ferias_ButtonAdd";
            this.Ferias_ButtonAdd.Size = new System.Drawing.Size(30, 30);
            this.Ferias_ButtonAdd.TabIndex = 3;
            this.Ferias_ButtonAdd.UseVisualStyleBackColor = true;
            this.Ferias_ButtonAdd.Click += new System.EventHandler(this.Ferias_ButtonAdd_Click);
            // 
            // Ferias_ListBoxFerias
            // 
            this.Ferias_ListBoxFerias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ferias_ListBoxFerias.FormattingEnabled = true;
            this.Ferias_ListBoxFerias.Location = new System.Drawing.Point(3, 23);
            this.Ferias_ListBoxFerias.Name = "Ferias_ListBoxFerias";
            this.Ferias_Layout.SetRowSpan(this.Ferias_ListBoxFerias, 2);
            this.Ferias_ListBoxFerias.Size = new System.Drawing.Size(275, 264);
            this.Ferias_ListBoxFerias.TabIndex = 4;
            this.Ferias_ListBoxFerias.SelectedIndexChanged += new System.EventHandler(this.Ferias_ListBoxFerias_SelectedIndexChanged);
            // 
            // Ferias_ButtonRemove
            // 
            this.Ferias_ButtonRemove.BackgroundImage = global::ControlePontos.Properties.Resources.delete;
            this.Ferias_ButtonRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Ferias_ButtonRemove.Location = new System.Drawing.Point(404, 197);
            this.Ferias_ButtonRemove.Name = "Ferias_ButtonRemove";
            this.Ferias_ButtonRemove.Size = new System.Drawing.Size(30, 30);
            this.Ferias_ButtonRemove.TabIndex = 5;
            this.Ferias_ButtonRemove.UseVisualStyleBackColor = true;
            this.Ferias_ButtonRemove.Click += new System.EventHandler(this.Ferias_ButtonRemove_Click);
            // 
            // Ferias_Label
            // 
            this.Ferias_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ferias_Label.AutoSize = true;
            this.Ferias_Label.Location = new System.Drawing.Point(3, 7);
            this.Ferias_Label.Name = "Ferias_Label";
            this.Ferias_Label.Size = new System.Drawing.Size(258, 13);
            this.Ferias_Label.TabIndex = 6;
            this.Ferias_Label.Text = "Use o calendário para adicionar dias de férias na lista";
            // 
            // Backup_Tab
            // 
            this.Backup_Tab.Controls.Add(this.Backup_Layout);
            this.Backup_Tab.Location = new System.Drawing.Point(4, 22);
            this.Backup_Tab.Name = "Backup_Tab";
            this.Backup_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Backup_Tab.Size = new System.Drawing.Size(527, 296);
            this.Backup_Tab.TabIndex = 0;
            this.Backup_Tab.Text = "Backup";
            this.Backup_Tab.UseVisualStyleBackColor = true;
            // 
            // Backup_Layout
            // 
            this.Backup_Layout.ColumnCount = 2;
            this.Backup_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Backup_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Backup_Layout.Controls.Add(this.Backup_ListBoxDiretorios, 0, 1);
            this.Backup_Layout.Controls.Add(this.Backup_Label, 0, 0);
            this.Backup_Layout.Controls.Add(this.Backup_ButtonAdd, 1, 1);
            this.Backup_Layout.Controls.Add(this.Backup_ButtonRemove, 1, 2);
            this.Backup_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Backup_Layout.Location = new System.Drawing.Point(3, 3);
            this.Backup_Layout.Name = "Backup_Layout";
            this.Backup_Layout.RowCount = 3;
            this.Backup_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Backup_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.Backup_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.Backup_Layout.Size = new System.Drawing.Size(521, 290);
            this.Backup_Layout.TabIndex = 0;
            // 
            // Backup_ListBoxDiretorios
            // 
            this.Backup_ListBoxDiretorios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Backup_ListBoxDiretorios.FormattingEnabled = true;
            this.Backup_ListBoxDiretorios.Location = new System.Drawing.Point(3, 23);
            this.Backup_ListBoxDiretorios.Name = "Backup_ListBoxDiretorios";
            this.Backup_Layout.SetRowSpan(this.Backup_ListBoxDiretorios, 2);
            this.Backup_ListBoxDiretorios.Size = new System.Drawing.Size(479, 264);
            this.Backup_ListBoxDiretorios.TabIndex = 0;
            // 
            // Backup_Label
            // 
            this.Backup_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Backup_Label.AutoSize = true;
            this.Backup_Label.Location = new System.Drawing.Point(3, 7);
            this.Backup_Label.Name = "Backup_Label";
            this.Backup_Label.Size = new System.Drawing.Size(366, 13);
            this.Backup_Label.TabIndex = 1;
            this.Backup_Label.Text = "Inclua na lista abaixo os diretórios onde o backup diário dos dados será feito";
            // 
            // Backup_ButtonAdd
            // 
            this.Backup_ButtonAdd.BackgroundImage = global::ControlePontos.Properties.Resources.add;
            this.Backup_ButtonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Backup_ButtonAdd.Location = new System.Drawing.Point(488, 23);
            this.Backup_ButtonAdd.Name = "Backup_ButtonAdd";
            this.Backup_ButtonAdd.Size = new System.Drawing.Size(30, 30);
            this.Backup_ButtonAdd.TabIndex = 2;
            this.Backup_ButtonAdd.UseVisualStyleBackColor = true;
            this.Backup_ButtonAdd.Click += new System.EventHandler(this.Backup_ButtonAdd_Click);
            // 
            // Backup_ButtonRemove
            // 
            this.Backup_ButtonRemove.BackgroundImage = global::ControlePontos.Properties.Resources.delete;
            this.Backup_ButtonRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Backup_ButtonRemove.Location = new System.Drawing.Point(488, 61);
            this.Backup_ButtonRemove.Name = "Backup_ButtonRemove";
            this.Backup_ButtonRemove.Size = new System.Drawing.Size(30, 30);
            this.Backup_ButtonRemove.TabIndex = 3;
            this.Backup_ButtonRemove.UseVisualStyleBackColor = true;
            this.Backup_ButtonRemove.Click += new System.EventHandler(this.Backup_ButtonRemove_Click);
            // 
            // Configuracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 358);
            this.Controls.Add(this.Configuracao_Layout);
            this.Name = "Configuracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.Configuracao_Load);
            this.Configuracao_Layout.ResumeLayout(false);
            this.Configuracao_TabControl.ResumeLayout(false);
            this.Feriados_Tab.ResumeLayout(false);
            this.Feriados_Layout.ResumeLayout(false);
            this.Feriados_Layout.PerformLayout();
            this.Ferias_Tab.ResumeLayout(false);
            this.Ferias_Layout.ResumeLayout(false);
            this.Ferias_Layout.PerformLayout();
            this.Backup_Tab.ResumeLayout(false);
            this.Backup_Layout.ResumeLayout(false);
            this.Backup_Layout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Configuracao_ButtonSalvar;
        private System.Windows.Forms.TabControl Configuracao_TabControl;
        private System.Windows.Forms.TableLayoutPanel Configuracao_Layout;

        private System.Windows.Forms.Button Backup_ButtonAdd;
        private System.Windows.Forms.Button Backup_ButtonRemove;
        private System.Windows.Forms.Label Backup_Label;
        private System.Windows.Forms.ListBox Backup_ListBoxDiretorios;
        private System.Windows.Forms.TableLayoutPanel Backup_Layout;
        private System.Windows.Forms.TabPage Backup_Tab;

        private System.Windows.Forms.Button Feriados_ButtonAdd;
        private System.Windows.Forms.Button Feriados_ButtonRemove;
        private System.Windows.Forms.Label Feriados_Label;
        private System.Windows.Forms.ListBox Feriados_ListBoxFeriados;
        private System.Windows.Forms.MonthCalendar Feriados_Calendar;
        private System.Windows.Forms.TableLayoutPanel Feriados_Layout;
        private System.Windows.Forms.TabPage Feriados_Tab;

        private System.Windows.Forms.Button Ferias_ButtonAdd;
        private System.Windows.Forms.Button Ferias_ButtonRemove;
        private System.Windows.Forms.Label Ferias_Label;
        private System.Windows.Forms.ListBox Ferias_ListBoxFerias;
        private System.Windows.Forms.MonthCalendar Ferias_Calendar;
        private System.Windows.Forms.TableLayoutPanel Ferias_Layout;
        private System.Windows.Forms.TabPage Ferias_Tab;
    }
}