using ControlePontos.Model;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace ControlePontos.Servicos
{
    internal interface IConfiguracaoServico
    {
        event Action<ConfigApp> ConfiguracaoMudou;

        void SalvarConfiguracao(ConfigApp configuracao);

        ConfigApp ObterConfiguracao();

        ConfigApp GerarConfiguracaoPadrao();
    }

    internal class ConfiguracaoServico : IConfiguracaoServico, IExportar
    {
        private static readonly Regex RegexArquivoConfiguracao = new Regex(@"^config-app\.\w+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly IArmazenamentoServico armazenamento;

        public event Action<ConfigApp> ConfiguracaoMudou;

        public ConfiguracaoServico(IArmazenamentoServico armazenamento)
        {
            this.armazenamento = armazenamento;
        }

        public ConfigApp ObterConfiguracao()
        {
            var json = this.armazenamento.Carregar("config-app");
            if (string.IsNullOrEmpty(json))
                return null;
            else
                return JsonConvert.DeserializeObject<ConfigApp>(json);
        }

        public void SalvarConfiguracao(ConfigApp configuracao)
        {
            this.armazenamento.Salvar("config-app", JsonConvert.SerializeObject(configuracao, Formatting.Indented));
            this.ConfiguracaoMudou?.Invoke(configuracao);
        }

        public ConfigApp GerarConfiguracaoPadrao()
        {
            return new ConfigApp
            {
                HoraInicio = new TimeSpan(9, 0, 0),
                HoraFim = new TimeSpan(18, 0, 0),
                DiasTrabalho = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday }
            };
        }

        public Regex RegexArquivos()
        {
            return RegexArquivoConfiguracao;
        }
    }
}