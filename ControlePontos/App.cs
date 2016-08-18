using ControlePontos.Forms;
using ControlePontos.Servicos;
using SimpleInjector;
using System;
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
            container.RegisterSingleton<IConfiguracaoServico, ConfiguracaoServico>();
            container.RegisterSingleton<IFormOpener, FormOpener>();

            container.RegisterForm(typeof(Dashboard), typeof(Configuracao));

            container.Verify();
        }
    }
}