using ControlePontos.Configuracao;
using ControlePontos.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlePontos
{
    internal static class Calculator
    {
        public static TimeSpan Coeficiente(ConfiguracaoDias config, ConfigFeriados feriados, MesTrabalho mes)
        {
            var offset = new TimeSpan(0, mes.CoficienteOffset, 0);
            return new TimeSpan(CoeficienteDiario(config, feriados, mes).Where(w => w.Value.HasValue).Select(w => w.Value.Value.Ticks).Sum()).Add(offset.Negate()).Negate();
        }

        public static TimeSpan? MediaEntradaEmpresa(ConfiguracaoDias config, ConfigFeriados feriados, MesTrabalho mes)
        {
            return MediaTimeSpan(mes.Dias.Validate(config, feriados).Select(w => w.Empresa.Entrada));
        }

        public static TimeSpan? MediaSaidaEmpresa(ConfiguracaoDias config, ConfigFeriados feriados, MesTrabalho mes)
        {
            return MediaTimeSpan(mes.Dias.Validate(config, feriados).Select(w => w.Empresa.Saida));
        }

        public static TimeSpan? MediaEntradaAlmoco(ConfiguracaoDias config, ConfigFeriados feriados, MesTrabalho mes)
        {
            return MediaTimeSpan(mes.Dias.Validate(config, feriados).Select(w => w.Almoco.Entrada));
        }

        public static TimeSpan? MediaSaidaAlmoco(ConfiguracaoDias config, ConfigFeriados feriados, MesTrabalho mes)
        {
            return MediaTimeSpan(mes.Dias.Validate(config, feriados).Select(w => w.Almoco.Saida));
        }

        public static TimeSpan? MediaTempoAlmoco(ConfiguracaoDias config, ConfigFeriados feriados, MesTrabalho mes)
        {
            return MediaTimeSpan(mes.Dias.Validate(config, feriados).Select(w => w.Almoco.TempoTotal()));
        }

        public static decimal? MediaValorAlmoco(ConfiguracaoDias config, ConfigFeriados feriados, MesTrabalho mes)
        {
            var valores = ValoresAlmoco(config, feriados, mes.Dias);
            if (valores.Count() == 0)
                return null;
            else
                return valores.Average();
        }

        public static decimal? ValorIdealAlmoco(ConfiguracaoDias config, ConfigFeriados feriados, MesTrabalho mes)
        {
            var diasSemAlmoco = mes.Dias.Validate(config, feriados).Where(w => !w.ValorAlmoco.HasValue);
            if (diasSemAlmoco.Count() == 0)
                return null;
            else
                return ValorAtualTr(config, feriados, mes) / (decimal)diasSemAlmoco.Count();
        }

        public static decimal ValorAtualTr(ConfiguracaoDias config, ConfigFeriados feriados, MesTrabalho mes)
        {
            var valoresAlmocos = ValoresAlmoco(config, feriados, mes.Dias);
            if (valoresAlmocos.Count() == 0)
                return mes.ValorSodexo;
            else
                return mes.ValorSodexo - valoresAlmocos.Sum();
        }

        public static Dictionary<DateTime, TimeSpan?> CoeficienteDiario(ConfiguracaoDias config, ConfigFeriados feriados, MesTrabalho mes)
        {
            return mes.Dias.Validate(config, feriados).ToDictionary(w => w.Data, w => w.Coeficiente(config.HoraInicio, config.HoraFim));
        }

        public static TimeSpan CoeficientePorDia(ConfiguracaoDias config, ConfigFeriados feriados, MesTrabalho mes)
        {
            var dias = mes.Dias.Validate(config, feriados).Where(w => !w.EstaCompleto());

            if (dias.Count() == 0)
                return Coeficiente(config, feriados, mes);
            else
                return new TimeSpan(Coeficiente(config, feriados, mes).Ticks / dias.Count());
        }

        private static IEnumerable<decimal> ValoresAlmoco(ConfiguracaoDias config, ConfigFeriados feriados, IEnumerable<DiaTrabalho> dias)
        {
            return dias.Validate(config, feriados).Where(w => w.ValorAlmoco.HasValue).Select(w => w.ValorAlmoco.Value);
        }

        private static TimeSpan? MediaTimeSpan(IEnumerable<TimeSpan?> times)
        {
            if (times.Count() == 0)
                return null;
            else
                return times.Average();
        }

        private static IEnumerable<DiaTrabalho> Validate(this IEnumerable<DiaTrabalho> dias, ConfiguracaoDias config, ConfigFeriados feriados)
        {
            return from dia in dias
                   where !dia.Falta &&
                         !feriados.Feriados.Any(w => w.Date == dia.Data.Date) &&
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