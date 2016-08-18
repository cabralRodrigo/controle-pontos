using ControlePontos.Report;
using System.Collections.Generic;

namespace ControlePontos.Servicos
{
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