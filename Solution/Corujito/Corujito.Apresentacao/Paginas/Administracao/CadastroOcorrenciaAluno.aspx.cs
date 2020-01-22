using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Corujito.Apresentacao.UtilitarioExt;
using Corujito.Entidade;
using Corujito.Negocio;
using Corujito.Negocio.Escola;
using Corujito.Entidade.Escola;
using System.Data;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroOcorrenciaAluno : System.Web.UI.Page
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
        private void PopularGrid(int idAluno)
        {
            //Atribuindo a Grid a páginação informada pelo usuário
            this.PagingToolbar1.PageSize = int.Parse(cboPageSize.Text);

            //Declarando e Instanciando o Objeto de Negócio e Coleção de Entidades.
            CRJOcorrenciaNegocio objCRJOcorrenciaNegocio = new CRJOcorrenciaNegocio();
           

            //Atribuindo ao objeto de coleção os registros encontrados na pesquisa.
            DataTable dtOcorrencia = objCRJOcorrenciaNegocio.ObterCRJOcorrenciaByAluno(idAluno);

            //Verifica se o retorno do método é diferente de Null. SE FOR popula a grid. SE NÃO FOR exibe mensagem de erro.
            if (dtOcorrencia != null && dtOcorrencia.Rows.Count > 0)
            {

                txtRA.Text = dtOcorrencia.Rows[0]["RA"].ToString();
                txtNome.Text = dtOcorrencia.Rows[0]["Nome"].ToString();
                if (dtOcorrencia.Rows[0]["idOcorrencia"] != null)
                {
                    StoreCRJOcorrencia.DataSource = dtOcorrencia;
                    StoreCRJOcorrencia.DataBind();
                }
            }
            else
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção","Ocorreu um erro ao tentar obter os dados tente novamente.","");
                UtilExt = null;
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
                PopularGrid(IdAluno);
            }
                 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPesquisar_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            
             
           
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            //Disparar a ação do botão btnPesquisar.
            this.btnPesquisar_DirectClick(null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCadastrarNovo_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            string URL = "CadastroOcorrencia.aspx?qIDAluno="+IdAluno.ToString();
            Response.Redirect(URL);
        }

    }
}