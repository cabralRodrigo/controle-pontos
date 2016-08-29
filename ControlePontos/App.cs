using ControlePontos.Forms;
using System;
using System.Windows.Forms;

namespace ControlePontos
{
    internal static class App
    {
        [STAThread]
        private static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bootstraper.Instancia.Bootstrap();
            Application.Run(Bootstraper.Instancia.ObterInstancia<Dashboard>());
        }
    }
}