using ControlePontos.Dominio.Model.Integracoes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePontos.Dominio.Servico
{
    public interface ITeamServiceServico
    {
        Task<IEnumerable<TeamServicesWorkItem>> ListarWorkItemPorIteracaoAsync(int[] iterationIDs, CancellationToken? cancellationToken = null);
        Task<int[]> ListarIteracoesAtuaisAsync(CancellationToken? cancellationToken = null);
        Task AtualizarWorkItemCompletedHoursAsync(int workItemID, int? horas, CancellationToken? cancellationToken = null);
    }
}