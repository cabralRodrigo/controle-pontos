using ControlePontos.Control;
using ControlePontos.Extensions;
using ControlePontos.Forms;
using ControlePontos.Forms.TeamServices;
using ControlePontos.Native;
using ControlePontos.Report;
using ControlePontos.Report.Reports;
using ControlePontos.Servicos;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace ControlePontos
{
    public class Bootstraper
    {
        private static readonly Lazy<Bootstraper> instancia = new Lazy<Bootstraper>(() => new Bootstraper());
        public static Bootstraper Instancia { get { return Bootstraper.instancia.Value; } }

        private readonly Container container;

        private Bootstraper()
        {
            this.container = new Container();
        }

        public void Bootstrap()
        {
            this.RegistrarMisc();
            this.RegistrarServicos();
            this.RegistrarServicosExportaveis();
            this.RegistrarRelatorios();
            this.RegistrarForms();

            this.container.Verify();
        }

        public T ObterInstancia<T>() where T : class
        {
            return this.container.GetInstance<T>();
        }

        private void RegistrarMisc()
        {
            this.container.RegisterSingleton<IControlRenderer, ControlRenderer>();
        }

        private void RegistrarServicos()
        {
            this.container.RegisterSingleton<IArmazenamentoServico, ArmazenamentoServico>();
            this.container.RegisterSingleton<IFormServico, FormServico>();
            this.container.RegisterSingleton<IExportacaoServico, ExportacaoServico>();
            this.container.RegisterSingleton<IBackupServico, BackupServico>();
            this.container.RegisterSingleton<ICalculoServico, CalculoServico>();
            this.container.RegisterSingleton<IParserServico, ParserServico>();
            this.container.RegisterSingleton<IRelatorioServico, RelatorioServico>();
            this.container.RegisterSingleton<ITeamServiceServico, TeamServiceServico>();
            this.container.RegisterSingleton<IAppInfoServico, AppInfoServico>();
        }

        private void RegistrarServicosExportaveis()
        {
            this.container.RegisterSingletonCollection<IExportar>(new Dictionary<Type, Type> {
                {typeof(IMesTrabalhoServico), typeof(MesTrabalhoServico)},
                {typeof(IConfiguracaoServico), typeof(ConfiguracaoServico)}
            });
        }

        private void RegistrarRelatorios()
        {
            this.container.RegisterCollection<IReport>(new[] {
                typeof(EvolucaoEntradaSaidaRelatorio),
                typeof(TabelaMesRelatorio),
                typeof(TabelaMesRelatorioFake),
                typeof(UsoSodexoRelatorio)
            });
        }

        private void RegistrarForms()
        {
            this.container.RegisterDisposable(new[]{
                typeof(Dashboard),
                typeof(Configuracao),
                typeof(DiaTrabalhoDataGridView),
                typeof(TotalHorasIntegracaoAtual),
                typeof(ProgressoCarregamento),
                typeof(Changelog),
                typeof(Sobre)
            });
        }
    }
}