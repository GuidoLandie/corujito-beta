using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Corujito.Negocio.Escola;
using Corujito.Entidade;
using Corujito.Entidade.Escola;
using System.Data;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class ConsultarAtividades : System.Web.UI.Page
    {

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
                PopularAtividade(UserLogin.DadosPessoais.IdAluno);
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PopularCboDependentes();
        }

        protected void cboPessoaDependente_Select(object sender, DirectEventArgs e)
        {
            if (!string.IsNullOrEmpty(cboPessoaDependente.SelectedItem.Value))
            {
                PopularAtividade(int.Parse(cboPessoaDependente.SelectedItem.Value));
            }
        }

        private void PopularAtividade(int IdAluno)
        {
            List<CRJAtividade> listMaterias = new List<CRJAtividade>();
            CRJAtividadeBO objMateriaBO = new CRJAtividadeBO();

            listMaterias = objMateriaBO.ObterCRJAtividadePorAluno(IdAluno);


            StoreCRJEscola.DataSource = listMaterias;
            StoreCRJEscola.DataBind();

        }
    }
}