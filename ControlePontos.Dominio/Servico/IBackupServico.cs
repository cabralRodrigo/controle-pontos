using ControlePontos.Dominio.Model;

namespace ControlePontos.Dominio.Servico
{
    public interface IBackupServico
    {
        bool BackupAgendadoRealizado();

        Resultado<BackupResultado> RealizarBackup();
    }
}