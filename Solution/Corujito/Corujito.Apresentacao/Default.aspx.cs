using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Corujito.Negocio;
using Corujito.Entidade;
using Corujito.Apresentacao.UtilitarioExt;
 


namespace Corujito.Apresentacao
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("Erro") != null)
            { 
                int Erro = int.Parse(Request.QueryString.Get("Erro").ToString());
                string ErroMsg = string.Empty;

                if (Erro == 1)
                {
                    ErroMsg = "Ocorreu um erro ao tentar carregar a pagina tente novamente.";  
                }

                if (!string.IsNullOrEmpty(ErroMsg))
                {
                    UtilitariosExt Util = new UtilitariosExt();
                    Util.MensagemAlerta("Atenção", ErroMsg, "");
                    Util = null;
                }
            }
        }       
       
        /// <summary>
        /// Validar Usuario
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Password"></param>
        private void ValidarUsuario(string User, string Password)
        {
            //Response.Redirect("Paginas/Home.aspx");

            UsuarioNegocio objUsuarioNegocio = new UsuarioNegocio();
            Usuario objUsuario = objUsuarioNegocio.EfetuarLoginUsuario(User, Password);

            if (objUsuario != null)
            {              
                Session["Usuario"] = objUsuario;

                Response.Redirect("Paginas/Home.aspx");
            }
            else
            {
                UtilitariosExt Util = new UtilitariosExt();
                Util.MensagemAlerta("Atenção", "Usuário e senha invalido, tente novamente", "");
                Util = null;
            }

        }

        protected void btnLogin_Click(object sender, DirectEventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtPassword.Text) && string.IsNullOrEmpty(txtUsername.Text)))
            {                
                ValidarUsuario(txtUsername.Text, txtPassword.Text);                
            }
        }
    }
}