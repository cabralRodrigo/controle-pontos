using ControlePontos.Model;
using ControlePontos.Native;
using ControlePontos.Servicos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ControlePontos.Control
{
    internal partial class DiaTrabalhoDataGridView : DataGridView
    {
        private static class Colunas
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

            public static readonly string[] TEMPOS = { ENTRADA, ALMOCO_SAIDA, ALMOCO_RETORNO, SAIDA };
        }

        public ICalculoServico CalculoServico { get; set; }
        public IControlRenderer ControlRenderer { get; set; }
        public IParserServico ParserServico { get; set; }
        private ConfigApp config;

        public event Action ValoresAtualizados;

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
        }

        private DiaTrabalho this[int rowIndex]
        {
            get
            {
                return this.Rows[rowIndex].Cells[Colunas.OBJETO].Value as DiaTrabalho;
            }
            set
            {
                this.Rows[rowIndex].Cells[Colunas.OBJETO].Value = value;
            }
        }

        public void BindDias(ConfigApp config, IEnumerable<DiaTrabalho> dias)
        {
            this.config = config;
            this.Columns.Clear();
            Func<object, string> descricaoTimeSpan = tempo =>
            {
                var timespan = tempo as TimeSpan?;
                if (timespan.HasValue)
                    return timespan.Descricao();
                else
                    return string.Empty;
            };

            #region Colunas

            this.Columns.Add(new TextBoxColumn(Colunas.DATA, "Data", new DiaTrabalhoColumnConfiguracao
            {
                Formato = "dd/MM/yyyy",
                SempreReadOnly = true,
                Tipo = typeof(DateTime)
            }));

            this.Columns.Add(new TextBoxColumn(Colunas.DIA_SEMANA, "Dia da Semana", new DiaTrabalhoColumnConfiguracao
            {
                Formato = "dddd",
                SempreReadOnly = true,
                Tipo = typeof(DateTime)
            }));

            this.Columns.Add(new CheckBoxColumn(Colunas.FALTA, "Falta"));

            this.Columns.Add(new TextBoxColumn(Colunas.ENTRADA, "Entrada", new DiaTrabalhoColumnConfiguracao
            {
                SempreReadOnly = false,
                Tipo = typeof(string)
            }));

            this.Columns.Add(new TextBoxColumn(Colunas.ALMOCO_SAIDA, "Almoço - Saída", new DiaTrabalhoColumnConfiguracao
            {
                SempreReadOnly = false,
                Tipo = typeof(string)
            }));

            this.Columns.Add(new TextBoxColumn(Colunas.ALMOCO_RETORNO, "Almoço - Retorno", new DiaTrabalhoColumnConfiguracao
            {
                SempreReadOnly = false,
                Tipo = typeof(string)
            }));

            this.Columns.Add(new TextBoxColumn(Colunas.SAIDA, "Saída", new DiaTrabalhoColumnConfiguracao
            {
                SempreReadOnly = false,
                Tipo = typeof(string)
            }));

            this.Columns.Add(new TextBoxColumn(Colunas.ALMOCO_VALOR, "Valor Almoço", new DiaTrabalhoColumnConfiguracao
            {
                Formato = "c",
                SempreReadOnly = false,
                Tipo = typeof(decimal?)
            }));

            this.Columns.Add(new TextBoxColumn(Colunas.CALCULO_TEMPO_ALMOCO, "Tempo Almoço", new DiaTrabalhoColumnConfiguracao
            {
                SempreReadOnly = true,
                Tipo = typeof(TimeSpan?),
                Formatador = descricaoTimeSpan,
                Colorizador = (configApp, dia, valor) =>
                {
                    var tempo = valor as TimeSpan?;
                    if (tempo.HasValue)
                        return tempo.Value.TotalHours > ConfigApp.HORAS_ALMOCO ? Color.Red : Color.DarkBlue;
                    else
                        return null;
                }
            }));

            this.Columns.Add(new TextBoxColumn(Colunas.CALCULO_HORAS, "Coeficiente", new DiaTrabalhoColumnConfiguracao
            {
                SempreReadOnly = true,
                Tipo = typeof(TimeSpan?),
                Formatador = descricaoTimeSpan,
                Colorizador = (configApp, dia, valor) =>
                {
                    var tempo = valor as TimeSpan?;
                    if (tempo.HasValue)
                        return tempo.Value.TotalHours < 0 ? Color.Red : Color.DarkBlue;
                    else
                        return null;
                }
            }));

            this.Columns.Add(new TextBoxColumn(Colunas.CALCULO_HORAS_TRABALHADAS, "Total de Horas", new DiaTrabalhoColumnConfiguracao
            {
                SempreReadOnly = true,
                Tipo = typeof(TimeSpan?),
                Formatador = descricaoTimeSpan,
                Colorizador = (configApp, dia, valor) =>
                {
                    var tempo = valor as TimeSpan?;
                    if (tempo.HasValue)
                        return tempo.Value.TotalHours < (config.HoraFim - config.HoraInicio).TotalHours - ConfigApp.HORAS_ALMOCO ? Color.Red : Color.DarkBlue;
                    else
                        return null;
                }
            }));

            this.Columns.Add(Colunas.OBJETO, string.Empty);
            this.Columns[Colunas.OBJETO].Visible = false;

            this.Columns[Colunas.DATA].Width = 80;
            this.Columns[Colunas.DIA_SEMANA].Width = 110;
            this.Columns[Colunas.FALTA].Width = 36;

            #endregion Colunas

            foreach (var dia in dias)
            {
                var coeficiente = dia.Coeficiente(this.config.HoraInicio, this.config.HoraFim);

                this.Rows.Add(new object[]  {
                    dia.Data,
                    dia.Data,
                    dia.Falta,
                    dia.Empresa.Entrada.ToStringOr(string.Empty,@"hh\:mm"),
                    dia.Almoco.Entrada.ToStringOr(string.Empty,@"hh\:mm"),
                    dia.Almoco.Saida.ToStringOr(string.Empty,@"hh\:mm"),
                    dia.Empresa.Saida.ToStringOr(string.Empty,@"hh\:mm"),
                    dia.ValorAlmoco,
                    dia.Almoco.TempoTotal(),
                    coeficiente.Negate(),
                    this.CalculoServico.TotalHorasTrabalhadas(dia),
                    dia
                });
            }
        }

        private void AtualizarEstatisticas(int rowIndex, bool tempoAlmoco = true, bool coeficiente = true, bool totalHoras = true)
        {
            if (tempoAlmoco || coeficiente || totalHoras)
            {
                var linha = this.Rows[rowIndex];
                var dia = linha.Cells[Colunas.OBJETO].Value as DiaTrabalho;

                if (tempoAlmoco)
                {
                    var cell = this.Rows[rowIndex].Cells[Colunas.CALCULO_TEMPO_ALMOCO] as IDiaTrabalhoCell;

                    cell.Value = dia.Almoco.TempoTotal();
                    cell.UpdateCell(this.config, dia);
                }

                if (coeficiente)
                {
                    var cell = this.Rows[rowIndex].Cells[Colunas.CALCULO_HORAS] as IDiaTrabalhoCell;

                    cell.Value = dia.Coeficiente(this.config.HoraInicio, this.config.HoraFim).Negate();
                    cell.UpdateCell(this.config, dia);
                }

                if (totalHoras)
                {
                    var cell = this.Rows[rowIndex].Cells[Colunas.CALCULO_HORAS_TRABALHADAS] as IDiaTrabalhoCell;

                    cell.Value = this.CalculoServico.TotalHorasTrabalhadas(dia);
                    cell.UpdateCell(this.config, dia);
                }
            }
        }

        private void AtualizarHorarios(int rowIndex, string nomeColuna)
        {
            var valor = (string)this.Rows[rowIndex].Cells[nomeColuna].Value;
            var timeSpan = this.ParserServico.ParseTimeSpan(valor);

            this.Rows[rowIndex].Cells[nomeColuna].Value = timeSpan.HasValue ? timeSpan.Value.ToString(@"hh\:mm") : null;

            var atualizarTempoAlmoco = false;
            switch (nomeColuna)
            {
                case Colunas.ENTRADA:
                    this[rowIndex].Empresa.Entrada = timeSpan;
                    break;

                case Colunas.ALMOCO_SAIDA:
                    atualizarTempoAlmoco = true;
                    this[rowIndex].Almoco.Entrada = timeSpan;
                    break;

                case Colunas.ALMOCO_RETORNO:
                    atualizarTempoAlmoco = true;
                    this[rowIndex].Almoco.Saida = timeSpan;
                    break;

                case Colunas.SAIDA:
                    this[rowIndex].Empresa.Saida = timeSpan;
                    break;
            }

            this.AtualizarEstatisticas(rowIndex, tempoAlmoco: atualizarTempoAlmoco, coeficiente: true, totalHoras: true);
            if (this.ValoresAtualizados != null)
                this.ValoresAtualizados();
        }

        private void AtualizarValorAlmoco(int rowIndex)
        {
            var valor = (decimal?)this.Rows[rowIndex].Cells[Colunas.ALMOCO_VALOR].Value;

            this[rowIndex].ValorAlmoco = valor;
            if (this.ValoresAtualizados != null)
                this.ValoresAtualizados();
        }

        private void AtualizarFalta(int rowIndex)
        {
            var valor = (bool)this.Rows[rowIndex].Cells[Colunas.FALTA].Value;
            this[rowIndex].Falta = valor;

            this.AtualizarCelulasLinhas(rowIndex);
            if (this.ValoresAtualizados != null)
                this.ValoresAtualizados();
        }

        private void AtualizarCelulasLinhas(int rowIndex)
        {
            foreach (var cell in this.Rows[rowIndex].Cells.Cast<DataGridViewCell>().OfType<IDiaTrabalhoCell>())
                cell.AddedCell(this.config, this[rowIndex]);
        }

        #region Eventos

        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            this.AtualizarCelulasLinhas(e.RowIndex);
            base.OnRowsAdded(e);
        }

        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var nomeColuna = this.Columns[e.ColumnIndex].Name;

                if (nomeColuna == Colunas.ALMOCO_VALOR)
                    this.AtualizarValorAlmoco(e.RowIndex);
                else if (nomeColuna == Colunas.FALTA)
                    this.AtualizarFalta(e.RowIndex);
                else if (Colunas.TEMPOS.Contains(nomeColuna))
                    this.AtualizarHorarios(e.RowIndex, nomeColuna);
            }

            base.OnCellEndEdit(e);
        }

        protected override void OnCellContentClick(DataGridViewCellEventArgs e)
        {
            base.OnCellContentClick(e);
            if (this.Columns[e.ColumnIndex].Name == Colunas.FALTA)
            {
                this.CurrentCell = this[0, e.RowIndex];
                this.CurrentCell.Selected = false;

                this.CurrentCell = this[e.ColumnIndex, e.RowIndex];
                this.CurrentCell.Selected = true;
            }
        }

        #endregion Eventos
    }
}