namespace ControlePontos.Exportacao
{
    internal class ExportacaoResultado
    {
        public string ArquivoZip { get; set; }

        public int QuantidadeArquivos { get; set; }
        public int AnoInicio { get; set; }
        public int AnoFim { get; set; }
        public int MesInicio { get; set; }
        public int MesFim { get; set; }
    }
}