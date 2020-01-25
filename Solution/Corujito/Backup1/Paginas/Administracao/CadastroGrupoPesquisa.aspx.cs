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

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroGrupoPesquisa : System.Web.UI.Page
    {

        #region DirectMethods
        

        /// <summary>
        /// Clique confirmaçao de exclusao
        /// </summary>
        /// <param name="Id"></param>
        [DirectMethod]
        public void CliqueBotaoSimMensagemExclusao(int Id)
        {
            Excluir(Id);
        }

        #endregion

        #region Metodos privados

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
        /// 
        /// </summary>
        private void PopularGrid()
        {
            List<GrupoPermissao> objGrupoPermissao = new List<GrupoPermissao>();
            GrupoPermissaoNegocio objGrupoPermissaoBO = new GrupoPermissaoNegocio();

            objGrupoPermissao = objGrupoPermissaoBO.ObterGrupoPermissao();

            if (objGrupoPermissao != null)
            {
                StoreCRJEscola.DataSource = objGrupoPermissao;
                StoreCRJEscola.DataBind();
            }

            objGrupoPermissao = null;
            objGrupoPermissaoBO = null;

        }

        private void Excluir(int Id)
        {

            GrupoPermissaoNegocio objGrupoNegocio = new GrupoPermissaoNegocio();

            string ret = objGrupoNegocio.ExcluirGrupo(Id);

            int LinhasAfetadas =0;

            if (int.TryParse(ret, out LinhasAfetadas) == true)
            {
                PopularGrid();
            }
            else
            {
                UtilitariosExt util = new UtilitariosExt();
                util.MensagemAlerta("Atenção","Não é possivel excluir o registro selecionado pois o mesmo esta sendo utilizado.", "");
                util = null;
            }
            
            
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
                PopularGrid();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCadastrarNovo_Click(object sender, DirectEventArgs e)
        {
            string URL = "CadastroGrupo.aspx";
            ExibirModalCadastro("Novo Grupo de Acesso", URL, 360, 780,true, false, Icon.GroupAdd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ModalCadastro_BeforeHide(object sender, DirectEventArgs e)
        {
            Session["Funcionalidade"] = null;
            PopularGrid();        
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinhaGrid_DirectClick(object sender, DirectEventArgs e)
        {
            //Obter o ID do registro selecionado na Grid.
            string IDTabela,NomeGrupo;
            IDTabela = e.ExtraParams["IdentificadorRegistroTabela"];
            NomeGrupo = e.ExtraParams["NomeGrupo"];



            //Se o click foi no botão Alterar.
            if (e.ExtraParams["IDObjeto"] == "btnAlterar")
            {

                string URL = "CadastroGrupo.aspx?qIdGrupo=" + IDTabela + "&qTela=Alterar&qNome=" + NomeGrupo;
                ExibirModalCadastro("Alterar Grupo de Acesso", URL, 360, 780, true, false, Icon.GroupEdit);

            }


            //Se o click foi no botão Alterar.
            if (e.ExtraParams["IDObjeto"] == "btnAddPermissao")
            {
                string URL = "CadastroGrupoPermissoes.aspx?qIdGrupo=" + IDTabela + "&qNome=" + NomeGrupo;;
                ExibirModalCadastro("Permissões do Grupo de Acesso", URL, 400, 780, true, false, Icon.Key);            
            }

            //Se o click foi no botão Alterar.
            if (e.ExtraParams["IDObjeto"] == "btnAddUser")
            {
                string URL = "CadastroGrupoUsuarios.aspx?qIdGrupo=" + IDTabela + "&qNome=" + NomeGrupo; ;
                ExibirModalCadastro("Usuários do Grupo de Acesso", URL, 500, 780, true, false, Icon.User);
            }   


            //Se o click foi no botão Remover.
            if (e.ExtraParams["IDObjeto"] == "btnRemover")
            {
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Excluir o registro?", "CliqueBotaoSimMensagemExclusao(" + int.Parse(IDTabela) + ")", "");
                UtilExt = null;
               
            }

           
        }
    }
}