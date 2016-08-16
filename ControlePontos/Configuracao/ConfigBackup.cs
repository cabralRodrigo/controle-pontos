using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ControlePontos.Configuracao
{
    public class ConfigBackup
    {
        private static string Arquivo()
        {
            var path = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            return  Path.Combine(path, "config-backup.json");
        }

        public static ConfigBackup Carregar()
        {
            var arquivo = Arquivo();
            try
            {
                if (File.Exists(arquivo))
                {
                    var json = File.ReadAllText(arquivo);
                    var diretorios = JsonConvert.DeserializeObject<string[]>(json);

                    return new ConfigBackup(diretorios);
                }
            }
            catch
            {
                //TODO: Log error.
            }

            return new ConfigBackup(new string[0]);
        }

        public static void Salvar(ConfigBackup config)
        {
            try
            {
                var json = JsonConvert.SerializeObject(config.Diretorios);
                File.WriteAllText(Arquivo(), json);
            }
            catch
            {
                //TODO: Log error.
            }
        }

        public List<string> Diretorios { get; set; }

        public ConfigBackup(string[] diretorios)
        {
            this.Diretorios = diretorios.ToList();
        }
    }
}