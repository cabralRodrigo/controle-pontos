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
            return $@"
                <script type'text/javascript'>
                    (function(args){{
                        {this.body}
                    }})(JSON.parse('{JsonConvert.SerializeObject(this.parameters)}'));
                </script>";
        }
    }
}