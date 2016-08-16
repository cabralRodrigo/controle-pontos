using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePontos.Report.Reports.Template.Html.Section.Chart
{

    public class ChartDataset
    {
        public string Label { get; set; }
        public object[] Data { get; set; }
        public string BackgroundColor { get; set; }
    }
}