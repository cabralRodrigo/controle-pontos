using ControlePontos.Control;
using ControlePontos.Forms;
using ControlePontos.Report;
using ControlePontos.Report.Reports;
using ControlePontos.Servicos;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlePontos
{
    internal static class App
    {
        private static Container container;

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            App.Bootstrap();

            Application.Run(container.GetInstance<Dashboard>());
        }

        private static void Bootstrap()
        {
            container = new Container();

            container.RegisterSingleton<IArmazenamentoServico, ArmazenamentoServico>();
            container.RegisterSingleton<IFormOpener, FormOpener>();
            container.RegisterSingleton<IExportacaoServico, ExportacaoServico>();
            container.RegisterSingleton<IBackupServico, BackupServico>();
            container.RegisterSingleton<ICalculoServico, CalculoServico>();

            container.RegisterSingletonCollection<IExportar>(new Dictionary<Type, Type> {
                {typeof(IMesTrabalhoServico), typeof(MesTrabalhoServico)},
                {typeof(IConfiguracaoServico), typeof(ConfiguracaoServico)}
            });

            container.RegisterSingleton<IRelatorioServico, RelatorioServico>();
            container.RegisterCollection<IReport>(new[] { typeof(EvolucaoEntradaSaidaRelatorio), typeof(TabelaMesRelatorio), typeof(TabelaMesRelatorioFake), typeof(UsoSodexoRelatorio) });

            container.RegisterDisposable(typeof(Dashboard), typeof(Configuracao), typeof(DiaTrabalhoDataGridView));

            container.Verify();
        }
    }
}