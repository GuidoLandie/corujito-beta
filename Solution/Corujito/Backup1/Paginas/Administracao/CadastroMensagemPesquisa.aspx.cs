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
    public partial class CadastroMensagemPesquisa : System.Web.UI.Page
    {


        #region Métodos Privados

        /// <summary>
        /// Método para carregar a grid com os dados da Coleção de CRJPessoa
        /// </summary>
        private void PopularGrid(string pNome = null, string pEmail = null, string pCPF = null,string pTelefone=null, string pRA = null)
        {
            //Atribuindo a Grid a páginação informada pelo usuário
            this.PagingToolbar1.PageSize = int.Parse(cboPageSize.Text);

            //Declarando e Instanciando o Objeto de Negócio e Coleção de Entidades.
            CRJMensagemNegocio objCRJMensagemNegocio = new CRJMensagemNegocio();
           

            //Atribuindo ao objeto de coleção os registros encontrados na pesquisa.
            DataTable dtMensagem = objCRJMensagemNegocio.ObterCRJMensagem(pNome, pEmail, pCPF, pTelefone, pRA);

            //Verifica se o retorno do método é diferente de Null. SE FOR popula a grid. SE NÃO FOR exibe mensagem de erro.
            if (dtMensagem != null)
            {
                StoreCRJMensagem.DataSource = dtMensagem;
                StoreCRJMensagem.DataBind();
            }
            else
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção","Ocorreu um erro ao tentar obter os dados tente novamente.","");
                UtilExt = null;
            }

            //Finalizando os objetos
            dtMensagem = null;
            objCRJMensagemNegocio = null;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

                 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPesquisar_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            
             PopularGrid( txtNome.Text.Trim(), txtEmail.Text.Trim(), txtCPF.Text.Trim(), txtTelefone.Text.Trim(), txtRA.Text.Trim());
           
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
                string URL = "CadastroMensagem.aspx?qID=" + IDTabela;
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
    }
}