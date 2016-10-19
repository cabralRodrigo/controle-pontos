using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ControlePontos.Model
{
    internal class ChangelogInfo
    {
        public Versao Versao { get; set; }
        public DateTime Data { get; set; }
        public List<MudancaInfo> Mudancas { get; set; }

        public override string ToString()
        {
            return $"{Data.ToString("dd/MM/yyyy")} {Versao}";
        }
    }

    internal class MudancaInfo
    {
        public string Descricao { get; set; }
        public TipoMudanca Tipo { get; set; }
    }

    internal enum TipoMudanca
    {
        [Description("Correção de Bug")]
        CorrecaoBug,

        [Description("Adição de Funcionalidade")]
        AdicaoFuncionalidade,

        [Description("Mudança de Funcionalidade")]
        MudancaFuncionalidade,

        [Description("Melhoramento de Código")]
        MelhoramentoCodigo
    }
}