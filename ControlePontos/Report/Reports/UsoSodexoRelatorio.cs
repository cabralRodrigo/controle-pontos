using ControlePontos.Model;
using ControlePontos.Report.Reports.Template.Html;
using ControlePontos.Report.Reports.Template.Html.Misc;
using ControlePontos.Report.Reports.Template.Html.Section.Chart;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ControlePontos.Report.Reports
{
    internal class UsoSodexoRelatorio : IReport
    {
        public string Name
        {
            get { return "Uso Geral do Sodexo"; }
        }

        public IReportExecutionResult Execute(ConfiguracaoDias config, int ano, int mes, MesTrabalho mesTrabalho)
        {
            var file = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".html");

            using (var writer = new StreamWriter(File.Open(file, FileMode.CreateNew), Encoding.UTF8))
            {
                var template = new HtmlTemplate(string.Format("Relatório mensal: {0} de {1}", new CultureInfo("pt-br").DateTimeFormat.GetMonthName(mes).ToTitleCase(), ano));

                template.AddScript(Script.ChartJs);
                template.AddSection(new ChartHtmlSection("Evolução do Uso (Mês Completo)", "graf-1", this.CreateChart(mesTrabalho, true, ChartType.Line)));
                template.AddSection(new ChartHtmlSection("Evolução do Uso (Dias Cadastrados)", "graf-2", this.CreateChart(mesTrabalho, false, ChartType.Line)));

                writer.Write(template.TransformText());
            }

            return new OpenFileReportExecutionResult(file);
        }

        private Chart CreateChart(MesTrabalho mesTrabalho, bool mesInteiro, ChartType type)
        {
            var grafico = new Chart()
            {
                Type = type,
                Options = new
                {
                    scales = new
                    {
                        xAxes = new dynamic[]
                        { 
                            new
                            { 
                                time = new 
                                { 
                                    parser = "dd/MM/yyyy" 
                                } 
                            }
                        }
                    }
                }
            };

            var dicData = mesTrabalho.Dias.Where(w => w.ValorAlmoco.HasValue || mesInteiro).ToDictionary(w => w.Data.ToString("dd/MM/yyyy"), w => w.ValorAlmoco.HasValue ? Math.Round(w.ValorAlmoco.Value, 2) : 0);

            grafico.Data = new ChartData
            {
                Labels = dicData.Keys.ToArray(),
                Datasets = new[]
                {
                    new ChartDataset
                    {
                        Data = dicData.Values.Cast<object>().ToArray(),
                        Label = "Valor Diário"
                    }
                }
            };

            return grafico;
        }
    }
}