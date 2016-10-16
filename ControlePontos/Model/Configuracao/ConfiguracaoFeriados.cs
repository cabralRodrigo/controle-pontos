using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlePontos.Model.Configuracao
{
    public class ConfiguracaoFeriados
    {
        public List<DateTime> Feriados { get; set; }

        public ConfiguracaoFeriados(DateTime[] diretorios)
        {
            this.Feriados = diretorios.ToList();
        }
    }
}