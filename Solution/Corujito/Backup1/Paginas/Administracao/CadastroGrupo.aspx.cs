using System;

using Ext.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Apresentacao.UtilitarioExt;
using Corujito.Entidade;
using Corujito.Entidade.Escola;
using Corujito.Negocio;
using Corujito.Negocio.Escola;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroGrupo : System.Web.UI.Page
    {

        #region DirectMethods

        [DirectMethod]
        public void CliqueMensagemSucessoOK()
        {
            X.AddScript("parent.hideModal();");
        }

        [DirectMethod]
        public void CliqueBotaoSimMensagemAlteracao()
        {
            Alterar();
        }

        #endregion

        #region Metodos Privados

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCodigo"></param>
        private void ObterDadosPorId(int pCodigo)
        {
            //Instancia os objetos
            GrupoPermissao objGrupoPermissao = new GrupoPermissao();
            GrupoPermissaoNegocio objGrupoPermissaoBO = new GrupoPermissaoNegocio();

            //obtem o ojeto
            objGrupoPermissao = objGrupoPermissaoBO.ObterGrupoPermissaoPorId(pCodigo);
            
            //coloca na pagina o item
            if (objGrupoPermissao != null)
            {
                txtNome.Text = objGrupoPermissao.Nome;
                txtDescricao.Text = objGrupoPermissao.Descricao;
                cboTipoPessoa.SelectedItem.Value = objGrupoPermissao.TipoPessoa.IdTipoPessoa.ToString();
            }

            //Finaliza os objetos
            objGrupoPermissao = null;
            objGrupoPermissaoBO = null;

        }

        /// <summary>
        ///
        /// </summary>
        private void Incluir()
        {
            GrupoPermissao objGrupoPermissao = PopularEntidade();
            GrupoPermissaoNegocio objGrupoPermissaoNegocio = new GrupoPermissaoNegocio();

            string ret = objGrupoPermissaoNegocio.IncluirNovo(objGrupoPermissao);

            int LinhasAfetadas = 0;

            UtilitariosExt Util = new UtilitariosExt();

            if (int.TryParse(ret, out LinhasAfetadas) == true && LinhasAfetadas > 0)
            {
                Util.MensagemAlerta("Atenção", "Registro incluido com sucesso!", "CliqueMensagemSucessoOK()");
            }
            else
            {
                Util.MensagemAlerta("Atenção", ret, "");
            }

            Util = null;

        }

        private void Alterar()
        {
            GrupoPermissao objGrupoPermissao = PopularEntidade();
            GrupoPermissaoNegocio objGrupoPermissaoNegocio = new GrupoPermissaoNegocio();

            string ret = objGrupoPermissaoNegocio.AlterarGrupo(objGrupoPermissao);

            int LinhasAfetadas = 0;

            UtilitariosExt Util = new UtilitariosExt();

            if (int.TryParse(ret, out LinhasAfetadas) == true && LinhasAfetadas > 0)
            {
                Util.MensagemAlerta("Atenção", "Registro alterado com sucesso!", "CliqueMensagemSucessoOK()");
            }
            else
            {
                Util.MensagemAlerta("Atenção", ret, "");
            }

            Util = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private GrupoPermissao PopularEntidade()
        {
            GrupoPermissao objGrupoPermissao = new GrupoPermissao();

            objGrupoPermissao.IdGrupo = Request.QueryString.Get("qIDGrupo") != null ? int.Parse(Request.QueryString.Get("qIDGrupo").ToString()) : 0;
            objGrupoPermissao.Nome = txtNome.Text;
            objGrupoPermissao.Descricao = txtDescricao.Text;
            objGrupoPermissao.TipoPessoa.IdTipoPessoa = int.Parse(cboTipoPessoa.SelectedItem.Value);

            return objGrupoPermissao;
        }

        private void PopularCboTipoPessoa()
        {
            storeTipoPessoa.DataSource = new CRJTipoPessoaNegocio().ObterCRJTipoPessoa();
            storeTipoPessoa.DataBind();
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
                PopularCboTipoPessoa();

                if (Request.QueryString.Get("qIdGrupo") != null)
                {
                    ObterDadosPorId(int.Parse(Request.QueryString.Get("qIdGrupo").ToString()));
                }

                if (Request.QueryString.Get("qTela") == "Consultar")
                {
                    txtDescricao.ReadOnly = true;
                    txtNome.ReadOnly = true;
                    btnGravar.Hidden = true;
                }
            }


        }

        /// <summary>
        /// Botao gravar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGravar_Click(object sender, Ext.Net.DirectEventArgs e)
        {

            //Armazenar na variável FormularioValido se o Form é válido ou não.
            bool FormularioValido = Convert.ToBoolean(e.ExtraParams["FormularioValido"]);

            if (FormularioValido == true)
            {
                //Se a QueryString for NULL, então é uma Inclusão. Caso contrário é uma Alteração.
                if (Request.QueryString.Get("qIdGrupo") == null)
                {
                    Incluir();
                }
                else
                {
                    UtilitariosExt UtilExt = new UtilitariosExt();
                    UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Alterar o registro?", "CliqueBotaoSimMensagemAlteracao()", "");
                    UtilExt = null;
                }


            }

        }

    }
}