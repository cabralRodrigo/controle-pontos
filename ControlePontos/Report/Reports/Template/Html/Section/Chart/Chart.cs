using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePontos.Report.Reports.Template.Html.Section.Chart
{
    public class Chart
    {
        public ChartData Data { get; set; }
        public ChartType Type { get; set; }
        public object Options { get; set; }
    }
}