using System;
using System.Threading.Tasks;

namespace ControlePontos.Extensions
{
    internal static class TaskExtensions
    {
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
    }
}