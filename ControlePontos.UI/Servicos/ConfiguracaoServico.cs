using ControlePontos.Extensions;
using ControlePontos.Model.Configuracao;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace ControlePontos.Servicos
{
    internal interface IConfiguracaoServico
    {
        event Action<ConfiguracaoApp> ConfiguracaoMudou;

        void SalvarConfiguracao(ConfiguracaoApp configuracao);

        ConfiguracaoApp ObterConfiguracao();

        ConfiguracaoApp GerarConfiguracaoPadrao();
    }

    internal class ConfiguracaoServico : IConfiguracaoServico, IExportar
    {
        private static readonly Regex RegexArquivoConfiguracao = new Regex(@"^config-app\.\w+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly IArmazenamentoServico armazenamento;

        public event Action<ConfiguracaoApp> ConfiguracaoMudou;

        public ConfiguracaoServico(IArmazenamentoServico armazenamento)
        {
            this.armazenamento = armazenamento;
        }

        public ConfiguracaoApp ObterConfiguracao()
        {
            var json = this.armazenamento.Carregar("config-app");
            if (json.IsNullOrEmpty())
                return null;
            else
                return JsonConvert.DeserializeObject<ConfiguracaoApp>(json);
        }

        public void SalvarConfiguracao(ConfiguracaoApp configuracao)
        {
            this.armazenamento.Salvar("config-app", JsonConvert.SerializeObject(configuracao, Formatting.Indented));
            this.ConfiguracaoMudou?.Invoke(configuracao);
        }

        public ConfiguracaoApp GerarConfiguracaoPadrao()
        {
            return new ConfiguracaoApp
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