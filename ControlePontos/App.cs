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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
        }
    }
}