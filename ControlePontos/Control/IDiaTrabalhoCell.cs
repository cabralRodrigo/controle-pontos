using ControlePontos.Model;

namespace ControlePontos.Control
{
    internal interface IDiaTrabalhoCell
    {
        object Value { get; set; }

        void AddedCell(ConfigApp appConfig, DiaTrabalho dia);

        void UpdateCell(ConfigApp appConfig, DiaTrabalho dia);
    }
}