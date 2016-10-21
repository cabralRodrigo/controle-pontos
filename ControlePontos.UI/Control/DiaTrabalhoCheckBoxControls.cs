using ControlePontos.Dominio.Model;
using ControlePontos.Dominio.Model.Configuracao;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ControlePontos.Control
{
    internal class CheckBoxCell : DataGridViewCheckBoxCell, IDiaTrabalhoCell
    {
        public void AddedCell(ConfiguracaoApp appConfig, DiaTrabalho dia)
        {
            this.UpdateCell(appConfig, dia);
        }

        public void UpdateCell(ConfiguracaoApp appConfig, DiaTrabalho dia)
        {
            var config = this.Configuracao() ?? new DiaTrabalhoColumnConfiguracao();

            var cor = appConfig.Cores.DiaNormal;
            var @readonly = false;
            
            if (dia.Falta)
                cor = appConfig.Cores.Falta;
            else if (!appConfig.DiasTrabalho.Contains(dia.Data.DayOfWeek))
            {
                cor = appConfig.Cores.NaoTrabalho;
                @readonly = true;
            }
            else if (appConfig.Feriados.Feriados.Contains(dia.Data.Date))
            {
                cor = appConfig.Cores.Feriado;
                @readonly = true;
            }
            else if (appConfig.Ferias.Contains(dia.Data.Date))
            {
                cor = appConfig.Cores.Ferias;
                @readonly = true;
            }
            else if (DateTime.Now.Date == dia.Data.Date)
                cor = appConfig.Cores.Hoje;

            this.Style.BackColor = cor;
            this.SetReadonly(@readonly);
        }

        private void SetReadonly(bool @readonly)
        {
            if (@readonly)
            {
                this.FlatStyle = FlatStyle.Flat;
                this.Style.ForeColor = Color.DarkGray;
                this.ReadOnly = true;
            }
            else
            {
                this.FlatStyle = FlatStyle.Standard;
                this.Style.ForeColor = Color.Black;
                this.ReadOnly = false;
            }
        }

        private DiaTrabalhoColumnConfiguracao Configuracao()
        {
            var coluna = this.OwningColumn as CheckBoxColumn;
            if (coluna == null)
                throw new Exception("OwningColumn invalid!");

            return coluna == null ? null : coluna.Configuracao;
        }
    }

    internal class CheckBoxColumn : DataGridViewCheckBoxColumn
    {
        public DiaTrabalhoColumnConfiguracao Configuracao { get; set; }

        public CheckBoxColumn(string nome, string cabecalho, DiaTrabalhoColumnConfiguracao config = null)
        {
            this.Name = nome;
            this.HeaderText = cabecalho;
            this.Configuracao = config;
            this.CellTemplate = new CheckBoxCell();

            if (config != null)
                this.ValueType = config.Tipo;
        }
    }
}