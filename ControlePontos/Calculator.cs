using ControlePontos.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlePontos
{
    internal static class Calculator
    {
        public static TimeSpan Coeficiente(ConfigApp config, MesTrabalho mes)
        {
            var offset = new TimeSpan(0, mes.CoficienteOffset, 0);
            return new TimeSpan(CoeficienteDiario(config, mes).Where(w => w.Value.HasValue).Select(w => w.Value.Value.Ticks).Sum()).Add(offset.Negate()).Negate();
        }

        public static TimeSpan? MediaEntradaEmpresa(ConfigApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(mes.Dias.Validate(config).Select(w => w.Empresa.Entrada));
        }

        public static TimeSpan? MediaSaidaEmpresa(ConfigApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(mes.Dias.Validate(config).Select(w => w.Empresa.Saida));
        }

        public static TimeSpan? MediaEntradaAlmoco(ConfigApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(mes.Dias.Validate(config).Select(w => w.Almoco.Entrada));
        }

        public static TimeSpan? MediaSaidaAlmoco(ConfigApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(mes.Dias.Validate(config).Select(w => w.Almoco.Saida));
        }

        public static TimeSpan? MediaTempoAlmoco(ConfigApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(mes.Dias.Validate(config).Select(w => w.Almoco.TempoTotal()));
        }

        public static decimal? MediaValorAlmoco(ConfigApp config, MesTrabalho mes)
        {
            var valores = ValoresAlmoco(config, mes.Dias);
            if (valores.Count() == 0)
                return null;
            else
                return valores.Average();
        }

        public static decimal? ValorIdealAlmoco(ConfigApp config, MesTrabalho mes)
        {
            var diasSemAlmoco = mes.Dias.Validate(config).Where(w => !w.ValorAlmoco.HasValue);
            if (diasSemAlmoco.Count() == 0)
                return null;
            else
                return ValorAtualTr(config, mes) / (decimal)diasSemAlmoco.Count();
        }

        public static decimal ValorAtualTr(ConfigApp config, MesTrabalho mes)
        {
            var valoresAlmocos = ValoresAlmoco(config, mes.Dias);
            if (valoresAlmocos.Count() == 0)
                return mes.ValorSodexo;
            else
                return mes.ValorSodexo - valoresAlmocos.Sum();
        }

        public static Dictionary<DateTime, TimeSpan?> CoeficienteDiario(ConfigApp config, MesTrabalho mes)
        {
            return mes.Dias.Validate(config).ToDictionary(w => w.Data, w => w.Coeficiente(config.HoraInicio, config.HoraFim));
        }

        public static TimeSpan CoeficientePorDia(ConfigApp config, MesTrabalho mes)
        {
            var dias = mes.Dias.Validate(config).Where(w => !w.EstaCompleto());

            if (dias.Count() == 0)
                return Coeficiente(config, mes);
            else
                return new TimeSpan(Coeficiente(config, mes).Ticks / dias.Count());
        }

        private static IEnumerable<decimal> ValoresAlmoco(ConfigApp config, IEnumerable<DiaTrabalho> dias)
        {
            return dias.Validate(config).Where(w => w.ValorAlmoco.HasValue).Select(w => w.ValorAlmoco.Value);
        }

        private static TimeSpan? MediaTimeSpan(IEnumerable<TimeSpan?> times)
        {
            if (times.Count() == 0)
                return null;
            else
                return times.Average();
        }

        private static IEnumerable<DiaTrabalho> Validate(this IEnumerable<DiaTrabalho> dias, ConfigApp config)
        {
            return from dia in dias
                   where !dia.Falta &&
                         !config.Feriados.Feriados.Any(w => w.Date == dia.Data.Date) &&
                         !config.Ferias.Any(w => w.Date == dia.Data.Date) &&
                         config.DiasTrabalho.Contains(dia.Data.DayOfWeek)
                   select dia;
        }

        public static TimeSpan? TotalHorasTrabalhadas(DiaTrabalho dia)
        {
            if (!dia.EstaCompleto())
                return null;
            else
            {
                return dia.Empresa.TempoTotal() - dia.Almoco.TempoTotal();
            }
        }
    }
}