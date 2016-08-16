using ControlePontos.Report.Reports.Template.Html.Misc;
using ControlePontos.Report.Reports.Template.Html.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePontos.Report.Reports.Template.Html
{
    public partial class HtmlTemplate
    {
        private readonly List<Script> scripts;
        private readonly List<IHtmlSection> sections;
        private DateTime generationDate;
        private string title;

        public HtmlTemplate(string title)
        {
            this.title = title;
            this.scripts = new List<Script> { Script.BootstrapCss, Script.Jquery, Script.BootstrapJs };
            this.sections = new List<IHtmlSection>();
            this.generationDate = DateTime.Now;
        }

        public void Validate()
        {
            foreach (var section in this.sections)
                foreach (var sectionScript in section.GetDependencies())
                {
                    if (!this.scripts.Contains(sectionScript))
                        throw new Exception(string.Format("Section '{0}' requer que o script '{1}' esteja no template", section.Name, sectionScript.Nome));
                }
        }

        public void AddScript(Script script)
        {
            this.scripts.Add(script);
        }

        public void AddSection(IHtmlSection section)
        {
            this.sections.Add(section);
        }

        public void SetGenerationDate(DateTime dateTime)
        {
            this.generationDate = dateTime;
        }

        private string RenderAllStyles()
        {
            var sb = new StringBuilder();

            foreach (var styles in this.scripts.Where(w => w.ScriptType == Script.Type.Css))
                sb.AppendFormat("<style type=\"text/css\">{0}</style>{1}", styles.GetAsString(), Environment.NewLine);

            return sb.ToString();
        }

        private string RenderAllScripts()
        {
            var sb = new StringBuilder();

            foreach (var styles in this.scripts.Where(w => w.ScriptType == Script.Type.Javascript))
                sb.AppendFormat("<script type=\"text/javascript\">{0}</script>{1}", styles.GetAsString(), Environment.NewLine);

            return sb.ToString();
        }

        private string RenderSectionsLinks()
        {
            var sb = new StringBuilder();

            foreach (var section in this.sections.Select(w => w as ILinkableHtmlSection).Where(w => w != null))
                sb.AppendFormat("<li><a href='#{0}'>{1}</a></li>{2}", section.Link, section.Name, Environment.NewLine);

            return sb.ToString();
        }

        private string RenderAllSections()
        {
            var sb = new StringBuilder();

            foreach (var section in this.sections)
                sb.Append(section.Render());

            return sb.ToString();
        }
    }
}