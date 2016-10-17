﻿using ControlePontos.Extensions;
using ControlePontos.Model;
using ControlePontos.Model.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlePontos.Servicos
{
    internal interface ICalculoServico
    {
        TimeSpan Coeficiente(ConfiguracaoApp config, MesTrabalho mes);

        TimeSpan CoeficientePorDia(ConfiguracaoApp config, MesTrabalho mes);

        TimeSpan? MediaEntradaEmpresa(ConfiguracaoApp config, MesTrabalho mes);

        TimeSpan? MediaSaidaEmpresa(ConfiguracaoApp config, MesTrabalho mes);

        TimeSpan? MediaEntradaAlmoco(ConfiguracaoApp config, MesTrabalho mes);

        TimeSpan? MediaSaidaAlmoco(ConfiguracaoApp config, MesTrabalho mes);

        TimeSpan? MediaTempoAlmoco(ConfiguracaoApp config, MesTrabalho mes);

        decimal? MediaValorAlmoco(ConfiguracaoApp config, MesTrabalho mes);

        decimal? ValorIdealAlmoco(ConfiguracaoApp config, MesTrabalho mes);

        decimal ValorAtualTr(ConfiguracaoApp config, MesTrabalho mes);

        TimeSpan? TotalHorasTrabalhadas(DiaTrabalho dia);

        TimeSpan TotalHorasTfs(ConfiguracaoApp config, MesTrabalho mesTrabalho);

        IEnumerable<DiaTrabalho> FiltrarDiasDeTrabalho(IEnumerable<DiaTrabalho> dias, ConfiguracaoApp config);
    }

    internal class CalculoServico : ICalculoServico
    {
        public TimeSpan Coeficiente(ConfiguracaoApp config, MesTrabalho mes)
        {
            var offset = new TimeSpan(0, mes.CoficienteOffset, 0);
            return new TimeSpan(CoeficienteDiario(config, mes).Where(w => w.Value.HasValue).Select(w => w.Value.Value.Ticks).Sum()).Add(offset.Negate()).Negate();
        }

        public TimeSpan CoeficientePorDia(ConfiguracaoApp config, MesTrabalho mes)
        {
            var dias = FiltrarDiasDeTrabalho(mes.Dias, config).Where(w => !w.EstaCompleto());

            if (dias.Count() == 0)
                return Coeficiente(config, mes);
            else
                return new TimeSpan(Coeficiente(config, mes).Ticks / dias.Count());
        }

        public TimeSpan? MediaEntradaEmpresa(ConfiguracaoApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(FiltrarDiasDeTrabalho(mes.Dias, config).Select(w => w.Empresa.Entrada));
        }

        public TimeSpan? MediaSaidaEmpresa(ConfiguracaoApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(FiltrarDiasDeTrabalho(mes.Dias, config).Select(w => w.Empresa.Saida));
        }

        public TimeSpan? MediaEntradaAlmoco(ConfiguracaoApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(FiltrarDiasDeTrabalho(mes.Dias, config).Select(w => w.Almoco.Entrada));
        }

        public TimeSpan? MediaSaidaAlmoco(ConfiguracaoApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(FiltrarDiasDeTrabalho(mes.Dias, config).Select(w => w.Almoco.Saida));
        }

        public TimeSpan? MediaTempoAlmoco(ConfiguracaoApp config, MesTrabalho mes)
        {
            return MediaTimeSpan(FiltrarDiasDeTrabalho(mes.Dias, config).Select(w => w.Almoco.TempoTotal()));
        }

        public decimal? MediaValorAlmoco(ConfiguracaoApp config, MesTrabalho mes)
        {
            var valores = ValoresAlmoco(config, mes.Dias);
            if (valores.Count() == 0)
                return null;
            else
                return valores.Average();
        }

        public decimal? ValorIdealAlmoco(ConfiguracaoApp config, MesTrabalho mes)
        {
            var diasSemAlmoco = FiltrarDiasDeTrabalho(mes.Dias, config).Where(w => !w.ValorAlmoco.HasValue);
            if (diasSemAlmoco.Count() == 0)
                return null;
            else
                return ValorAtualTr(config, mes) / (decimal)diasSemAlmoco.Count();
        }

        public decimal ValorAtualTr(ConfiguracaoApp config, MesTrabalho mes)
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

        public TimeSpan TotalHorasTfs(ConfiguracaoApp config, MesTrabalho mesTrabalho)
        {
            var totalDias = this.FiltrarDiasDeTrabalho(mesTrabalho.Dias, config).Where(w => w.Data <= DateTime.Now).Count();
            var minutosPorDia = Math.Round((config.HoraFim - config.HoraInicio).TotalMinutes);

            //Remove a hora de almoço e também 1 hora de distração.
            var descontos = ((ConfiguracaoApp.HORAS_ALMOCO + 1) * 60);

            return new TimeSpan(0, Convert.ToInt32(minutosPorDia - descontos) * totalDias, 0);
        }

        public IEnumerable<DiaTrabalho> FiltrarDiasDeTrabalho(IEnumerable<DiaTrabalho> dias, ConfiguracaoApp config)
        {
            return from dia in dias
                   where !dia.Falta &&
                         !config.Feriados.Feriados.Any(w => w.Date == dia.Data.Date) &&
                         !config.Ferias.Any(w => w.Date == dia.Data.Date) &&
                         config.DiasTrabalho.Contains(dia.Data.DayOfWeek)
                   select dia;
        }

        private Dictionary<DateTime, TimeSpan?> CoeficienteDiario(ConfiguracaoApp config, MesTrabalho mes)
        {
            return FiltrarDiasDeTrabalho(mes.Dias, config).ToDictionary(w => w.Data, w => w.Coeficiente(config.HoraInicio, config.HoraFim));
        }

        private TimeSpan? MediaTimeSpan(IEnumerable<TimeSpan?> times)
        {
            if (times.Count() == 0)
                return null;
            else
                return times.Average();
        }

        private IEnumerable<decimal> ValoresAlmoco(ConfiguracaoApp config, IEnumerable<DiaTrabalho> dias)
        {
            return FiltrarDiasDeTrabalho(dias, config).Where(w => w.ValorAlmoco.HasValue).Select(w => w.ValorAlmoco.Value);
        }
    }
}