using System;

namespace ControlePontos.Model
{
    public class ConfiguracaoDias
    {
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public DayOfWeek[] DiasTrabalho { get; set; }
       // public DateTime[] Feriados { get; set; }
        public DateTime[] Ferias { get; set; }
    }
}