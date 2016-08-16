using System;

namespace ControlePontos.Model
{
    public class DiaTrabalho
    {
        public DateTime Data { get; set; }
        public EntradaSaida Empresa { get; set; }
        public EntradaSaida Almoco { get; set; }
        public decimal? ValorAlmoco { get; set; }
        public bool Falta { get; set; }

        public bool EstaCompleto()
        {
            return Empresa.EstaCompleto() && Almoco.EstaCompleto();
        }

        public TimeSpan? Coeficiente(TimeSpan horaInicio, TimeSpan horaFim)
        {
            if (this.EstaCompleto())
            {
                const int HORAS_ALMOCO = 1;
                var HORAS_POR_DIA = (int)(horaFim - horaInicio).TotalHours - HORAS_ALMOCO;

                var acc = this.Empresa.Saida.Value - this.Empresa.Entrada.Value;
                var accAlmoco = this.Almoco.Saida.Value - this.Almoco.Entrada.Value;

                return new TimeSpan(HORAS_POR_DIA, 0, 0) - (acc - accAlmoco);
            }
            else
                return null;
        }
    }
}