using ControlePontos.Forms;
using ControlePontos.Start;
using System;
using System.Windows.Forms;

namespace ControlePontos.Start
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