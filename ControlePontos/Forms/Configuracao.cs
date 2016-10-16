using ControlePontos.Extensions;
using ControlePontos.Misc;
using ControlePontos.Model;
using ControlePontos.Model.Configuracao;
using ControlePontos.Servicos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ControlePontos.Forms
{
    internal partial class Configuracao : BaseForm
    {
        #region Partes

        private interface IConfiguracaoParte
        {
            void Carregar(Configuracao form, ConfiguracaoApp config);
            Resultado Salvar(Configuracao form, ConfiguracaoApp config);
        }

        private class ConfiguracaoBackup : IConfiguracaoParte
        {
            public void Carregar(Configuracao form, ConfiguracaoApp config)
            {
                form.Backup_ListBoxDiretorios.Items.AddRange(config.Backup.Diretorios.ToArray());

                form.Backup_ButtonAdd.Click += (sender, e) => this.ButtonAdd_Click(form);
                form.Backup_ButtonRemove.Click += (sender, e) => this.ButtonRemove_Click(form);
            }

            public Resultado Salvar(Configuracao form, ConfiguracaoApp config)
            {
                config.Backup = new Model.Configuracao.ConfiguracaoBackup(form.Backup_ListBoxDiretorios.Items.Cast<string>().ToArray());

                return Resultado.Sucesso();
            }

            private void ButtonAdd_Click(Configuracao form)
            {
                using (var folderDiaglog = new FolderBrowserDialog())
                {
                    if (folderDiaglog.ShowDialog() == DialogResult.OK)
                        form.Backup_ListBoxDiretorios.Items.Add(folderDiaglog.SelectedPath);
                }
            }

            private void ButtonRemove_Click(Configuracao form)
            {
                var index = form.Backup_ListBoxDiretorios.SelectedIndex;
                if (index > -1)
                {
                    form.Backup_ListBoxDiretorios.Items.RemoveAt(index--);
                    if (index > -1)
                        form.Backup_ListBoxDiretorios.SelectedIndex = index;
                }
            }
        }

        private abstract class ConfiguracaoFeriadoFerias : IConfiguracaoParte
        {
            protected void Carregar(ListBox lista, MonthCalendar calendario, DateTime[] datas)
            {
                foreach (var data in datas.OrderBy(w => w))
                {
                    calendario.AddBoldedDate(data);
                    lista.Items.Add(data);
                }
                lista.SortBy<DateTime, DateTime>(w => w);
                calendario.UpdateBoldedDates();
            }

            protected void ButtonAdd_Click(ListBox lista, MonthCalendar calendario)
            {
                var novas = calendario.SelectionRange.AllInRange().ToList();
                var antigas = lista.Items.Cast<DateTime>().ToList();

                var datas = novas.Where(w => !antigas.Contains(w));

                foreach (var data in datas)
                {
                    lista.Items.Add(data);
                    calendario.AddBoldedDate(data);
                }

                if (datas.Any())
                {
                    calendario.UpdateBoldedDates();
                    lista.SortBy<DateTime, DateTime>(w => w);

                    if (datas.Count() == 1)
                        lista.SelectedIndex = lista.Items.IndexOf(datas.Single());
                }
            }

            protected void ButtonRemove_Click(ListBox lista, MonthCalendar calendario)
            {
                var index = lista.SelectedIndex;
                if (index > -1)
                {
                    var data = (DateTime)lista.SelectedItem;

                    lista.Items.RemoveAt(index--);
                    if (index > -1)
                        lista.SelectedIndex = index;
                    else if (lista.Items.Count > 0)
                        lista.SelectedIndex = 0;

                    calendario.RemoveBoldedDate(data);
                    calendario.UpdateBoldedDates();
                }
            }

            protected void Lista_SelectedIndexChanged(ListBox lista, MonthCalendar calendario)
            {
                var index = lista.SelectedIndex;
                if (index > -1)
                {
                    var data = (DateTime)lista.SelectedItem;
                    calendario.SelectionStart = data;
                    calendario.SelectionEnd = data;
                }
            }

            protected void Calendario_DateSelected(ListBox lista, MonthCalendar calendario)
            {
                var datas = calendario.SelectionRange.AllInRange();
                if (datas.Count() == 1)
                {
                    var data = datas.Single();
                    if (lista.Items.Cast<DateTime>().Contains(data))
                        lista.SelectedItem = data;
                }
            }

            public abstract void Carregar(Configuracao form, ConfiguracaoApp config);

            public abstract Resultado Salvar(Configuracao form, ConfiguracaoApp config);
        }

        private class ConfiguracaoFeriado : ConfiguracaoFeriadoFerias
        {
            public override void Carregar(Configuracao form, ConfiguracaoApp config)
            {
                base.Carregar(form.Feriados_ListBoxFeriados, form.Feriados_Calendar, config.Feriados.Feriados.ToArray());

                form.Feriados_ButtonAdd.Click += (sender, e) => base.ButtonAdd_Click(form.Feriados_ListBoxFeriados, form.Feriados_Calendar);
                form.Feriados_ButtonRemove.Click += (sende, e) => base.ButtonRemove_Click(form.Feriados_ListBoxFeriados, form.Feriados_Calendar);
                form.Feriados_ListBoxFeriados.SelectedIndexChanged += (sender, e) => base.Lista_SelectedIndexChanged(form.Feriados_ListBoxFeriados, form.Feriados_Calendar);
                form.Feriados_Calendar.DateSelected += (sender, e) => base.Calendario_DateSelected(form.Feriados_ListBoxFeriados, form.Feriados_Calendar);
            }

            public override Resultado Salvar(Configuracao form, ConfiguracaoApp config)
            {
                config.Feriados = new ConfiguracaoFeriados(form.Feriados_ListBoxFeriados.Items.Cast<DateTime>().ToArray());

                return Resultado.Sucesso();
            }
        }

        private class ConfiguracaoFerias : ConfiguracaoFeriadoFerias
        {
            public override void Carregar(Configuracao form, ConfiguracaoApp config)
            {
                base.Carregar(form.Ferias_ListBoxFerias, form.Ferias_Calendar, config.Ferias.ToArray());

                form.Ferias_ButtonAdd.Click += (sender, e) => base.ButtonAdd_Click(form.Ferias_ListBoxFerias, form.Ferias_Calendar);
                form.Ferias_ButtonRemove.Click += (sende, e) => base.ButtonRemove_Click(form.Ferias_ListBoxFerias, form.Ferias_Calendar);
                form.Ferias_ListBoxFerias.SelectedIndexChanged += (sender, e) => base.Lista_SelectedIndexChanged(form.Ferias_ListBoxFerias, form.Ferias_Calendar);
                form.Ferias_Calendar.DateSelected += (sender, e) => base.Calendario_DateSelected(form.Ferias_ListBoxFerias, form.Ferias_Calendar);
            }

            public override Resultado Salvar(Configuracao form, ConfiguracaoApp config)
            {
                config.Ferias = form.Ferias_ListBoxFerias.Items.Cast<DateTime>().ToArray();

                return Resultado.Sucesso();
            }
        }

        private class ConfiguracaoGeral : IConfiguracaoParte
        {
            public void Carregar(Configuracao form, ConfiguracaoApp config)
            {
                var ptbr = CultureInfo.GetCultureInfo("pt-br");
                var dias = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().Select(w => new
                {
                    Item = w,
                    Valor = ptbr.DateTimeFormat.GetDayName(w).ToTitleCase()
                });

                foreach (var diaSemana in dias.OrderBy(w => w.Item))
                    form.Geral_DiasTrabalho_ListaCheckbox.Items.Add(new CheckboxListItem<DayOfWeek>(diaSemana.Item, diaSemana.Valor), config.DiasTrabalho.Contains(diaSemana.Item));

                form.Geral_Horario_Inicio.ValidatingType = form.Geral_Horario_Final.ValidatingType = typeof(TimeSpan);
                form.Geral_Horario_Inicio.Text = config.HoraInicio.ToString(@"hh\:mm");
                form.Geral_Horario_Final.Text = config.HoraFim.ToString(@"hh\:mm");
            }

            public Resultado Salvar(Configuracao form, ConfiguracaoApp config)
            {
                var diasTrabalho = form.Geral_DiasTrabalho_ListaCheckbox.CheckedItems.OfType<CheckboxListItem<DayOfWeek>>().ToArray();
                config.DiasTrabalho = diasTrabalho.Select(w => w.Value).ToArray();

                var inicioObj = form.Geral_Horario_Inicio.ValidateText();
                var fimObj = form.Geral_Horario_Final.ValidateText();

                if (inicioObj == null || fimObj == null)
                    return Resultado.Erro(mensagem: "Horário de trabalho inválido.");

                var inicio = (TimeSpan)inicioObj;
                var fim = (TimeSpan)fimObj;

                if (inicio < new TimeSpan(0, 0, 0))
                    return Resultado.Erro(mensagem: "Horário de inicio de trabalho inválido.");

                if (fim > new TimeSpan(23, 59, 59))
                    return Resultado.Erro(mensagem: "Horário de fim de trabalho inválido");

                if (fim <= inicio)
                    return Resultado.Erro(mensagem: "Fim do horário de trabalho deve ser maior ao horário de inicio.");

                config.HoraInicio = inicio;
                config.HoraFim = fim;

                return Resultado.Sucesso();
            }
        }

        private class ConfiguracaoCores : IConfiguracaoParte
        {
            public void Carregar(Configuracao form, ConfiguracaoApp config)
            {
                form.Cores_Image_DiaTrabalho.BackColor = config.Cores.DiaNormal;
                form.Cores_Image_Ferias.BackColor = config.Cores.Ferias;
                form.Cores_Image_NaoTrabalho.BackColor = config.Cores.NaoTrabalho;
                form.Cores_Image_Feriado.BackColor = config.Cores.Feriado;
                form.Cores_Image_Falta.BackColor = config.Cores.Falta;
                form.Cores_Image_Hoje.BackColor = config.Cores.Hoje;

                form.Cores_Image_DiaTrabalho.Click += (sender, e) => this.Cores_Image_Click(sender as PictureBox);
                form.Cores_Image_Ferias.Click += (sender, e) => this.Cores_Image_Click(sender as PictureBox);
                form.Cores_Image_NaoTrabalho.Click += (sender, e) => this.Cores_Image_Click(sender as PictureBox);
                form.Cores_Image_Feriado.Click += (sender, e) => this.Cores_Image_Click(sender as PictureBox);
                form.Cores_Image_Falta.Click += (sender, e) => this.Cores_Image_Click(sender as PictureBox);
                form.Cores_Image_Hoje.Click += (sender, e) => this.Cores_Image_Click(sender as PictureBox);
            }

            public Resultado Salvar(Configuracao form, ConfiguracaoApp config)
            {
                bool algumaCorTransparente = false;
                Func<Color, Color> processarCor = cor =>
                {
                    var verificacao = this.Cores_RemoverAlpha(cor);
                    if (verificacao.Key)
                        algumaCorTransparente = true;

                    return verificacao.Value;
                };

                config.Cores.DiaNormal = processarCor(form.Cores_Image_DiaTrabalho.BackColor);
                config.Cores.Ferias = processarCor(form.Cores_Image_Ferias.BackColor);
                config.Cores.NaoTrabalho = processarCor(form.Cores_Image_NaoTrabalho.BackColor);
                config.Cores.Feriado = processarCor(form.Cores_Image_Feriado.BackColor);
                config.Cores.Falta = processarCor(form.Cores_Image_Falta.BackColor);
                config.Cores.Hoje = processarCor(form.Cores_Image_Hoje.BackColor);

                if (algumaCorTransparente)
                    return Resultado.Aviso("Alguma cor foi selecionada com transparência. Isso não é suportado.\nA transparência da cor foi removida.");
                else
                    return Resultado.Sucesso();
            }

            private void Cores_Image_Click(PictureBox box)
            {
                if (box != null)
                {
                    using (var dialog = new ColorDialog { Color = box.BackColor })
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                            box.BackColor = dialog.Color;
                    }
                }
            }

            private KeyValuePair<bool, Color> Cores_RemoverAlpha(Color cor)
            {
                if (cor.A == 255)
                    return new KeyValuePair<bool, Color>(false, cor);
                else
                    return new KeyValuePair<bool, Color>(true, Color.FromArgb(cor.R, cor.G, cor.B));
            }
        }

        private class ConfiguracaoIntegracoes : IConfiguracaoParte
        {
            public void Carregar(Configuracao form, ConfiguracaoApp config)
            {
                form.Integracoes_TeamService_TextBox.Text = config.TeamService.Endereco?.AbsoluteUri;
                form.Integracoes_Sodexo_NumeroCartao_TextBox.Text = config.Sodexo?.NumeroCartao;
                form.Integracoes_Sodexo_Cpf_TextBox.Text = config.Sodexo?.NumeroCpf;
            }

            public Resultado Salvar(Configuracao form, ConfiguracaoApp config)
            {
                if (!form.Integracoes_TeamService_TextBox.Text.IsNullOrEmpty())
                {
                    Uri enderecoTeamService;
                    if (!Uri.TryCreate(form.Integracoes_TeamService_TextBox.Text, UriKind.Absolute, out enderecoTeamService))
                        return Resultado.Erro(mensagem: "Endereço do TFS/Team Service não é válido.");
                    config.TeamService.Endereco = enderecoTeamService;
                }
                else
                    config.TeamService.Endereco = null;

                form.Integracoes_Sodexo_NumeroCartao_TextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                config.Sodexo.NumeroCartao = form.Integracoes_Sodexo_NumeroCartao_TextBox.Text;
                form.Integracoes_Sodexo_NumeroCartao_TextBox.TextMaskFormat = MaskFormat.IncludeLiterals;

                form.Integracoes_Sodexo_Cpf_TextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                config.Sodexo.NumeroCpf = form.Integracoes_Sodexo_Cpf_TextBox.Text;
                form.Integracoes_Sodexo_Cpf_TextBox.TextMaskFormat = MaskFormat.IncludeLiterals;

                return Resultado.Sucesso();
            }
        }

        #endregion

        private readonly IConfiguracaoServico configuracaoServico;
        private readonly List<IConfiguracaoParte> partes;

        public Configuracao(IConfiguracaoServico configuracaoServico)
        {
            this.InitializeComponent();

            this.configuracaoServico = configuracaoServico;
            this.partes = new List<IConfiguracaoParte>();
        }

        private void Configuracao_Load(object sender, EventArgs e)
        {
            var config = this.configuracaoServico.ObterConfiguracao();

            this.partes.AddRange(new IConfiguracaoParte[] {
                new ConfiguracaoBackup(),
                new ConfiguracaoFeriado(),
                new ConfiguracaoFerias(),
                new ConfiguracaoGeral(),
                new ConfiguracaoCores(),
                new ConfiguracaoIntegracoes()
            });

            foreach (var parte in this.partes)
                parte.Carregar(this, config);
        }

        private void ButtonSalvar_Click(object sender, EventArgs e)
        {
            var config = new ConfiguracaoApp();

            foreach (var parte in this.partes)
            {
                var resultado = parte.Salvar(this, config);
                if (resultado.Tipo != TipoMensagem.Sucesso)
                {
                    resultado.ToMessageBox("Configurações");
                    if (resultado.Tipo == TipoMensagem.Erro)
                        return;
                }
            }

            this.configuracaoServico.SalvarConfiguracao(config);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                this.ButtonSalvar_Click(this, EventArgs.Empty);

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}