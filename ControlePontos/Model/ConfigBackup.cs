using System.Collections.Generic;
using System.Linq;

namespace ControlePontos.Model
{
    public class ConfigBackup
    {
        public List<string> Diretorios { get; set; }

        public ConfigBackup(string[] diretorios)
        {
            this.Diretorios = diretorios.ToList();
        }
    }
}