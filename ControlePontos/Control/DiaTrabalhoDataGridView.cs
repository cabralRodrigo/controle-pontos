using ControlePontos.Extensions;
using ControlePontos.Model;
using ControlePontos.Model.Configuracao;
using ControlePontos.Native;
using ControlePontos.Servicos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
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
        private ConfiguracaoApp config;
        private TimeSpan? ultimoHorarioEditado;

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

        public void DefinirHoraEntrada(DateTime data, TimeSpan hora)
        {
            this.DefinirHora(data, hora, Colunas.ENTRADA, d => d.Empresa.Entrada);
        }

        public void DefinirHoraAlmocoEntrada(DateTime data, TimeSpan hora)
        {
            this.DefinirHora(data, hora, Colunas.ALMOCO_SAIDA, d => d.Almoco.Entrada);
        }

        public void DefinirHoraAlmocoSaida(DateTime data, TimeSpan hora)
        {
            this.DefinirHora(data, hora, Colunas.ALMOCO_RETORNO, d => d.Almoco.Saida);
        }

        public void DefinirHoraSaida(DateTime data, TimeSpan hora)
        {
            this.DefinirHora(data, hora, Colunas.SAIDA, d => d.Empresa.Saida);
        }

        public void DefinirValorAlmoco(DateTime data, decimal valor)
        {
            int rowIndex = -1;
            for (int i = 0; i < this.Rows.Count; i++)
            {
                var dia = this.Rows[i].Cells[Colunas.OBJETO].Value as DiaTrabalho;
                if (dia.Data.Date == data.Date)
                {
                    rowIndex = i;
                    break;
                }
            }

            if (rowIndex >= 0)
            {
                this.Rows[rowIndex].Cells[Colunas.ALMOCO_VALOR].Value = valor;
                this.AtualizarValorAlmoco(rowIndex);
            }
        }

        public IEnumerable<DiaTrabalho> ObterDias()
        {
            return this.Rows.OfType<DataGridViewRow>().Select(s => s.Cells[Colunas.OBJETO].Value as DiaTrabalho);
        }

        private void DefinirHora(DateTime data, TimeSpan hora, string nomeColuna, Func<DiaTrabalho, TimeSpan?> acessorPropriedade)
        {
            int rowIndex = 0;
            for (int i = 0; i < this.Rows.Count; i++)
            {
                var dia = this.Rows[i].Cells[Colunas.OBJETO].Value as DiaTrabalho;
                if (dia.Data.Date == data.Date)
                {
                    this.ultimoHorarioEditado = acessorPropriedade(dia);
                    rowIndex = i;
                    break;
                }
            }
            this.Rows[rowIndex].Cells[nomeColuna].Value = hora.ToString(@"hh\:mm");
            this.AtualizarHorarios(rowIndex, nomeColuna);
        }

        public DiaTrabalho this[DateTime data]
        {
            get
            {
                foreach (var dia in this.Rows.OfType<DataGridViewRow>().Select(s => s.Cells[Colunas.OBJETO].Value as DiaTrabalho))
                {
                    if (dia.Data.Date == data.Date)
                        return dia;
                }

                return null;
            }
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

        public void BindDias(ConfiguracaoApp config, IEnumerable<DiaTrabalho> dias)
        {
            this.config = config;
            this.Columns.Clear();
            Func<object, string> descricaoTimeSpan = tempo =>
            {
                var timespan = tempo as TimeSpan?;
                return timespan?.Descricao() ?? string.Empty;
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
                SempreReadOnly = true,
                Tipo = typeof(DayOfWeek),
                Formatador = dia => Thread.CurrentThread.CurrentUICulture.DateTimeFormat.GetDayName((DayOfWeek)dia)
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
                        return tempo.Value.TotalHours > ConfiguracaoApp.HORAS_ALMOCO ? Color.Red : Color.DarkBlue;
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
                        return tempo.Value.TotalHours < (config.HoraFim - config.HoraInicio).TotalHours - ConfiguracaoApp.HORAS_ALMOCO ? Color.Red : Color.DarkBlue;
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
                    dia.Data.DayOfWeek,
                    dia.Falta,
                    dia.Empresa.Entrada?.ToString(@"hh\:mm") ?? string.Empty,
                    dia.Almoco.Entrada?.ToString(@"hh\:mm") ?? string.Empty,
                    dia.Almoco.Saida?.ToString(@"hh\:mm") ?? string.Empty,
                    dia.Empresa.Saida?.ToString(@"hh\:mm") ?? string.Empty,
                    dia.ValorAlmoco,
                    dia.Almoco.TempoTotal(),
                    coeficiente?.Negate(),
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

                    cell.Value = dia.Coeficiente(this.config.HoraInicio, this.config.HoraFim)?.Negate();
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
            var timeSpan = this.ValidarHorario(this.ParserServico.ParseTimeSpan(valor), nomeColuna, rowIndex);

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
            this.ValoresAtualizados?.Invoke();
        }

        private TimeSpan? ValidarHorario(TimeSpan? horario, string nomeColuna, int rowIndex)
        {
            if (horario.HasValue)
            {
                var dia = this.Rows[rowIndex].Cells[Colunas.OBJETO].Value as DiaTrabalho;
                string mensagemErro = null;

                switch (nomeColuna)
                {
                    case Colunas.ENTRADA:
                        {
                            if (dia.Almoco.Entrada.HasValue && dia.Almoco.Entrada.Value <= horario.Value)
                                mensagemErro = "O horário de entrada deve ser menor que o horário de saída para o almoço";

                            if (dia.Almoco.Saida.HasValue && dia.Almoco.Saida.Value <= horario.Value)
                                mensagemErro = "O horário de entrada deve ser menor que o horário de retorno do almoço";

                            if (dia.Empresa.Saida.HasValue && dia.Empresa.Saida.Value <= horario.Value)
                                mensagemErro = "O horário de entrada deve ser menor que o horário de saída";
                        }
                        break;
                    case Colunas.ALMOCO_SAIDA:
                        {
                            if (dia.Empresa.Entrada.HasValue && dia.Empresa.Entrada.Value >= horario.Value)
                                mensagemErro = "O horário de saída para o almoço deve ser maior que o horário de entrada";

                            if (dia.Almoco.Saida.HasValue && dia.Almoco.Saida.Value < horario.Value)
                                mensagemErro = "O horário de saída para o almoço deve ser menor que o horário de retorno do almoço";

                            if (dia.Empresa.Saida.HasValue && dia.Empresa.Saida.Value <= horario.Value)
                                mensagemErro = "O horário de saída para o almoço deve ser menor que o horário de saída";
                        }
                        break;
                    case Colunas.ALMOCO_RETORNO:
                        {
                            if (dia.Empresa.Entrada.HasValue && dia.Empresa.Entrada.Value >= horario.Value)
                                mensagemErro = "O horário de retorno do almoço deve ser maior que o horário de entrada";

                            if (dia.Almoco.Entrada.HasValue && dia.Almoco.Entrada.Value > horario.Value)
                                mensagemErro = "O horário de retorno do almoço deve ser maior que o horário de saída para o almoço";

                            if (dia.Empresa.Saida.HasValue && dia.Empresa.Saida.Value <= horario.Value)
                                mensagemErro = "O horário de retorno do almoço deve ser menor que o horário de saída";
                        }
                        break;
                    case Colunas.SAIDA:
                        {
                            if (dia.Empresa.Entrada.HasValue && dia.Empresa.Entrada.Value >= horario.Value)
                                mensagemErro = "O horário de saída deve ser maior que o horário de entrada";

                            if (dia.Almoco.Entrada.HasValue && dia.Almoco.Entrada.Value >= horario.Value)
                                mensagemErro = "O horário de saída deve ser maior que o horário de saída para o almoço";

                            if (dia.Almoco.Saida.HasValue && dia.Almoco.Saida.Value >= horario.Value)
                                mensagemErro = "O horário de saída deve ser maior que o horário de retorno do almoço";
                        }
                        break;
                    default:
                        return horario;
                }

                if (!mensagemErro.IsNullOrEmpty())
                {
                    MessageBox.Show(mensagemErro, "Horário Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return this.ultimoHorarioEditado;
                }
            }

            return horario;
        }

        private void AtualizarValorAlmoco(int rowIndex)
        {
            var valor = (decimal?)this.Rows[rowIndex].Cells[Colunas.ALMOCO_VALOR].Value;

            this[rowIndex].ValorAlmoco = valor;
            this.ValoresAtualizados?.Invoke();
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

        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex > 0 && Colunas.TEMPOS.Contains(this.Columns[e.ColumnIndex].Name))
                this.ultimoHorarioEditado = this.ParserServico.ParseTimeSpan(this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString());

            base.OnCellBeginEdit(e);
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

            this.ultimoHorarioEditado = null;
            base.OnCellEndEdit(e);
        }

        protected override void OnCellContentClick(DataGridViewCellEventArgs e)
        {
            base.OnCellContentClick(e);
            if (this.Columns[e.ColumnIndex].Name == Colunas.FALTA && e.RowIndex >= 0)
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