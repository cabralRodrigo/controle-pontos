using ControlePontos.Model;
using ControlePontos.Model.Configuracao;
using System;
using System.Drawing;

namespace ControlePontos.Control
{
    internal class DiaTrabalhoColumnConfiguracao
    {
        public bool SempreReadOnly { get; set; }
        public string Formato { get; set; }
        public Func<object, string> Formatador { get; set; }
        public Func<ConfiguracaoApp, DiaTrabalho, object, Color?> Colorizador { get; set; }
        public Type Tipo { get; set; }
    }
}