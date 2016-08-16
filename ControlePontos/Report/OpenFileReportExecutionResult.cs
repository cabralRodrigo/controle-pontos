using System.Diagnostics;

namespace ControlePontos.Report
{
    internal class OpenFileReportExecutionResult : IReportExecutionResult
    {
        private readonly string fileName;
        public OpenFileReportExecutionResult(string fileName)
        {
            this.fileName = fileName;
        }

        public ActionType Action { get { return ActionType.OpenFile; } }
        
        public void Execute()
        {
            Process.Start("chrome", fileName);
        }
    }
}
