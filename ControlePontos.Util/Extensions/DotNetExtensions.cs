using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePontos.Util.Extensions
{
    public static class DotNetExtensions
    {
        public static string Descricao(this TimeSpan time)
        {
            var horas = Math.Abs(Math.Truncate(time.TotalHours));
            var minutos = Math.Abs(Math.Truncate(time.TotalMinutes - (Math.Truncate(time.TotalHours) * 60)));

            string desc;
            if (horas == 0)
                desc = $"{minutos} minuto{(minutos == 1 ? string.Empty : "s")}";
            else if (minutos == 0)
                desc = $"{horas} hora{(horas == 1 ? string.Empty : "s")}";
            else
                desc = $"{horas} hora{(horas == 1 ? string.Empty : "s")}, {minutos} minuto{(minutos == 1 ? string.Empty : "s")}";

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

        public static string ObterDescricao(this Enum valorEnum)
        {
            var field = valorEnum?.GetType()?.GetField(valorEnum?.ToString());
            var atributos = field?.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);

            return (atributos?.FirstOrDefault() as System.ComponentModel.DescriptionAttribute)?.Description ?? valorEnum?.ToString();
        }

        public static string ToHexString(this byte[] bytes)
        {
            var hex = new StringBuilder(bytes.Length * 2);

            foreach (var b in bytes)
                hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }
    }
}