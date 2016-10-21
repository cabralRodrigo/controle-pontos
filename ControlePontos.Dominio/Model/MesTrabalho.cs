using System.Collections.Generic;

namespace ControlePontos.Dominio.Model
{
    public class MesTrabalho
    {
        public List<DiaTrabalho> Dias { get; set; }
        public int CoficienteOffset { get; set; }
        public decimal ValorSodexo { get; set; }
    }
}