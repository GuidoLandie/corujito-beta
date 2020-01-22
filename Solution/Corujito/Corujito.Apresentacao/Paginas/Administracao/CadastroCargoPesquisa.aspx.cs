using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroCargoPesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCadastrarCargo_DirectClick(object sender, DirectEventArgs e)
        {
            Response.Redirect("CadastroCargo.aspx");
        }
        protected void btnPesquisarCargo_DirectClicar(object sender, DirectEventArgs e)
        {  
        }

    }
}