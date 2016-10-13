using ControlePontos.Extensions;
using ControlePontos.Model;
using ControlePontos.Report.Reports.Template.Html;
using ControlePontos.Report.Reports.Template.Html.Section;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;

namespace ControlePontos.Report.Reports
{
    internal class TabelaMesRelatorio : IReport
    {
        private static readonly string Javascript = @"
            window.addEventListener('load', function load() {
            window.removeEventListener('load', load, false);

            function Marcar(tr, show) {
                if (show) {
                    var estilo = 'success';

                    for (var j = 0; j < tr.cells.length; j++)
                        if (tr.cells[j].innerText === '') {
                            estilo = 'danger';
                            break;
                        }

                    tr.classList.add(estilo);
                }
                else {
                    tr.classList.remove('danger');
                    tr.classList.remove('success');
                }
            }

            var ups = [87/*W*/, 38/*Up Arrow*/, 33/*Page Up*/];
            var downs = [83/*S*/, 40/*Down Arrow*/, 34/*Page Down*/]
            var tabela = document.getElementById('tabela-horarios');
            var index = 1;

            Marcar(tabela.rows[index], true);

            window.addEventListener('keydown', function (e) {
                var change = false;
                if (downs.indexOf(e.keyCode) >= 0) {
                    index++;
                    change = true;

                    if (index >= tabela.rows.length)
                        index = 1;

                    e.preventDefault();
                }
                else if (ups.indexOf(e.keyCode) >= 0) {
                    index--;
                    change = true;

                    if (index < 1)
                        index = tabela.rows.length - 1;

                    e.preventDefault();
                }

                if (change)
                    for (var i = 0; i < tabela.rows.length; i++)
                        Marcar(tabela.rows[i], index == i);
            });
        }, false);
        ";

        public virtual string Name
        {
            get
            {
                return "Tabela de impressão dos horários do mês";
            }
        }

        public virtual IReportExecutionResult Execute(ConfigApp config, int ano, int mes, MesTrabalho mesTrabalho)
        {
            var file = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".html");

            using (var writer = new StreamWriter(File.Open(file, FileMode.CreateNew), Encoding.UTF8))
            {
                var template = new HtmlTemplate($"Relatório mensal: {new CultureInfo("pt-br").DateTimeFormat.GetMonthName(mes).ToTitleCase()} de {ano}");
                template.AddSection(new TableHtmlSection("Horários do Mês", "table-1", this.GenerateDataTable(mesTrabalho), "tabela-horarios"));
                template.AddSection(new JavascriptHtmlSection("Horários do Mês Javascript", Javascript, new Dictionary<string, string> { { "tabela_id", "tabela-horarios" } }));

                writer.Write(template.TransformText());
            }

            return new OpenFileReportExecutionResult(file);
        }

        private DataTable GenerateDataTable(MesTrabalho mesTrabalho)
        {
            var dt = new DataTable();

            dt.Columns.Add("Dia");
            dt.Columns.Add("Entrada");
            dt.Columns.Add("Intervalo - Entrada");
            dt.Columns.Add("Intervalo - Saída");
            dt.Columns.Add("Saída");

            foreach (var dia in mesTrabalho.Dias)
                dt.Rows.Add
                (
                    dia.Data.ToString("dd/MM/yyyy"),
                    !dia.Empresa.Entrada.HasValue ? string.Empty : dia.Empresa.Entrada.Value.ToString(@"hh\:mm"),
                    !dia.Almoco.Entrada.HasValue ? string.Empty : dia.Almoco.Entrada.Value.ToString(@"hh\:mm"),
                    !dia.Almoco.Saida.HasValue ? string.Empty : dia.Almoco.Saida.Value.ToString(@"hh\:mm"),
                    !dia.Empresa.Saida.HasValue ? string.Empty : dia.Empresa.Saida.Value.ToString(@"hh\:mm")
                );

            return dt;
        }
    }
}