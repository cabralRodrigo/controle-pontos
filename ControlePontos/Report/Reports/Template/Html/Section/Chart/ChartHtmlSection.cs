using ControlePontos.Report.Reports.Template.Html.Misc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace ControlePontos.Report.Reports.Template.Html.Section.Chart
{
    public class ChartHtmlSection : ILinkableHtmlSection
    {
        private Chart chart;

        public bool ShouldRenderInsideContent { get { return true; } }
        public string Name { get; private set; }
        public string Link { get; private set; }
        public string Legend { get; set; }

        public ChartHtmlSection(string name, string link, Chart chart)
        {
            this.Name = name;
            this.Link = link;
            this.chart = chart;
        }

        public IEnumerable<Script> GetDependencies()
        {
            return new Script[] { Script.ChartJs };
        }

        public string Render()
        {
            var chartId = Guid.NewGuid();

            return $@"
                <div id='{this.Link}'>
                    {this.RenderChartJs(chartId.ToString())}
                    <div>
                        <h1>{this.Name}</h1>
                        <canvas id='{chartId}'></canvas>
                        <label>{this.Legend}</label>
                    </div>
                </div>
            ";
        }

        private string RenderChartJs(string chartId)
        {
            return $@"
                <script type='text/javascript'>
                    window.addEventListener('load', function load(){{
                        window.removeEventListener('load', load, false);

                        new Chart(document.getElementById('{this.chart.Type.ToString().ToLower()}'), {{
                            type: '{chartId}',
                            data: JSON.parse('{this.RenderChartData()}'),
                            options: {this.RenderChartOptions()}
                        }});
                    }}, false);
                </script>
            ";
        }

        private string RenderChartOptions()
        {
            if (this.chart.Options is string)
                return this.chart.Options as string;
            else
                return $"JSON.parse('{JsonConvert.SerializeObject(this.chart.Options)}')";
        }

        private string RenderChartData()
        {
            return JsonConvert.SerializeObject(this.chart.Data, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.None
            });
        }
    }
}