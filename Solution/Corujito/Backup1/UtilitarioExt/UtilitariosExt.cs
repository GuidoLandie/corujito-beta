using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Net;
using System.Web.UI;

namespace Corujito.Apresentacao.UtilitarioExt
{
    public class UtilitariosExt
    {
        /// <summary>
        /// MensagemAlerta - Método que encapsula as MessageBox do Ext para Mensagens que possui somente o Botão OK.
        /// Recomenda-se o uso deste método para mensagens em que o clique no botão execute uma função no server.
        /// </summary>
        /// <param name="pTitulo">Titulo da Mensagem.</param>
        /// <param name="pTextoMensagem">Texto da Mensagem.</param>
        /// <param name="pNomeFuncaoBotaoSim">Nome da função no server que será disparado ao clicar no Botão SIM. Importante ressaltar que a função deverá ter a diretiva [DirectMethod].</param>
        /// <param name="pNomeFuncaoBotaoNao">Nome da função no server que será disparado ao clicar no Botão NÃO. Importante ressaltar que a função deverá ter a diretiva [DirectMethod].</param>
        /// <param name="pNomeFuncaoBotaoCancelar">Nome da função no server que será disparado ao clicar no Botão CANCELAR. Importante ressaltar que a função deverá ter a diretiva [DirectMethod].</param>
        public void MensagemAlerta(string pTitulo, string pTextoMensagem, string pNomeFuncaoBotaoSim, string pNomeFuncaoBotaoNao, string pNomeFuncaoBotaoCancelar)
        {
            //Configurar individualmente os Botões das mensagens usando o ButtonsConfig.
            X.Msg.Confirm(pTitulo, pTextoMensagem, new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = (pNomeFuncaoBotaoSim.Trim() == "" ? "" : "Ext.net.DirectMethods." + pNomeFuncaoBotaoSim),
                    Text = "Sim"
                },

                No = new MessageBoxButtonConfig
                {
                    Handler = (pNomeFuncaoBotaoNao.Trim() == "" ? "" : "Ext.net.DirectMethods." + pNomeFuncaoBotaoNao),
                    Text = "Não"
                },

                Cancel = new MessageBoxButtonConfig
                {
                    Handler = (pNomeFuncaoBotaoCancelar.Trim() == "" ? "" : "Ext.net.DirectMethods." + pNomeFuncaoBotaoCancelar),
                    Text = "Cancelar"
                }

            }).Show();

        }



        /// <summary>
        /// MensagemAlerta - Método que encapsula as MessageBox do Ext para Mensagens que possui somente o Botão OK.
        /// Recomenda-se o uso deste método para mensagens em que o clique no botão execute uma função no server.
        /// </summary>
        /// <param name="pTitulo">Titulo da Mensagem.</param>
        /// <param name="pTextoMensagem">Texto da Mensagem.</param>
        /// <param name="pNomeFuncaoBotaoSim">Nome da função no server que será disparado ao clicar no Botão SIM. Importante ressaltar que a função deverá ter a diretiva [DirectMethod].</param>
        /// <param name="pNomeFuncaoBotaoNao">Nome da função no server que será disparado ao clicar no Botão NÃO. Importante ressaltar que a função deverá ter a diretiva [DirectMethod].</param>
        public void MensagemAlerta(string pTitulo, string pTextoMensagem, string pNomeFuncaoBotaoSim, string pNomeFuncaoBotaoNao)
        {
            //Configurar individualmente os Botões das mensagens usando o ButtonsConfig.
            X.Msg.Confirm(pTitulo, pTextoMensagem, new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = (pNomeFuncaoBotaoSim.Trim() == "" ? "" : "Ext.net.DirectMethods." + pNomeFuncaoBotaoSim),
                    Text = "Sim"
                },

                No = new MessageBoxButtonConfig
                {
                    Handler = (pNomeFuncaoBotaoNao.Trim() == "" ? "" : "Ext.net.DirectMethods." + pNomeFuncaoBotaoNao),
                    Text = "Não"
                }
            }).Show();

        }



        /// <summary>
        /// MensagemAlerta - Método que encapsula as MessageBox do Ext para Mensagens que possui somente o Botão OK.
        /// Recomenda-se o uso deste método para mensagens em que o clique no botão execute uma função no server.
        /// </summary>
        /// <param name="pTitulo">Titulo da Mensagem.</param>
        /// <param name="pTextoMensagem">Texto da Mensagem</param>
        /// <param name="pNomeFuncaoBotaoOK">Nome da função no server que será disparado ao clicar no Botão OK. Importante ressaltar que a função deverá ter a diretiva [DirectMethod].</param>
        public void MensagemAlerta(string pTitulo, string pTextoMensagem, string pNomeFuncaoBotaoOK)
        {
            //Configurar individualmente os Botões das mensagens usando o ButtonsConfig.
            /*
            X.Msg.Alert(pTitulo, pTextoMensagem,  new MessageBoxButtonsConfig
            {
                Ok = new MessageBoxButtonConfig
                {
                    Handler = (pNomeFuncaoBotaoOK.Trim() == "" ? "" : "Ext.net.DirectMethods." + pNomeFuncaoBotaoOK),
                    Text = "OK"
                }
            }).Show();
            */
            X.MessageBox.Show(new MessageBoxConfig
            {
                Title = pTitulo,
                Closable = false,
                Icon = MessageBox.Icon.INFO,
                Message = pTextoMensagem,
                Handler = (pNomeFuncaoBotaoOK.Trim() == "" ? "" : "Ext.net.DirectMethods." + pNomeFuncaoBotaoOK),
                Buttons = MessageBox.Button.OK
            });
        }



        /// <summary>
        /// MensagemAlerta - Método que encapsula as MessageBox do Ext. 
        /// Recomenda-se o uso deste método somente para mensagens em que o clique dos botões não execute nenhuma ação, ou que a ação disparada seja uma função JavaScript.
        /// </summary>
        /// <param name="pTitulo">Titulo da Mensagem.</param>
        /// <param name="pIcone">Ícone que será exibido na Mensagem.</param>
        /// <param name="pBotao">Botões que serão exibidos na Mensagem.</param>
        /// <param name="pTextoMensagem">Texto da Mensagem</param>
        /// <param name="pIDObjetoChamador">ID do objeto que chamou a Messagem (usado para animações).</param>
        public void MensagemAlerta(string pTitulo, MessageBox.Icon pIcone, MessageBox.Button pBotao, string pTextoMensagem, string pIDObjetoChamador)
        {
            X.MessageBox.Show(new MessageBoxConfig
            {
                Title = pTitulo,
                Closable = false,
                Icon = pIcone,
                Buttons = pBotao,
                Message = pTextoMensagem,
                AnimEl = pIDObjetoChamador
            });
        }



        /// <summary>
        /// MensagemAlerta - Método que encapsula as MessageBox do Ext. 
        /// Recomenda-se o uso deste método somente para mensagens em que o clique dos botões não execute nenhuma ação, ou que a ação disparada seja uma função JavaScript.
        /// </summary>
        /// <param name="pTitulo">Titulo da Mensagem.</param>
        /// <param name="pIcone">Ícone que será exibido na Mensagem.</param>
        /// <param name="pTextoMensagem">Texto da Mensagem</param>
        /// <param name="pIDObjetoChamador">ID do objeto que chamou a Messagem (usado para animações).</param>
        /// <param name="pCodigoJavaScript">Código JavaScript que será executado.</param>
        public void MensagemAlerta(string pTitulo, MessageBox.Icon pIcone, string pTextoMensagem, string pIDObjetoChamador, string pCodigoJavaScript)
        {
            X.MessageBox.Show(new MessageBoxConfig
            {
                Title = pTitulo,
                Closable = false,
                Icon = pIcone,
                Buttons = MessageBox.Button.OK,
                Message = pTextoMensagem,
                AnimEl = pIDObjetoChamador,
                Fn = new JFunction(pCodigoJavaScript)

            });
        }


        #region Desabilitar Controles

        /// <summary>
        /// Desabilita os Controles do Objeto (INUTILIZADO)
        /// Utilizar o DesabilitarControlesObjeto(Object pObject, bool recursivo = false)
        /// </summary>
        /// <param name="pPanel">Objeto Panel (Ext) do Formulário Web.</param>
        public void DesabilitarControlesDoPanel(Panel pPanel)
        {
            DesabilitarControles(pPanel, false);
        }

        /// <summary>
        /// Desabilita os Controles do Objeto
        /// </summary>
        /// <param name="pObject">Objeto (Ext) do Formulário Web</param>
        /// <param name="pRecursivo">Se irá percorrer todos os controles dos objetos passados (Form, Panel, TabPanel,etc)</param>
        public void DesabilitarControles(Object pObject, bool pRecursivo = false)
        {
            //Objeto = Panel
            if (pObject is Ext.Net.Panel)
            {
                if (pRecursivo)
                    DesabilitarControlCollection(((Ext.Net.Panel)pObject).Controls);
                else
                    DesabilitarControl(((Ext.Net.Panel)pObject).Controls[0]);
            }
            //Objeto = Container
            else if (pObject is Ext.Net.Container)
            {
                if (pRecursivo)
                    DesabilitarControlCollection(((Ext.Net.Container)pObject).Controls);
                else
                    DesabilitarControl(((Ext.Net.Container)pObject).Controls[0]);
            }
            //Objeto = FormPanel
            else if (pObject is Ext.Net.FormPanel)
            {
                if (pRecursivo)
                    DesabilitarControlCollection(((Ext.Net.FormPanel)pObject).Controls);
                else
                    DesabilitarControl(((Ext.Net.FormPanel)pObject).Controls[0]);
            }
        }

        /// <summary>
        /// Desabilita todos os controles da collection passada como parâmetro (recursivo, todos os níveis de cotnrole)
        /// </summary>
        /// <param name="pControles">Coleção de controle</param>
        public void DesabilitarControlCollection(ControlCollection pControles)
        {
            //ConfigItem para acionar a função para travar checkbox e radiobox
            ConfigItem ci = new ConfigItem();
            ci.Name = "onClick";
            ci.Value = "function (e) {if ((this.el.dom.checked != this.checked) && !this.readOnly) { this.setValue(this.el.dom.checked); } e.stopEvent(); }";
            ci.Mode = ParameterMode.Raw;


            //Desabilita controles
            for (int k = 0; k < pControles.Count; k++)
            {
                foreach (System.Web.UI.Control ctl in pControles[k].Controls)
                {
                    /*if (ctl.Controls.Count == 0)
                    {*/
                    if (ctl.Parent is Ext.Net.FormPanel || ctl.Parent is Ext.Net.TabPanel || ctl.Parent is Ext.Net.Panel || ctl.Parent is Ext.Net.Container || ctl.Parent is Ext.Net.FormLayout)
                    {
                        DesabilitarControlCollection(ctl.Parent.Controls);
                    }

                    DesabilitarControleTipo(ci, ctl.Parent);
                    /*}
                    else
                    {
                        if (ctl is Ext.Net.FormPanel || ctl is Ext.Net.TabPanel || ctl is Ext.Net.Panel || ctl is Ext.Net.Container || ctl is Ext.Net.FormLayout)
                        {
                            DesabilitarControles(ctl.Controls);
                        }

                        DesabilitarControleTipo(ci, ctl);
                    }*/
                }
            }
        }

        /// <summary>
        /// Desabilita o controle do objeto passado como parâmetro  (primeiro nível de controles)
        /// </summary>
        /// <param name="pControle">Controle do Objeto</param>
        private void DesabilitarControl(Control pControle)
        {
            //ConfigItem para acionar a função para travar checkbox e radiobox
            ConfigItem ci = new ConfigItem();
            ci.Name = "onClick";
            ci.Value = "function (e) {if ((this.el.dom.checked != this.checked) && !this.readOnly) { this.setValue(this.el.dom.checked); } e.stopEvent(); }";
            ci.Mode = ParameterMode.Raw;


            //Desabilita controles
            foreach (System.Web.UI.Control ctl in pControle.Controls)
            {
                DesabilitarControleTipo(ci, ctl);
            }
        }

        /// <summary>
        /// Desabilita de acordo com o tipo do controle passado
        /// </summary>
        /// <param name="ci">ConfigItem para radiobutton e checkbox</param>
        /// <param name="ctl">Controle do objeto</param>
        private static void DesabilitarControleTipo(ConfigItem ci, System.Web.UI.Control ctl)
        {
            if (ctl is Ext.Net.FileUploadField)
            {
                ((Ext.Net.FileUploadField)ctl).ReadOnly = true;
            }
            if (ctl is Ext.Net.DateField)
            {
                ((Ext.Net.DateField)ctl).ReadOnly = true;
            }
            if (ctl is Ext.Net.TimeField)
            {
                ((Ext.Net.TimeField)ctl).ReadOnly = true;
            }
            if (ctl is Ext.Net.TextField)
            {
                ((Ext.Net.TextField)ctl).ReadOnly = true;
            }
            if (ctl is Ext.Net.NumberField)
            {
                ((Ext.Net.NumberField)ctl).ReadOnly = true;
            }
            if (ctl is Ext.Net.TextArea)
            {
                ((Ext.Net.TextArea)ctl).ReadOnly = true;
            }
            if (ctl is Ext.Net.ComboBox)
            {
                ((Ext.Net.ComboBox)ctl).ReadOnly = true;
            }
            if (ctl is Ext.Net.MultiCombo)
            {
                ((Ext.Net.MultiCombo)ctl).ReadOnly = true;
            }
            if (ctl is Ext.Net.CheckboxGroup)
            {
                for (int i = 0; i < ((Ext.Net.CheckboxGroup)ctl).Items.Count; i++)
                {
                    ((Ext.Net.CheckboxGroup)ctl).Items[i].CustomConfig.Add(ci);
                }
            }
            if (ctl is Ext.Net.Checkbox)
            {
                ((Ext.Net.Checkbox)ctl).CustomConfig.Add(ci);
            }
            if (ctl is Ext.Net.RadioGroup)
            {
                for (int i = 0; i < ((Ext.Net.RadioGroup)ctl).Items.Count; i++)
                {
                    ((Ext.Net.RadioGroup)ctl).Items[i].CustomConfig.Add(ci);
                }
            }
            if (ctl is Ext.Net.Radio)
            {
                ((Ext.Net.Radio)ctl).CustomConfig.Add(ci);
            }
        }

        #endregion
    }
}