using Newtonsoft.Json.Converters;

namespace ControlePontos.Util.Misc
{
    public class DataBrasilJsonConverter : IsoDateTimeConverter
    {
        public DataBrasilJsonConverter() { base.DateTimeFormat = "dd/MM/yyyy"; }
    }
}