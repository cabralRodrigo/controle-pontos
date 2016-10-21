using System;

namespace ControlePontos.Dominio.Servico
{
    public interface IParserServico
    {
        TimeSpan? ParseTimeSpan(string timeSpan);
    }
}