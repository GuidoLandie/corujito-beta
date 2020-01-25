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
    public partial class LancamentoCartao : System.Web.UI.Page
    {


        #region Métodos Privados

        /// <summary>
        /// Método para carregar a grid com os dados da Coleção de CRJPessoa
        /// </summary>
        private void PopularGrid(int idCartao)
        {
            //Atribuindo a Grid a páginação informada pelo usuário
            this.PagingToolbar1.PageSize = int.Parse(cboPageSize.Text);

            //Declarando e Instanciando o Objeto de Negócio e Coleção de Entidades.
            CRJLancamentoCartaoNegocio objCRJLancamentoCartaoNegocio = new CRJLancamentoCartaoNegocio();


            //Atribuindo ao objeto de coleção os registros encontrados na pesquisa.
            DataTable dtLancamentoCartao = objCRJLancamentoCartaoNegocio.ObterCRJLancamentoCartao2(idCartao);

            //Verifica se o retorno do método é diferente de Null. SE FOR popula a grid. SE NÃO FOR exibe mensagem de erro.
            if (dtLancamentoCartao != null)
            {
                StoreCRJProduto.DataSource = dtLancamentoCartao;
                StoreCRJProduto.DataBind();

                CalcularSaldo(dtLancamentoCartao);
            }
            else
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", "Ocorreu um erro ao tentar obter os dados tente novamente.", "");
                UtilExt = null;
            }

            //Finalizando os objetos
            dtLancamentoCartao = null;
            objCRJLancamentoCartaoNegocio = null;
        }

        private void CalcularSaldo(DataTable dtLancamentoCartao)
        {

            float valor = 0;

            foreach (DataRow row in dtLancamentoCartao.Rows)
            {
                if (!string.IsNullOrEmpty(row["Valor"].ToString()))
                    valor += float.Parse(row["Valor"].ToString());
            }

            lblSaldo.Text = string.Format("{0:c2}", valor);

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

                //Verifica se existe um valor na QueryString vinda da página de pesquisa.
                //Se existir, então escreve no campo que é a Chave Primária da tabela.
                if (Request.QueryString.Get("qID") != null)
                {
                    txtNumeroCartao.Text = Request.QueryString.Get("qID");
                    PopularGrid(int.Parse(Request.QueryString.Get("qID")));

                    if (!string.IsNullOrEmpty(Request.QueryString.Get("qTela")))
                    {
                        if (Request.QueryString.Get("qTela") == "Consultar")
                        {
                            btnAdicionarCredito.Hidden = true;
                            txtDescricao.Hidden = true;
                            txtValor.Hidden = true;
                        }
                    }

                }
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
                string URL = "CadastroLancamentoCartao.aspx?qID=" + IDTabela;
                Response.Redirect(URL);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPesquisar_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            if (txtValor.Text != string.Empty && txtDescricao.Text != string.Empty)
            {
                Usuario UserLogin = (Usuario)Session["Usuario"];

                CRJLancamentoCartao objCRJLancamentoCartao = new CRJLancamentoCartao();
                objCRJLancamentoCartao.IdCartao = int.Parse(txtNumeroCartao.Text);
                objCRJLancamentoCartao.Valor = double.Parse(txtValor.Text);
                objCRJLancamentoCartao.DataLancamento = DateTime.Now;
                objCRJLancamentoCartao.IdLancador = UserLogin.DadosPessoais.IdPessoa;
                objCRJLancamentoCartao.Descricao = txtDescricao.Text;

                new CRJLancamentoCartaoNegocio().Incluir(objCRJLancamentoCartao);

                Response.Redirect("LancamentoCartao.aspx?qID=" + txtNumeroCartao.Text);

            }
            else
            {
                UtilitariosExt util = new UtilitariosExt();
                util.MensagemAlerta("Atenção", "Os campos Valor e Descrição são obrigatórios.", "");
                util = null;
            }

        }
    }

}