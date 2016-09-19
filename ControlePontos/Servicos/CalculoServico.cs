using ControlePontos.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlePontos.Servicos
{
    internal interface ICalculoServico
    {
        TimeSpan Coeficiente(ConfigApp config, MesTrabalho mes);

        TimeSpan CoeficientePorDia(ConfigApp config, MesTrabalho mes);

        TimeSpan? MediaEntradaEmpresa(ConfigApp config, MesTrabalho mes);

        TimeSpan? MediaSaidaEmpresa(ConfigApp config, MesTrabalho mes);

        TimeSpan? MediaEntradaAlmoco(ConfigApp config, MesTrabalho mes);

        TimeSpan? MediaSaidaAlmoco(ConfigApp config, MesTrabalho mes);

        TimeSpan? MediaTempoAlmoco(ConfigApp config, MesTrabalho mes);

        decimal? MediaValorAlmoco(ConfigApp config, MesTrabalho mes);

        decimal? ValorIdealAlmoco(ConfigApp config, MesTrabalho mes);

        decimal ValorAtualTr(ConfigApp config, MesTrabalho mes);

        TimeSpan? TotalHorasTrabalhadas(DiaTrabalho dia);

        TimeSpan TotalHorasTfs(ConfigApp config, MesTrabalho mesTrabalho);
    }

    internal class CalculoServico : ICalculoServico
    {
        public TimeSpan Coeficiente(ConfigApp config, MesTrabalho mes)
        {
            var offset = new TimeSpan(0, mes.CoficienteOffset, 0);
            return new TimeSpan(CoeficienteDiario(config, mes).Where(w => w.Value.HasValue).Select(w => w.Value.Value.Ticks).Sum()).Add(offset.Negate()).Negate();
        }

        public TimeSpan CoeficientePorDia(ConfigApp config, MesTrabalho mes)
        {
            var dias = Validate(mes.Dias, config).Where(w => !w.EstaCompleto());

            if (dias.Count() == 0)
                return Coeficiente(config, mes);
            else
                return new TimeSpan(Coeficiente(config, mes).Ticks / dias.Count());
        }

        public TimeSpan? MediaEntradaEmpresa(ConfigApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(Validate(mes.Dias, config).Select(w => w.Empresa.Entrada));
        }

        public TimeSpan? MediaSaidaEmpresa(ConfigApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(Validate(mes.Dias, config).Select(w => w.Empresa.Saida));
        }

        public TimeSpan? MediaEntradaAlmoco(ConfigApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(Validate(mes.Dias, config).Select(w => w.Almoco.Entrada));
        }

        public TimeSpan? MediaSaidaAlmoco(ConfigApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(Validate(mes.Dias, config).Select(w => w.Almoco.Saida));
        }

        public TimeSpan? MediaTempoAlmoco(ConfigApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(Validate(mes.Dias, config).Select(w => w.Almoco.TempoTotal()));
        }

        public decimal? MediaValorAlmoco(ConfigApp config, MesTrabalho mes)
        {
            var valores = ValoresAlmoco(config, mes.Dias);
            if (valores.Count() == 0)
                return null;
            else
                return valores.Average();
        }

        public decimal? ValorIdealAlmoco(ConfigApp config, MesTrabalho mes)
        {
            var diasSemAlmoco = Validate(mes.Dias, config).Where(w => !w.ValorAlmoco.HasValue);
            if (diasSemAlmoco.Count() == 0)
                return null;
            else
                return ValorAtualTr(config, mes) / (decimal)diasSemAlmoco.Count();
        }

        public decimal ValorAtualTr(ConfigApp config, MesTrabalho mes)
        {
            var valoresAlmocos = ValoresAlmoco(config, mes.Dias);
            if (valoresAlmocos.Count() == 0)
                return mes.ValorSodexo;
            else
                return mes.ValorSodexo - valoresAlmocos.Sum();
        }

        public TimeSpan? TotalHorasTrabalhadas(DiaTrabalho dia)
        {
            if (!dia.EstaCompleto())
                return null;
            else
                return dia.Empresa.TempoTotal() - dia.Almoco.TempoTotal();
        }

        public TimeSpan TotalHorasTfs(ConfigApp config, MesTrabalho mesTrabalho)
        {
            var totalDias = this.Validate(mesTrabalho.Dias, config).Where(w => w.Data <= DateTime.Now).Count();
            var minutosPorDia = Math.Round((config.HoraFim - config.HoraInicio).TotalMinutes);

            //Remove a hora de almoço e também 1 hora de distração.
            var descontos = ((ConfigApp.HORAS_ALMOCO + 1) * 60);

            return new TimeSpan(0, Convert.ToInt32(minutosPorDia - descontos) * totalDias, 0);
        }

        private Dictionary<DateTime, TimeSpan?> CoeficienteDiario(ConfigApp config, MesTrabalho mes)
        {
            return Validate(mes.Dias, config).ToDictionary(w => w.Data, w => w.Coeficiente(config.HoraInicio, config.HoraFim));
        }

        private IEnumerable<DiaTrabalho> Validate(IEnumerable<DiaTrabalho> dias, ConfigApp config)
        {
            return from dia in dias
                   where !dia.Falta &&
                         !config.Feriados.Feriados.Any(w => w.Date == dia.Data.Date) &&
                         !config.Ferias.Any(w => w.Date == dia.Data.Date) &&
                         config.DiasTrabalho.Contains(dia.Data.DayOfWeek)
                   select dia;
        }

        private TimeSpan? MediaTimeSpan(IEnumerable<TimeSpan?> times)
        {
            if (times.Count() == 0)
                return null;
            else
                return times.Average();
        }

        private IEnumerable<decimal> ValoresAlmoco(ConfigApp config, IEnumerable<DiaTrabalho> dias)
        {
            return Validate(dias, config).Where(w => w.ValorAlmoco.HasValue).Select(w => w.ValorAlmoco.Value);
        }
    }
}