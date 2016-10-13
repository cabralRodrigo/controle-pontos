using ControlePontos.Model;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.ProcessConfiguration.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.VisualStudio.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePontos.Servicos
{
    internal interface ITeamServiceServico
    {
        Task<TfsTeamProjectCollection> AutenticarUsuarioAsync();
        Task<TfsTeamProjectCollection> AutenticarUsuarioAsync(CancellationToken cancellationToken);

        Task<int[]> ListarIteracoesAtuaisAsync(TfsTeamProjectCollection collection);
        Task<int[]> ListarIteracoesAtuaisAsync(TfsTeamProjectCollection collection, CancellationToken cancellationToken);

        Task<IEnumerable<WorkItem>> ListarWorkItemPorIteracaoAsync(TfsTeamProjectCollection collection, int[] iterationIDs);
        Task<IEnumerable<WorkItem>> ListarWorkItemPorIteracaoAsync(TfsTeamProjectCollection collection, int[] iterationIDs, CancellationToken cancellationToken);

        Task AtualizarWorkItemCompletedHoursAsync(TfsTeamProjectCollection collection, int workItemID, int? horas);
        Task AtualizarWorkItemCompletedHoursAsync(TfsTeamProjectCollection collection, int workItemID, int? horas, CancellationToken cancellationToken);
    }

    internal class TeamServiceServico : ITeamServiceServico
    {
        public static class CamposTfs
        {
            public const string IterationId = "System.IterationId";
            public const string IterationPath = "System.IterationPath";
            public const string Id = "System.Id";
            public const string Title = "System.Title";
            public const string AssignedTo = "System.AssignedTo";
            public const string State = "System.State";
            public const string CompletedWork = "Microsoft.VSTS.Scheduling.CompletedWork";
            public const string ClosedData = "Microsoft.VSTS.Common.ClosedDate";
            public const string WorkItemType = "System.WorkItemType";
            public const string CreatedDate = "System.CreatedDate";
            public const string TeamProject = "System.TeamProject";
        }

        private ConfigApp config;

        public TeamServiceServico(IConfiguracaoServico configuracaoServico)
        {
            configuracaoServico.ConfiguracaoMudou += c => this.config = c;
            this.config = configuracaoServico.ObterConfiguracao();
        }

        #region AutenticarUsuarioAsync

        public Task<TfsTeamProjectCollection> AutenticarUsuarioAsync()
        {
            return Task.Run(this.AutenticarUsuarioAsyncInterno(null));
        }

        public Task<TfsTeamProjectCollection> AutenticarUsuarioAsync(CancellationToken cancellationToken)
        {
            return Task.Run(this.AutenticarUsuarioAsyncInterno(cancellationToken), cancellationToken);
        }

        private Func<TfsTeamProjectCollection> AutenticarUsuarioAsyncInterno(CancellationToken? cancellationToken)
        {
            return () =>
            {
                var credencial = new VssCredentials(new Microsoft.VisualStudio.Services.Common.WindowsCredential());
                var collection = new TfsTeamProjectCollection(this.config.TeamService.Endereco, credencial);

                cancellationToken?.ThrowIfCancellationRequested();

                collection.EnsureAuthenticated();
                return collection;
            };
        }

        #endregion

        #region ListarIteracoesAtuaisAsync

        public Task<int[]> ListarIteracoesAtuaisAsync(TfsTeamProjectCollection collection)
        {
            return Task.Run(this.ListarIteracoesAtuaisAsyncInterno(collection, null));
        }

        public Task<int[]> ListarIteracoesAtuaisAsync(TfsTeamProjectCollection collection, CancellationToken cancellationToken)
        {
            return Task.Run(this.ListarIteracoesAtuaisAsyncInterno(collection, cancellationToken), cancellationToken);
        }

        private Func<int[]> ListarIteracoesAtuaisAsyncInterno(TfsTeamProjectCollection collection, CancellationToken? cancellationToken)
        {
            return () =>
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
                var query = $@"select [{CamposTfs.IterationId}] from WorkItems where [{CamposTfs.IterationPath}] IN (" + queryParametros + ")";
                cancellationToken?.ThrowIfCancellationRequested();

                //Executa a query e extrai os ids das iterações.
                return store.Query(query, parametros)
                    .OfType<WorkItem>()
                    .Select(w => w.IterationId)
                    .Distinct()
                    .ToArray();
            };
        }

        #endregion

        #region ListarWorkItemPorIteracaoAsync

        public Task<IEnumerable<WorkItem>> ListarWorkItemPorIteracaoAsync(TfsTeamProjectCollection collection, int[] iterationIDs)
        {
            return Task.Run(this.ListarWorkItemPorIteracaoAsyncInterno(collection, iterationIDs, null));
        }

        public Task<IEnumerable<WorkItem>> ListarWorkItemPorIteracaoAsync(TfsTeamProjectCollection collection, int[] iterationIDs, CancellationToken cancellationToken)
        {
            return Task.Run(this.ListarWorkItemPorIteracaoAsyncInterno(collection, iterationIDs, cancellationToken), cancellationToken);
        }

        public Func<IEnumerable<WorkItem>> ListarWorkItemPorIteracaoAsyncInterno(TfsTeamProjectCollection collection, int[] iterationIDs, CancellationToken? cancellationToken)
        {
            return () =>
            {
                var store = collection.GetService<WorkItemStore>();

                var parametros = iterationIDs.Select((id, i) => new { ID = id, Index = i }).ToDictionary(w => w.Index.ToString(), w => w.ID);
                var parametrosQuery = string.Join(", ", parametros.Select(w => "@" + w.Key).ToArray());

                var query = $@"
                    select 
                        [{CamposTfs.Id}], 
                        [{CamposTfs.Title}], 
                        [{CamposTfs.AssignedTo}], 
                        [{CamposTfs.State}], 
                        [{CamposTfs.IterationPath}], 
                        [{CamposTfs.CompletedWork}], 
                        [{CamposTfs.ClosedData}],
                        [{CamposTfs.CreatedDate}],
                        [{CamposTfs.TeamProject}]
                    from WorkItems 
                    where [{CamposTfs.IterationId}] in ({parametrosQuery}) and 
                          [{CamposTfs.AssignedTo}] = @Me and
                          [{CamposTfs.WorkItemType}] in ('Task', 'Issue') and
                          [{CamposTfs.State}] <> 'Removed'
                    order by [{CamposTfs.CreatedDate}]";

                cancellationToken?.ThrowIfCancellationRequested();
                return store.Query(query, parametros).OfType<WorkItem>();
            };
        }

        #endregion

        #region AtualizarWorkItemCompletedHoursAsync

        public Task AtualizarWorkItemCompletedHoursAsync(TfsTeamProjectCollection collection, int workItemID, int? horas)
        {
            return Task.Run(this.AtualizarWorkItemCompletedHoursAsyncInterno(collection, workItemID, horas, null));
        }

        public Task AtualizarWorkItemCompletedHoursAsync(TfsTeamProjectCollection collection, int workItemID, int? horas, CancellationToken cancellationToken)
        {
            return Task.Run(this.AtualizarWorkItemCompletedHoursAsyncInterno(collection, workItemID, horas, cancellationToken), cancellationToken);
        }

        public Action AtualizarWorkItemCompletedHoursAsyncInterno(TfsTeamProjectCollection collection, int workItemID, int? horas, CancellationToken? cancellationToken)
        {
            return () =>
            {
                var store = collection.GetService<WorkItemStore>();

                cancellationToken?.ThrowIfCancellationRequested();
                var workItem = store.GetWorkItem(workItemID);

                if (workItem != null)
                {
                    workItem.Fields[CamposTfs.CompletedWork].Value = horas;

                    cancellationToken?.ThrowIfCancellationRequested();
                    workItem.Save();
                }
                else
                    throw new InvalidOperationException($"Não foi possível encontrar o work item com id {workItemID}.");
            };
        }

        #endregion AtualizarWorkItemCompletedHoursAsync
    }
}