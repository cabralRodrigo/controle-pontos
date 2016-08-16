namespace ControlePontos.Dialog
{
    partial class MonthPicker
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
            this.lstMeses = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lstAnos = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lstMeses, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lstAnos, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(298, 96);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lstMeses
            // 
            this.lstMeses.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lstMeses.DisplayMember = "Descricao";
            this.lstMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstMeses.FormattingEnabled = true;
            this.lstMeses.Location = new System.Drawing.Point(23, 23);
            this.lstMeses.Name = "lstMeses";
            this.lstMeses.Size = new System.Drawing.Size(121, 21);
            this.lstMeses.TabIndex = 1;
            this.lstMeses.ValueMember = "Valor";
            this.lstMeses.SelectedIndexChanged += new System.EventHandler(this.lstMeses_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOK.Location = new System.Drawing.Point(69, 50);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lstAnos
            // 
            this.lstAnos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstAnos.DisplayMember = "Descricao";
            this.lstAnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstAnos.FormattingEnabled = true;
            this.lstAnos.Location = new System.Drawing.Point(150, 23);
            this.lstAnos.Name = "lstAnos";
            this.lstAnos.Size = new System.Drawing.Size(121, 21);
            this.lstAnos.TabIndex = 2;
            this.lstAnos.ValueMember = "Valor";
            this.lstAnos.SelectedIndexChanged += new System.EventHandler(this.lstAnos_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(150, 50);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // MonthPicker
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(298, 96);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonthPicker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selecione o mês e ano";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MonthPicker_KeyUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox lstAnos;
        private System.Windows.Forms.ComboBox lstMeses;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOK;
    }
}