using System;
using System.Linq;
using System.Collections.Generic;

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
    }
}