using ControlePontos.Report.Reports.Template.Html.Misc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ControlePontos.Report.Reports.Template.Html.Section
{
    public class JavascriptHtmlSection : IHtmlSection
    {
        private Dictionary<string, string> parameters;
        private string body;

        public JavascriptHtmlSection(string name, string body, Dictionary<string, string> parameters = null)
        {
            this.Name = name;
            this.body = body;
            this.parameters = parameters ?? new Dictionary<string, string>();
        }

        public bool ShouldRenderInsideContent { get { return false; } }
        public string Name { get; private set; }

        public IEnumerable<Script> GetDependencies()
        {
            return new Script[0];
        }

        public string Render()
        {
            var json = JsonConvert.SerializeObject(this.parameters);

            var tag = @"
                <script type'text/javascript'>
                    (function(args){{
                        {0}
                    }})(JSON.parse('{1}'));
                </script>";

            return string.Format(tag, this.body, json);
        }
    }
}