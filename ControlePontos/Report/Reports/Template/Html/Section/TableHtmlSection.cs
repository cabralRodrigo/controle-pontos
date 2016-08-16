using ControlePontos.Report.Reports.Template.Html.Misc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ControlePontos.Report.Reports.Template.Html.Section
{
    public class TableHtmlSection : ILinkableHtmlSection
    {
        private DataTable data;
        private string tabelaID;

        public TableHtmlSection(string name, string link, DataTable data, string tabelaID = "")
        {
            this.Name = name;
            this.Link = link;
            this.data = data;
            this.tabelaID = tabelaID;
        }

        public bool ShouldRenderInsideContent { get { return true; } }
        public string Name { get; private set; }
        public string Link { get; private set; }

        public IEnumerable<Script> GetDependencies()
        {
            return new Script[0];
        }

        public string Render()
        {
            var html = new StringBuilder("<table class='table table-bordered table-condensed' id='" + this.tabelaID + "'>");

            html.Append("<tr>");
            foreach (var columnName in this.data.Columns.Cast<DataColumn>().Select(w => w.ColumnName))
                html.AppendFormat("<td><b>{0}</b></td>", columnName);
            html.Append("</tr>");

            foreach (var row in this.data.Rows.Cast<DataRow>())
            {
                html.Append("<tr>");
                foreach (var value in row.ItemArray)
                    html.AppendFormat("<td>{0}</td>", value);
                html.Append("</tr>");
            }

            html.Append("</table>");
            return new TextHtmlSection(this.Name, this.Link, html.ToString()).Render();
        }
    }
}