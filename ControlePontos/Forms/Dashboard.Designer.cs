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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.Menu_Relatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Dados = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Dados_Exportar = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Dados_Exportar_Zip = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Dados_ImportarCoeficiente = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Dados_RealizarBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Configuracoes = new System.Windows.Forms.ToolStripMenuItem();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.Status_LabelVersao = new System.Windows.Forms.ToolStripStatusLabel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LabelCoeficienteDisplay = new System.Windows.Forms.Label();
            this.LabelCoeficiente = new System.Windows.Forms.Label();
            this.LabelMediaEntradaDisplay = new System.Windows.Forms.Label();
            this.LabelMediaEntrada = new System.Windows.Forms.Label();
            this.LabelCodicienteDiaDisplay = new System.Windows.Forms.Label();
            this.LabelCoeficientePorDia = new System.Windows.Forms.Label();
            this.LabelAlmocoRetorno = new System.Windows.Forms.Label();
            this.LabelAlmocoRetornoDisplay = new System.Windows.Forms.Label();
            this.LabelAlmocoSaida = new System.Windows.Forms.Label();
            this.LabelMediaSaidaDisplay = new System.Windows.Forms.Label();
            this.LabelMediaSaida = new System.Windows.Forms.Label();
            this.LabelAlmocoSaidaDisplay = new System.Windows.Forms.Label();
            this.LabelMediaValorAlmocoDisplay = new System.Windows.Forms.Label();
            this.LabelMediaTempoAlmoco = new System.Windows.Forms.Label();
            this.LabelMedioValorAlmocoDisplay = new System.Windows.Forms.Label();
            this.LabelMediaValorAlmoco = new System.Windows.Forms.Label();
            this.LabelValorTotalTrDisplay = new System.Windows.Forms.Label();
            this.LabelValorTotalTr = new System.Windows.Forms.Label();
            this.LabelValorIdealDiarioDisplay = new System.Windows.Forms.Label();
            this.LabelValorIdealDiario = new System.Windows.Forms.Label();
            this.LabelOffsetCoeficiente = new System.Windows.Forms.Label();
            this.TextBoxOffset = new System.Windows.Forms.TextBox();
            this.LabelValorSodexo = new System.Windows.Forms.Label();
            this.TextBoxSodexo = new System.Windows.Forms.TextBox();
            this.ButtonMesAno = new System.Windows.Forms.Button();
            this.Layout = new System.Windows.Forms.TableLayoutPanel();
            this.GridDias = new ControlePontos.Control.DiaTrabalhoDataGridView();
            this.LayoutFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.LabelSeparador10 = new System.Windows.Forms.Label();
            this.LabelSeparador07 = new System.Windows.Forms.Label();
            this.LabelSeparador06 = new System.Windows.Forms.Label();
            this.LabelSeparador05 = new System.Windows.Forms.Label();
            this.LabelSeparador04 = new System.Windows.Forms.Label();
            this.LabelSeparador03 = new System.Windows.Forms.Label();
            this.LabelSeparador02 = new System.Windows.Forms.Label();
            this.LabelSeparador01 = new System.Windows.Forms.Label();
            this.LabelSeparador00 = new System.Windows.Forms.Label();
            this.LabelSeparador09 = new System.Windows.Forms.Label();
            this.LabelSeparador08 = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            this.Status.SuspendLayout();
            this.Layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDias)).BeginInit();
            this.LayoutFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Relatorio,
            this.Menu_Dados,
            this.Menu_Configuracoes});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1347, 24);
            this.Menu.TabIndex = 15;
            this.Menu.Text = "menuStrip1";
            // 
            // Menu_Relatorio
            // 
            this.Menu_Relatorio.Name = "Menu_Relatorio";
            this.Menu_Relatorio.Size = new System.Drawing.Size(66, 20);
            this.Menu_Relatorio.Text = "Relatório";
            // 
            // Menu_Dados
            // 
            this.Menu_Dados.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Dados_Exportar,
            this.Menu_Dados_ImportarCoeficiente,
            this.Menu_Dados_RealizarBackup});
            this.Menu_Dados.Name = "Menu_Dados";
            this.Menu_Dados.Size = new System.Drawing.Size(52, 20);
            this.Menu_Dados.Text = "Dados";
            // 
            // Menu_Dados_Exportar
            // 
            this.Menu_Dados_Exportar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Dados_Exportar_Zip});
            this.Menu_Dados_Exportar.Name = "Menu_Dados_Exportar";
            this.Menu_Dados_Exportar.Size = new System.Drawing.Size(183, 22);
            this.Menu_Dados_Exportar.Text = "Exportar";
            // 
            // Menu_Dados_Exportar_Zip
            // 
            this.Menu_Dados_Exportar_Zip.Name = "Menu_Dados_Exportar_Zip";
            this.Menu_Dados_Exportar_Zip.Size = new System.Drawing.Size(136, 22);
            this.Menu_Dados_Exportar_Zip.Text = "Arquivo Zip";
            this.Menu_Dados_Exportar_Zip.Click += new System.EventHandler(this.Menu_Dados_Exportar_Zip_Click);
            // 
            // Menu_Dados_ImportarCoeficiente
            // 
            this.Menu_Dados_ImportarCoeficiente.Name = "Menu_Dados_ImportarCoeficiente";
            this.Menu_Dados_ImportarCoeficiente.Size = new System.Drawing.Size(183, 22);
            this.Menu_Dados_ImportarCoeficiente.Text = "Importar Coeficiente";
            this.Menu_Dados_ImportarCoeficiente.Click += new System.EventHandler(this.Menu_Dados_ImportarCoeficiente_Click);
            // 
            // Menu_Dados_RealizarBackup
            // 
            this.Menu_Dados_RealizarBackup.Name = "Menu_Dados_RealizarBackup";
            this.Menu_Dados_RealizarBackup.Size = new System.Drawing.Size(183, 22);
            this.Menu_Dados_RealizarBackup.Text = "Realizar Backup";
            this.Menu_Dados_RealizarBackup.Click += new System.EventHandler(this.Menu_Dados_RealizarBackup_Click);
            // 
            // Menu_Configuracoes
            // 
            this.Menu_Configuracoes.Name = "Menu_Configuracoes";
            this.Menu_Configuracoes.Size = new System.Drawing.Size(96, 20);
            this.Menu_Configuracoes.Text = "Configurações";
            this.Menu_Configuracoes.Click += new System.EventHandler(this.Menu_Configuracoes_Click);
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status_LabelVersao});
            this.Status.Location = new System.Drawing.Point(0, 739);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(1347, 22);
            this.Status.TabIndex = 16;
            this.Status.Text = "statusStrip1";
            // 
            // Status_LabelVersao
            // 
            this.Status_LabelVersao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Status_LabelVersao.Name = "Status_LabelVersao";
            this.Status_LabelVersao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Status_LabelVersao.Size = new System.Drawing.Size(118, 17);
            this.Status_LabelVersao.Text = "toolStripStatusLabel1";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 5000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LabelCoeficienteDisplay
            // 
            this.LabelCoeficienteDisplay.AutoSize = true;
            this.LabelCoeficienteDisplay.Location = new System.Drawing.Point(3, 0);
            this.LabelCoeficienteDisplay.Name = "LabelCoeficienteDisplay";
            this.LabelCoeficienteDisplay.Size = new System.Drawing.Size(87, 13);
            this.LabelCoeficienteDisplay.TabIndex = 17;
            this.LabelCoeficienteDisplay.Text = "Total Coeficiente";
            // 
            // LabelCoeficiente
            // 
            this.LabelCoeficiente.AutoSize = true;
            this.LabelCoeficiente.Location = new System.Drawing.Point(3, 13);
            this.LabelCoeficiente.Name = "LabelCoeficiente";
            this.LabelCoeficiente.Size = new System.Drawing.Size(70, 13);
            this.LabelCoeficiente.TabIndex = 18;
            this.LabelCoeficiente.Text = "lblCoeficiente";
            // 
            // LabelMediaEntradaDisplay
            // 
            this.LabelMediaEntradaDisplay.AutoSize = true;
            this.LabelMediaEntradaDisplay.Location = new System.Drawing.Point(3, 78);
            this.LabelMediaEntradaDisplay.Name = "LabelMediaEntradaDisplay";
            this.LabelMediaEntradaDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelMediaEntradaDisplay.Size = new System.Drawing.Size(76, 13);
            this.LabelMediaEntradaDisplay.TabIndex = 31;
            this.LabelMediaEntradaDisplay.Text = "Média Entrada";
            // 
            // LabelMediaEntrada
            // 
            this.LabelMediaEntrada.AutoSize = true;
            this.LabelMediaEntrada.Location = new System.Drawing.Point(3, 91);
            this.LabelMediaEntrada.Name = "LabelMediaEntrada";
            this.LabelMediaEntrada.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelMediaEntrada.Size = new System.Drawing.Size(83, 13);
            this.LabelMediaEntrada.TabIndex = 32;
            this.LabelMediaEntrada.Text = "lblMediaEntrada";
            // 
            // LabelCodicienteDiaDisplay
            // 
            this.LabelCodicienteDiaDisplay.AutoSize = true;
            this.LabelCodicienteDiaDisplay.Location = new System.Drawing.Point(3, 39);
            this.LabelCodicienteDiaDisplay.Name = "LabelCodicienteDiaDisplay";
            this.LabelCodicienteDiaDisplay.Size = new System.Drawing.Size(81, 13);
            this.LabelCodicienteDiaDisplay.TabIndex = 33;
            this.LabelCodicienteDiaDisplay.Text = "Coeficiente/Dia";
            // 
            // LabelCoeficientePorDia
            // 
            this.LabelCoeficientePorDia.AutoSize = true;
            this.LabelCoeficientePorDia.Location = new System.Drawing.Point(3, 52);
            this.LabelCoeficientePorDia.Name = "LabelCoeficientePorDia";
            this.LabelCoeficientePorDia.Size = new System.Drawing.Size(102, 13);
            this.LabelCoeficientePorDia.TabIndex = 34;
            this.LabelCoeficientePorDia.Text = "lblCoeficientePorDia";
            // 
            // LabelAlmocoRetorno
            // 
            this.LabelAlmocoRetorno.AutoSize = true;
            this.LabelAlmocoRetorno.Location = new System.Drawing.Point(3, 208);
            this.LabelAlmocoRetorno.Name = "LabelAlmocoRetorno";
            this.LabelAlmocoRetorno.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelAlmocoRetorno.Size = new System.Drawing.Size(90, 13);
            this.LabelAlmocoRetorno.TabIndex = 40;
            this.LabelAlmocoRetorno.Text = "lblAlmocoRetorno";
            // 
            // LabelAlmocoRetornoDisplay
            // 
            this.LabelAlmocoRetornoDisplay.AutoSize = true;
            this.LabelAlmocoRetornoDisplay.Location = new System.Drawing.Point(3, 195);
            this.LabelAlmocoRetornoDisplay.Name = "LabelAlmocoRetornoDisplay";
            this.LabelAlmocoRetornoDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelAlmocoRetornoDisplay.Size = new System.Drawing.Size(115, 13);
            this.LabelAlmocoRetornoDisplay.TabIndex = 39;
            this.LabelAlmocoRetornoDisplay.Text = "Média Almoço Retorno";
            // 
            // LabelAlmocoSaida
            // 
            this.LabelAlmocoSaida.AutoSize = true;
            this.LabelAlmocoSaida.Location = new System.Drawing.Point(3, 169);
            this.LabelAlmocoSaida.Name = "LabelAlmocoSaida";
            this.LabelAlmocoSaida.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelAlmocoSaida.Size = new System.Drawing.Size(79, 13);
            this.LabelAlmocoSaida.TabIndex = 37;
            this.LabelAlmocoSaida.Text = "lblAlmocoSaida";
            // 
            // LabelMediaSaidaDisplay
            // 
            this.LabelMediaSaidaDisplay.AutoSize = true;
            this.LabelMediaSaidaDisplay.Location = new System.Drawing.Point(3, 117);
            this.LabelMediaSaidaDisplay.Name = "LabelMediaSaidaDisplay";
            this.LabelMediaSaidaDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelMediaSaidaDisplay.Size = new System.Drawing.Size(66, 13);
            this.LabelMediaSaidaDisplay.TabIndex = 35;
            this.LabelMediaSaidaDisplay.Text = "Média Saida";
            // 
            // LabelMediaSaida
            // 
            this.LabelMediaSaida.AutoSize = true;
            this.LabelMediaSaida.Location = new System.Drawing.Point(3, 130);
            this.LabelMediaSaida.Name = "LabelMediaSaida";
            this.LabelMediaSaida.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelMediaSaida.Size = new System.Drawing.Size(73, 13);
            this.LabelMediaSaida.TabIndex = 36;
            this.LabelMediaSaida.Text = "lblMediaSaida";
            // 
            // LabelAlmocoSaidaDisplay
            // 
            this.LabelAlmocoSaidaDisplay.AutoSize = true;
            this.LabelAlmocoSaidaDisplay.Location = new System.Drawing.Point(3, 156);
            this.LabelAlmocoSaidaDisplay.Name = "LabelAlmocoSaidaDisplay";
            this.LabelAlmocoSaidaDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelAlmocoSaidaDisplay.Size = new System.Drawing.Size(104, 13);
            this.LabelAlmocoSaidaDisplay.TabIndex = 38;
            this.LabelAlmocoSaidaDisplay.Text = "Média Almoco Saida";
            // 
            // LabelMediaValorAlmocoDisplay
            // 
            this.LabelMediaValorAlmocoDisplay.AutoSize = true;
            this.LabelMediaValorAlmocoDisplay.Location = new System.Drawing.Point(3, 234);
            this.LabelMediaValorAlmocoDisplay.Name = "LabelMediaValorAlmocoDisplay";
            this.LabelMediaValorAlmocoDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelMediaValorAlmocoDisplay.Size = new System.Drawing.Size(110, 13);
            this.LabelMediaValorAlmocoDisplay.TabIndex = 29;
            this.LabelMediaValorAlmocoDisplay.Text = "Média Tempo Almoço";
            // 
            // LabelMediaTempoAlmoco
            // 
            this.LabelMediaTempoAlmoco.AutoSize = true;
            this.LabelMediaTempoAlmoco.Location = new System.Drawing.Point(3, 247);
            this.LabelMediaTempoAlmoco.Name = "LabelMediaTempoAlmoco";
            this.LabelMediaTempoAlmoco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelMediaTempoAlmoco.Size = new System.Drawing.Size(114, 13);
            this.LabelMediaTempoAlmoco.TabIndex = 30;
            this.LabelMediaTempoAlmoco.Text = "lblMediaTempoAlmoco";
            // 
            // LabelMedioValorAlmocoDisplay
            // 
            this.LabelMedioValorAlmocoDisplay.AutoSize = true;
            this.LabelMedioValorAlmocoDisplay.Location = new System.Drawing.Point(3, 273);
            this.LabelMedioValorAlmocoDisplay.Name = "LabelMedioValorAlmocoDisplay";
            this.LabelMedioValorAlmocoDisplay.Size = new System.Drawing.Size(116, 13);
            this.LabelMedioValorAlmocoDisplay.TabIndex = 31;
            this.LabelMedioValorAlmocoDisplay.Text = "Média do Valor Almoço";
            // 
            // LabelMediaValorAlmoco
            // 
            this.LabelMediaValorAlmoco.AutoSize = true;
            this.LabelMediaValorAlmoco.Location = new System.Drawing.Point(3, 286);
            this.LabelMediaValorAlmoco.Name = "LabelMediaValorAlmoco";
            this.LabelMediaValorAlmoco.Size = new System.Drawing.Size(105, 13);
            this.LabelMediaValorAlmoco.TabIndex = 32;
            this.LabelMediaValorAlmoco.Text = "lblMediaValorAlmoco";
            // 
            // LabelValorTotalTrDisplay
            // 
            this.LabelValorTotalTrDisplay.AutoSize = true;
            this.LabelValorTotalTrDisplay.Location = new System.Drawing.Point(3, 312);
            this.LabelValorTotalTrDisplay.Name = "LabelValorTotalTrDisplay";
            this.LabelValorTotalTrDisplay.Size = new System.Drawing.Size(110, 13);
            this.LabelValorTotalTrDisplay.TabIndex = 33;
            this.LabelValorTotalTrDisplay.Text = "Valor Restante no TR";
            // 
            // LabelValorTotalTr
            // 
            this.LabelValorTotalTr.AutoSize = true;
            this.LabelValorTotalTr.Location = new System.Drawing.Point(3, 325);
            this.LabelValorTotalTr.Name = "LabelValorTotalTr";
            this.LabelValorTotalTr.Size = new System.Drawing.Size(80, 13);
            this.LabelValorTotalTr.TabIndex = 34;
            this.LabelValorTotalTr.Text = "lblValorTotalTR";
            // 
            // LabelValorIdealDiarioDisplay
            // 
            this.LabelValorIdealDiarioDisplay.AutoSize = true;
            this.LabelValorIdealDiarioDisplay.Location = new System.Drawing.Point(3, 351);
            this.LabelValorIdealDiarioDisplay.Name = "LabelValorIdealDiarioDisplay";
            this.LabelValorIdealDiarioDisplay.Size = new System.Drawing.Size(87, 13);
            this.LabelValorIdealDiarioDisplay.TabIndex = 35;
            this.LabelValorIdealDiarioDisplay.Text = "Valor Ideal Diário";
            // 
            // LabelValorIdealDiario
            // 
            this.LabelValorIdealDiario.AutoSize = true;
            this.LabelValorIdealDiario.Location = new System.Drawing.Point(3, 364);
            this.LabelValorIdealDiario.Name = "LabelValorIdealDiario";
            this.LabelValorIdealDiario.Size = new System.Drawing.Size(91, 13);
            this.LabelValorIdealDiario.TabIndex = 36;
            this.LabelValorIdealDiario.Text = "lblValorIdealDiario";
            // 
            // LabelOffsetCoeficiente
            // 
            this.LabelOffsetCoeficiente.AutoSize = true;
            this.LabelOffsetCoeficiente.Location = new System.Drawing.Point(3, 390);
            this.LabelOffsetCoeficiente.Name = "LabelOffsetCoeficiente";
            this.LabelOffsetCoeficiente.Size = new System.Drawing.Size(116, 13);
            this.LabelOffsetCoeficiente.TabIndex = 41;
            this.LabelOffsetCoeficiente.Text = "Offset Coeficiênte (min)";
            // 
            // TextBoxOffset
            // 
            this.TextBoxOffset.Dock = System.Windows.Forms.DockStyle.Right;
            this.TextBoxOffset.Location = new System.Drawing.Point(3, 406);
            this.TextBoxOffset.Name = "TextBoxOffset";
            this.TextBoxOffset.Size = new System.Drawing.Size(116, 20);
            this.TextBoxOffset.TabIndex = 42;
            // 
            // LabelValorSodexo
            // 
            this.LabelValorSodexo.AutoSize = true;
            this.LabelValorSodexo.Location = new System.Drawing.Point(3, 442);
            this.LabelValorSodexo.Name = "LabelValorSodexo";
            this.LabelValorSodexo.Size = new System.Drawing.Size(116, 13);
            this.LabelValorSodexo.TabIndex = 43;
            this.LabelValorSodexo.Text = "Valor Sodexo Mês (R$)";
            // 
            // TextBoxSodexo
            // 
            this.TextBoxSodexo.Dock = System.Windows.Forms.DockStyle.Right;
            this.TextBoxSodexo.Location = new System.Drawing.Point(3, 458);
            this.TextBoxSodexo.Name = "TextBoxSodexo";
            this.TextBoxSodexo.Size = new System.Drawing.Size(116, 20);
            this.TextBoxSodexo.TabIndex = 44;
            // 
            // ButtonMesAno
            // 
            this.ButtonMesAno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMesAno.Location = new System.Drawing.Point(1199, 688);
            this.ButtonMesAno.Name = "ButtonMesAno";
            this.ButtonMesAno.Size = new System.Drawing.Size(145, 24);
            this.ButtonMesAno.TabIndex = 28;
            this.ButtonMesAno.Text = "Novembro de 2016";
            this.ButtonMesAno.UseVisualStyleBackColor = true;
            this.ButtonMesAno.Click += new System.EventHandler(this.ButtonMesAno_Click);
            // 
            // LayoutFlow
            // 
            this.Layout.ColumnCount = 2;
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.Layout.Controls.Add(this.GridDias, 0, 0);
            this.Layout.Controls.Add(this.ButtonMesAno, 1, 1);
            this.Layout.Controls.Add(this.LayoutFlow, 1, 0);
            this.Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Layout.Location = new System.Drawing.Point(0, 24);
            this.Layout.Name = "LayoutFlow";
            this.Layout.RowCount = 2;
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.Layout.Size = new System.Drawing.Size(1347, 715);
            this.Layout.TabIndex = 46;
            // 
            // GridDias
            // 
            this.GridDias.AllowUserToAddRows = false;
            this.GridDias.AllowUserToDeleteRows = false;
            this.GridDias.AllowUserToResizeRows = false;
            this.GridDias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridDias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridDias.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.GridDias.Location = new System.Drawing.Point(3, 3);
            this.GridDias.MultiSelect = false;
            this.GridDias.Name = "GridDias";
            this.GridDias.RowHeadersVisible = false;
            this.Layout.SetRowSpan(this.GridDias, 2);
            this.GridDias.Size = new System.Drawing.Size(1190, 709);
            this.GridDias.TabIndex = 45;
            // 
            // flowLayoutPanel1
            // 
            this.LayoutFlow.AutoScroll = true;
            this.LayoutFlow.Controls.Add(this.LabelCoeficienteDisplay);
            this.LayoutFlow.Controls.Add(this.LabelCoeficiente);
            this.LayoutFlow.Controls.Add(this.LabelSeparador10);
            this.LayoutFlow.Controls.Add(this.LabelCodicienteDiaDisplay);
            this.LayoutFlow.Controls.Add(this.LabelCoeficientePorDia);
            this.LayoutFlow.Controls.Add(this.LabelSeparador07);
            this.LayoutFlow.Controls.Add(this.LabelMediaEntradaDisplay);
            this.LayoutFlow.Controls.Add(this.LabelMediaEntrada);
            this.LayoutFlow.Controls.Add(this.LabelSeparador06);
            this.LayoutFlow.Controls.Add(this.LabelMediaSaidaDisplay);
            this.LayoutFlow.Controls.Add(this.LabelMediaSaida);
            this.LayoutFlow.Controls.Add(this.LabelSeparador05);
            this.LayoutFlow.Controls.Add(this.LabelAlmocoSaidaDisplay);
            this.LayoutFlow.Controls.Add(this.LabelAlmocoSaida);
            this.LayoutFlow.Controls.Add(this.LabelSeparador04);
            this.LayoutFlow.Controls.Add(this.LabelAlmocoRetornoDisplay);
            this.LayoutFlow.Controls.Add(this.LabelAlmocoRetorno);
            this.LayoutFlow.Controls.Add(this.LabelSeparador03);
            this.LayoutFlow.Controls.Add(this.LabelMediaValorAlmocoDisplay);
            this.LayoutFlow.Controls.Add(this.LabelMediaTempoAlmoco);
            this.LayoutFlow.Controls.Add(this.LabelSeparador02);
            this.LayoutFlow.Controls.Add(this.LabelMedioValorAlmocoDisplay);
            this.LayoutFlow.Controls.Add(this.LabelMediaValorAlmoco);
            this.LayoutFlow.Controls.Add(this.LabelSeparador01);
            this.LayoutFlow.Controls.Add(this.LabelValorTotalTrDisplay);
            this.LayoutFlow.Controls.Add(this.LabelValorTotalTr);
            this.LayoutFlow.Controls.Add(this.LabelSeparador00);
            this.LayoutFlow.Controls.Add(this.LabelValorIdealDiarioDisplay);
            this.LayoutFlow.Controls.Add(this.LabelValorIdealDiario);
            this.LayoutFlow.Controls.Add(this.LabelSeparador09);
            this.LayoutFlow.Controls.Add(this.LabelOffsetCoeficiente);
            this.LayoutFlow.Controls.Add(this.TextBoxOffset);
            this.LayoutFlow.Controls.Add(this.LabelSeparador08);
            this.LayoutFlow.Controls.Add(this.LabelValorSodexo);
            this.LayoutFlow.Controls.Add(this.TextBoxSodexo);
            this.LayoutFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.LayoutFlow.Location = new System.Drawing.Point(1199, 3);
            this.LayoutFlow.Name = "flowLayoutPanel1";
            this.LayoutFlow.Size = new System.Drawing.Size(145, 679);
            this.LayoutFlow.TabIndex = 46;
            this.LayoutFlow.WrapContents = false;
            // 
            // label1
            // 
            this.LabelSeparador10.AutoSize = true;
            this.LabelSeparador10.Location = new System.Drawing.Point(3, 26);
            this.LabelSeparador10.Name = "label1";
            this.LabelSeparador10.Size = new System.Drawing.Size(51, 13);
            this.LabelSeparador10.TabIndex = 47;
            this.LabelSeparador10.Text = "separator";
            // 
            // label2
            // 
            this.LabelSeparador07.AutoSize = true;
            this.LabelSeparador07.Location = new System.Drawing.Point(3, 65);
            this.LabelSeparador07.Name = "label2";
            this.LabelSeparador07.Size = new System.Drawing.Size(51, 13);
            this.LabelSeparador07.TabIndex = 47;
            this.LabelSeparador07.Text = "separator";
            // 
            // label3
            // 
            this.LabelSeparador06.AutoSize = true;
            this.LabelSeparador06.Location = new System.Drawing.Point(3, 104);
            this.LabelSeparador06.Name = "label3";
            this.LabelSeparador06.Size = new System.Drawing.Size(51, 13);
            this.LabelSeparador06.TabIndex = 47;
            this.LabelSeparador06.Text = "separator";
            // 
            // label4
            // 
            this.LabelSeparador05.AutoSize = true;
            this.LabelSeparador05.Location = new System.Drawing.Point(3, 143);
            this.LabelSeparador05.Name = "label4";
            this.LabelSeparador05.Size = new System.Drawing.Size(51, 13);
            this.LabelSeparador05.TabIndex = 47;
            this.LabelSeparador05.Text = "separator";
            // 
            // label5
            // 
            this.LabelSeparador04.AutoSize = true;
            this.LabelSeparador04.Location = new System.Drawing.Point(3, 182);
            this.LabelSeparador04.Name = "label5";
            this.LabelSeparador04.Size = new System.Drawing.Size(51, 13);
            this.LabelSeparador04.TabIndex = 47;
            this.LabelSeparador04.Text = "separator";
            // 
            // label6
            // 
            this.LabelSeparador03.AutoSize = true;
            this.LabelSeparador03.Location = new System.Drawing.Point(3, 221);
            this.LabelSeparador03.Name = "label6";
            this.LabelSeparador03.Size = new System.Drawing.Size(51, 13);
            this.LabelSeparador03.TabIndex = 47;
            this.LabelSeparador03.Text = "separator";
            // 
            // label7
            // 
            this.LabelSeparador02.AutoSize = true;
            this.LabelSeparador02.Location = new System.Drawing.Point(3, 260);
            this.LabelSeparador02.Name = "label7";
            this.LabelSeparador02.Size = new System.Drawing.Size(51, 13);
            this.LabelSeparador02.TabIndex = 47;
            this.LabelSeparador02.Text = "separator";
            // 
            // label8
            // 
            this.LabelSeparador01.AutoSize = true;
            this.LabelSeparador01.Location = new System.Drawing.Point(3, 299);
            this.LabelSeparador01.Name = "label8";
            this.LabelSeparador01.Size = new System.Drawing.Size(51, 13);
            this.LabelSeparador01.TabIndex = 47;
            this.LabelSeparador01.Text = "separator";
            // 
            // label9
            // 
            this.LabelSeparador00.AutoSize = true;
            this.LabelSeparador00.Location = new System.Drawing.Point(3, 338);
            this.LabelSeparador00.Name = "label9";
            this.LabelSeparador00.Size = new System.Drawing.Size(51, 13);
            this.LabelSeparador00.TabIndex = 47;
            this.LabelSeparador00.Text = "separator";
            // 
            // label10
            // 
            this.LabelSeparador09.AutoSize = true;
            this.LabelSeparador09.Location = new System.Drawing.Point(3, 377);
            this.LabelSeparador09.Name = "label10";
            this.LabelSeparador09.Size = new System.Drawing.Size(51, 13);
            this.LabelSeparador09.TabIndex = 47;
            this.LabelSeparador09.Text = "separator";
            // 
            // label11
            // 
            this.LabelSeparador08.AutoSize = true;
            this.LabelSeparador08.Location = new System.Drawing.Point(3, 429);
            this.LabelSeparador08.Name = "label11";
            this.LabelSeparador08.Size = new System.Drawing.Size(51, 13);
            this.LabelSeparador08.TabIndex = 47;
            this.LabelSeparador08.Text = "separator";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1347, 761);
            this.Controls.Add(this.Layout);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Pontos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.Layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDias)).EndInit();
            this.LayoutFlow.ResumeLayout(false);
            this.LayoutFlow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.DiaTrabalhoDataGridView GridDias;
        private System.Windows.Forms.Button ButtonMesAno;
        private System.Windows.Forms.FlowLayoutPanel LayoutFlow;
        private System.Windows.Forms.Label LabelAlmocoRetorno;
        private System.Windows.Forms.Label LabelAlmocoRetornoDisplay;
        private System.Windows.Forms.Label LabelAlmocoSaida;
        private System.Windows.Forms.Label LabelAlmocoSaidaDisplay;
        private System.Windows.Forms.Label LabelCodicienteDiaDisplay;
        private System.Windows.Forms.Label LabelCoeficiente;
        private System.Windows.Forms.Label LabelCoeficienteDisplay;
        private System.Windows.Forms.Label LabelCoeficientePorDia;
        private System.Windows.Forms.Label LabelMediaEntrada;
        private System.Windows.Forms.Label LabelMediaEntradaDisplay;
        private System.Windows.Forms.Label LabelMediaSaida;
        private System.Windows.Forms.Label LabelMediaSaidaDisplay;
        private System.Windows.Forms.Label LabelMediaTempoAlmoco;
        private System.Windows.Forms.Label LabelMediaValorAlmoco;
        private System.Windows.Forms.Label LabelMediaValorAlmocoDisplay;
        private System.Windows.Forms.Label LabelMedioValorAlmocoDisplay;
        private System.Windows.Forms.Label LabelOffsetCoeficiente;
        private System.Windows.Forms.Label LabelSeparador00;
        private System.Windows.Forms.Label LabelSeparador01;
        private System.Windows.Forms.Label LabelSeparador02;
        private System.Windows.Forms.Label LabelSeparador03;
        private System.Windows.Forms.Label LabelSeparador04;
        private System.Windows.Forms.Label LabelSeparador05;
        private System.Windows.Forms.Label LabelSeparador06;
        private System.Windows.Forms.Label LabelSeparador07;
        private System.Windows.Forms.Label LabelSeparador08;
        private System.Windows.Forms.Label LabelSeparador09;
        private System.Windows.Forms.Label LabelSeparador10;
        private System.Windows.Forms.Label LabelValorIdealDiario;
        private System.Windows.Forms.Label LabelValorIdealDiarioDisplay;
        private System.Windows.Forms.Label LabelValorSodexo;
        private System.Windows.Forms.Label LabelValorTotalTr;
        private System.Windows.Forms.Label LabelValorTotalTrDisplay;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.TableLayoutPanel Layout;
        private System.Windows.Forms.TextBox TextBoxOffset;
        private System.Windows.Forms.TextBox TextBoxSodexo;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ToolStripMenuItem Menu_Configuracoes;
        private System.Windows.Forms.ToolStripMenuItem Menu_Dados;
        private System.Windows.Forms.ToolStripMenuItem Menu_Dados_Exportar;
        private System.Windows.Forms.ToolStripMenuItem Menu_Dados_Exportar_Zip;
        private System.Windows.Forms.ToolStripMenuItem Menu_Dados_ImportarCoeficiente;
        private System.Windows.Forms.ToolStripMenuItem Menu_Dados_RealizarBackup;
        private System.Windows.Forms.ToolStripMenuItem Menu_Relatorio;
        private System.Windows.Forms.ToolStripStatusLabel Status_LabelVersao;
    }
}