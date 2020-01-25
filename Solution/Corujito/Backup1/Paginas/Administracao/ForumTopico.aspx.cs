using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Entidade;
using Corujito.Negocio;
using Ext.Net;

namespace Corujito.Apresentacao
{
    public partial class ForumTopico: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                if (Request.QueryString["qID"] != null)
                {
                    hdIdClasse.Text = Request.QueryString["qID"].ToString();
                }

                PopularTopico();
            }
        }

        private void PopularTopico()
        {
            StoreCRJForumTopico.DataSource = new CRJForumTopicoNegocio().ObterCRJForumTopicoByClasse(1);
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
            CRJForumTopico objCRJForumTopico= new CRJForumTopico();
            objCRJForumTopico.DataCriacao = DateTime.Now;
            objCRJForumTopico.IdClasse = int.Parse(hdIdClasse.Text);
            objCRJForumTopico.Titulo = txtTitulo.Text;
            objCRJForumTopico.Mensagem = txtMensagem.Text;
            Usuario UserLogin = (Usuario)Session["Usuario"];
            objCRJForumTopico.IdCriador = UserLogin.DadosPessoais.IdPessoa;
            new CRJForumTopicoNegocio().Incluir(objCRJForumTopico);
            txtMensagem.Text = "";
            txtTitulo.Text = "";
            PopularTopico();
        }
    }
}