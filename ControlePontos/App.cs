using ControlePontos.Forms;
using ControlePontos.Servicos;
using SimpleInjector;
using System;
using System.Windows.Forms;

namespace ControlePontos
{
    internal static class App
    {
        //TODO: Marcar esse campo como privado.
        public static Container container;

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

            container.Register<Dashboard>();
            container.Register<Forms.Configuracao>();

            container.RegisterSingleton<IArmazenamentoServico, ArmazenamentoServico>();
            container.RegisterSingleton<IConfiguracaoServico, ConfiguracaoServico>();

            //TODO: Descomentar esse método quando a issue for resolvida: https://github.com/simpleinjector/SimpleInjector/issues/286
            //container.Verify();
        }
    }
}