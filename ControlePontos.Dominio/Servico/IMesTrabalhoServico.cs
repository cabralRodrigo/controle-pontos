using ControlePontos.Dominio.Model;

namespace ControlePontos.Dominio.Servico
{
    public interface IMesTrabalhoServico
    {
        MesTrabalho ObterMesTrabalho(int ano, int mes, bool gerarMesSeNaoDisponivel = true);

        void SalvarMesTrabalho(int ano, int mes, MesTrabalho mesTrabalho);

        MesTrabalho GerarMesTrabalho(int ano, int mes);
    }
}
