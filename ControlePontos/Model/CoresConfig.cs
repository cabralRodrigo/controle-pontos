using System.Drawing;

namespace ControlePontos.Model
{
    public class CoresConfig
    {
        public Color DiaNormal { get; set; } = Color.White;
        public Color Ferias { get; set; } = Color.FromArgb(144, 195, 212);
        public Color NaoTrabalho { get; set; } = Color.FromArgb(209, 209, 209);
        public Color Feriado { get; set; } = Color.FromArgb(201, 180, 226);
        public Color Falta { get; set; } = Color.FromArgb(255, 164, 164);
        public Color Hoje { get; set; } = Color.FromArgb(161, 212, 144);
    }
}