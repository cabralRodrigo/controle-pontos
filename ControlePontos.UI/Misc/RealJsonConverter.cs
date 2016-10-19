using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace ControlePontos.Misc
{
    internal class RealJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal) || objectType == typeof(decimal?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
                return token.ToObject<decimal>();

            else if (token.Type == JTokenType.Null && objectType == typeof(decimal?))
                return null;

            else if (token.Type == JTokenType.String)
                return decimal.Parse(token.ToString(), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-br"));

            throw new JsonSerializationException($"Unexpected token type: {token.Type}");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}