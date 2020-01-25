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
using Corujito.Apresentacao.UtilitarioExt;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class PesquisaAtividade : System.Web.UI.Page
    {

        [DirectMethod(Namespace = "CompanyX")]
        public void AfterEdit(int IdAtividade, string NomeAtividade, string TipoAtividade, string Descricao, string Datainicial, string DataFinal)
        {

            CRJAtividade objAtividade = new CRJAtividade();
            CRJAtividadeBO objAtividadeBO = new CRJAtividadeBO();
            Usuario UserLogin = (Usuario)Session["Usuario"];

            objAtividade.IdAtividade = IdAtividade;
            objAtividade.IdProfXMatxEns = int.Parse(Request.QueryString.Get("IdProf"));
            objAtividade.NomeAtividade = NomeAtividade;
            objAtividade.Descricao = Descricao;
            objAtividade.TipoAtividade = (new CRJTipoAtividadeBO().ObterCRJTipoAtividade(TipoAtividade));
            objAtividade.Datainicial = Convert.ToDateTime(Datainicial.Replace("\"", ""));
            objAtividade.DataFinal = Convert.ToDateTime(DataFinal.Replace("\"", ""));

            objAtividadeBO.Alterar(objAtividade, UserLogin.DadosPessoais.IdPessoa);

            PopularGrid();

        }

        [DirectMethod(Namespace = "CompanyX")]
        public void btnExcluir(int IdAtividade)
        {
            UtilitariosExt util = new UtilitariosExt();
            util.MensagemAlerta("Atenção", "Você tem certeza que deseja excluir o registro", "ExcluirAtividade(" + IdAtividade + ")", "");
            util = null;

        }

        [DirectMethod]
        public void ExcluirAtividade(int IdAtividade)
        {
            Usuario UserLogin = (Usuario)Session["Usuario"];

            CRJAtividadeBO objAtividadeBO = new CRJAtividadeBO();
            objAtividadeBO.Excluir(IdAtividade, UserLogin.DadosPessoais.IdPessoa);
            PopularGrid();
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!X.IsAjaxRequest)
            {
                Usuario UserLogin = (Usuario)Session["Usuario"];

                //  lblprofessor.Html = " <h1>" + UserLogin.DadosPessoais.Nome + "</h1>";

                string titulo = Request.QueryString.Get("TitulodaPagina");

                GridPesquisaAtividade.Title = titulo;

                PopularGrid();
                Popular_cboTipoatividade();
            }

        }

        private void PopularGrid()
        {
            int IdClasse = Request.QueryString.Get("IdClasse") != null ? int.Parse(Request.QueryString.Get("IdClasse")) : 0;

            List<CRJAtividade> listMaterias = new List<CRJAtividade>();
            CRJAtividadeBO objMateriaBO = new CRJAtividadeBO();

            listMaterias = objMateriaBO.ObterCRJAtividadePorId(IdClasse);


            StoreCRJEscola.DataSource = listMaterias;
            StoreCRJEscola.DataBind();




        }

        private void Popular_cboTipoatividade()
        {
            CRJTipoAtividadeBO objTipoAtividadeBO = new CRJTipoAtividadeBO();
            List<CRJTipoAtividade> ListaTipoAtividade = new List<CRJTipoAtividade>();

            ListaTipoAtividade = objTipoAtividadeBO.ObterCRJTipoAtividade();
            StoreTipoAtividade.DataSource = ListaTipoAtividade;
            StoreTipoAtividade.DataBind();

        }

    }
}