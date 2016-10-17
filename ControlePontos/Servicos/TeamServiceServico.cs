using ControlePontos.Misc;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.ProcessConfiguration.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.VisualStudio.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static ControlePontos.Misc.ColunasTeamServices;

namespace ControlePontos.Servicos
{
    internal interface ITeamServiceServico
    {
        Task<TfsTeamProjectCollection> AutenticarUsuarioAsync(Uri enderecoTeamServices, CancellationToken? cancellationToken = null);
        Task<int[]> ListarIteracoesAtuaisAsync(TfsTeamProjectCollection collection, CancellationToken? cancellationToken = null);
        Task<IEnumerable<WorkItem>> ListarWorkItemPorIteracaoAsync(TfsTeamProjectCollection collection, int[] iterationIDs, CancellationToken? cancellationToken = null);
        Task AtualizarWorkItemCompletedHoursAsync(TfsTeamProjectCollection collection, int workItemID, int? horas, CancellationToken? cancellationToken = null);
    }

    internal class TeamServiceServico : ITeamServiceServico
    {
        public Task<TfsTeamProjectCollection> AutenticarUsuarioAsync(Uri enderecoTeamServices, CancellationToken? cancellationToken = null)
        {
            return Task.Run(() =>
            {
                var credencial = new VssCredentials(new Microsoft.VisualStudio.Services.Common.WindowsCredential());
                var collection = new TfsTeamProjectCollection(enderecoTeamServices, credencial);

                cancellationToken?.ThrowIfCancellationRequested();

                collection.EnsureAuthenticated();
                return collection;
            });
        }

        public Task<int[]> ListarIteracoesAtuaisAsync(TfsTeamProjectCollection collection, CancellationToken? cancellationToken = null)
        {
            return Task.Run(() =>
            {
                //Obtém o serviço responsável por manipular os work items.
                var store = collection.GetService<WorkItemStore>();

                //Obtém o serviço responsável por manipular as configurações do time.
                var config = collection.GetService<TeamSettingsConfigurationService>();

                cancellationToken?.ThrowIfCancellationRequested();

                //Lista todos os endereços de todos os projetos.
                var projetos = store.Projects.OfType<Project>().Select(w => w.Uri.AbsoluteUri);
                cancellationToken?.ThrowIfCancellationRequested();


                //Lista todas as iterações atuais dos projetdos que o usuário tem acesso.
                var iteracoes = config.GetTeamConfigurationsForUser(projetos).Select(w => w.TeamSettings.CurrentIterationPath).Where(w => w != null);
                cancellationToken?.ThrowIfCancellationRequested();

                //Monta a query que irá listar os IDS das iterações.
                var parametros = iteracoes.Select((iteracao, index) => new { Valor = iteracao, Chave = index }).ToDictionary(w => w.Chave, w => w.Valor.ToString());
                var queryParametros = string.Join(", ", parametros.Select(w => "@" + w.Key).ToArray());
                var query = $@"select [{IterationId}] from WorkItems where [{IterationPath}] IN (" + queryParametros + ")";
                cancellationToken?.ThrowIfCancellationRequested();

                //Executa a query e extrai os ids das iterações.
                return store.Query(query, parametros)
                    .OfType<WorkItem>()
                    .Select(w => w.IterationId)
                    .Distinct()
                    .ToArray();
            });
        }

        public Task<IEnumerable<WorkItem>> ListarWorkItemPorIteracaoAsync(TfsTeamProjectCollection collection, int[] iterationIDs, CancellationToken? cancellationToken = null)
        {
            return Task.Run(() =>
            {
                var store = collection.GetService<WorkItemStore>();

                var parametros = iterationIDs.Select((id, i) => new { ID = id, Index = i }).ToDictionary(w => w.Index.ToString(), w => w.ID);
                var parametrosQuery = string.Join(", ", parametros.Select(w => "@" + w.Key).ToArray());

                var query = $@"
                    select 
                        [{Id}], 
                        [{Title}], 
                        [{AssignedTo}], 
                        [{ColunasTeamServices.State}], 
                        [{IterationPath}], 
                        [{CompletedWork}], 
                        [{ClosedData}],
                        [{CreatedDate}],
                        [{TeamProject}]
                    from WorkItems 
                    where [{IterationId}] in ({parametrosQuery}) and 
                          [{AssignedTo}] = @Me and
                          [{ColunasTeamServices.WorkItemType}] in ('Task', 'Issue') and
                          [{ColunasTeamServices.State}] <> 'Removed'
                    order by [{CreatedDate}]";

                cancellationToken?.ThrowIfCancellationRequested();
                return store.Query(query, parametros).OfType<WorkItem>();
            });
        }

        public Task AtualizarWorkItemCompletedHoursAsync(TfsTeamProjectCollection collection, int workItemID, int? horas, CancellationToken? cancellationToken = null)
        {
            return Task.Run(() =>
            {
                var store = collection.GetService<WorkItemStore>();

                cancellationToken?.ThrowIfCancellationRequested();
                var workItem = store.GetWorkItem(workItemID);

                if (workItem != null)
                {
                    workItem.Fields[CompletedWork].Value = horas;

                    cancellationToken?.ThrowIfCancellationRequested();
                    workItem.Save();
                }
                else
                    throw new InvalidOperationException($"Não foi possível encontrar o work item com id {workItemID}.");
            });
        }
    }
}