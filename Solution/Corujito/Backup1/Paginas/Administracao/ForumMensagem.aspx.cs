using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Entidade;
using Corujito.Negocio;
using Ext.Net;
using Corujito.Negocio.Escola;
using Corujito.Entidade.Escola;

namespace Corujito.Apresentacao
{
    public partial class ForumMensagem: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!X.IsAjaxRequest)
            {
                if (Request.QueryString["qID"] != null)
                {
                    hdIdTopico.Text = Request.QueryString["qID"].ToString();
                

                CRJForumTopico objCRJForumTopico = new CRJForumTopicoNegocio().ObterCRJForumTopico(int.Parse(hdIdTopico.Text)).First();
                lblTopico.Html = "<b>" + objCRJForumTopico.Titulo + "</b><br/>";
                lblMensagem.Html = objCRJForumTopico.Mensagem + "<br/>";

                CRJPessoa objCRJPessoa = new CRJPessoaNegocio().ObterCRJPessoaPorId(objCRJForumTopico.IdCriador);

                lblDetalhes.Text = objCRJPessoa.Nome + " - " + objCRJForumTopico.DataCriacao.ToString();

                PopularMensagem();
                }
            }
        }

        private void PopularMensagem()
        {
            StoreCRJForumTopico.DataSource = new CRJForumMensagemNegocio().ObterCRJForumMensagemByTopico(int.Parse(hdIdTopico.Text));
            StoreCRJForumTopico.DataBind();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinhaGrid_DirectClick(object sender, DirectEventArgs e)
        {
            //Obter o ID do registro selecionado na Grid.
            string IDTabela;
            IDTabela = e.ExtraParams["IdentificadorRegistroTabela"];

            //Se o click foi no botão Alterar.
            if (e.ExtraParams["IDObjeto"] == "btnVisualizar")
            {
                string URL = "ForumMensagem.aspx?qID=" + IDTabela;
                Response.Redirect(URL);
            }

        }

        protected void btnGravar_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            CRJForumMensagem objCRJForumMensagem = new CRJForumMensagem();
            objCRJForumMensagem.DataCriacao = DateTime.Now;
            objCRJForumMensagem.IdForumTopico = int.Parse(hdIdTopico.Text);
            objCRJForumMensagem.Mensagem = txtMensagem.Text;
            Usuario UserLogin = (Usuario)Session["Usuario"];
            objCRJForumMensagem.IdCriador = UserLogin.DadosPessoais.IdPessoa;
            new CRJForumMensagemNegocio().Incluir(objCRJForumMensagem);
            txtMensagem.Text = "";
            PopularMensagem();
        }
    }
}