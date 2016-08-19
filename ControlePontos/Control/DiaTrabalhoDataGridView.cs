using ControlePontos.Model;
using ControlePontos.Servicos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ControlePontos.Control
{
    internal partial class DiaTrabalhoDataGridView : DataGridView
    {
        private static class Nomes
        {
            public const string DATA = "data";
            public const string DIA_SEMANA = "dia-semana";
            public const string FALTA = "falta";
            public const string ENTRADA = "entrada";
            public const string ALMOCO_SAIDA = "almoco-saida";
            public const string ALMOCO_RETORNO = "almoco-retorno";
            public const string ALMOCO_VALOR = "almoco-valor";
            public const string SAIDA = "saida";
            public const string OBJETO = "dia-trabalho";
            public const string CALCULO_HORAS = "calculo-horas";
            public const string CALCULO_TEMPO_ALMOCO = "calculo-tempo-almoco";
            public const string CALCULO_HORAS_TRABALHADAS = "calculo-horas-trabalhadas";
        }

        public ICalculoServico CalculoServico { get; set; }
        private ConfigApp config;

        public DiaTrabalhoDataGridView()
        {
            this.AllowUserToAddRows = false;
            this.RowHeadersVisible = false;
            this.AllowUserToResizeRows = false;
            this.MultiSelect = false;
            this.EditMode = DataGridViewEditMode.EditOnEnter;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Columns.Clear();

            InitializeComponent();
            this.BindDias(null, new List<DiaTrabalho>());
        }

        public void BindDias(ConfigApp config, IEnumerable<DiaTrabalho> dias)
        {
            this.config = config;
            this.Columns.Clear();

            this.Columns.Add(Nomes.DATA, "Data");
            this.Columns.Add(Nomes.DIA_SEMANA, "Dia da Semana");
            this.Columns.Add(new DataGridViewCheckBoxColumn { Name = Nomes.FALTA, HeaderText = "Falta" });
            this.Columns.Add(Nomes.ENTRADA, "Entrada");
            this.Columns.Add(Nomes.ALMOCO_SAIDA, "Almoço - Saída");
            this.Columns.Add(Nomes.ALMOCO_RETORNO, "Almoço - Retorno");
            this.Columns.Add(Nomes.SAIDA, "Saída");
            this.Columns.Add(Nomes.ALMOCO_VALOR, "Valor Almoço");
            this.Columns.Add(Nomes.CALCULO_TEMPO_ALMOCO, "Tempo Almoço");
            this.Columns.Add(Nomes.CALCULO_HORAS, "Coeficiente");
            this.Columns.Add(Nomes.CALCULO_HORAS_TRABALHADAS, "Total de Horas");
            this.Columns.Add(Nomes.OBJETO, string.Empty);

            this.Columns[Nomes.CALCULO_HORAS_TRABALHADAS].CellTemplate = new Cell();

            this.Columns[Nomes.DATA].ReadOnly = true;
            this.Columns[Nomes.DIA_SEMANA].ReadOnly = true;
            this.Columns[Nomes.CALCULO_TEMPO_ALMOCO].ReadOnly = true;
            this.Columns[Nomes.CALCULO_HORAS_TRABALHADAS].ReadOnly = true;
            this.Columns[Nomes.CALCULO_HORAS].ReadOnly = true;

            this.Columns[Nomes.OBJETO].Visible = false;
            this.Columns[Nomes.DATA].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.Columns[Nomes.ALMOCO_VALOR].DefaultCellStyle.Format = "c";
            this.Columns[Nomes.ALMOCO_VALOR].ValueType = typeof(decimal?);
            this.Columns[Nomes.ENTRADA].DefaultCellStyle.Format = @"hh\:mm";
            this.Columns[Nomes.ALMOCO_SAIDA].DefaultCellStyle.Format = @"hh\:mm";
            this.Columns[Nomes.ALMOCO_RETORNO].DefaultCellStyle.Format = @"hh\:mm";
            this.Columns[Nomes.SAIDA].DefaultCellStyle.Format = @"hh\:mm";
            this.Columns[Nomes.FALTA].Width = 35;

            foreach (var dia in dias)
            {
                var coeficiente = dia.Coeficiente(this.config.HoraInicio, this.config.HoraFim);

                this.Rows.Add(new object[]  {
                    dia.Data,
                    dia.Data.ToString("dddd", new CultureInfo("pt-br")),
                    dia.Falta,
                    dia.Empresa.Entrada,
                    dia.Almoco.Entrada,
                    dia.Almoco.Saida,
                    dia.Empresa.Saida,
                    dia.ValorAlmoco,
                    dia.Almoco.TempoTotal().Descricao(),
                    coeficiente.HasValue ? coeficiente.Value.Negate().Descricao() : null,
                    this.CalculoServico.TotalHorasTrabalhadas(dia),
                    dia
                });
            }

            foreach (var row in this.Rows.Cast<DataGridViewRow>())
                AplicarEstiloNaLinha(row, true);
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var valor = this.Cell(e.ColumnIndex, e.RowIndex).Value;
                Action<DiaTrabalho, TimeSpan?> acao = null;

                switch (this.Columns[e.ColumnIndex].Name)
                {
                    case Nomes.ENTRADA:
                        acao = (dia, span) => dia.Empresa.Entrada = span;
                        break;

                    case Nomes.ALMOCO_SAIDA:
                        acao = (dia, span) => dia.Almoco.Entrada = span;
                        break;

                    case Nomes.ALMOCO_RETORNO:
                        acao = (dia, span) => dia.Almoco.Saida = span;
                        break;

                    case Nomes.SAIDA:
                        acao = (dia, span) => dia.Empresa.Saida = span;
                        break;

                    case Nomes.ALMOCO_VALOR:
                        this.UpdateValor(e.RowIndex);
                        goto evento;
                    case Nomes.FALTA:
                        this.UpdateFalta(e.RowIndex);
                        this.AplicarEstiloFalta(this.Rows[e.RowIndex]);
                        this.AplicarEstiloNaLinha(this.Rows[e.RowIndex]);
                        goto evento;
                    default:
                        return;
                }

                if (acao != null)
                    this.UpdateTimeSpan(e.ColumnIndex, e.RowIndex, valor, acao);
            }

        evento:
            base.OnCellValueChanged(e);
        }

        private void AplicarEstiloNaLinha(DataGridViewRow row, bool inicial = false)
        {
            var dia = row.Cells[Nomes.OBJETO].Value as DiaTrabalho;
            var color = Color.Black;
            var readOnly = true;
            var mudarRow = true;

            if (inicial)
                this.AplicarEstiloFalta(row);

            if (this.config.Ferias.Contains(dia.Data.Date))
            {
                color = Color.FromArgb(144, 195, 212);
                readOnly = true;
            }
            else if (!this.config.DiasTrabalho.Contains(dia.Data.DayOfWeek))
            {
                color = Color.FromArgb(212, 144, 147);
                readOnly = true;
            }
            else if (this.config.Feriados.Feriados.Contains(dia.Data.Date))
            {
                color = Color.FromArgb(175, 144, 212);
                readOnly = true;
            }
            else if (dia.Data.Date == DateTime.Now.Date)
            {
                color = Color.FromArgb(161, 212, 144);
                readOnly = false;
            }
            else
                mudarRow = false;

            foreach (var cell in row.Cells.Cast<DataGridViewCell>())
            {
                if (mudarRow)
                {
                    cell.ReadOnly = readOnly;
                    cell.Style.BackColor = color;
                }
                if (cell.ReadOnly)
                    cell.Style.ForeColor = Color.FromArgb(92, 92, 92);
            }
        }

        private void AplicarEstiloFalta(DataGridViewRow row)
        {
            var dia = row.Cells[Nomes.OBJETO].Value as DiaTrabalho;
            if (dia.Falta)
                foreach (var cell in row.Cells.Cast<DataGridViewCell>())
                {
                    if (cell.OwningColumn.Name != Nomes.FALTA && !cell.ReadOnly)
                    {
                        cell.ReadOnly = true;
                        cell.Tag = new object();
                    }

                    cell.Style.BackColor = Color.FromArgb(186, 116, 4);
                }
            else
                foreach (var cell in row.Cells.Cast<DataGridViewCell>())
                {
                    if (cell.Tag != null)
                    {
                        cell.ReadOnly = false;
                        cell.Tag = null;
                        cell.Style.ForeColor = cell.OwningRow.DefaultCellStyle.ForeColor;
                    }
                    cell.Style.BackColor = Color.White;
                }
        }

        private void UpdateTimeSpan(int columnIndex, int rowIndex, object valor, Action<DiaTrabalho, TimeSpan?> updater)
        {
            var dia = (DiaTrabalho)this.Rows[rowIndex].Cells[Nomes.OBJETO].Value;

            if (valor == null)
                updater(dia, null);
            else
            {
                var valors = valor.ToString();

                if (valors.Length == 4)
                    valors = string.Format("{0}{1}:{2}{3}", valors[0], valors[1], valors[2], valors[3]);
                else if (valors.Length == 3)
                    valors = string.Format("0{0}:{1}{2}", valors[0], valors[1], valors[2]);

                TimeSpan resultado;
                if (TimeSpan.TryParse(valors, out resultado))
                {
                    updater(dia, resultado);
                    this.Cell(columnIndex, rowIndex).Value = resultado;
                }
                else
                {
                    MessageBox.Show("Valor não válido!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    updater(dia, null);
                    this.Cell(columnIndex, rowIndex).Value = null;
                }
            }

            this.Rows[rowIndex].Cells[Nomes.OBJETO].Value = dia;

            var coeficiente = dia.Coeficiente(this.config.HoraInicio, this.config.HoraFim);

            this.Rows[rowIndex].Cells[Nomes.CALCULO_HORAS].Value = coeficiente.HasValue ? coeficiente.Value.Negate().Descricao() : null;
            this.Rows[rowIndex].Cells[Nomes.CALCULO_HORAS].Style.ForeColor = coeficiente.HasValue ? (coeficiente.Value < new TimeSpan(8, 0, 0) ? Color.Blue : Color.Red) : Color.Black;

            this.Rows[rowIndex].Cells[Nomes.CALCULO_TEMPO_ALMOCO].Value = dia.Almoco.TempoTotal().Descricao();
            this.Rows[rowIndex].Cells[Nomes.CALCULO_HORAS_TRABALHADAS].Value = this.CalculoServico.TotalHorasTrabalhadas(dia);
            this.Refresh();
        }

        private void UpdateValor(int rowIndex)
        {
            var dia = (DiaTrabalho)this.Rows[rowIndex].Cells[Nomes.OBJETO].Value;

            if (this.Rows[rowIndex].Cells[Nomes.ALMOCO_VALOR].Value != null)
                dia.ValorAlmoco = (decimal)this.Rows[rowIndex].Cells[Nomes.ALMOCO_VALOR].Value;
            else
                dia.ValorAlmoco = null;

            this.Rows[rowIndex].Cells[Nomes.OBJETO].Value = dia;
        }

        private void UpdateFalta(int rowIndex)
        {
            var dia = (DiaTrabalho)this.Rows[rowIndex].Cells[Nomes.OBJETO].Value;

            dia.Falta = (bool)this.Rows[rowIndex].Cells[Nomes.FALTA].Value;

            this.Rows[rowIndex].Cells[Nomes.OBJETO].Value = dia;
        }

        private DataGridViewCell Cell(int columnIndex, int rowIndex)
        {
            return this.Rows[rowIndex].Cells[columnIndex];
        }

        protected override void OnCellContentClick(DataGridViewCellEventArgs e)
        {
            base.OnCellContentClick(e);
            if (this.Columns[e.ColumnIndex].Name == Nomes.FALTA)
            {
                this.CurrentCell = this[0, e.RowIndex];
                this.CurrentCell.Selected = false;

                this.CurrentCell = this[e.ColumnIndex, e.RowIndex];
                this.CurrentCell.Selected = true;
            }
        }
    }

    internal class Cell : DataGridViewTextBoxCell
    {
        private static readonly TimeSpan tempo = new TimeSpan(8, 0, 0);

        public Cell()
        {
            this.ValueType = typeof(TimeSpan?);
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            var time = value as TimeSpan?;
            if (time.HasValue)
                cellStyle.ForeColor = time.Value < tempo ? Color.Red : Color.Blue;

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }
    }
}