using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlePontos.Model
{
    public class ConfigFeriados
    {
        public List<DateTime> Feriados { get; set; }

        public ConfigFeriados(DateTime[] diretorios)
        {
            this.Feriados = diretorios.ToList();
        }
    }
}