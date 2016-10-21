using ControlePontos.Util.Misc;
using Newtonsoft.Json;
using System;

namespace ControlePontos.Dominio.Model.Integracoes
{
    public class SodexoHistorioUsoModel
    {
        [JsonProperty("serviceName")]
        public string Servico { get; set; }

        [JsonProperty("cardStatus")]
        public string Status { get; set; }

        [JsonProperty("companyName")]
        public string NomeEmpresa { get; set; }

        [JsonProperty("name")]
        public string NomeAssociado { get; set; }

        [JsonProperty("dateBalance"), JsonConverter(typeof(DataBrasilJsonConverter))]
        public DateTime DataAtualizacao { get; set; }

        [JsonProperty("balanceAmount"), JsonConverter(typeof(RealJsonConverter))]
        public decimal SaldoAtual { get; set; }

        [JsonProperty("cardNumber")]
        public string NumeroCartao { get; set; }

        [JsonProperty("document")]
        public string Cpf { get; set; }

        [JsonProperty("transactions")]
        public SodexoTransacaoModel[] Transacoes { get; set; }
    }
}