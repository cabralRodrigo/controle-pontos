namespace ControlePontos.Exportacao
{
    internal class DataFile
    {
        public readonly string Diretorio, Nome;
        public readonly int Ano, Mes;
        
        public DataFile(string diretorio, string nome, int ano, int mes)
        {
            this.Diretorio = diretorio;
            this.Nome = nome;
            this.Ano = ano;
            this.Mes = mes;
        }
    }
}