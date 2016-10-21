using ControlePontos.Dominio.Model;
using ControlePontos.Dominio.Model.Configuracao;

namespace ControlePontos.Report
{
    internal interface IReport
    {
        string Name { get; }

        IReportExecutionResult Execute(ConfiguracaoApp config, int ano, int mes, MesTrabalho mesTrabalho);
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