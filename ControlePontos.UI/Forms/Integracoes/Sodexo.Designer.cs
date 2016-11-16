namespace ControlePontos.Forms.Integracoes
{
    partial class Sodexo
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
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.GridSodexo = new System.Windows.Forms.DataGridView();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LayoutInformacoes = new System.Windows.Forms.FlowLayoutPanel();
            this.DataDadosLabelDisplay = new System.Windows.Forms.Label();
            this.DataDadosLabel = new System.Windows.Forms.Label();
            this.Separador6 = new System.Windows.Forms.Label();
            this.NomeLabelDisplay = new System.Windows.Forms.Label();
            this.NomeLabel = new System.Windows.Forms.Label();
            this.Separador1 = new System.Windows.Forms.Label();
            this.EmpresaLabelDisplay = new System.Windows.Forms.Label();
            this.EmpresaLabel = new System.Windows.Forms.Label();
            this.Separador2 = new System.Windows.Forms.Label();
            this.NumeroCartaoLabelDisplay = new System.Windows.Forms.Label();
            this.NumeroCartaoLabel = new System.Windows.Forms.Label();
            this.Separador4 = new System.Windows.Forms.Label();
            this.NumeroCpfLabelDisplay = new System.Windows.Forms.Label();
            this.NumeroCpfLabel = new System.Windows.Forms.Label();
            this.Separador5 = new System.Windows.Forms.Label();
            this.ServicoLabelDisplay = new System.Windows.Forms.Label();
            this.ServicoLabel = new System.Windows.Forms.Label();
            this.Separador7 = new System.Windows.Forms.Label();
            this.StatusLabelDisplay = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.Separador8 = new System.Windows.Forms.Label();
            this.SaldoLabelDisplay = new System.Windows.Forms.Label();
            this.SaldoLabel = new System.Windows.Forms.Label();
            this.TableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridSodexo)).BeginInit();
            this.LayoutInformacoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.25703F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.74296F));
            this.TableLayout.Controls.Add(this.GridSodexo, 0, 0);
            this.TableLayout.Controls.Add(this.LayoutInformacoes, 1, 0);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 1;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayout.Size = new System.Drawing.Size(817, 488);
            this.TableLayout.TabIndex = 0;
            // 
            // GridSodexo
            // 
            this.GridSodexo.AllowUserToAddRows = false;
            this.GridSodexo.AllowUserToDeleteRows = false;
            this.GridSodexo.AllowUserToOrderColumns = true;
            this.GridSodexo.AllowUserToResizeRows = false;
            this.GridSodexo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridSodexo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridSodexo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Tipo,
            this.Descricao,
            this.Valor,
            this.ColunaTotal});
            this.GridSodexo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridSodexo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GridSodexo.Location = new System.Drawing.Point(3, 3);
            this.GridSodexo.MultiSelect = false;
            this.GridSodexo.Name = "GridSodexo";
            this.GridSodexo.ReadOnly = true;
            this.GridSodexo.RowHeadersVisible = false;
            this.GridSodexo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridSodexo.Size = new System.Drawing.Size(567, 482);
            this.GridSodexo.TabIndex = 0;
            // 
            // Data
            // 
            this.Data.FillWeight = 35F;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.FillWeight = 18F;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Descricao
            // 
            this.Descricao.FillWeight = 40F;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.FillWeight = 20F;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // ColunaTotal
            // 
            this.ColunaTotal.HeaderText = "ColunaTotal";
            this.ColunaTotal.Name = "ColunaTotal";
            this.ColunaTotal.ReadOnly = true;
            this.ColunaTotal.Visible = false;
            // 
            // LayoutInformacoes
            // 
            this.LayoutInformacoes.Controls.Add(this.DataDadosLabelDisplay);
            this.LayoutInformacoes.Controls.Add(this.DataDadosLabel);
            this.LayoutInformacoes.Controls.Add(this.Separador6);
            this.LayoutInformacoes.Controls.Add(this.NomeLabelDisplay);
            this.LayoutInformacoes.Controls.Add(this.NomeLabel);
            this.LayoutInformacoes.Controls.Add(this.Separador1);
            this.LayoutInformacoes.Controls.Add(this.EmpresaLabelDisplay);
            this.LayoutInformacoes.Controls.Add(this.EmpresaLabel);
            this.LayoutInformacoes.Controls.Add(this.Separador2);
            this.LayoutInformacoes.Controls.Add(this.NumeroCartaoLabelDisplay);
            this.LayoutInformacoes.Controls.Add(this.NumeroCartaoLabel);
            this.LayoutInformacoes.Controls.Add(this.Separador4);
            this.LayoutInformacoes.Controls.Add(this.NumeroCpfLabelDisplay);
            this.LayoutInformacoes.Controls.Add(this.NumeroCpfLabel);
            this.LayoutInformacoes.Controls.Add(this.Separador5);
            this.LayoutInformacoes.Controls.Add(this.ServicoLabelDisplay);
            this.LayoutInformacoes.Controls.Add(this.ServicoLabel);
            this.LayoutInformacoes.Controls.Add(this.Separador7);
            this.LayoutInformacoes.Controls.Add(this.StatusLabelDisplay);
            this.LayoutInformacoes.Controls.Add(this.StatusLabel);
            this.LayoutInformacoes.Controls.Add(this.Separador8);
            this.LayoutInformacoes.Controls.Add(this.SaldoLabelDisplay);
            this.LayoutInformacoes.Controls.Add(this.SaldoLabel);
            this.LayoutInformacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutInformacoes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.LayoutInformacoes.Location = new System.Drawing.Point(576, 3);
            this.LayoutInformacoes.Name = "LayoutInformacoes";
            this.LayoutInformacoes.Size = new System.Drawing.Size(238, 482);
            this.LayoutInformacoes.TabIndex = 1;
            // 
            // DataDadosLabelDisplay
            // 
            this.DataDadosLabelDisplay.AutoSize = true;
            this.DataDadosLabelDisplay.Location = new System.Drawing.Point(3, 0);
            this.DataDadosLabelDisplay.Name = "DataDadosLabelDisplay";
            this.DataDadosLabelDisplay.Size = new System.Drawing.Size(84, 13);
            this.DataDadosLabelDisplay.TabIndex = 16;
            this.DataDadosLabelDisplay.Text = "Data dos Dados";
            // 
            // DataDadosLabel
            // 
            this.DataDadosLabel.AutoSize = true;
            this.DataDadosLabel.Location = new System.Drawing.Point(3, 13);
            this.DataDadosLabel.Name = "DataDadosLabel";
            this.DataDadosLabel.Size = new System.Drawing.Size(87, 13);
            this.DataDadosLabel.TabIndex = 17;
            this.DataDadosLabel.Text = "DataDadosLabel";
            // 
            // Separador6
            // 
            this.Separador6.AutoSize = true;
            this.Separador6.Cursor = System.Windows.Forms.Cursors.Default;
            this.Separador6.Location = new System.Drawing.Point(3, 26);
            this.Separador6.Name = "Separador6";
            this.Separador6.Size = new System.Drawing.Size(54, 13);
            this.Separador6.TabIndex = 15;
            this.Separador6.Text = "separador";
            // 
            // NomeLabelDisplay
            // 
            this.NomeLabelDisplay.AutoSize = true;
            this.NomeLabelDisplay.Location = new System.Drawing.Point(3, 39);
            this.NomeLabelDisplay.Name = "NomeLabelDisplay";
            this.NomeLabelDisplay.Size = new System.Drawing.Size(35, 13);
            this.NomeLabelDisplay.TabIndex = 0;
            this.NomeLabelDisplay.Text = "Nome";
            // 
            // NomeLabel
            // 
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.Location = new System.Drawing.Point(3, 52);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(61, 13);
            this.NomeLabel.TabIndex = 1;
            this.NomeLabel.Text = "NomeLabel";
            // 
            // Separador1
            // 
            this.Separador1.AutoSize = true;
            this.Separador1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Separador1.Location = new System.Drawing.Point(3, 65);
            this.Separador1.Name = "Separador1";
            this.Separador1.Size = new System.Drawing.Size(54, 13);
            this.Separador1.TabIndex = 2;
            this.Separador1.Text = "separador";
            // 
            // EmpresaLabelDisplay
            // 
            this.EmpresaLabelDisplay.AutoSize = true;
            this.EmpresaLabelDisplay.Location = new System.Drawing.Point(3, 78);
            this.EmpresaLabelDisplay.Name = "EmpresaLabelDisplay";
            this.EmpresaLabelDisplay.Size = new System.Drawing.Size(48, 13);
            this.EmpresaLabelDisplay.TabIndex = 3;
            this.EmpresaLabelDisplay.Text = "Empresa";
            // 
            // EmpresaLabel
            // 
            this.EmpresaLabel.AutoSize = true;
            this.EmpresaLabel.Location = new System.Drawing.Point(3, 91);
            this.EmpresaLabel.Name = "EmpresaLabel";
            this.EmpresaLabel.Size = new System.Drawing.Size(74, 13);
            this.EmpresaLabel.TabIndex = 4;
            this.EmpresaLabel.Text = "EmpresaLabel";
            // 
            // Separador2
            // 
            this.Separador2.AutoSize = true;
            this.Separador2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Separador2.Location = new System.Drawing.Point(3, 104);
            this.Separador2.Name = "Separador2";
            this.Separador2.Size = new System.Drawing.Size(54, 13);
            this.Separador2.TabIndex = 5;
            this.Separador2.Text = "separador";
            // 
            // NumeroCartaoLabelDisplay
            // 
            this.NumeroCartaoLabelDisplay.AutoSize = true;
            this.NumeroCartaoLabelDisplay.Location = new System.Drawing.Point(3, 117);
            this.NumeroCartaoLabelDisplay.Name = "NumeroCartaoLabelDisplay";
            this.NumeroCartaoLabelDisplay.Size = new System.Drawing.Size(93, 13);
            this.NumeroCartaoLabelDisplay.TabIndex = 9;
            this.NumeroCartaoLabelDisplay.Text = "Número do Cartão";
            // 
            // NumeroCartaoLabel
            // 
            this.NumeroCartaoLabel.AutoSize = true;
            this.NumeroCartaoLabel.Location = new System.Drawing.Point(3, 130);
            this.NumeroCartaoLabel.Name = "NumeroCartaoLabel";
            this.NumeroCartaoLabel.Size = new System.Drawing.Size(101, 13);
            this.NumeroCartaoLabel.TabIndex = 10;
            this.NumeroCartaoLabel.Text = "NumeroCartaoLabel";
            // 
            // Separador4
            // 
            this.Separador4.AutoSize = true;
            this.Separador4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Separador4.Location = new System.Drawing.Point(3, 143);
            this.Separador4.Name = "Separador4";
            this.Separador4.Size = new System.Drawing.Size(54, 13);
            this.Separador4.TabIndex = 11;
            this.Separador4.Text = "separador";
            // 
            // NumeroCpfLabelDisplay
            // 
            this.NumeroCpfLabelDisplay.AutoSize = true;
            this.NumeroCpfLabelDisplay.Location = new System.Drawing.Point(3, 156);
            this.NumeroCpfLabelDisplay.Name = "NumeroCpfLabelDisplay";
            this.NumeroCpfLabelDisplay.Size = new System.Drawing.Size(82, 13);
            this.NumeroCpfLabelDisplay.TabIndex = 12;
            this.NumeroCpfLabelDisplay.Text = "Número do CPF";
            // 
            // NumeroCpfLabel
            // 
            this.NumeroCpfLabel.AutoSize = true;
            this.NumeroCpfLabel.Location = new System.Drawing.Point(3, 169);
            this.NumeroCpfLabel.Name = "NumeroCpfLabel";
            this.NumeroCpfLabel.Size = new System.Drawing.Size(86, 13);
            this.NumeroCpfLabel.TabIndex = 13;
            this.NumeroCpfLabel.Text = "NumeroCpfLabel";
            // 
            // Separador5
            // 
            this.Separador5.AutoSize = true;
            this.Separador5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Separador5.Location = new System.Drawing.Point(3, 182);
            this.Separador5.Name = "Separador5";
            this.Separador5.Size = new System.Drawing.Size(54, 13);
            this.Separador5.TabIndex = 14;
            this.Separador5.Text = "separador";
            // 
            // ServicoLabelDisplay
            // 
            this.ServicoLabelDisplay.AutoSize = true;
            this.ServicoLabelDisplay.Location = new System.Drawing.Point(3, 195);
            this.ServicoLabelDisplay.Name = "ServicoLabelDisplay";
            this.ServicoLabelDisplay.Size = new System.Drawing.Size(43, 13);
            this.ServicoLabelDisplay.TabIndex = 18;
            this.ServicoLabelDisplay.Text = "Serviço";
            // 
            // ServicoLabel
            // 
            this.ServicoLabel.AutoSize = true;
            this.ServicoLabel.Location = new System.Drawing.Point(3, 208);
            this.ServicoLabel.Name = "ServicoLabel";
            this.ServicoLabel.Size = new System.Drawing.Size(69, 13);
            this.ServicoLabel.TabIndex = 19;
            this.ServicoLabel.Text = "ServicoLabel";
            // 
            // Separador7
            // 
            this.Separador7.AutoSize = true;
            this.Separador7.Cursor = System.Windows.Forms.Cursors.Default;
            this.Separador7.Location = new System.Drawing.Point(3, 221);
            this.Separador7.Name = "Separador7";
            this.Separador7.Size = new System.Drawing.Size(54, 13);
            this.Separador7.TabIndex = 20;
            this.Separador7.Text = "separador";
            // 
            // StatusLabelDisplay
            // 
            this.StatusLabelDisplay.AutoSize = true;
            this.StatusLabelDisplay.Location = new System.Drawing.Point(3, 234);
            this.StatusLabelDisplay.Name = "StatusLabelDisplay";
            this.StatusLabelDisplay.Size = new System.Drawing.Size(37, 13);
            this.StatusLabelDisplay.TabIndex = 21;
            this.StatusLabelDisplay.Text = "Status";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(3, 247);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(63, 13);
            this.StatusLabel.TabIndex = 22;
            this.StatusLabel.Text = "StatusLabel";
            // 
            // Separador8
            // 
            this.Separador8.AutoSize = true;
            this.Separador8.Cursor = System.Windows.Forms.Cursors.Default;
            this.Separador8.Location = new System.Drawing.Point(3, 260);
            this.Separador8.Name = "Separador8";
            this.Separador8.Size = new System.Drawing.Size(54, 13);
            this.Separador8.TabIndex = 23;
            this.Separador8.Text = "separador";
            // 
            // SaldoLabelDisplay
            // 
            this.SaldoLabelDisplay.AutoSize = true;
            this.SaldoLabelDisplay.Location = new System.Drawing.Point(3, 273);
            this.SaldoLabelDisplay.Name = "SaldoLabelDisplay";
            this.SaldoLabelDisplay.Size = new System.Drawing.Size(34, 13);
            this.SaldoLabelDisplay.TabIndex = 6;
            this.SaldoLabelDisplay.Text = "Saldo";
            // 
            // SaldoLabel
            // 
            this.SaldoLabel.AutoSize = true;
            this.SaldoLabel.Location = new System.Drawing.Point(3, 286);
            this.SaldoLabel.Name = "SaldoLabel";
            this.SaldoLabel.Size = new System.Drawing.Size(60, 13);
            this.SaldoLabel.TabIndex = 7;
            this.SaldoLabel.Text = "SaldoLabel";
            // 
            // Sodexo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 488);
            this.Controls.Add(this.TableLayout);
            this.Name = "Sodexo";
            this.Text = "Sodexo";
            this.Load += new System.EventHandler(this.Sodexo_Load);
            this.TableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridSodexo)).EndInit();
            this.LayoutInformacoes.ResumeLayout(false);
            this.LayoutInformacoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.DataGridView GridSodexo;
        private System.Windows.Forms.FlowLayoutPanel LayoutInformacoes;
        private System.Windows.Forms.Label NomeLabelDisplay;
        private System.Windows.Forms.Label NomeLabel;
        private System.Windows.Forms.Label Separador1;
        private System.Windows.Forms.Label EmpresaLabelDisplay;
        private System.Windows.Forms.Label EmpresaLabel;
        private System.Windows.Forms.Label Separador2;
        private System.Windows.Forms.Label SaldoLabelDisplay;
        private System.Windows.Forms.Label SaldoLabel;
        private System.Windows.Forms.Label NumeroCartaoLabelDisplay;
        private System.Windows.Forms.Label NumeroCartaoLabel;
        private System.Windows.Forms.Label Separador4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaTotal;
        private System.Windows.Forms.Label NumeroCpfLabelDisplay;
        private System.Windows.Forms.Label NumeroCpfLabel;
        private System.Windows.Forms.Label Separador5;
        private System.Windows.Forms.Label DataDadosLabelDisplay;
        private System.Windows.Forms.Label Separador6;
        private System.Windows.Forms.Label DataDadosLabel;
        private System.Windows.Forms.Label ServicoLabelDisplay;
        private System.Windows.Forms.Label ServicoLabel;
        private System.Windows.Forms.Label Separador7;
        private System.Windows.Forms.Label StatusLabelDisplay;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label Separador8;
    }
}