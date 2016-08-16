using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePontos.Report.Reports.Template.Html.Section.Chart
{
    public class ChartData
    {
        public string[] Labels { get; set; }
        public ChartDataset[] Datasets { get; set; }
    }
}