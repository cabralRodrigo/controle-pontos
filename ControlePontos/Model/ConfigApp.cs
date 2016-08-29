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
            this.Ferias = new DateTime[0];
            this.DiasTrabalho = new DayOfWeek[0];
        }

        public ConfigBackup Backup { get; set; }
        public ConfigFeriados Feriados { get; set; }

        public static class Cores
        {
            public static readonly Color Normal = Color.White;
            public static readonly Color Ferias = Color.FromArgb(144, 195, 212);
            public static readonly Color NaoTrabalho = Color.FromArgb(212, 144, 147);
            public static readonly Color Feriado = Color.FromArgb(175, 144, 212);
            public static readonly Color Falta = Color.FromArgb(186, 116, 4);
            public static readonly Color Hoje = Color.FromArgb(161, 212, 144);
        }
    }
}