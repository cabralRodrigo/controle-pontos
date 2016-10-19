using ControlePontos.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;

namespace ControlePontos.Servicos
{
    internal interface IExportar
    {
        Regex RegexArquivos();
    }

    internal interface IExportacaoServico
    {
        Resultado<ExportacaoResulado> ExportarDados(string diretorio, string nomeArquivo);
    }

    internal enum ExportacaoResulado
    {
        Sucesso,
        NenhumDadoEncontrado,
        DriveNaoDisponivel,
        Erro
    }

    internal class ExportacaoServico : IExportacaoServico
    {
        private readonly IArmazenamentoServico armazenamentoServico;
        private readonly IEnumerable<IExportar> candidatos;

        public ExportacaoServico(IArmazenamentoServico armazenamentoServico, IEnumerable<IExportar> candidatos)
        {
            this.armazenamentoServico = armazenamentoServico;
            this.candidatos = candidatos;
        }

        public Resultado<ExportacaoResulado> ExportarDados(string diretorio, string nomeArquivo)
        {
            try
            {
                if (!this.candidatos.Any())
                    return Resultado.Aviso(ExportacaoResulado.NenhumDadoEncontrado);

                var arquivosExportacao = this.ArquivosParaExportacao();
                if (!arquivosExportacao.Any())
                    return Resultado.Aviso(ExportacaoResulado.NenhumDadoEncontrado);

                var drive = new DriveInfo(new DirectoryInfo(diretorio).Root.Name);
                if (!drive.IsReady)
                    return Resultado.Aviso(ExportacaoResulado.DriveNaoDisponivel, drive.Name);

                if (!Directory.Exists(diretorio))
                    Directory.CreateDirectory(diretorio);

                var arquivo = Path.Combine(diretorio, nomeArquivo);
                if (File.Exists(arquivo))
                    File.Delete(arquivo);

                using (var zip = ZipFile.Open(arquivo, ZipArchiveMode.Create))
                    foreach (var arquivoExportacao in arquivosExportacao)
                        zip.CreateEntryFromFile(arquivoExportacao, new FileInfo(arquivoExportacao).Name, CompressionLevel.Optimal);

                return Resultado.Sucesso(ExportacaoResulado.Sucesso);
            }
            catch (Exception ex)
            {
                return Resultado.Erro(ExportacaoResulado.Erro, ex);
            }
        }

        private IEnumerable<string> ArquivosParaExportacao()
        {
            foreach (var candidato in this.candidatos)
            {
                var arquivos = this.armazenamentoServico.BuscarArquivos(candidato.RegexArquivos());
                foreach (var arquivoCandidato in arquivos)
                    yield return arquivoCandidato;
            }
        }
    }
}