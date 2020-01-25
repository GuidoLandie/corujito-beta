using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;


using Corujito.Entidade;
using Corujito.Apresentacao.UtilitarioExt;
using Corujito.Entidade.Escola;
using Corujito.Negocio;
using Corujito.Negocio.Escola;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroEscola : System.Web.UI.Page
    {

        #region Direct Metodos

        [DirectMethod]
        public void CliqueBotaoSimMensagemAlteracao()
        {
            Alterar();
        }

        [DirectMethod]
        public void CliqueBotaoSimMensagemInclusaoComSucesso()
        {

        }



        #endregion

        #region Metodos Privados

        /// <summary>
        /// Metodo que busca um registro
        /// </summary>
        /// <param name="pId"></param>
        private void ObterDadosPorId(int pId)
        {

            CRJEscola objEscola = new CRJEscolaNegocio().ObterCRJEscola(pId);

            if (objEscola != null)
            {
                txtRazaoSocial.Text = objEscola.RazaoSocial;
                txtNome.Text = objEscola.Nome;
                txtCNPJ.Text = objEscola.CNPJ;              
                txtCEP.Text = objEscola.CEP;
                txtLogradouro.Text = objEscola.Logradouro;
                txtBairro.Text = objEscola.Bairro;
                txtEstado.SelectedItem.Text = objEscola.Estado;
                PopularCidade(null, null);
                txtCidade.SelectedItem.Text = objEscola.Cidade;
                txtTelefonePrincipal.Text = objEscola.TelefonePrincipal;
                txtTelefoneSecundario.Text = objEscola.TelefoneSecundario;
                txtEmail.Text = objEscola.Email;
                txtDataAbertura.SelectedDate = objEscola.DataAbertura;
                txtMissao.Text = objEscola.Missao;
                txtObservacao.Text = objEscola.Observacao;
            }


        }

        /// <summary>
        /// metodo que altera um registro
        /// </summary>
        private void Alterar()
        {
            CRJEscola objEscola = PopularEntidade();
            CRJEscolaNegocio objEscolaBO = new CRJEscolaNegocio();

            objEscolaBO.Alterar(objEscola);

            UtilitariosExt util = new UtilitariosExt();
            util.MensagemAlerta("Atenção", "Registro salvo com sucesso!", "CliqueBotaoSimMensagemInclusaoComSucesso()");
            util = null;
        }

        private CRJEscola PopularEntidade()
        {
            CRJEscola objEscola = new CRJEscola();

            objEscola.RazaoSocial = txtRazaoSocial.Text;
            objEscola.Nome = txtNome.Text;
            objEscola.CNPJ = txtCNPJ.Text;           
            objEscola.CEP = txtCEP.Text;
            objEscola.Logradouro = txtLogradouro.Text;
            objEscola.Bairro = txtBairro.Text;
            objEscola.Estado = txtEstado.SelectedItem.Text;

            objEscola.Cidade = txtCidade.SelectedItem.Text;
            objEscola.TelefonePrincipal = txtTelefonePrincipal.Text;
            objEscola.TelefoneSecundario = txtTelefoneSecundario.Text;
            objEscola.Email = txtEmail.Text;
            objEscola.DataAbertura = txtDataAbertura.SelectedDate;
            objEscola.Missao = txtMissao.Text;
            objEscola.Observacao = txtObservacao.Text;

            return objEscola;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!X.IsAjaxRequest)
            {
                PopularComboEstado();
                ObterDadosPorId(1);
            }

        }

        public void PopularCidade(object sender, Ext.Net.DirectEventArgs e)
        {

            int idestado = 0;

            if (int.TryParse(txtEstado.SelectedItem.Value, out idestado) == false)
            {
                idestado = 0;
            }


            if (idestado > 0)
            {
                storeCidade.DataSource = (new CidadeNegocio().ObterCidade(idestado));
                storeCidade.DataBind();
                txtCidade.Clear();
            }
        }

        private void PopularComboEstado()
        {
            storeEstado.DataSource = (new EstadoNegocio().ObterEstado());
            storeEstado.DataBind();
        }


        public void txtCNPJ_Change(object sender, Ext.Net.DirectEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCNPJ.Text))
            {
                if (!UtilitarioBO.CNPJValido(txtCNPJ.Text))
                {
                    UtilitariosExt util = new UtilitariosExt();
                    util.MensagemAlerta("Atenção", txtCNPJ.Text + " CNPJ inválido!", "");
                    txtCNPJ.Clear();
                    util = null;
                }
            }
        }

        protected void btnGravar_Click(object sender, Ext.Net.DirectEventArgs e)
        {

            //Armazenar na variável FormularioValido se o Form é válido ou não.
            bool FormularioValido = Convert.ToBoolean(e.ExtraParams["FormularioValido"]);

            if (FormularioValido == true)
            {

                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Alterar o registro?", "CliqueBotaoSimMensagemAlteracao()", "");
                UtilExt = null;


            }

        }

        protected void btnCancelar_Click(object sender, DirectEventArgs e)
        {
            UtilitariosExt UtilExt = new UtilitariosExt();
            UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Cancelar a Alteração?", "CliqueBotaoSimMensagemInclusaoComSucesso()", "");
            UtilExt = null;
        }
    }
}