using ControlePontos.Configuracao;
using ControlePontos.Model;

namespace ControlePontos.Report
{
    internal interface IReport
    {
        //TODO: Adicionar a função de escolher a saida do relatório: html, csv, pdf, markdown...
        string Name { get; }

        IReportExecutionResult Execute(ConfiguracaoDias config, ConfigFeriados feriados, int ano, int mes, MesTrabalho mesTrabalho);
    }

    internal interface IReportExecutionResult
    {
        ActionType Action { get; }

        void Execute();
    }

    internal enum ActionType
    {
        OpenFile
    }
}