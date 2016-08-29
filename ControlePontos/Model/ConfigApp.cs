using System;
using System.Drawing;

namespace ControlePontos.Model
{
    public class ConfigApp
    {
        public const int HORAS_ALMOCO = 1;

        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public DayOfWeek[] DiasTrabalho { get; set; }
        public DateTime[] Ferias { get; set; }

        public ConfigApp()
        {
            this.Backup = new ConfigBackup(new string[0]);
            this.Feriados = new ConfigFeriados(new DateTime[0]);
            this.Cores = new CoresConfig();
            this.Ferias = new DateTime[0];
            this.DiasTrabalho = new DayOfWeek[0];
        }

        public ConfigBackup Backup { get; set; }
        public ConfigFeriados Feriados { get; set; }
        public CoresConfig Cores { get; set; }
    }
}