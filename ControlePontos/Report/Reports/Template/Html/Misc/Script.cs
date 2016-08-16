namespace ControlePontos.Report.Reports.Template.Html.Misc
{
    public class Script
    {
        public enum Type
        {
            Css,
            Javascript
        }

        public static readonly Script ChartJs = new Script("chartjs", "ChartJs", Type.Javascript);
        public static readonly Script BootstrapCss = new Script("bootstrapcss", "BootstrapCss", Type.Css);
        public static readonly Script BootstrapJs = new Script("bootstrapjs", "BootstrapJs", Type.Javascript);
        public static readonly Script Jquery = new Script("jquery", "Jquery", Type.Javascript);
        public static readonly Script Util = new Script("util", "util", Type.Javascript);

        public Type ScriptType { get; private set; }
        public string Nome { get; private set; }
        public string ResourceName { get; private set; }

        private Script(string nome, string resourceName, Type type)
        {
            this.Nome = nome;
            this.ResourceName = resourceName;
            this.ScriptType = type;
        }

        public string GetAsString()
        {
            return HtmlResources.ResourceManager.GetString(this.ResourceName);
        }

        public class JsFunction
        {
            public JsFunction(string body)
            {
                this.Body = body;
            }

            public string Body { get; private set; }
        }
    }
}