using System;

namespace ControlePontos.Servicos
{
    internal interface IParserServico
    {
        TimeSpan? ParseTimeSpan(string timeSpan);
    }

    internal class ParserServico : IParserServico
    {
        public TimeSpan? ParseTimeSpan(string timeSpan)
        {
            if (!timeSpan.IsNullOrEmpty())
            {
                string novoValor;
                if (timeSpan.Length == 4)
                    novoValor = $"{timeSpan[0]}{timeSpan[1]}:{timeSpan[2]}{timeSpan[3]}";
                else if (timeSpan.Length == 3)
                    novoValor = $"0{timeSpan[0]}:{timeSpan[1]}{timeSpan[2]}";
                else
                    novoValor = timeSpan;

                TimeSpan resultado;
                if (TimeSpan.TryParse(novoValor, out resultado))
                    return resultado;
                else
                    return null;
            }
            else
                return null;
        }
    }
}