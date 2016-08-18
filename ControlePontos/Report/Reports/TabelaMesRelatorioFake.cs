using ControlePontos.Model;
using ControlePontos.Servicos;
using System;
using System.Linq;

namespace ControlePontos.Report.Reports
{
    internal class TabelaMesRelatorioFake : TabelaMesRelatorio
    {

        public override string Name
        {
            get
            {
                return "Tabela de impressão dos horários do mês fake";
            }
        }

        private readonly IMesTrabalhoServico mesTrabalhoServico;

        public TabelaMesRelatorioFake(IMesTrabalhoServico mesTrabalhoServico)
        {
            this.mesTrabalhoServico = mesTrabalhoServico;
        }

        public override IReportExecutionResult Execute(ConfigApp config, int ano, int mes, MesTrabalho mesTrabalho)
        {
            var rand = new Random();
            var faltas = mesTrabalho.Dias.Where(w => w.Falta).Select(s => s.Data);

            var dias = this.mesTrabalhoServico.GerarMesTrabalho(ano, mes).Dias.Select(w => new DiaTrabalho
            {
                Data = w.Data,
                ValorAlmoco = w.ValorAlmoco,
                Almoco = new EntradaSaida
                {
                    Entrada = Random(rand, 11, 59, 0, 12, 1, 0),
                    Saida = Random(rand, 12, 58, 0, 13, 1, 0)
                },
                Empresa = new EntradaSaida
                {
                    Entrada = Random(rand, 8, 55, 0, 9, 5, 0),
                    Saida = Random(rand, 17, 59, 0, 18, 2, 0)
                }
            }).ToList();

            dias.ForEach(w =>
            {
                if (w.Data.DayOfWeek == DayOfWeek.Saturday || w.Data.DayOfWeek == DayOfWeek.Sunday || faltas.Contains(w.Data) || config.Feriados.Feriados.Contains(w.Data.Date) || config.Ferias.Contains(w.Data.Date))
                {
                    w.Almoco = new EntradaSaida();
                    w.Empresa = new EntradaSaida();
                }
            });

            return base.Execute(config, ano, mes, new MesTrabalho { CoficienteOffset = mesTrabalho.CoficienteOffset, ValorSodexo = mesTrabalho.ValorSodexo, Dias = dias });
        }

        private static TimeSpan Random(Random rand, int minH, int minM, int minS, int maxH, int maxM, int maxS)
        {
            return new TimeSpan(LongRandom(new TimeSpan(minH, minM, minS).Ticks, new TimeSpan(maxH, maxM, maxS).Ticks, rand));
        }

        private static long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }
    }
}