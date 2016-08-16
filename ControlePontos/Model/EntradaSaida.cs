using System;

namespace ControlePontos.Model
{
    public class EntradaSaida
    {
        public TimeSpan? Entrada { get; set; }
        public TimeSpan? Saida { get; set; }

        public bool EstaCompleto()
        {
            return Entrada.HasValue && Saida.HasValue;
        }

        public TimeSpan? TempoTotal()
        {
            if (EstaCompleto())
                return Saida - Entrada;
            else
                return null;
        }
    }
}