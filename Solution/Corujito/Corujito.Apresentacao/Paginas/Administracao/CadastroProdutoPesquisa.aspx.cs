using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Corujito.Entidade;
using Corujito.Negocio;
using Corujito.Apresentacao.UtilitarioExt;
using System.Configuration;
using Corujito.Entidade.Escola;
using Corujito.Negocio.Escola;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroProdutoPesquisa : System.Web.UI.Page
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
        /// Método para carregar a grid com os dados da Coleção de CRJProduto
        /// </summary>
        private void PopularGrid()
        {
            string Nome = txtNomePesquisa.Text;

            int? IdTipoProduto = null;

            if (!string.IsNullOrEmpty(cboTipoProduto.SelectedItem.Value))
                IdTipoProduto = int.Parse(cboTipoProduto.SelectedItem.Value);

            int? IdStatus = null;

            if (!string.IsNullOrEmpty(cboIdStatus.SelectedItem.Value))
                IdStatus = int.Parse(cboIdStatus.SelectedItem.Value);



            //Atribuindo a Grid a páginação informada pelo usuário

            //Declarando e Instanciando o Objeto de Negócio e Coleção de Entidades.
            CRJProdutoNegocio objCRJProdutoNegocio = new CRJProdutoNegocio();
            List<CRJProduto> objCRJProdutoColecao = new List<CRJProduto>();

            //Atribuindo ao objeto de coleção os registros encontrados na pesquisa.
            objCRJProdutoColecao = objCRJProdutoNegocio.ObterCRJProduto(Nome, IdTipoProduto, IdStatus);

            //Verifica se o retorno do método é diferente de Null. SE FOR popula a grid. SE NÃO FOR exibe mensagem de erro.
            if (objCRJProdutoColecao != null)
            {
                StoreCRJProduto.DataSource = objCRJProdutoColecao;
                StoreCRJProduto.DataBind();
            }
            else
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.ERROR, MessageBox.Button.OK, ConfigurationManager.AppSettings["MensagemSemDados"], "btnPesquisar");
                UtilExt = null;
            }

            //Finalizando os objetos
            objCRJProdutoColecao = null;
            objCRJProdutoNegocio = null;
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


        /// <summary>
        /// Excluir um objeto no Banco.
        /// </summary>
        /// <param name="pID">ID do Registro a ser excluído.</param>
        private void Excluir(int pID)
        {
            //Declarando e Instânciando a classe de Negócio para Persistir o objeto objCRJProduto.
            CRJProdutoNegocio objCRJProdutoNegocio = new CRJProdutoNegocio();

            //Executando método para Excluir na Base de Dados o objeto objCRJProduto e armazenando o resultado obtido na variável Resultado.
            string Retorno = objCRJProdutoNegocio.Excluir(pID);


            //Se o Retorno do método Excluir for um valor númerico maior que 0, então significa Sucesso.
            int LinhasAfetadas = 0;


            if (int.TryParse(Retorno, out LinhasAfetadas) == false)
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();

                //Erro de FK
                if (Retorno.IndexOf("DELETE statement conflicted with COLUMN REFERENCE constraint") >= 0)
                {
                    UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.ERROR, MessageBox.Button.OK, ConfigurationManager.AppSettings["MensagemErroFK"], "btnGravar");
                }
                else //Erro padrão
                {
                    UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.ERROR, MessageBox.Button.OK, ConfigurationManager.AppSettings["MensagemErroPadrao"], "btnGravar");
                }

                UtilExt = null;
            }
            else if (LinhasAfetadas <= 0)
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.WARNING, MessageBox.Button.OK, ConfigurationManager.AppSettings["MensagemNenhumRegistroAfetado"], "btnGravar");
                UtilExt = null;
            }
            else if (LinhasAfetadas >= 1)
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.INFO, MessageBox.Button.OK, ConfigurationManager.AppSettings["MensagemSucessoExcluido"], "btnGravar");
                UtilExt = null;
                this.btnPesquisar_DirectClick(null, null);
            }

            //Finalizando a classe Utilitarios.


            //Finalizando a classe de Negócio.
            objCRJProdutoNegocio = null;

        }


        /// <summary>
        /// Desabilita os Botões caso o usuário não tenha permissão de acesso no SIP.
        /// </summary>
        private void DesabilitarBotoes()
        {


        }


        #endregion

        //Evento Load da página.
        protected void Page_Load(object sender, EventArgs e)
        {



            //Se estiver carregando a página pela primeira vez e o usuário possui permissão na Aplicação.
            if (!X.IsAjaxRequest)
            {
                popularTipoProduto();
                popularIdStatus();


                //Desabilitar os botões que o usuário não possui permissão no SIP.
                DesabilitarBotoes();

                //Popular a Grid com todos os registros da tabela.
                //PopularGrid();
            }

        }

        //Botão Pesquisar.
        protected void btnPesquisar_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {

            PopularGrid();


        }

        //Botão CadastrarNovo.
        protected void btnCadastrarNovo_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {

            //Chama a página de Cadastro de CRJProduto.
            string URLModal = "CadastroProduto.aspx?qTela=Incluir";


            //TODO: Informe no parâmetro Altura e Largura no método ExibirModalCadastro, os valores compativeis com a tela de cadastro. O tamanho máximo para a Intranet é: 520, 760
            ExibirModalCadastro("Incluir", URLModal, 550, 720, true, true, Icon.Add);

        }

        //Direct Click - Clique nos botões da Grid.
        protected void LinhaGrid_DirectClick(object sender, DirectEventArgs e)
        {
            //Obter o ID do registro selecionado na Grid.
            string IDTabela;
            IDTabela = e.ExtraParams["IdentificadorRegistroTabela"];


            //Se o click foi no botão Consultar.
            if (e.ExtraParams["IDObjeto"] == "btnVisualizar")
            {
                string URLModal = "CadastroProduto.aspx?qID=" + IDTabela + "&qTela=Consultar";
                //TODO: Informe no parâmetro Altura e Largura no método ExibirModalCadastro, os valores compativeis com a tela de cadastro. O tamanho máximo para a Intranet é: 520, 760
                ExibirModalCadastro("Consultar Cadastro", URLModal, 545, 715, true, true, Icon.Magnifier);

            }

            //Se o click foi no botão Alterar.
            if (e.ExtraParams["IDObjeto"] == "btnAlterar")
            {
                string URLModal = "CadastroProduto.aspx?qID=" + IDTabela + "&qTela=Alterar";
                //TODO: Informe no parâmetro Altura e Largura no método ExibirModalCadastro, os valores compativeis com a tela de cadastro. O tamanho máximo para a Intranet é: 520, 760
                ExibirModalCadastro("Alterar Cadastro", URLModal, 545, 715, true, true, Icon.PageWhiteEdit);

            }

            //Se o click foi no botão Remover.
            if (e.ExtraParams["IDObjeto"] == "btnRemover")
            {
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Excluir o registro?", "CliqueBotaoSimMensagemExclusao(" + int.Parse(IDTabela) + ")", "");
                UtilExt = null;
            }


        }

        //MyData_Refresh - Botão de Refresh da Grid.
        protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            //Disparar a ação do botão btnPesquisar.
            this.btnPesquisar_DirectClick(null, null);
        }

        protected void popularTipoProduto()
        {

            CRJTipoProdutoNegocio TipoProdutoBO = new CRJTipoProdutoNegocio();
            List<CRJTipoProduto> TipoProdutoColecao = new List<CRJTipoProduto>();

            TipoProdutoColecao = TipoProdutoBO.ObterCRJTipoProduto();

            StoreTipoProduto.DataSource = TipoProdutoColecao;
            StoreTipoProduto.DataBind();

        }
        protected void popularIdStatus()
        {

            CRJStatusNegocio StatusBO = new CRJStatusNegocio();
            List<CRJStatus> StatusColecao = new List<CRJStatus>();

            StatusColecao = StatusBO.ObterCRJStatus();

            StoreStatus.DataSource = StatusColecao;
            StoreStatus.DataBind();

        }

    }
}