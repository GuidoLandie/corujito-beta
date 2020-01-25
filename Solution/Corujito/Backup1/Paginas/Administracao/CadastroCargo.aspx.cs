using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("qTela") == "Alterar" && Request.QueryString.Get("qID") != null)
            {
                string IdTabela = Request.QueryString.Get("qID").ToString();
                //ObterDadosPorId(int.Parse(IdTabela));
            }
            else
            {
               // txtIdEscola.Text = "0";
            }
        }
    }
}