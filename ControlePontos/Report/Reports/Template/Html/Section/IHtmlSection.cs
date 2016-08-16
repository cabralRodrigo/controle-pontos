using ControlePontos.Report.Reports.Template.Html.Misc;
using System.Collections.Generic;

namespace ControlePontos.Report.Reports.Template.Html.Section
{
    public interface IHtmlSection
    {
        string Name { get; }
        bool ShouldRenderInsideContent { get; }

        IEnumerable<Script> GetDependencies();

        string Render();
    }
}