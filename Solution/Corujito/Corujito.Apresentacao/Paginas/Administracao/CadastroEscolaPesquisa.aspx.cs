using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
 
using System.Data;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroEscolaPesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            

        }

        protected void btnCadastrarNovo_DirectClick(object sender, DirectEventArgs e)
        {
            X.Redirect("CadastroEscola.aspx");
        }

        protected void btnPesquisar_DirectClick(object sender, DirectEventArgs e)
        {
            //CRJEscolaBLL objEscolaBLL = new CRJEscolaBLL();

            //DataTable dt = objEscolaBLL.Select();

            //StoreCRJEscola.DataSource = dt;
            //StoreCRJEscola.DataBind();          
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
                ////Se o usuário NÃO POSSUIR permissão no SIP para Consultar, então exibe mensagem.
                //if (Util.PermissaoRoleIntra(Session["RU"].ToString(), Convert.ToInt32(Session["CodAplicacao"]), Session["Email"].ToString(), this.CodigoSIPPermissaoConsultar))
                //{
                //    string URLModal = "CRJEscolaCadastro.aspx?qID=" + IDTabela + "&qTela=Consultar";
                //    //TODO: Informe no parâmetro Altura e Largura no método ExibirModalCadastro, os valores compativeis com a tela de cadastro. O tamanho máximo para a Intranet é: 520, 760
                //    ExibirModalCadastro("Consultar Cadastro", URLModal, 430, 690, true, true, Icon.Magnifier);
                //}
                //else
                //{
                //    //Exibe mensagem para o usuário.
                //    UtilitarioExt UtilExt = new UtilitarioExt();
                //    UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.WARNING, MessageBox.Button.OK, ConfigurationManager.AppSettings["MensagemSemPermissaoRoleIntra"], "");
                //    UtilExt = null;
                //}
            }

            //Se o click foi no botão Alterar.
            if (e.ExtraParams["IDObjeto"] == "btnAlterar")
            {


                string URLModal = "CadastroEscola.aspx?qID=" + IDTabela + "&qTela=Alterar";

                Response.Redirect(URLModal);
                    
               
            }

            //Se o click foi no botão Remover.
            if (e.ExtraParams["IDObjeto"] == "btnRemover")
            {
                ////Se o usuário NÃO POSSUIR permissão no SIP para Excluir, então exibe mensagem.
                //if (Util.PermissaoRoleIntra(Session["RU"].ToString(), Convert.ToInt32(Session["CodAplicacao"]), Session["Email"].ToString(), this.CodigoSIPPermissaoExcluir))
                //{
                //    UtilitarioExt UtilExt = new UtilitarioExt();
                //    UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Excluir o registro?", "CliqueBotaoSimMensagemExclusao(" + int.Parse(IDTabela) + ")", "");
                //    UtilExt = null;

                //}
                //else
                //{
                //    //Exibe mensagem para o usuário.
                //    UtilitarioExt UtilExt = new UtilitarioExt();
                //    UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.WARNING, MessageBox.Button.OK, ConfigurationManager.AppSettings["MensagemSemPermissaoRoleIntra"], "");
                //    UtilExt = null;
                //}
            }
          
        }
    }
}