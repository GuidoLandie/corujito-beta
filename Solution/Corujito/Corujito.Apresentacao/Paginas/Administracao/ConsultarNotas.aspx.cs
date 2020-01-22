using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Corujito.Negocio.Escola;
using Corujito.Entidade;
using Ext.Net;
using Corujito.Entidade.Escola;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class ConsultarNotas : System.Web.UI.Page
    {

       


        private void PopularNota(int IdAluno)
        {
            DataTable dt = new CRJNotaAlunoNegocio().ObterCRJNotaAlunoPorAluno(IdAluno);
            if (dt != null && dt.Rows.Count > 0)
            {
                StoreNotaAluno.DataSource = dt;
                StoreNotaAluno.DataBind();
            }
        }

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
                PopularNota(int.Parse(cboPessoaDependente.SelectedItem.Value));
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
                PopularNota(UserLogin.DadosPessoais.IdAluno);
            }

        }

    }
}