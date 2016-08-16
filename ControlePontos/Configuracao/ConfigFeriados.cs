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
        private static string Arquivo()
        {
            var path = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            return Path.Combine(path, "config-feriados.json");
        }

        public static ConfigFeriados Carregar()
        {
            var arquivo = Arquivo();
            try
            {
                if (File.Exists(arquivo))
                {
                    var json = File.ReadAllText(arquivo);
                    var feriados = JsonConvert.DeserializeObject<DateTime[]>(json);

                    return new ConfigFeriados(feriados);
                }
            }
            catch
            {
                //TODO: Log error.
            }

            return new ConfigFeriados(new DateTime[0]);
        }

        public static void Salvar(ConfigFeriados config)
        {
            try
            {
                var json = JsonConvert.SerializeObject(config.Feriados);
                File.WriteAllText(Arquivo(), json);
            }
            catch
            {
                //TODO: Log error.
            }
        }


        public List<DateTime> Feriados { get; set; }

        public ConfigFeriados(DateTime[] diretorios)
        {
            this.Feriados = diretorios.ToList();
        }
    }
}
