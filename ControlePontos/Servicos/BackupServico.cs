using ControlePontos.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlePontos.Servicos
{
    internal interface IBackupServico
    {
        bool BackupAgendadoRealizado();

        Resultado<BackupResultado> RealizarBackup();
    }

    internal enum BackupResultado
    {
        Sucesso,
        NenhumDadoEncontrado,
        NenhumDiretorioParaBackup,
        DriveNaoDisponivel,
        Erro
    }

    internal class BackupServico : IBackupServico
    {
        private readonly IArmazenamentoServico armazenamentoServico;
        private readonly IExportacaoServico exportacaoServico;
        private ConfigApp configuracao;

        public BackupServico(IConfiguracaoServico configuracaoServico, IArmazenamentoServico armazenamentoServico, IExportacaoServico exportacaoServico)
        {
            this.armazenamentoServico = armazenamentoServico;
            this.exportacaoServico = exportacaoServico;

            this.configuracao = configuracaoServico.ObterConfiguracao();
            configuracaoServico.ConfiguracaoMudou += novaConfiguracao =>
            {
                this.configuracao = novaConfiguracao;
            };
        }

        public bool BackupAgendadoRealizado()
        {
            foreach (var diretorio in this.configuracao.Backup.Diretorios)
            {
                var json = this.armazenamentoServico.Carregar("backup", diretorio);
                if (json.IsNullOrEmpty())
                    return false;

                var datas = JsonConvert.DeserializeObject<DateTime[]>(json);
                if (!datas.Any(w => w.Date == DateTime.Now.Date))
                    return false;
            }

            return true;
        }

        public Resultado<BackupResultado> RealizarBackup()
        {
            if (!this.configuracao.Backup.Diretorios.Any())
                return Resultado.Aviso(BackupResultado.NenhumDiretorioParaBackup);

            var chave = DateTime.Now.ToString("yyyy.MM.dd hh.mm.ss");

            foreach (var diretorio in this.configuracao.Backup.Diretorios)
            {
                var resultado = this.exportacaoServico.ExportarDados(diretorio, chave + ".zip");

                if (resultado.Tipo != TipoMensagem.Sucesso)
                {
                    if (resultado.Valor == ExportacaoResulado.NenhumDadoEncontrado)
                        return Resultado.Aviso(BackupResultado.NenhumDadoEncontrado);
                    else if (resultado.Valor == ExportacaoResulado.DriveNaoDisponivel)
                        return Resultado.Aviso(BackupResultado.DriveNaoDisponivel, resultado.ValorMensagem);
                    else if (resultado.Tipo == TipoMensagem.Erro)
                        return Resultado.Erro(BackupResultado.Erro, resultado.Excecao, resultado.ValorMensagem);
                }
                else
                    this.MarcarBackupComoFeito(diretorio);
            }

            return Resultado.Sucesso(BackupResultado.Sucesso);
        }

        private void MarcarBackupComoFeito(string diretorio)
        {
            var json = this.armazenamentoServico.Carregar("backup", diretorio);
            if (string.IsNullOrEmpty(json))
                json = "[]";

            var datas = JsonConvert.DeserializeObject<List<DateTime>>(json);
            datas.Add(DateTime.Now);

            this.armazenamentoServico.Salvar("backup", JsonConvert.SerializeObject(datas), diretorio);
        }
    }
}