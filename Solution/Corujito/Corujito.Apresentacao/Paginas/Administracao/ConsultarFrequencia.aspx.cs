using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Corujito.Negocio.Escola;
using Ext.Net;
using Corujito.Entidade.Escola;
using Corujito.Entidade;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class ConsultarFrequencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                PopularCboDependentes();
            }
        }

        protected void cboPessoaDependente_Select(object sender, DirectEventArgs e)
        {
            if (!string.IsNullOrEmpty(cboPessoaDependente.SelectedItem.Value))
            {
                PopularFrequencia(int.Parse(cboPessoaDependente.SelectedItem.Value));
            }
        }

        private void PopularCboDependentes()
        {
            Usuario UserLogin = (Usuario)Session["Usuario"];

            List<CRJPessoa> objPessoa = (new CRJPessoaNegocio()).ObterDependentesPorResponsavel(UserLogin.DadosPessoais.IdPessoa);

            if (objPessoa != null && objPessoa.Count > 0)
            {
                StorePessoaDependente.DataSource = objPessoa;
                StorePessoaDependente.DataBind();
            }
            else
            {
                cboPessoaDependente.Text = UserLogin.DadosPessoais.Nome;
                cboPessoaDependente.ReadOnly = true;
                PopularFrequencia(UserLogin.DadosPessoais.IdAluno);
            }

        }

        private void PopularFrequencia(int IdAluno)
        {
            DataTable dt = new CRJFrequenciaNegocio().ObterCRJFrequenciaPorAluno(IdAluno);
            if (dt != null && dt.Rows.Count > 0)
            {

                StoreFrequencia.DataSource = dt;
                StoreFrequencia.DataBind();
            }

        }
    }
}