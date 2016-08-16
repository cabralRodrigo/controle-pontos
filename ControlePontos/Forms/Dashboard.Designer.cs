namespace ControlePontos.Forms
{
    internal partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblAlmocoSaida = new System.Windows.Forms.Label();
            this.lblAlmocoRetorno = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMediaTempoAlmoco = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMesAno = new System.Windows.Forms.Button();
            this.gridDias = new ControlePontos.Control.DiaTrabalhoDataGridView();
              this.lblCoeficiente = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblMediaEntrada = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMediaSaida = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMediaValorAlmoco = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblValorTotalTR = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblValorIdealDiario = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.txtSodexo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCoeficientePorDia = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menu_relatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dados = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dados_importar = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dados_importar_zip = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dados_importar_drive = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dados_exportar = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dados_exportar_zip = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dados_exportar_drive = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dados_importarCoeficiente = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_configuracoes = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblVersao = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menu_dados_realizarBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDias)).BeginInit();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(1217, 20);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(87, 13);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "Total Coeficiente";
            // 
            // lblAlmocoSaida
            // 
            this.lblAlmocoSaida.AutoSize = true;
            this.lblAlmocoSaida.Location = new System.Drawing.Point(1217, 217);
            this.lblAlmocoSaida.Name = "lblAlmocoSaida";
            this.lblAlmocoSaida.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAlmocoSaida.Size = new System.Drawing.Size(79, 13);
            this.lblAlmocoSaida.TabIndex = 9;
            this.lblAlmocoSaida.Text = "lblAlmocoSaida";
            // 
            // lblAlmocoRetorno
            // 
            this.lblAlmocoRetorno.AutoSize = true;
            this.lblAlmocoRetorno.Location = new System.Drawing.Point(1217, 263);
            this.lblAlmocoRetorno.Name = "lblAlmocoRetorno";
            this.lblAlmocoRetorno.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAlmocoRetorno.Size = new System.Drawing.Size(90, 13);
            this.lblAlmocoRetorno.TabIndex = 11;
            this.lblAlmocoRetorno.Text = "lblAlmocoRetorno";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1217, 250);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Média Almoço Retorno";
            // 
            // lblMediaTempoAlmoco
            // 
            this.lblMediaTempoAlmoco.AutoSize = true;
            this.lblMediaTempoAlmoco.Location = new System.Drawing.Point(1217, 309);
            this.lblMediaTempoAlmoco.Name = "lblMediaTempoAlmoco";
            this.lblMediaTempoAlmoco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMediaTempoAlmoco.Size = new System.Drawing.Size(114, 13);
            this.lblMediaTempoAlmoco.TabIndex = 13;
            this.lblMediaTempoAlmoco.Text = "lblMediaTempoAlmoco";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1217, 296);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Média Tempo Almoço";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.Controls.Add(this.btnMesAno, 0, 38);
            this.tableLayoutPanel1.Controls.Add(this.gridDias, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 19);
            this.tableLayoutPanel1.Controls.Add(this.lblCoeficiente, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAlmocoRetorno, 1, 17);
            this.tableLayoutPanel1.Controls.Add(this.lbl2, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.lblMediaEntrada, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblAlmocoSaida, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblMediaSaida, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.lblMediaTempoAlmoco, 1, 20);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 22);
            this.tableLayoutPanel1.Controls.Add(this.lblMediaValorAlmoco, 1, 23);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 25);
            this.tableLayoutPanel1.Controls.Add(this.lblValorTotalTR, 1, 26);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 28);
            this.tableLayoutPanel1.Controls.Add(this.lblValorIdealDiario, 1, 29);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 31);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 34);
            this.tableLayoutPanel1.Controls.Add(this.txtOffset, 1, 32);
            this.tableLayoutPanel1.Controls.Add(this.txtSodexo, 1, 35);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCoeficientePorDia, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 39;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1354, 729);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // btnMesAno
            // 
            this.btnMesAno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMesAno.Location = new System.Drawing.Point(1217, 683);
            this.btnMesAno.Name = "btnMesAno";
            this.btnMesAno.Size = new System.Drawing.Size(134, 23);
            this.btnMesAno.TabIndex = 28;
            this.btnMesAno.Text = "Novembro de 2016";
            this.btnMesAno.UseVisualStyleBackColor = true;
            this.btnMesAno.Click += new System.EventHandler(this.btnMesAno_Click);
            // 
            // lblCoeficiente
            // 
            this.lblCoeficiente.AutoSize = true;
            this.lblCoeficiente.Location = new System.Drawing.Point(1217, 33);
            this.lblCoeficiente.Name = "lblCoeficiente";
            this.lblCoeficiente.Size = new System.Drawing.Size(70, 13);
            this.lblCoeficiente.TabIndex = 4;
            this.lblCoeficiente.Text = "lblCoeficiente";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(1217, 112);
            this.lbl2.Name = "lbl2";
            this.lbl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl2.Size = new System.Drawing.Size(76, 13);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = "Média Entrada";
            // 
            // lblMediaEntrada
            // 
            this.lblMediaEntrada.AutoSize = true;
            this.lblMediaEntrada.Location = new System.Drawing.Point(1217, 125);
            this.lblMediaEntrada.Name = "lblMediaEntrada";
            this.lblMediaEntrada.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMediaEntrada.Size = new System.Drawing.Size(83, 13);
            this.lblMediaEntrada.TabIndex = 6;
            this.lblMediaEntrada.Text = "lblMediaEntrada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1217, 158);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Média Saida";
            // 
            // lblMediaSaida
            // 
            this.lblMediaSaida.AutoSize = true;
            this.lblMediaSaida.Location = new System.Drawing.Point(1217, 171);
            this.lblMediaSaida.Name = "lblMediaSaida";
            this.lblMediaSaida.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMediaSaida.Size = new System.Drawing.Size(73, 13);
            this.lblMediaSaida.TabIndex = 8;
            this.lblMediaSaida.Text = "lblMediaSaida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1217, 204);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Média Almoco Saida";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1217, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Média do Valor Almoço";
            // 
            // lblMediaValorAlmoco
            // 
            this.lblMediaValorAlmoco.AutoSize = true;
            this.lblMediaValorAlmoco.Location = new System.Drawing.Point(1217, 355);
            this.lblMediaValorAlmoco.Name = "lblMediaValorAlmoco";
            this.lblMediaValorAlmoco.Size = new System.Drawing.Size(105, 13);
            this.lblMediaValorAlmoco.TabIndex = 18;
            this.lblMediaValorAlmoco.Text = "lblMediaValorAlmoco";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1217, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Valor Restante no TR";
            // 
            // lblValorTotalTR
            // 
            this.lblValorTotalTR.AutoSize = true;
            this.lblValorTotalTR.Location = new System.Drawing.Point(1217, 401);
            this.lblValorTotalTR.Name = "lblValorTotalTR";
            this.lblValorTotalTR.Size = new System.Drawing.Size(80, 13);
            this.lblValorTotalTR.TabIndex = 20;
            this.lblValorTotalTR.Text = "lblValorTotalTR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1217, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Valor Ideal Diário";
            // 
            // lblValorIdealDiario
            // 
            this.lblValorIdealDiario.AutoSize = true;
            this.lblValorIdealDiario.Location = new System.Drawing.Point(1217, 447);
            this.lblValorIdealDiario.Name = "lblValorIdealDiario";
            this.lblValorIdealDiario.Size = new System.Drawing.Size(91, 13);
            this.lblValorIdealDiario.TabIndex = 22;
            this.lblValorIdealDiario.Text = "lblValorIdealDiario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1217, 480);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Offset Coeficiênte (min)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1217, 539);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Valor Sodexo Mês (R$)";
            // 
            // txtOffset
            // 
            this.txtOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOffset.Location = new System.Drawing.Point(1217, 496);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(134, 20);
            this.txtOffset.TabIndex = 25;
            this.txtOffset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOffset_KeyDown);
            this.txtOffset.Leave += new System.EventHandler(this.txtOffset_Leave);
            // 
            // txtSodexo
            // 
            this.txtSodexo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSodexo.Location = new System.Drawing.Point(1217, 555);
            this.txtSodexo.Name = "txtSodexo";
            this.txtSodexo.Size = new System.Drawing.Size(134, 20);
            this.txtSodexo.TabIndex = 26;
            this.txtSodexo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSodexo_KeyDown);
            this.txtSodexo.Leave += new System.EventHandler(this.txtSodexo_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1217, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Coeficiente/Dia";
            // 
            // lblCoeficientePorDia
            // 
            this.lblCoeficientePorDia.AutoSize = true;
            this.lblCoeficientePorDia.Location = new System.Drawing.Point(1217, 79);
            this.lblCoeficientePorDia.Name = "lblCoeficientePorDia";
            this.lblCoeficientePorDia.Size = new System.Drawing.Size(102, 13);
            this.lblCoeficientePorDia.TabIndex = 30;
            this.lblCoeficientePorDia.Text = "lblCoeficientePorDia";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_relatorio,
            this.menu_dados,
            this.menu_configuracoes});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1354, 24);
            this.menu.TabIndex = 15;
            this.menu.Text = "menuStrip1";
            // 
            // menu_relatorio
            // 
            this.menu_relatorio.Name = "menu_relatorio";
            this.menu_relatorio.Size = new System.Drawing.Size(66, 20);
            this.menu_relatorio.Text = "Relatório";
            // 
            // menu_dados
            // 
            this.menu_dados.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_dados_importar,
            this.menu_dados_exportar,
            this.menu_dados_importarCoeficiente,
            this.menu_dados_realizarBackup});
            this.menu_dados.Name = "menu_dados";
            this.menu_dados.Size = new System.Drawing.Size(52, 20);
            this.menu_dados.Text = "Dados";
            // 
            // menu_dados_importar
            // 
            this.menu_dados_importar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_dados_importar_zip,
            this.menu_dados_importar_drive});
            this.menu_dados_importar.Name = "menu_dados_importar";
            this.menu_dados_importar.Size = new System.Drawing.Size(183, 22);
            this.menu_dados_importar.Text = "Importar";
            // 
            // menu_dados_importar_zip
            // 
            this.menu_dados_importar_zip.Name = "menu_dados_importar_zip";
            this.menu_dados_importar_zip.Size = new System.Drawing.Size(142, 22);
            this.menu_dados_importar_zip.Text = "Arquivo Zip";
            // 
            // menu_dados_importar_drive
            // 
            this.menu_dados_importar_drive.Name = "menu_dados_importar_drive";
            this.menu_dados_importar_drive.Size = new System.Drawing.Size(142, 22);
            this.menu_dados_importar_drive.Text = "Google Drive";
            // 
            // menu_dados_exportar
            // 
            this.menu_dados_exportar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_dados_exportar_zip,
            this.menu_dados_exportar_drive});
            this.menu_dados_exportar.Name = "menu_dados_exportar";
            this.menu_dados_exportar.Size = new System.Drawing.Size(183, 22);
            this.menu_dados_exportar.Text = "Exportar";
            // 
            // menu_dados_exportar_zip
            // 
            this.menu_dados_exportar_zip.Name = "menu_dados_exportar_zip";
            this.menu_dados_exportar_zip.Size = new System.Drawing.Size(142, 22);
            this.menu_dados_exportar_zip.Text = "Arquivo Zip";
            this.menu_dados_exportar_zip.Click += new System.EventHandler(this.menu_dados_exportar_zip_Click);
            // 
            // menu_dados_exportar_drive
            // 
            this.menu_dados_exportar_drive.Name = "menu_dados_exportar_drive";
            this.menu_dados_exportar_drive.Size = new System.Drawing.Size(142, 22);
            this.menu_dados_exportar_drive.Text = "Google Drive";
            // 
            // menu_dados_importarCoeficiente
            // 
            this.menu_dados_importarCoeficiente.Name = "menu_dados_importarCoeficiente";
            this.menu_dados_importarCoeficiente.Size = new System.Drawing.Size(183, 22);
            this.menu_dados_importarCoeficiente.Text = "Importar Coeficiente";
            this.menu_dados_importarCoeficiente.Click += new System.EventHandler(this.menu_dados_importarCoeficiente_Click);
            // 
            // menu_configuracoes
            // 
            this.menu_configuracoes.Name = "menu_configuracoes";
            this.menu_configuracoes.Size = new System.Drawing.Size(96, 20);
            this.menu_configuracoes.Text = "Configurações";
            this.menu_configuracoes.Click += new System.EventHandler(this.menu_configuracoes_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVersao});
            this.status.Location = new System.Drawing.Point(0, 731);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1354, 22);
            this.status.TabIndex = 16;
            this.status.Text = "statusStrip1";
            // 
            // lblVersao
            // 
            this.lblVersao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVersao.Size = new System.Drawing.Size(118, 17);
            this.lblVersao.Text = "toolStripStatusLabel1";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // menu_dados_realizarBackup
            // 
            this.menu_dados_realizarBackup.Name = "menu_dados_realizarBackup";
            this.menu_dados_realizarBackup.Size = new System.Drawing.Size(183, 22);
            this.menu_dados_realizarBackup.Text = "Realizar Backup";
            this.menu_dados_realizarBackup.Click += new System.EventHandler(this.menu_dados_realizarBackup_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 753);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Pontos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.Shown += new System.EventHandler(this.Dashboard_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDias)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblAlmocoSaida;
        private System.Windows.Forms.Label lblAlmocoRetorno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMediaTempoAlmoco;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lblMediaEntrada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMediaSaida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCoeficiente;
        private Control.DiaTrabalhoDataGridView gridDias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMediaValorAlmoco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblValorTotalTR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblValorIdealDiario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.TextBox txtSodexo;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menu_relatorio;
        private System.Windows.Forms.ToolStripMenuItem menu_dados;
        private System.Windows.Forms.ToolStripMenuItem menu_dados_importar;
        private System.Windows.Forms.ToolStripMenuItem menu_dados_importar_zip;
        private System.Windows.Forms.ToolStripMenuItem menu_dados_importar_drive;
        private System.Windows.Forms.ToolStripMenuItem menu_dados_exportar;
        private System.Windows.Forms.ToolStripMenuItem menu_dados_exportar_zip;
        private System.Windows.Forms.ToolStripMenuItem menu_dados_exportar_drive;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnMesAno;
        private System.Windows.Forms.ToolStripMenuItem menu_dados_importarCoeficiente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCoeficientePorDia;
        private System.Windows.Forms.ToolStripStatusLabel lblVersao;
        private System.Windows.Forms.ToolStripMenuItem menu_configuracoes;
        private System.Windows.Forms.ToolStripMenuItem menu_dados_realizarBackup;
    }
}