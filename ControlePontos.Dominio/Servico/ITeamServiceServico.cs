using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePontos.Dominio.Servico
{
    public interface ITeamServiceServico
    {
        Task<TfsTeamProjectCollection> AutenticarUsuarioAsync(Uri enderecoTeamServices, CancellationToken? cancellationToken = null);
        Task<int[]> ListarIteracoesAtuaisAsync(TfsTeamProjectCollection collection, CancellationToken? cancellationToken = null);
        Task<IEnumerable<WorkItem>> ListarWorkItemPorIteracaoAsync(TfsTeamProjectCollection collection, int[] iterationIDs, CancellationToken? cancellationToken = null);
        Task AtualizarWorkItemCompletedHoursAsync(TfsTeamProjectCollection collection, int workItemID, int? horas, CancellationToken? cancellationToken = null);
    }
}