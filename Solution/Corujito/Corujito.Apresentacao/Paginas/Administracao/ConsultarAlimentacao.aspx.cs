using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Corujito.Entidade.Escola;
using Corujito.Negocio.Escola;
using Corujito.Entidade;
using Corujito.Negocio;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class ConsultarAlimentacao : System.Web.UI.Page
    {

        private void PopularCboDependentes()
        {
            Usuario UserLogin = (Usuario)Session["Usuario"];

            List<CRJPessoa> objPessoa = (new CRJPessoaNegocio()).ObterDependentesPorResponsavel(UserLogin.DadosPessoais.IdPessoa);
            
            objPessoa.Add(UserLogin.DadosPessoais);



            if (objPessoa != null && objPessoa.Count > 0)
            {
                StorePessoaDependente.DataSource = objPessoa;
                StorePessoaDependente.DataBind();
            }
            else
            {
                cboPessoaDependente.Text = UserLogin.DadosPessoais.Nome;
                cboPessoaDependente.ReadOnly = true;
                PopularAlimentacao(UserLogin.DadosPessoais.IdAluno);
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
                PopularAlimentacao(int.Parse(cboPessoaDependente.SelectedItem.Value));
            }
        }

        private void PopularAlimentacao(int IdPessoa)
        {

            StoreCRJEscola.DataSource = new CRJVendaProdutoNegocio().ObterAlimentacaoByPessoa(IdPessoa);
            StoreCRJEscola.DataBind();

        }
    }
}