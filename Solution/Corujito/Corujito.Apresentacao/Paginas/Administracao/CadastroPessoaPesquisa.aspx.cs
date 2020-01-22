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

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroPessoaPesquisa : System.Web.UI.Page
    {


        #region ExtNet - DirectMethod

        /// <summary>
        /// Método que é disparado ao clicar no botão Sim da Mensagem de Exclusão do Registro.
        /// </summary>
        /// <param name="pID">ID do Registro que será Excluído.</param>
        [DirectMethod]
        public void CliqueBotaoSimMensagemExclusao(int pID)
        {
            Excluir(pID);
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Método para carregar a grid com os dados da Coleção de CRJPessoa
        /// </summary>
        private void PopularGrid(string pNome = null, string pEmail = null, string pCPF = null, string pTelefone = null, string pRA = null)
        {
            //Atribuindo a Grid a páginação informada pelo usuário
            this.PagingToolbar1.PageSize = int.Parse(cboPageSize.Text);

            //Declarando e Instanciando o Objeto de Negócio e Coleção de Entidades.
            CRJPessoaNegocio objCRJPessoaNegocio = new CRJPessoaNegocio();
            List<CRJPessoa> objCRJPessoaColecao = new List<CRJPessoa>();

            //Atribuindo ao objeto de coleção os registros encontrados na pesquisa.
            objCRJPessoaColecao = objCRJPessoaNegocio.ObterCRJPessoa(pNome, pEmail, pCPF, pTelefone, pRA);

            //Verifica se o retorno do método é diferente de Null. SE FOR popula a grid. SE NÃO FOR exibe mensagem de erro.
            if (objCRJPessoaColecao != null)
            {
                StoreCRJPessoa.DataSource = objCRJPessoaColecao;
                StoreCRJPessoa.DataBind();
            }
            else
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", "Ocorreu um erro ao tentar obter os dados tente novamente.", "");
                UtilExt = null;
            }

            //Finalizando os objetos
            objCRJPessoaColecao = null;
            objCRJPessoaNegocio = null;
        }

        /// <summary>
        /// Excluir um objeto no Banco.
        /// </summary>
        /// <param name="pID">ID do Registro a ser excluído.</param>
        private void Excluir(int pID)
        {
            //Declarando e Instânciando a classe de Negócio para Persistir o objeto objCRJPessoa.
            CRJPessoaNegocio objCRJPessoaNegocio = new CRJPessoaNegocio();

            //Executando método para Excluir na Base de Dados o objeto objCRJPessoa e armazenando o resultado obtido na variável Resultado.
            string Retorno = objCRJPessoaNegocio.Excluir(pID);

            //Se o Retorno do método Excluir for um valor númerico maior que 0, então significa Sucesso.
            int LinhasAfetadas = 0;

            if (int.TryParse(Retorno, out LinhasAfetadas) == false)
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", Retorno, "");
                UtilExt = null;
            }
            else if (LinhasAfetadas <= 0)
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", "Nenhum registro afetado.", "btnGravar");
                UtilExt = null;
            }
            else if (LinhasAfetadas >= 1)
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", "Registro excluido com sucesso", "");
                UtilExt = null;

                this.btnPesquisar_DirectClick(null, null);
            }

            //Finalizando a classe de Negócio.
            objCRJPessoaNegocio = null;

        }

        /// <summary>
        /// Desabilita os Botões caso o usuário não tenha permissão de acesso no SIP.
        /// </summary>
        private void DesabilitarBotoes()
        {

        }

        /// <summary>
        /// Método para Exibir a Tela de Cadastro de em Modal.
        /// </summary>
        /// <param name="pTitulo">Titulo da Janela Modal.</param>
        /// <param name="pURL">URL que a Modal irá chamar.</param>
        /// <param name="pAltura">Altura da Janela.</param>
        /// <param name="pLargura">Largura da Janela.</param>
        /// <param name="pModal">Indica se a janela será modal ou não. Podendo ser True para ser Modal, e False para Não ser Modal.</param>
        /// <param name="pResizable">Indica ser a janela poderá ser redimensionada. Podendo ser True para ser, e False para não ser redimensionada.</param>
        /// <param name="pIcon">Ícone da aplicação.</param>
        private void ExibirModalCadastro(string pTitulo, string pURL, int pAltura, int pLargura, bool pModal, bool pResizable, Icon pIcon)
        {
            this.ModalCadastro.Title = pTitulo;
            this.ModalCadastro.Icon = pIcon;
            this.ModalCadastro.AutoLoad.Url = pURL;
            this.ModalCadastro.AutoLoad.Mode = LoadMode.IFrame;
            this.ModalCadastro.Height = pAltura;
            this.ModalCadastro.Width = pLargura;
            this.ModalCadastro.Modal = pModal;
            this.ModalCadastro.Resizable = pResizable;
            this.ModalCadastro.Draggable = false;

            ModalCadastro.Render(this.Form, RenderMode.RenderTo);
            this.ModalCadastro.Show();
        }


        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            //Se estiver carregando a página pela primeira vez e o usuário possui permissão na Aplicação.
            if (!X.IsAjaxRequest)
            {
                DesabilitarBotoes();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPesquisar_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {

            PopularGrid(txtNome.Text.Trim(), txtEmail.Text.Trim(), txtCPF.Text.Trim(), txtTelefone.Text.Trim(), txtRA.Text.Trim());

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCadastrarNovo_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            string URL = "CadastroPessoa.aspx?qTela=Incluir";
            Response.Redirect(URL);
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



            //Se o click foi no botão Consultar.
            if (e.ExtraParams["IDObjeto"] == "btnVisualizar")
            {

                string URL = "CadastroPessoa.aspx?qTela=Consultar&qID=" + IDTabela;
                Response.Redirect(URL);

            }

            //Se o click foi no botão Alterar.
            if (e.ExtraParams["IDObjeto"] == "btnAlterar")
            {
                string URL = "CadastroPessoa.aspx?qTela=Alterar&qID=" + IDTabela;
                Response.Redirect(URL);
            }

            //Se o click foi no botão Alterar.
            if (e.ExtraParams["IDObjeto"] == "btnCartao")
            {

                string URL = "CadastroCartao.aspx?qID=" + IDTabela;
                URL += "&qTela=Alterar";
                ExibirModalCadastro("Cartão", URL, 450, 700, true, false, Icon.Money);
            }



            //Se o click foi no botão Remover.
            if (e.ExtraParams["IDObjeto"] == "btnRemover")
            {
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Excluir o registro?", "CliqueBotaoSimMensagemExclusao(" + int.Parse(IDTabela) + ")", "");
                UtilExt = null;
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