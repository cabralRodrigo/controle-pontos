using ControlePontos.Extensions;
using ControlePontos.Model;
using ControlePontos.Model.Configuracao;
using ControlePontos.Report.Reports.Template.Html;
using ControlePontos.Report.Reports.Template.Html.Misc;
using ControlePontos.Report.Reports.Template.Html.Section;
using ControlePontos.Report.Reports.Template.Html.Section.Chart;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ControlePontos.Report.Reports
{
    internal class EvolucaoEntradaSaidaRelatorio : IReport
    {
        public string Name
        {
            get { return "Evolução do Coeficiente"; }
        }

        public IReportExecutionResult Execute(ConfiguracaoApp config, int ano, int mes, MesTrabalho mesTrabalho)
        {
            var file = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".html");

            using (var writer = new StreamWriter(File.Open(file, FileMode.CreateNew), Encoding.UTF8))
            {
                var template = new HtmlTemplate($"Relatório mensal: {new CultureInfo("pt-br").DateTimeFormat.GetMonthName(mes).ToTitleCase()} de {ano}");
                template.AddScript(Script.ChartJs);
                template.AddScript(Script.Util);
                template.AddSection(this.RelacaoEntradaSaida(mesTrabalho));
                template.AddSection(this.RelacaoEvolucaoCoeficiente(config, mesTrabalho));

                writer.Write(template.TransformText());
            }

            return new OpenFileReportExecutionResult(file);
        }

        private IHtmlSection RelacaoEntradaSaida(MesTrabalho mesTrabalho)
        {
            var data = mesTrabalho.Dias.Where(w => !w.Falta && w.Empresa.EstaCompleto())
                .ToDictionary(w => w.Data.ToString("dd/MM/yyyy"), w => new Tuple<double, double>(w.Empresa.Entrada.Value.TotalSeconds, w.Empresa.Saida.Value.TotalSeconds));

            return new ChartHtmlSection("Relação de Entrada/Saída", "evo-horarios", new Chart
            {
                Data = new ChartData
                {
                    Labels = data.Keys.ToArray(),
                    Datasets = new ChartDataset[]
                    {
                        new ChartDataset
                        {
                            Label = "Horário de Entrada",
                            Data = data.Values.Select(w => w.Item1).Cast<object>().ToArray(),
                            BackgroundColor = "rgba(59, 146, 196, 0.5)"
                        },
                        new ChartDataset
                        {
                            Label = "Horário de Saída",
                            Data = data.Values.Select(w => w.Item2).Cast<object>().ToArray(),
                            BackgroundColor = "rgba(196, 72, 59, 0.5)"
                        }
                    }
                },
                Options = @"{
                    scales: {
                        xAxes: [{
                            time: {
                                parser: 'dd/MM/yyyy'
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                userCallback: function(value) { return util.secondsToTimeSpan(value, false); }
                            }
                        }]
                    },
                    tooltips: {
                        mode: 'label',
                        callbacks: {
                            label: function(props, data) {
                                return data.datasets[props.datasetIndex].label + ': ' + util.secondsToTimeSpan(props.yLabel, false);
                            }
                        }
                    },
                    hover: {mode: 'label'}
                }",
                Type = ChartType.Line
            });
        }

        private IHtmlSection RelacaoEvolucaoCoeficiente(ConfiguracaoApp config, MesTrabalho mesTrabalho)
        {
            var data = mesTrabalho.Dias.Where(w => !w.Falta && w.Coeficiente(config.HoraInicio, config.HoraFim).HasValue)
                .ToDictionary(w => w.Data.ToString("dd/MM/yyyy"), w => w.Coeficiente(config.HoraInicio, config.HoraFim).Value.Negate().TotalSeconds);

            var dataEvolucao = data.ToArray();

            for (int i = 0; i < dataEvolucao.Length; i++)
            {
                if (i == 0)
                    dataEvolucao[i] = new KeyValuePair<string, double>(dataEvolucao[i].Key, dataEvolucao[i].Value + mesTrabalho.CoficienteOffset * 60);

                if (!(i <= 0))
                    dataEvolucao[i] = new KeyValuePair<string, double>(dataEvolucao[i].Key, dataEvolucao[i].Value + dataEvolucao[i - 1].Value);
            }

            return new ChartHtmlSection("Relação/Evolução do Coeficiente", "evo-coef", new Chart
            {
                Data = new ChartData
                {
                    Labels = data.Keys.ToArray(),
                    Datasets = new[]
                    {
                        new ChartDataset
                        {
                            BackgroundColor = "rgba(59, 146, 196, 0.5)",
                            Label = "Coeficiênte Diário",
                            Data = data.Values.Cast<object>().ToArray()
                        },
                        new ChartDataset
                        {
                            BackgroundColor = "rgba(196, 72, 59, 0.5)",
                            Label = "Evolução Diária",
                            Data = dataEvolucao.Select(w => w.Value).Cast<object>().ToArray()
                        }
                    }
                },
                Type = ChartType.Line,
                Options = @"{
                    scales: {
                        xAxes: [{
                            time: {
                                parser: 'dd/MM/yyyy'
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                userCallback: function(value) { return util.secondsToTimeSpan(value, true); }
                            }
                        }]
                    },
                    tooltips: {
                        mode: 'label',
                        callbacks: {
                            label: function(props, data) {
                                return data.datasets[props.datasetIndex].label + ': ' + util.secondsToTimeSpan(props.yLabel, true);
                            }
                        }
                    }
                }"
            });
        }
    }
}