﻿using ControlePontos.Model;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlePontos
{
    internal static class Extensions
    {
        public static string Descricao(this TimeSpan? time)
        {
            if (time.HasValue)
                return time.Value.Descricao();
            else
                return null;
        }

        public static string Descricao(this TimeSpan time)
        {
            var horas = Math.Abs(Math.Truncate(time.TotalHours));
            var minutos = Math.Abs(Math.Truncate(time.TotalMinutes - (Math.Truncate(time.TotalHours) * 60)));

            string desc;
            if (horas == 0)
                desc = string.Format("{0} minuto{1}", minutos, minutos == 1 ? string.Empty : "s");
            else if (minutos == 0)
                desc = string.Format("{0} hora{1}", horas, horas == 1 ? string.Empty : "s");
            else
                desc = string.Format("{0} hora{1}, {2} minuto{3}", horas, horas == 1 ? string.Empty : "s", minutos, minutos == 1 ? string.Empty : "s");

            return (time.Ticks < 0 ? "- " : string.Empty) + desc;
        }

        public static TimeSpan? Negate(this TimeSpan? time)
        {
            return time.HasValue ? (TimeSpan?)time.Value.Negate() : null;
        }

        public static TimeSpan Average(this IEnumerable<TimeSpan?> times)
        {
            return times.Where(w => w.HasValue).Select(s => s.Value).Average();
        }

        public static TimeSpan Average(this IEnumerable<TimeSpan> times)
        {
            if (times.Count() == 0)
                return new TimeSpan(0);
            else
                return new TimeSpan((long)times.Average(a => a.Ticks));
        }

        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static string ToTitleCase(this string source)
        {
            if (source.IsNullOrEmpty())
                return source;

            if (source.Length == 1)
                return source.ToUpper();

            return char.ToUpper(source[0]) + source.Substring(1);
        }

        public static string FormatWith(this string source, params object[] objects)
        {
            return string.Format(source, objects);
        }

        public static string ToStringOr(this TimeSpan? timeSpan, string @else, string format = null)
        {
            return timeSpan.HasValue ? (format == null ? timeSpan.Value.ToString() : timeSpan.Value.ToString(format)) : @else;
        }

        public static string ToStringOr(this decimal? timeSpan, string @else, string format = null)
        {
            return timeSpan.HasValue ? (format == null ? timeSpan.Value.ToString() : timeSpan.Value.ToString(format)) : @else;
        }

        public static IEnumerable<DateTime> AllInRange(this SelectionRange range)
        {
            for (var date = range.Start; date <= range.End; date = date.AddDays(1))
                yield return date;
        }

        public static void SortBy<T, R>(this ListBox list, Func<T, R> func)
        {
            var items = list.Items.Cast<T>().OrderBy(func).ToList();

            list.Items.Clear();
            list.Items.AddRange(items.Cast<object>().ToArray());
        }

        public static void RegisterDisposable(this Container container, params Type[] forms)
        {
            foreach (var form in forms)
                container.Register(form);

            foreach (var form in forms)
            {
                var registration = container.GetRegistration(form).Registration;
                registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Winforms registration supression.");
            }
        }

        public static void RegisterSingletonCollection<T>(this Container container, Dictionary<Type, Type> tipos) where T : class
        {
            var interfaceTipos = container.GetTypesToRegister(typeof(T), new[] { typeof(T).Assembly });

            var interfaceRegistros = (
                from tipo in interfaceTipos
                select Lifestyle.Singleton.CreateRegistration(tipo, container)).ToList();

            container.RegisterCollection<T>(interfaceRegistros);

            foreach (var tipo in tipos)
            {
                var tipoRegistro = interfaceRegistros.Single(w => w.ImplementationType == tipo.Value);
                container.AddRegistration(tipo.Key, tipoRegistro);
            }
        }

        public static void Continue<T>(this Task<T> task, Action<T> action, Action<Exception> onFail = null)
        {
            task.ContinueWith(async t =>
            {
                if (t.Status == TaskStatus.Faulted)
                    onFail?.Invoke(t.Exception?.InnerException);

                action?.Invoke(await t);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public static void Continue(this Task task, Action action, Action<Exception> onFail = null)
        {
            task.ContinueWith(async t =>
            {
                if (t.Status == TaskStatus.Faulted)
                    onFail?.Invoke(t.Exception?.InnerException);

                await t;

                action.Invoke();
            }, TaskScheduler.FromCurrentSynchronizationContext());
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