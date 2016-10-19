using ControlePontos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlePontos.Extensions
{
    internal static class WindowsFormsExtensions
    {
        public static void SortBy<T, R>(this ListBox list, Func<T, R> func)
        {
            var items = list.Items.Cast<T>().OrderBy(func).ToList();

            list.Items.Clear();
            list.Items.AddRange(items.Cast<object>().ToArray());
        }

        public static IEnumerable<DateTime> AllInRange(this SelectionRange range)
        {
            for (var date = range.Start; date <= range.End; date = date.AddDays(1))
                yield return date;
        }

        public static Task<DialogResult> ShowDialogAsync(this Form form, Form parent)
        {
            return Task.Factory.FromAsync(parent.BeginInvoke(new Func<DialogResult>(() => form.ShowDialog(parent))), res => (DialogResult)form.EndInvoke(res));
        }

        public static DialogResult? ToMessageBox(this Resultado resultado, string titulo, MessageBoxButtons? buttons = null, MessageBoxIcon? icon = null)
        {
            if (!resultado.ValorMensagem.IsNullOrEmpty())
            {
                if (!icon.HasValue)
                {
                    switch (resultado.Tipo)
                    {
                        case TipoMensagem.Sucesso:
                            icon = MessageBoxIcon.None;
                            break;
                        case TipoMensagem.Informacao:
                            icon = MessageBoxIcon.Information;
                            break;
                        case TipoMensagem.Aviso:
                            icon = MessageBoxIcon.Warning;
                            break;
                        case TipoMensagem.Erro:
                            icon = MessageBoxIcon.Error;
                            break;
                    }
                }

                return MessageBox.Show(resultado.ValorMensagem, titulo, buttons ?? MessageBoxButtons.OK, icon ?? MessageBoxIcon.None);
            }
            else
                return null;
        }
    }
}