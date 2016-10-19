using Newtonsoft.Json.Converters;

namespace ControlePontos.Misc
{
    internal class DataBrasilJsonConverter : IsoDateTimeConverter
    {
        public DataBrasilJsonConverter() { base.DateTimeFormat = "dd/MM/yyyy"; }
    }
}