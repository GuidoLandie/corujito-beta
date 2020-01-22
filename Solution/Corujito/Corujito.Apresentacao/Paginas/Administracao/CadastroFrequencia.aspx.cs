using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Negocio.Escola;
using Corujito.Entidade.Escola;
using Ext.Net;


namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroFrequencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopularProf();

        }

        private void PopularProf()
        {
            CRJPessoaNegocio TipoProfessorBO = new CRJPessoaNegocio();
            List<CRJPessoa> TipoProfessorColecao = new List<CRJPessoa>();

            TipoProfessorColecao = TipoProfessorBO.ObterCRJProfessor();

            StoreProfessor.DataSource = TipoProfessorColecao;
            StoreProfessor.DataBind();
        }

        protected void btnVoltar_Click(object sender, DirectEventArgs e)
        {
            X.Redirect("../Home.aspx", "Cagando...");
        }

        private void PopularEnsino()
        {
            CRJEnsinoNegocio TipoEnsinoBO = new CRJEnsinoNegocio();
            List<CRJEnsino> TipoEnsinoColecao = new List<CRJEnsino>();

            if (!string.IsNullOrEmpty(cboProfessor.SelectedItem.Value))
            {
                int IdProfessor = int.Parse(cboProfessor.SelectedItem.Value);

                TipoEnsinoColecao = TipoEnsinoBO.ObterCRJEnsinoxProfessor(IdProfessor);

                StoreEnsino.DataSource = TipoEnsinoColecao;
                StoreEnsino.DataBind();

            }

        }

        protected void cboProfessor_Select(object sender, DirectEventArgs e)
        {
            PopularEnsino();
        }
    }




}