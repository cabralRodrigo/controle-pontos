using ControlePontos.Model;
using Newtonsoft.Json;

namespace ControlePontos.Servicos
{
    public delegate void ConfiguracaoMudouHandler(ConfigApp novaConfiguracao);

    public interface IConfiguracaoServico
    {
        event ConfiguracaoMudouHandler ConfiguracaoMudou;
        void SalvarConfiguracao(ConfigApp configuracao);
        ConfigApp ObterConfiguracao();
    }

    public class ConfiguracaoServico : IConfiguracaoServico
    {
        private readonly IArmazenamentoServico armazenamento;

        public event ConfiguracaoMudouHandler ConfiguracaoMudou;

        public ConfiguracaoServico(IArmazenamentoServico armazenamento)
        {
            this.armazenamento = armazenamento;
        }

        public ConfigApp ObterConfiguracao()
        {
            var json = this.armazenamento.Carregar("config-app");
            if (string.IsNullOrEmpty(json))
                return new ConfigApp();
            else
                return JsonConvert.DeserializeObject<ConfigApp>(json);
        }

        public void SalvarConfiguracao(ConfigApp configuracao)
        {
            this.armazenamento.Salvar("config-app", JsonConvert.SerializeObject(configuracao, Formatting.Indented));
            
            if (this.ConfiguracaoMudou != null)
                this.ConfiguracaoMudou(configuracao);
        }
    }
}