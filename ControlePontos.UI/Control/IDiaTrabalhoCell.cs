using ControlePontos.Dominio.Model;
using ControlePontos.Dominio.Model.Configuracao;

namespace ControlePontos.Control
{
    internal interface IDiaTrabalhoCell
    {
        object Value { get; set; }

        void AddedCell(ConfiguracaoApp appConfig, DiaTrabalho dia);

        void UpdateCell(ConfiguracaoApp appConfig, DiaTrabalho dia);
    }
}