using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Negocio.Escola;
using Corujito.Entidade.Escola;
using System.Configuration;
using Corujito.Apresentacao.UtilitarioExt;
using Ext.Net;
using Corujito.Entidade;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroAtividade : System.Web.UI.Page
    {
        /// <summary>
        /// Incluir um objeto no Banco.
        /// </summary>
        private void Incluir()
        {

            Usuario UserLogin = (Usuario)Session["Usuario"];

            //Declara, Instancia, e Preenche a Entidade.
            CRJAtividade objAtividade = PopularEntidade();

            //Declarando e Instânciando a classe de Negócio para Persistir o objeto objCRJProduto.
            CRJAtividadeBO objCRJAtividadeBO = new CRJAtividadeBO();
               
            //Executando método para Incluir na Base de Dados o objeto objCRJProduto e armazenando o resultado obtido na variável Resultado.
            string Retorno = objCRJAtividadeBO.Incluir(objAtividade, UserLogin.DadosPessoais.IdPessoa);

            //Se o Retorno do método Incluir for um valor númerico maior que 0, então significa Sucesso.
            int LinhasAfetadas = 0;

            if (int.TryParse(Retorno, out LinhasAfetadas) == false)
            {
                //Caso seja mensagem de exception, exibe mensagem padrão.
                if (Retorno.IndexOf("Exception:") >= 0)
                    Retorno = ConfigurationManager.AppSettings["MensagemErroPadrao"];
                //Exibe mensagem para o usuário.

                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.ERROR, MessageBox.Button.OK, Retorno, "btnGravar");
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
                UtilExt.MensagemAlerta("Atenção", "Cadastrado com Sucesso!", "CliqueBotaoOkMensagemInclusaoSucesso()");
                UtilExt = null;

            }

            //Finalizando as variáveis de Negócio.
            objCRJAtividadeBO = null;


        }
        
        private CRJAtividade PopularEntidade()
        {
            CRJAtividade ObjAtividade = new CRJAtividade();
            ObjAtividade.TipoAtividade = new CRJTipoAtividade();
            ObjAtividade.IdProfXMatxEns = int.Parse(Request.QueryString.Get("IdProf"));
            ObjAtividade.NomeAtividade = txtAtividade.Text;
            ObjAtividade.TipoAtividade.IdTipoAtividade = int.Parse(cboTipoatividade.SelectedItem.Value);
            ObjAtividade.Datainicial = dtini.SelectedDate;
            ObjAtividade.DataFinal = dtFim.SelectedDate;
            ObjAtividade.Descricao = txtDesc.Text;

            return ObjAtividade;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Popular_cboTipoatividade();
        }
        
        private void Popular_cboTipoatividade()
        {
            CRJTipoAtividadeBO objTipoAtividadeBO = new CRJTipoAtividadeBO();
            List<CRJTipoAtividade> ListaTipoAtividade = new List<CRJTipoAtividade>();

            ListaTipoAtividade = objTipoAtividadeBO.ObterCRJTipoAtividade();
            StoreTipoAtividade.DataSource = ListaTipoAtividade;
            StoreTipoAtividade.DataBind();

        }
        
        protected void btnGravar_Click(object sender, Ext.Net.DirectEventArgs e)
        {


            //Se a QueryString for NULL, então é uma Inclusão. Caso contrário é uma Alteração.
            if (Request.QueryString.Get("qID") == null)
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