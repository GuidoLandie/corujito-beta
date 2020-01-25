using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Corujito.Negocio;
using Corujito.Entidade;
using Corujito.Entidade.Escola;
using Corujito.Negocio.Escola;
using Corujito.Apresentacao.UtilitarioExt;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroGrupoUsuarios : System.Web.UI.Page
    {

        [DirectMethod]
        public void CliqueBotaoSimMensagemExclusao(int IdGrupo, string Usuario)
        {
            GrupoPermissaoNegocio objNegocio = new GrupoPermissaoNegocio();
            string retorno = objNegocio.ExcluirUsuarioGrupo(IdGrupo, Usuario);

            int LinhasAfetadas = 0;

            if (int.TryParse(retorno, out LinhasAfetadas) == true)
            {
                PopularGridUsuarios(IdGrupo);
            }
            else
            {
                UtilitariosExt util = new UtilitariosExt();
                util.MensagemAlerta("Atenção", retorno, "");
                util = null;
            }
        }        
        
        /// <summary>
        /// m
        /// </summary>
        private void PopularUsuariosDisponiveis()
        {
            CRJPessoaNegocio pessoa = new CRJPessoaNegocio();


            StoreUsuarios.DataSource = pessoa.ObterCRJPessoa();
            StoreUsuarios.DataBind();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdGrupo"></param>
        private void PopularGridUsuarios(int IdGrupo)
        {
            UsuarioNegocio objNegocio = new UsuarioNegocio();

            StoreCRJPessoa.DataSource = objNegocio.ObterUsuarioFromGrupo(IdGrupo);
            StoreCRJPessoa.DataBind();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                PopularUsuariosDisponiveis();

                PopularGridUsuarios(int.Parse(Request.QueryString.Get("qIdGrupo").ToString()));

                FormPanelCadastro.Title = Request.QueryString.Get("qNome").ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddUsuario_Click(object sender, DirectEventArgs e)
        {
            if (!string.IsNullOrEmpty(cboUsers.SelectedItem.Value))
            {
                int IdGrupo = int.Parse(Request.QueryString.Get("qIdGrupo").ToString());
                string Usuario = cboUsers.SelectedItem.Value;

                GrupoPermissaoNegocio objBO = new GrupoPermissaoNegocio();
                string ret = objBO.IncluirNovoUsuarioGrupo(IdGrupo, Usuario);

                int LinhasAfetadas = 0;

                if (int.TryParse(ret, out LinhasAfetadas) == true)
                {
                    PopularGridUsuarios(IdGrupo);

                    cboUsers.Clear();
                }
                else
                {
                    UtilitariosExt Util = new UtilitariosExt();
                    Util.MensagemAlerta("Atenção", ret, "");
                    Util = null;
                }
            }
            else
            {
                UtilitariosExt Util = new UtilitariosExt();
                Util.MensagemAlerta("Atenção", "É necessário selecionar um usuário", "");
                Util = null;
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
          
            int IdGrupo = int.Parse(Request.QueryString.Get("qIdGrupo").ToString());


          
            //Se o click foi no botão Remover.
            if (e.ExtraParams["IDObjeto"] == "btnRemover")
            {
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Excluir o registro?", "CliqueBotaoSimMensagemExclusao(" + IdGrupo +",'"+ IDTabela + "')", "");
                UtilExt = null;

            }


        }
    }
}