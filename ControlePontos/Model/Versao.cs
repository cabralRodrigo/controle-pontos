using ControlePontos.Extensions;
using System;

namespace ControlePontos.Model
{
    internal struct Versao : IComparable<Versao>
    {
        public int VersaoMaior { get; private set; }
        public int VersaoFuncionalidade { get; private set; }
        public int VersaoBugs { get; private set; }

        public Versao(int maior, int funcionalidade, int bugs)
        {
            this.VersaoMaior = maior;
            this.VersaoFuncionalidade = funcionalidade;
            this.VersaoBugs = bugs;
        }

        public Versao(string versao) : this()
        {
            this.Parse(versao);
        }

        public static bool operator >(Versao a, Versao b)
        {
            if (b.VersaoMaior < a.VersaoMaior)
                return true;

            if (b.VersaoFuncionalidade < a.VersaoMaior)
                return true;

            if (b.VersaoBugs < a.VersaoBugs)
                return true;

            return false;
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
                return this.VersaoMaior == versao?.VersaoMaior && this.VersaoFuncionalidade == versao?.VersaoFuncionalidade && this.VersaoBugs == versao?.VersaoBugs;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.VersaoMaior.GetHashCode() ^ this.VersaoFuncionalidade.GetHashCode() ^ this.VersaoBugs.GetHashCode();
        }

        public override string ToString()
        {
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

            this.VersaoMaior = maior;
            this.VersaoFuncionalidade = funcionalidade;
            this.VersaoBugs = bugs;
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