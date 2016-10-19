using ControlePontos.Misc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ControlePontos.Model.Integracoes
{
    internal class SodexoTransacaoModel
    {
        [JsonProperty("value"), JsonConverter(typeof(RealJsonConverter))]
        public decimal Valor { get; set; }

        [JsonProperty("authorizationNumber")]
        public string CodigoAutorizacao { get; set; }

        [JsonProperty("history")]
        public string Historico { get; set; }

        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        public SodexoTipoTransacao Tipo { get; set; }

        [JsonProperty("date"), JsonConverter(typeof(DataBrasilJsonConverter))]
        public DateTime Data { get; set; }
    }
}