using System;
using System.Runtime.InteropServices;

namespace ControlePontos.Native
{
    internal interface IControlRenderer
    {
        void PauseRender(System.Windows.Forms.Control control);

        void ResumeRender(System.Windows.Forms.Control control);
    }

    public class ControlRenderer : IControlRenderer
    {
        //Classe modificada. Source: http://stackoverflow.com/questions/487661/how-do-i-suspend-painting-for-a-control-and-its-children

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);

        private const int WM_SETREDRAW = 11;

        public void PauseRender(System.Windows.Forms.Control control)
        {
            SendMessage(control.Handle, WM_SETREDRAW, false, 0);
        }

        public void ResumeRender(System.Windows.Forms.Control control)
        {
            SendMessage(control.Handle, WM_SETREDRAW, true, 0);
            control.Refresh();
        }
    }
}