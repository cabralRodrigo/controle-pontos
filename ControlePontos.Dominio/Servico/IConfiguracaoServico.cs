using ControlePontos.Dominio.Model.Configuracao;
using System;

namespace ControlePontos.Dominio.Servico
{
    public interface IConfiguracaoServico
    {
        event Action<ConfiguracaoApp> ConfiguracaoMudou;

        void SalvarConfiguracao(ConfiguracaoApp configuracao);

        ConfiguracaoApp ObterConfiguracao();

        ConfiguracaoApp GerarConfiguracaoPadrao();
    }
}
