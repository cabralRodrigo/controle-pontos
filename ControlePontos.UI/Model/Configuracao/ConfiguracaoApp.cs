using System;

namespace ControlePontos.Model.Configuracao
{
    public class ConfiguracaoApp
    {
        public const int HORAS_ALMOCO = 1;

        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public DayOfWeek[] DiasTrabalho { get; set; }
        public DateTime[] Ferias { get; set; }

        public ConfiguracaoApp()
        {
            this.Backup = new ConfiguracaoBackup(new string[0]);
            this.Feriados = new ConfiguracaoFeriados(new DateTime[0]);
            this.TeamService = new ConfiguracaoTeamService();
            this.Sodexo = new ConfiguracaoSodexo();

            this.Cores = new ConfiguracaoCores();
            this.Ferias = new DateTime[0];
            this.DiasTrabalho = new DayOfWeek[0];
        }

        public ConfiguracaoBackup Backup { get; set; }
        public ConfiguracaoFeriados Feriados { get; set; }
        public ConfiguracaoCores Cores { get; set; }
        public ConfiguracaoTeamService TeamService { get; set; }
        public ConfiguracaoSodexo Sodexo { get; internal set; }
    }
}