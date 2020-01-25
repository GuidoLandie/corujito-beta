using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Entidade;
using Corujito.Negocio;
using Ext.Net;
using Corujito.Apresentacao.UtilitarioExt;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroGrupoPermissoes : System.Web.UI.Page
    {

        #region DirectMethods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Seleciondo"></param>
        /// <param name="IdAplicacao"></param>
        /// <param name="IdFuncionalidade"></param>
        [DirectMethod(ShowMask = true,Namespace="Corujito")]
        public void AfterEdit(bool Seleciondo, int IdAplicacao, int IdFuncionalidade)
        {
            if (Seleciondo)
            {
                IncluirSession(IdAplicacao, IdFuncionalidade);
            }
            else
            {
                ExcluiSession(IdAplicacao, IdFuncionalidade);
            }

            int IdGrupo = Request.QueryString.Get("qIdGrupo") != null ? int.Parse(Request.QueryString.Get("qIdGrupo").ToString()):0;

            this.GridFuncionalidades.Store.Primary.CommitChanges();

            //PopularGrid(IdGrupo);
        }

        [DirectMethod(ShowMask=true)]
        public void CliqueBotaoSimAlteracao(int IdGrupo)
        {
            SalvarPermissoes(IdGrupo);
        }

        [DirectMethod(ShowMask = true)]
        public void CliqueBotaoOKMensagemSucesso()
        {
            X.AddScript("parent.hideModal();");
        }

        #endregion

        #region Metodos Privados

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdGrupo"></param>
        private void PopularGrid(int IdGrupo)
        {
             List<Funcionalidade> objFuncionalidade = new List<Funcionalidade>();
            
            if(Session["Funcionalidade"] == null)
            {
                FuncionalidadeBO objFuncionalidadeBO = new FuncionalidadeBO();
                objFuncionalidade = objFuncionalidadeBO.ObterFuncionalidade(IdGrupo);          
                
                Session["Funcionalidade"] = objFuncionalidade;

                objFuncionalidadeBO = null;
            }
            else
            {
                objFuncionalidade = (List<Funcionalidade>)Session["Funcionalidade"];
            }


            if (objFuncionalidade != null)
            {
                StoreFuncionalidades.DataSource = objFuncionalidade;
                StoreFuncionalidades.DataBind();
            }                     
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdAplicacao"></param>
        /// <param name="IdFuncionalidade"></param>
        private void IncluirSession(int IdAplicacao,int IdFuncionalidade)
        {            
            List<Funcionalidade> objFuncionalidadeColecao = new List<Funcionalidade>();

            if(Session["Funcionalidade"] != null)
            {
                objFuncionalidadeColecao = (List<Funcionalidade>)Session["Funcionalidade"];
            }

           for(int i = 0; i < objFuncionalidadeColecao.Count ;i++)
           {
                if(objFuncionalidadeColecao[i].IdAplicacao == IdAplicacao && objFuncionalidadeColecao[i].IdFuncionalidade == IdFuncionalidade) 
                {
                   objFuncionalidadeColecao[i].PossuiPermissao = true; 
                }
           }

            Session["Funcionalidade"] = objFuncionalidadeColecao;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdAplicacao"></param>
        /// <param name="IdFuncionalidade"></param>
        private void ExcluiSession(int IdAplicacao,int IdFuncionalidade)
        {
            List<Funcionalidade> objFuncionalidadeColecao = new List<Funcionalidade>();

            if(Session["Funcionalidade"] != null)
            {
                objFuncionalidadeColecao = (List<Funcionalidade>)Session["Funcionalidade"];
            }

            
           for(int i = 0; i < objFuncionalidadeColecao.Count ;i++)
           {
                if(objFuncionalidadeColecao[i].IdAplicacao == IdAplicacao && objFuncionalidadeColecao[i].IdFuncionalidade == IdFuncionalidade) 
                {
                   objFuncionalidadeColecao[i].PossuiPermissao = false; 
                }
           }
            
            Session["Funcionalidade"] = objFuncionalidadeColecao;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private List<Funcionalidade> PopularEntidade()
        {
            List<Funcionalidade> objFuncionalidade = new List<Funcionalidade>();
            List<Funcionalidade> objFuncionalidadeColecao = new List<Funcionalidade>();

            if(Session["Funcionalidade"] != null)
            {
                objFuncionalidade = (List<Funcionalidade>)Session["Funcionalidade"];
            }

            foreach (Funcionalidade Item in objFuncionalidade)
            {
                if(Item.PossuiPermissao == true)
                {
                    objFuncionalidadeColecao.Add(Item);
                }
            }
            
            return objFuncionalidadeColecao;
        }              

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <param name="json"></param>
        private void SalvarPermissoes(int IdGrupo)
        {
            List<Funcionalidade> objFuncionlidades = PopularEntidade();
            FuncionalidadeBO objFuncionalidadeBO = new FuncionalidadeBO();

            string Retorno = objFuncionalidadeBO.IncluirPermissaoGrupo(IdGrupo, objFuncionlidades);

            int LinhasAfetada = 0;

            if (int.TryParse(Retorno, out LinhasAfetada) == true || string.IsNullOrEmpty(Retorno))
            {
                UtilitariosExt Util = new UtilitariosExt();
                Util.MensagemAlerta("Atenção", "Registro Salvo com sucesso", "CliqueBotaoOKMensagemSucesso()");
                Util = null;
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
                int IdGrupo = string.IsNullOrEmpty(Request.QueryString.Get("qIdGrupo")) ? 0 : int.Parse(Request.QueryString.Get("qIdGrupo").ToString());

                PopularGrid(IdGrupo);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGravar_Click(object sender, DirectEventArgs e)
        {
            int IdGrupo = string.IsNullOrEmpty(Request.QueryString.Get("qIdGrupo")) ? 0 : int.Parse(Request.QueryString.Get("qIdGrupo").ToString());

            UtilitariosExt Util = new UtilitariosExt();
            Util.MensagemAlerta("Confirmação", "Você tem certeza que deseja alterar as permissões?", "CliqueBotaoSimAlteracao(" + IdGrupo +")", "");
            Util = null;
        }
    }
}