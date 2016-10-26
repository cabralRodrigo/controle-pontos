using System;
using ControlePontos.Util.Extensions;

namespace ControlePontos.Dominio.Model
{
    public struct Versao : IComparable<Versao>
    {
        public int VersaoMaior { get; private set; }
        public int VersaoFuncionalidade { get; private set; }
        public int VersaoBugs { get; private set; }
        public int VersaoBuild { get; private set; }

        public Versao(int maior, int funcionalidade, int bugs, int build = 0)
        {
            this.VersaoMaior = maior;
            this.VersaoFuncionalidade = funcionalidade;
            this.VersaoBugs = bugs;
            this.VersaoBuild = build;
        }

        public Versao(string versao) : this()
        {
            this.Parse(versao);
        }

        public static bool operator >(Versao a, Versao b)
        {
            var versaoA = $"{a.VersaoMaior}{a.VersaoFuncionalidade}{a.VersaoBugs}{a.VersaoBuild}";
            var versaoB = $"{b.VersaoMaior}{b.VersaoFuncionalidade}{b.VersaoBugs}{b.VersaoBuild}";

            return int.Parse(versaoA) > int.Parse(versaoB);
        }

        public static bool operator <(Versao a, Versao b)
        {
            return a != b && !(a > b);
        }

        public static bool operator ==(Versao a, Versao b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Versao a, Versao b)
        {
            return !(a == b);
        }

        public static bool operator >=(Versao a, Versao b)
        {
            return a > b || a == b;
        }

        public static bool operator <=(Versao a, Versao b)
        {
            return a < b || a == b;
        }

        public override bool Equals(object obj)
        {
            var versao = obj as Versao?;

            if (versao.HasValue)
                return this.VersaoMaior == versao?.VersaoMaior && this.VersaoFuncionalidade == versao?.VersaoFuncionalidade && this.VersaoBugs == versao?.VersaoBugs && this.VersaoBuild == versao?.VersaoBuild;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.VersaoMaior.GetHashCode() ^ this.VersaoFuncionalidade.GetHashCode() ^ this.VersaoBugs.GetHashCode() ^ this.VersaoBuild.GetHashCode();
        }

        public override string ToString()
        {
            if (this.VersaoBuild != 0)
                return $"{this.VersaoMaior}.{this.VersaoFuncionalidade}.{this.VersaoBugs}.{this.VersaoBuild}";
            else
                return $"{this.VersaoMaior}.{this.VersaoFuncionalidade}.{this.VersaoBugs}";
        }

        private void Parse(string versao)
        {
            if (versao.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(versao));

            var partes = versao.Split('.');
            if (partes.Length < 3)
                throw new ArgumentOutOfRangeException(nameof(versao));

            int maior;
            if (!int.TryParse(partes[0], out maior))
                throw new ArgumentOutOfRangeException(nameof(versao));

            int funcionalidade;
            if (!int.TryParse(partes[1], out funcionalidade))
                throw new ArgumentOutOfRangeException(nameof(versao));

            int bugs;
            if (!int.TryParse(partes[2], out bugs))
                throw new ArgumentOutOfRangeException(nameof(versao));

            int build = 0;
            if (partes.Length >= 4)
            {
                if (!int.TryParse(partes[3], out build))
                    throw new ArgumentOutOfRangeException(nameof(versao));
            }

            this.VersaoMaior = maior;
            this.VersaoFuncionalidade = funcionalidade;
            this.VersaoBugs = bugs;
            this.VersaoBuild = build;
        }

        public int CompareTo(Versao other)
        {
            if (this < other)
                return -1;

            if (this > other)
                return 1;

            return 0;
        }
    }
}