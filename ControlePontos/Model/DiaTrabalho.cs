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
                var tempoPorDia = (horaFim - horaInicio).Add(new TimeSpan(ConfigApp.HORAS_ALMOCO * -1, 0, 0));

                var acc = this.Empresa.Saida.Value - this.Empresa.Entrada.Value;
                var accAlmoco = this.Almoco.Saida.Value - this.Almoco.Entrada.Value;

                return tempoPorDia - (acc - accAlmoco);
            }
            else
                return null;
        }
    }
}