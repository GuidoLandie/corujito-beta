using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Negocio;
using Corujito.Entidade;
using Corujito.Apresentacao.UtilitarioExt;
using Ext.Net;

namespace Corujito.Apresentacao
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Usuario UserLogin = (Usuario)Session["Usuario"];

                if (UserLogin != null)
                {
                    string Htmlmenu = string.Empty;

                    if (Session["UserMenu"] == null)
                    {
                        AplicacaoBO objAplicacaoBO = new AplicacaoBO();
                        List<Aplicacao> objAplicacao = new List<Aplicacao>();

                        Htmlmenu = objAplicacaoBO.CriarMenuDoUsuario(UserLogin.UserLogin);

                        Session["UserMenu"] = Htmlmenu;
                    }
                    else
                    {
                        Htmlmenu = Session["UserMenu"].ToString();
                    }

                    PopularDadosDoUsuario(UserLogin);

                    menu.InnerHtml = Htmlmenu;
                }
                else
                {
                    Response.Redirect("/Default.aspx?Erro=1");
                }
            }

        }

        /// <summary>
        /// Clique botao Logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["Ususario"] = null;
            Session["UserMenu"] = null;

            Session.RemoveAll();

            Response.Redirect("/Default.aspx");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        private void PopularDadosDoUsuario(Usuario User)
        {
            if (User != null)
            {
                string NomeExibicao = string.Empty;
                if (User.DadosPessoais != null)
                {
                    int i = User.DadosPessoais.Nome.IndexOf(" ");

                    if (i > 0)
                    {
                        NomeExibicao = User.DadosPessoais.Nome.Substring(0, i);
                    }
                    else
                    {
                        NomeExibicao = User.DadosPessoais.Nome;
                    }
                }

                lblUser.Text = "Bem vindo <b><a alt='Visualizar dados' title='Visualizar dados' href='/Paginas/Administracao/CadastroPessoa.aspx?qID=" + User.DadosPessoais.IdPessoa.ToString() + "&qTela=Consultar'>" + NomeExibicao + "</a></b> ";

                if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour <= 12)
                {
                    lblUser.Text += ", tenha um bom dia.";
                }
                else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour <= 18)
                {
                    lblUser.Text += ", tenha uma boa tarde.";
                }
                else if (DateTime.Now.Hour >= 0 || DateTime.Now.Hour > 18)
                {
                    lblUser.Text += ", tenha uma boa noite.";
                }

            }
        }

    }
}
