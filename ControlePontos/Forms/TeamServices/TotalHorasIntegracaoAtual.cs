using ControlePontos.Servicos;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ControlePontos.Forms.TeamServices
{
    internal partial class TotalHorasIntegracaoAtual : BaseForm
    {
        private static class Colunas
        {
            public const int ID = 0;
            public const int Projeto = ID + 1;
            public const int Criacao = Projeto + 1;
            public const int Titulo = Criacao + 1;
            public const int Estado = Titulo + 1;
            public const int Horas = Estado + 1;
        }

        private readonly ITeamServiceServico tfs;
        private readonly ProgressoCarregamento progressoForm;
        private readonly CancellationTokenSource tokenSource;

        private int? horasAntigas;
        private int[] iteracoesIDs;
        private TfsTeamProjectCollection project;

        public TotalHorasIntegracaoAtual(ITeamServiceServico tfs, ProgressoCarregamento progressoForm)
        {
            this.InitializeComponent();

            this.tfs = tfs;
            this.progressoForm = progressoForm;
            this.tokenSource = new CancellationTokenSource();
        }

        private void CarregarGrid(IEnumerable<WorkItem> workItems)
        {
            this.Grid.Rows.Clear();

            foreach (var workItem in workItems)
                this.Grid.Rows.Add(new object[] {
                        workItem.Id,
                        workItem.Fields[TeamServiceServico.CamposTfs.TeamProject]?.Value,
                        workItem.Fields[TeamServiceServico.CamposTfs.CreatedDate]?.Value,
                        workItem.Title,
                        workItem.State,
                        workItem.Fields[TeamServiceServico.CamposTfs.CompletedWork]?.Value
                    });

            this.AtualizarBarraStatus();
        }

        private void AtualizarBarraStatus()
        {
            var total = this.Grid.Rows.OfType<DataGridViewRow>().Select(linha =>
            {
                var horaString = linha.Cells[Colunas.Horas].Value?.ToString();

                int hora;
                if (int.TryParse(horaString, out hora))
                    return hora;
                else
                    return 0;
            }).Sum();

            this.LabelStatusAtual.Text = $"Total de horas realizadas: {total}";
        }

        #region Team Services

        private void AutenticarUsuario()
        {
            this.progressoForm.Mensagem = "Autenticando usuário...";
            this.progressoForm.PassoAtual++;

            this.tfs.AutenticarUsuarioAsync(this.tokenSource.Token).Continue(project =>
            {
                this.progressoForm.PassoAtual++;

                this.project = project;
                this.CarregarIterationIDs();
            }, ErroTeamService);
        }

        private void CarregarIterationIDs()
        {
            this.progressoForm.Mensagem = "Carregando iterações atuais...";
            this.tfs.ListarIteracoesAtuaisAsync(this.project, this.tokenSource.Token).Continue(ids =>
            {
                this.progressoForm.PassoAtual++;

                this.iteracoesIDs = ids;
                this.CarregarWorkItems();
            }, ErroTeamService);
        }

        private void CarregarWorkItems()
        {
            this.progressoForm.Mensagem = "Carregando work items...";

            this.tfs.ListarWorkItemPorIteracaoAsync(this.project, iteracoesIDs, this.tokenSource.Token).Continue(items =>
            {
                this.CarregarGrid(items);
                this.progressoForm.Close();
            }, ErroTeamService);
        }

        private void ErroTeamService(Exception ex)
        {
            MessageBox.Show("Ocorreu um erro carregar os work items.\nErro: " + ex.Message, "Team Services", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.progressoForm.Close();
            this.Close();
        }

        #endregion

        #region Eventos

        private void TotalHorasIntegracaoAtual_Load(object sender, EventArgs e)
        {
            this.Grid.Columns[Colunas.ID].Width = 41;
            this.Grid.Columns[Colunas.Projeto].Width = 116;
            this.Grid.Columns[Colunas.Criacao].Width = 116;
            this.Grid.Columns[Colunas.Titulo].Width = 555;
            this.Grid.Columns[Colunas.Estado].Width = 63;
            this.Grid.Columns[Colunas.Horas].Width = 45;

            this.progressoForm.Titulo = this.progressoForm.Mensagem = "Carregando...";
            this.progressoForm.TotalPassos = 3;
            this.progressoForm.OnCancel(() =>
            {
                this.tokenSource.Cancel();
                this.progressoForm.Close();
                this.Close();
            });

            this.progressoForm.ShowDialogAsync(this);

            this.AutenticarUsuario();
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Colunas.ID && e.RowIndex >= 0)
            {
                var id = this.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                var url = $@"http://waplprd26v:8080/tfs/DEMOGRAF_SOCIAIS/GECEN.SIGC/_workitems?id={id}&_a=edit";

                Process.Start(url);
            }
        }

        private void Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == Colunas.Horas)
            {
                var horasString = this.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!horasString.IsNullOrEmpty())
                {
                    int horas;
                    if (int.TryParse(horasString, out horas))
                        this.horasAntigas = horas;
                    else
                        this.horasAntigas = null;
                }
                else
                    this.horasAntigas = null;
            }
        }

        private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Colunas.Horas)
            {
                var horasString = this.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                var idString = this.Grid.Rows[e.RowIndex].Cells[Colunas.ID].Value?.ToString();

                if (!string.IsNullOrEmpty(idString))
                {
                    int horas = 0, id;
                    if ((string.IsNullOrEmpty(horasString) || int.TryParse(horasString, out horas)) && int.TryParse(idString, out id) && (string.IsNullOrEmpty(horasString) || this.horasAntigas != horas))
                    {
                        //Copia a hora antiga antes da atualização da celula pois, como a atualizar é assincrona, essa variavel pode mudar antes de o processo ser atualizado.
                        int? horasAntigasCelula = this.horasAntigas;

                        this.LabelStatusAtual.Text = $"Atualizando work item com id {id}.";

                        this.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                        this.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Gray;

                        this.tfs.AtualizarWorkItemCompletedHoursAsync(this.project, id, horasString.IsNullOrEmpty() ? null : (int?)horas).Continue(() =>
                        {
                            this.AtualizarBarraStatus();

                            this.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                            this.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                        }, ex =>
                        {
                            this.AtualizarBarraStatus();

                            this.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = horasAntigasCelula;

                            this.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                            this.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;

                            MessageBox.Show($"Erro ao atualizar o work item com id {id}.\nErro: {ex.Message}", "Team Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });

                        return;
                    }
                }

                this.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.horasAntigas;
            }
        }

        #endregion
    }
}