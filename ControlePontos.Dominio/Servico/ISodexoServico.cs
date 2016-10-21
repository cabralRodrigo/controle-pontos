using ControlePontos.Dominio.Model.Integracoes;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePontos.Dominio.Servico
{
    public interface ISodexoServico
    {
        Task<SodexoHistorioUsoModel> ConsultarSaldoAsync(string numeroCartao, string cpf, CancellationToken cancellationToken);
    }
}