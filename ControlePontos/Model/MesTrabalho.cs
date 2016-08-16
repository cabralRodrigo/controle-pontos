using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlePontos.Model
{
    internal class MesTrabalho
    {
        public static MesTrabalho Gerar(int ano, int mes)
        {
            return new MesTrabalho
            {
                ValorSodexo = 0,
                CoficienteOffset = 0,
                Dias = Enumerable
                    .Range(1, DateTime.DaysInMonth(ano, mes))
                    .Select(day => new DateTime(ano, mes, day))
                    .Select(s => new DiaTrabalho { Data = s, Almoco = new EntradaSaida(), Empresa = new EntradaSaida() }).ToList()
            };
        }

        public List<DiaTrabalho> Dias { get; set; }
        public int CoficienteOffset { get; set; }
        public decimal ValorSodexo { get; set; }
    }
}