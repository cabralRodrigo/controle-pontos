namespace ControlePontos.Forms.TeamServices
{
    partial class TotalHorasIntegracaoAtual
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LabelStatusAtual = new System.Windows.Forms.ToolStripStatusLabel();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Projeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompletedWork = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelStatusAtual});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(905, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LabelStatusAtual
            // 
            this.LabelStatusAtual.Name = "LabelStatusAtual";
            this.LabelStatusAtual.Size = new System.Drawing.Size(0, 17);
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AllowUserToOrderColumns = true;
            this.Grid.AllowUserToResizeRows = false;
            this.Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Projeto,
            this.CreatedDate,
            this.Title,
            this.State,
            this.CompletedWork});
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Grid.Location = new System.Drawing.Point(0, 0);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.RowHeadersVisible = false;
            this.Grid.Size = new System.Drawing.Size(905, 551);
            this.Grid.TabIndex = 1;
            this.Grid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Grid_CellBeginEdit);
            this.Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellContentClick);
            this.Grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellEndEdit);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.FillWeight = 150.3865F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Projeto
            // 
            this.Projeto.HeaderText = "Projeto";
            this.Projeto.Name = "Projeto";
            this.Projeto.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CreatedDate.FillWeight = 67.23234F;
            this.CreatedDate.HeaderText = "Criação";
            this.CreatedDate.Name = "CreatedDate";
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.FillWeight = 15.15474F;
            this.Title.HeaderText = "Título";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // State
            // 
            this.State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.State.FillWeight = 13.91737F;
            this.State.HeaderText = "Estado";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // CompletedWork
            // 
            this.CompletedWork.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompletedWork.FillWeight = 13.19203F;
            this.CompletedWork.HeaderText = "Horas";
            this.CompletedWork.Name = "CompletedWork";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 346.8154F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Título";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 593;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 74.59609F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 128;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 30.3519F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Horas";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 52;
            // 
            // TotalHorasIntegracaoAtual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 573);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.statusStrip1);
            this.Name = "TotalHorasIntegracaoAtual";
            this.Text = "Total de Horas da Itegração Atual";
            this.Load += new System.EventHandler(this.TotalHorasIntegracaoAtual_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LabelStatusAtual;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewLinkColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Projeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompletedWork;
    }
}