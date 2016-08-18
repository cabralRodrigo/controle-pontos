using System;

namespace ControlePontos.Model
{
    public class ConfigApp
    {
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public DayOfWeek[] DiasTrabalho { get; set; }
        public DateTime[] Ferias { get; set; }

        public ConfigApp()
        {
            this.HoraInicio = new TimeSpan(9, 0, 0);
            this.HoraFim = new TimeSpan(18, 0, 0);
            this.DiasTrabalho = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            this.Ferias = new DateTime[]
            {
                new DateTime(2016, 4, 1),
                new DateTime(2016, 4, 4),
                new DateTime(2016, 4, 5),
                new DateTime(2016, 4, 6),
                new DateTime(2016, 4, 7),
                new DateTime(2016, 4, 8)
            };

            this.Backup = new ConfigBackup(new string[0]);
            this.Feriados = new ConfigFeriados(new DateTime[0]);
        }

        public ConfigBackup Backup { get; set; }
        public ConfigFeriados Feriados { get; set; }
    }
}