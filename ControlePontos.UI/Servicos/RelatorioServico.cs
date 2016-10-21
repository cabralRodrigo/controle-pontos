using ControlePontos.Report;
using System.Collections.Generic;

namespace ControlePontos.Servicos
{
    //TODO: Separar o serviço de relatório da camada de UI.
    internal interface IRelatorioServico
    {
        IEnumerable<IReport> ListarRelatorios();
    }

    internal class RelatorioServico : IRelatorioServico
    {
        private readonly IEnumerable<IReport> relatorio;

        public RelatorioServico(IEnumerable<IReport> relatorios)
        {
            this.relatorio = relatorios;
        }

        public IEnumerable<IReport> ListarRelatorios()
        {
            return this.relatorio;
        }
    }
}