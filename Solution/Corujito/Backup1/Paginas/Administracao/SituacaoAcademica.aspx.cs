using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Corujito.Apresentacao.UtilitarioExt;
using Corujito.Negocio;
using System.Data;
using Corujito.Negocio.Escola;
using Corujito.Entidade;
using Corujito.Entidade.Escola;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class SituacaoAcademica : System.Web.UI.Page
    {
        public int IdAluno
        {
            get { return int.Parse(ViewState["IdAluno"].ToString()); }
            set { ViewState["IdAluno"] = value; }
        }

        #region Métodos Privados

        /// <summary>
        /// Método para carregar a grid com os dados da Coleção de CRJPessoa
        /// </summary>
        private void PopularOcorrencia()
        {
            //Atribuindo a Grid a páginação informada pelo usuário
            this.PagingToolbar1.PageSize = int.Parse(cboPageSize.Text);

            //Declarando e Instanciando o Objeto de Negócio e Coleção de Entidades.
            CRJOcorrenciaNegocio objCRJOcorrenciaNegocio = new CRJOcorrenciaNegocio();


            //Atribuindo ao objeto de coleção os registros encontrados na pesquisa.
            DataTable dtOcorrencia = objCRJOcorrenciaNegocio.ObterCRJOcorrenciaByAluno(IdAluno);

            //Verifica se o retorno do método é diferente de Null. SE FOR popula a grid. SE NÃO FOR exibe mensagem de erro.
            if (dtOcorrencia != null && dtOcorrencia.Rows.Count > 0)
            {

                txtRA.Text = dtOcorrencia.Rows[0]["RA"].ToString();
                txtNome.Text = dtOcorrencia.Rows[0]["Nome"].ToString();
                if (dtOcorrencia.Rows[0]["idOcorrencia"] != null)
                {
                    gvOcorrencia.Visible = true;
                    StoreCRJOcorrencia.DataSource = dtOcorrencia;
                    StoreCRJOcorrencia.DataBind();
                }
                else
                {
                    gvOcorrencia.Visible = false;
                }
            }
            

            //Finalizando os objetos
            dtOcorrencia = null;
            objCRJOcorrenciaNegocio = null;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                IdAluno = int.Parse(Request.QueryString["qIDAluno"].ToString());
                PopularOcorrencia();
                PopularNota();
                PopularFrequencia();
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinhaGrid_DirectClick(object sender, DirectEventArgs e)
        {
            //Obter o ID do registro selecionado na Grid.
            string IDTabela;
            IDTabela = e.ExtraParams["IdentificadorRegistroTabela"];

            //Se o click foi no botão Alterar.
            if (e.ExtraParams["IDObjeto"] == "btnAlterar")
            {
                string URL = "CadastroOcorrencia.aspx?qID=" + IDTabela;
                Response.Redirect(URL);
            }

        }

        [DirectMethod(Namespace = "CRJ", ShowMask = true)]
        public void SetarPresenca(int IdNotaAluno, float Nota)
        {
            CRJNotaAlunoNegocio obj = new CRJNotaAlunoNegocio();

            if (Nota < 0) Nota = 0;

            Usuario UserLogin = (Usuario)Session["Usuario"];

            obj.Alterar(IdNotaAluno, Nota, UserLogin.DadosPessoais.IdPessoa);
        }


        private void PopularNota()
        {
            DataTable dt = new CRJNotaAlunoNegocio().ObterCRJNotaAlunoPorAluno(IdAluno);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridNotaAluno.Visible = true;
                StoreNotaAluno.DataSource = dt;
                StoreNotaAluno.DataBind();
            }
            else
            {
                GridNotaAluno.Visible = false;
            }
        }

        private void PopularFrequencia()
        {
            DataTable dt = new CRJFrequenciaNegocio().ObterCRJFrequenciaPorAluno(IdAluno);
            if (dt != null && dt.Rows.Count > 0)
            {
                gvFrequencia.Visible = true;
                StoreFrequencia.DataSource = dt;
                StoreFrequencia.DataBind();
            }
            else
            {
                gvFrequencia.Visible = false;
            }
        }
    }
}