using ControlePontos.Report.Reports.Template.Html.Misc;
using System.Collections.Generic;

namespace ControlePontos.Report.Reports.Template.Html.Section
{
    public class TextHtmlSection : ILinkableHtmlSection
    {
        private string texto;

        public bool ShouldRenderInsideContent { get { return true; } }
        public string Name { get; private set; }
        public string Link { get; private set; }

        public TextHtmlSection(string name, string link, string texto)
        {
            this.Name = name;
            this.Link = link;
            this.texto = texto;
        }

        public IEnumerable<Script> GetDependencies()
        {
            return new Script[0];
        }

        public string Render()
        {
            return $@"
                <div id='{this.Link}'>
                    <div>
                        <h1>{this.Name}</h1>
                        {this.texto}
                    </div>
                </div>
            ";
        }
    }
}