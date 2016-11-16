using ControlePontos.Dominio.Model;
using ControlePontos.Dominio.Model.Configuracao;
using System;
using System.Collections.Generic;

namespace ControlePontos.Dominio.Servico
{
    public interface ICalculoServico
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

        int TotalHorasPorDia(ConfiguracaoApp config);

        IEnumerable<DiaTrabalho> FiltrarDiasDeTrabalho(IEnumerable<DiaTrabalho> dias, ConfiguracaoApp config);
    }
}
