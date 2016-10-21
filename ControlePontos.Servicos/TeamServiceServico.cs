using ControlePontos.Dominio.Model.Configuracao;
using ControlePontos.Dominio.Model.Integracoes;
using ControlePontos.Dominio.Servico;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.ProcessConfiguration.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePontos.Servicos
{
    public class TeamServiceServico : ITeamServiceServico
    {
        private static class Colunas
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

        private ConfiguracaoApp config;
        private TfsTeamProjectCollection tfs;

        public TeamServiceServico(IConfiguracaoServico configuracaoServico)
        {
            configuracaoServico.ConfiguracaoMudou += c => this.config = c;
            this.config = configuracaoServico.ObterConfiguracao();
        }

        public async Task<IEnumerable<TeamServicesWorkItem>> ListarWorkItemPorIteracaoAsync(int[] iterationIDs, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            await this.AutenticarUsuarioAsync(cancellationToken);

            var store = this.tfs.GetService<WorkItemStore>();

            var parametros = iterationIDs.Select((id, i) => new { ID = id, Index = i }).ToDictionary(w => w.Index.ToString(), w => w.ID);
            var parametrosQuery = string.Join(", ", parametros.Select(w => "@" + w.Key).ToArray());

            var query = $@"
                    select 
                        [{Colunas.Id}], 
                        [{Colunas.Title}], 
                        [{Colunas.AssignedTo}], 
                        [{Colunas.State}], 
                        [{Colunas.IterationPath}], 
                        [{Colunas.CompletedWork}], 
                        [{Colunas.ClosedData}],
                        [{Colunas.CreatedDate}],
                        [{Colunas.TeamProject}]
                    from WorkItems 
                    where [{Colunas.IterationId}] in ({parametrosQuery}) and 
                          [{Colunas.AssignedTo}] = @Me and
                          [{Colunas.WorkItemType}] in ('Task', 'Issue') and
                          [{Colunas.State}] <> 'Removed'
                    order by [{Colunas.CreatedDate}]";

            cancellationToken?.ThrowIfCancellationRequested();
            return store.Query(query, parametros).OfType<WorkItem>().Select(s => new TeamServicesWorkItem
            {
                ID = s.Id,
                DataCriacao = (DateTime)s.Fields[Colunas.CreatedDate].Value,
                Estado = s.State,
                HorasCompletadas = (double?)s.Fields[Colunas.CompletedWork]?.Value,
                Projeto = s.Fields[Colunas.TeamProject]?.Value as string,
                Titulo = s.Title
            });
        }

        public async Task<int[]> ListarIteracoesAtuaisAsync(CancellationToken? cancellationToken = default(CancellationToken?))
        {
            await this.AutenticarUsuarioAsync(cancellationToken);

            //Obtém o serviço responsável por manipular os work items.
            var store = this.tfs.GetService<WorkItemStore>();

            //Obtém o serviço responsável por manipular as configurações do time.
            var config = this.tfs.GetService<TeamSettingsConfigurationService>();

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
            var query = $@"select [{Colunas.IterationId}] from WorkItems where [{Colunas.IterationPath}] IN (" + queryParametros + ")";
            cancellationToken?.ThrowIfCancellationRequested();

            //Executa a query e extrai os ids das iterações.
            return store.Query(query, parametros)
                .OfType<WorkItem>()
                .Select(w => w.IterationId)
                .Distinct()
                .ToArray();
        }

        public async Task AtualizarWorkItemCompletedHoursAsync(int workItemID, int? horas, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            await this.AutenticarUsuarioAsync(cancellationToken);

            var store = this.tfs.GetService<WorkItemStore>();

            cancellationToken?.ThrowIfCancellationRequested();
            var workItem = store.GetWorkItem(workItemID);

            if (workItem != null)
            {
                workItem.Fields[Colunas.CompletedWork].Value = horas;

                cancellationToken?.ThrowIfCancellationRequested();
                workItem.Save();
            }
            else
                throw new InvalidOperationException($"Não foi possível encontrar o work item com id {workItemID}.");
        }

        private Task AutenticarUsuarioAsync(CancellationToken? cancellationToken = null)
        {
            return Task.Run(() =>
            {
                if (this.tfs == null)
                    this.tfs = new TfsTeamProjectCollection(this.config.TeamService.Endereco, new WindowsCredential());

                cancellationToken?.ThrowIfCancellationRequested();

                this.tfs.EnsureAuthenticated();
            });
        }
    }
}