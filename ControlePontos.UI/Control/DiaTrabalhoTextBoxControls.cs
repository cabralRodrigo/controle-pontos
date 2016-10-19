using ControlePontos.Extensions;
using ControlePontos.Model;
using ControlePontos.Model.Configuracao;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ControlePontos.Control
{
    internal class TextBoxCell : DataGridViewTextBoxCell, IDiaTrabalhoCell
    {
        public void AddedCell(ConfiguracaoApp appConfig, DiaTrabalho dia)
        {
            var config = this.Configuracao();

            if (config != null && !config.Formato.IsNullOrEmpty())
                this.Style.Format = config.Formato;

            this.UpdateCell(appConfig, dia);
        }

        public void UpdateCell(ConfiguracaoApp appConfig, DiaTrabalho dia)
        {
            var config = this.Configuracao() ?? new DiaTrabalhoColumnConfiguracao();

            Color? customColor = null;
            if (config != null && config.Colorizador != null)
                customColor = config.Colorizador(appConfig, dia, this.Value);

            this.Style.BackColor = appConfig.Cores.DiaNormal;
            this.SetReadonly(config.SempreReadOnly, config.SempreReadOnly, customColor);

            if (dia.Falta)
            {
                this.Style.BackColor = appConfig.Cores.Falta;
                this.SetReadonly(true, false, customColor);
            }
            else
            {
                var aplicarCustomColor = true;
                var cor = this.Style.BackColor;
                var @readonly = this.ReadOnly;

                if (!appConfig.DiasTrabalho.Contains(dia.Data.DayOfWeek))
                {
                    cor = appConfig.Cores.NaoTrabalho;
                    @readonly = true;
                    aplicarCustomColor = false;
                }
                else if (appConfig.Feriados.Feriados.Contains(dia.Data.Date))
                {
                    cor = appConfig.Cores.Feriado;
                    @readonly = true;
                    aplicarCustomColor = false;
                }
                else if (appConfig.Ferias.Contains(dia.Data.Date))
                {
                    cor = appConfig.Cores.Ferias;
                    @readonly = true;
                    aplicarCustomColor = false;
                }
                else if (DateTime.Now.Date == dia.Data.Date)
                    cor = appConfig.Cores.Hoje;

                this.Style.BackColor = cor;
                this.SetReadonly(@readonly, aplicarCustomColor, customColor);
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            var config = this.Configuracao();
            if (config != null && config.Formatador != null)
                formattedValue = config.Formatador(value);

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }

        private void SetReadonly(bool @readonly, bool aplicarCustomColor, Color? customColor)
        {
            if (@readonly)
            {
                this.ReadOnly = true;
                if (aplicarCustomColor && customColor.HasValue)
                    this.Style.ForeColor = customColor.Value;
                else
                    this.Style.ForeColor = Color.DimGray;
            }
            else
            {
                this.ReadOnly = false;
                this.Style.ForeColor = customColor.HasValue ? customColor.Value : Color.Black;
            }
        }

        private DiaTrabalhoColumnConfiguracao Configuracao()
        {
            var coluna = this.OwningColumn as TextBoxColumn;
            if (coluna == null)
                throw new Exception("OwningColumn invalid!");

            return coluna == null ? null : coluna.Configuracao;
        }
    }

    internal class TextBoxColumn : DataGridViewColumn
    {
        public DiaTrabalhoColumnConfiguracao Configuracao { get; set; }

        public TextBoxColumn(string nome, string cabecalho, DiaTrabalhoColumnConfiguracao config)
        {
            this.Name = nome;
            this.HeaderText = cabecalho;
            this.ValueType = config.Tipo;
            this.Configuracao = config;
            this.CellTemplate = new TextBoxCell();
            this.SortMode = DataGridViewColumnSortMode.Automatic;
        }
    }
}