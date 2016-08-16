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

            var html = @"
                <div id='{0}'>
                    {1}
                    <div>
                        <h1>{2}</h1>
                        <canvas id='{3}'></canvas>
                        <label>{4}</label>
                    </div>
                </div>
            ";

            return string.Format(html, this.Link, this.RenderChartJs(chartId.ToString()), this.Name, chartId, this.Legend);
        }

        private string RenderChartJs(string chartId)
        {
            var js = @"
                <script type='text/javascript'>
                    window.addEventListener('load', function load(){{
                        window.removeEventListener('load', load, false);

                        new Chart(document.getElementById('{0}'), {{
                            type: '{1}',
                            data: JSON.parse('{2}'),
                            options: {3}
                        }});
                    }}, false);
                </script>
            ";

            return string.Format(js, chartId, this.chart.Type.ToString().ToLower(), this.RenderChartData(), this.RenderChartOptions());
        }

        private string RenderChartOptions()
        {
            if (this.chart.Options is string)
                return this.chart.Options as string;
            else
                return string.Format("JSON.parse('{0}')", JsonConvert.SerializeObject(this.chart.Options));
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