using System.IO;

namespace ControlePontos.Misc
{
    internal static class Resources
    {
        public static Stream Changelog()
        {
            return typeof(Resources).Assembly.GetManifestResourceStream("ControlePontos.changelog.txt");
        }
    }
}