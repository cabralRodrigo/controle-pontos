namespace ControlePontos.Forms
{
    partial class Changelog
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
            this.Layout = new System.Windows.Forms.TableLayoutPanel();
            this.GroupBox_Estatisticas = new System.Windows.Forms.GroupBox();
            this.GroupBox_Estatisticas_Layout = new System.Windows.Forms.FlowLayoutPanel();
            this.GroupBox_Legenda = new System.Windows.Forms.GroupBox();
            this.GroupBox_Legenda_Layout = new System.Windows.Forms.FlowLayoutPanel();
            this.TreeView_Changelog = new System.Windows.Forms.TreeView();
            this.Layout.SuspendLayout();
            this.GroupBox_Estatisticas.SuspendLayout();
            this.GroupBox_Legenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // Layout
            // 
            this.Layout.ColumnCount = 2;
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Layout.Controls.Add(this.GroupBox_Estatisticas, 1, 0);
            this.Layout.Controls.Add(this.GroupBox_Legenda, 1, 1);
            this.Layout.Controls.Add(this.TreeView_Changelog, 0, 0);
            this.Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Layout.Location = new System.Drawing.Point(0, 0);
            this.Layout.Name = "Layout";
            this.Layout.RowCount = 2;
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.Size = new System.Drawing.Size(1021, 743);
            this.Layout.TabIndex = 0;
            // 
            // GroupBox_Estatisticas
            // 
            this.GroupBox_Estatisticas.AutoSize = true;
            this.GroupBox_Estatisticas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupBox_Estatisticas.Controls.Add(this.GroupBox_Estatisticas_Layout);
            this.GroupBox_Estatisticas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_Estatisticas.Location = new System.Drawing.Point(1012, 3);
            this.GroupBox_Estatisticas.Name = "GroupBox_Estatisticas";
            this.GroupBox_Estatisticas.Size = new System.Drawing.Size(6, 19);
            this.GroupBox_Estatisticas.TabIndex = 0;
            this.GroupBox_Estatisticas.TabStop = false;
            this.GroupBox_Estatisticas.Text = "Estatísticas";
            // 
            // GroupBox_Estatisticas_Layout
            // 
            this.GroupBox_Estatisticas_Layout.AutoSize = true;
            this.GroupBox_Estatisticas_Layout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupBox_Estatisticas_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_Estatisticas_Layout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.GroupBox_Estatisticas_Layout.Location = new System.Drawing.Point(3, 16);
            this.GroupBox_Estatisticas_Layout.Name = "GroupBox_Estatisticas_Layout";
            this.GroupBox_Estatisticas_Layout.Size = new System.Drawing.Size(0, 0);
            this.GroupBox_Estatisticas_Layout.TabIndex = 1;
            // 
            // GroupBox_Legenda
            // 
            this.GroupBox_Legenda.AutoSize = true;
            this.GroupBox_Legenda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupBox_Legenda.Controls.Add(this.GroupBox_Legenda_Layout);
            this.GroupBox_Legenda.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox_Legenda.Location = new System.Drawing.Point(1012, 28);
            this.GroupBox_Legenda.Name = "GroupBox_Legenda";
            this.GroupBox_Legenda.Size = new System.Drawing.Size(6, 19);
            this.GroupBox_Legenda.TabIndex = 2;
            this.GroupBox_Legenda.TabStop = false;
            this.GroupBox_Legenda.Text = "Legenda";
            // 
            // GroupBox_Legenda_Layout
            // 
            this.GroupBox_Legenda_Layout.AutoSize = true;
            this.GroupBox_Legenda_Layout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupBox_Legenda_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_Legenda_Layout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.GroupBox_Legenda_Layout.Location = new System.Drawing.Point(3, 16);
            this.GroupBox_Legenda_Layout.Name = "GroupBox_Legenda_Layout";
            this.GroupBox_Legenda_Layout.Size = new System.Drawing.Size(0, 0);
            this.GroupBox_Legenda_Layout.TabIndex = 0;
            // 
            // treeView1
            // 
            this.TreeView_Changelog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView_Changelog.Location = new System.Drawing.Point(3, 3);
            this.TreeView_Changelog.Name = "treeView1";
            this.Layout.SetRowSpan(this.TreeView_Changelog, 2);
            this.TreeView_Changelog.Size = new System.Drawing.Size(1003, 737);
            this.TreeView_Changelog.TabIndex = 3;
            // 
            // Changelog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 743);
            this.Controls.Add(this.Layout);
            this.Name = "Changelog";
            this.Text = "Changelog";
            this.Load += new System.EventHandler(this.Changelog_Load);
            this.Layout.ResumeLayout(false);
            this.Layout.PerformLayout();
            this.GroupBox_Estatisticas.ResumeLayout(false);
            this.GroupBox_Estatisticas.PerformLayout();
            this.GroupBox_Legenda.ResumeLayout(false);
            this.GroupBox_Legenda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Layout;
        private System.Windows.Forms.GroupBox GroupBox_Estatisticas;
        private System.Windows.Forms.GroupBox GroupBox_Legenda;
        private System.Windows.Forms.TreeView TreeView_Changelog;
        private System.Windows.Forms.FlowLayoutPanel GroupBox_Legenda_Layout;
        private System.Windows.Forms.FlowLayoutPanel GroupBox_Estatisticas_Layout;
    }
}