﻿using System.Collections.Generic;
using System.Linq;

namespace ControlePontos.Dominio.Model.Configuracao
{
    public class ConfiguracaoBackup
    {
        public List<string> Diretorios { get; set; }

        public ConfiguracaoBackup(string[] diretorios)
        {
            this.Diretorios = diretorios.ToList();
        }
    }
}