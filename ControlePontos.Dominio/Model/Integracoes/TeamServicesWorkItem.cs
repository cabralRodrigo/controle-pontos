using System;

namespace ControlePontos.Dominio.Model.Integracoes
{
    public class TeamServicesWorkItem
    {
        public int ID { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Estado { get; set; }
        public double? HorasCompletadas { get; set; }
        public string Projeto { get; set; }
        public string Titulo { get; set; }
    }
}