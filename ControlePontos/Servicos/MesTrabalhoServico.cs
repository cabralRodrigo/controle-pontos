using ControlePontos.Model;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ControlePontos.Servicos
{
    internal interface IMesTrabalhoServico
    {
        MesTrabalho ObterMesTrabalho(int ano, int mes, bool gerarMesSeNaoDisponivel = true);

        void SalvarMesTrabalho(int ano, int mes, MesTrabalho mesTrabalho);

        MesTrabalho GerarMesTrabalho(int ano, int mes);
    }

    internal class MesTrabalhoServico : IMesTrabalhoServico, IExportar
    {
        private static readonly Regex RegexMesTrabalho = new Regex(@"^horarios-[0-9]{4}-[0-9]{1,2}\.\w+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly IArmazenamentoServico armazenamentoServico;

        public MesTrabalhoServico(IArmazenamentoServico armazenamentoServico)
        {
            this.armazenamentoServico = armazenamentoServico;
        }

        public MesTrabalho ObterMesTrabalho(int ano, int mes, bool gerarMesSeNaoDisponivel = true)
        {
            var json = this.armazenamentoServico.Carregar(this.MontarNomeArquivo(ano, mes));

            if (!json.IsNullOrEmpty())
                return JsonConvert.DeserializeObject<MesTrabalho>(json);
            else if (gerarMesSeNaoDisponivel)
                return this.GerarMesTrabalho(ano, mes);
            else
                return null;
        }

        public void SalvarMesTrabalho(int ano, int mes, MesTrabalho mesTrabalho)
        {
            if (ano < DateTime.MinValue.Year || ano > DateTime.MaxValue.Year)
                throw new ArgumentOutOfRangeException(nameof(ano));

            if (mes < 1 || mes > 12)
                throw new ArgumentOutOfRangeException(nameof(mes));

            this.armazenamentoServico.Salvar(this.MontarNomeArquivo(ano, mes), JsonConvert.SerializeObject(mesTrabalho));
        }

        public MesTrabalho GerarMesTrabalho(int ano, int mes)
        {
            return new MesTrabalho
            {
                ValorSodexo = 0,
                CoficienteOffset = 0,
                Dias = Enumerable
                    .Range(1, DateTime.DaysInMonth(ano, mes))
                    .Select(day => new DateTime(ano, mes, day))
                    .Select(s => new DiaTrabalho { Data = s, Almoco = new EntradaSaida(), Empresa = new EntradaSaida() }).ToList()
            };
        }

        private string MontarNomeArquivo(int ano, int mes)
        {
            return $"horarios-{ano}-{mes}";
        }

        public Regex RegexArquivos()
        {
            return RegexMesTrabalho;
        }
    }
}