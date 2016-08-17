using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ControlePontos.Configuracao
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
