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
    public partial class CadastroCartao : System.Web.UI.Page
    {

        /// <summary>
        /// Obter os dados do objeto CRJPessoa a partir da chave primária da tabela.
        /// </summary>
        /// <param name="pID">Identificador único do objeto.</param>
        private void ObterDadosPorID(int pID)
        {
            CRJPessoaNegocio objCRJPessoaNegocio = new CRJPessoaNegocio();
            CRJPessoa objCRJPessoa = new CRJPessoa();

            objCRJPessoa = objCRJPessoaNegocio.ObterCRJPessoaPorId(pID);

            if (objCRJPessoa != null)
            {
                //Dados pessoais                
                txtNome.Text = objCRJPessoa.Nome.ToString();
            }
            else
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.WARNING, MessageBox.Button.OK, "Não existe um registro com o Identificador " + pID.ToString(), "");
                UtilExt = null;

            }
            //Finalizando os objetos.

            objCRJPessoa = null;
            objCRJPessoaNegocio = null;
        }

        [DirectMethod]
        public void CliqueBotaoSimMensagemInclusaoComSucesso()
        {
            X.AddScript("parent.hideModal();");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                hdIdPessoa.Value = Request.QueryString.Get("qID").ToString();
                VerificaCartao(int.Parse(hdIdPessoa.Value.ToString()));
                ObterDadosPorID(int.Parse(hdIdPessoa.Value.ToString()));
            }
        }

        private void VerificaCartao(int idPessoa)
        {
            DataTable dt = new CRJCartaoNegocio().ObterCRJCartaoByIdPessoa(idPessoa);
            if (dt != null && dt.Rows.Count > 0)
            {
                string URL = "LancamentoCartao.aspx?qID=" + dt.Rows[0]["IdCartao"].ToString();

                if (!string.IsNullOrEmpty(Request.QueryString.Get("qTela")) && Request.QueryString.Get("qTela") == "Consultar")
                {
                    URL += "&qTela=Consultar";
                }

                Response.Redirect(URL);
            }
        }

        protected void btnCancelar_Click(object sender, DirectEventArgs e)
        {
            UtilitariosExt UtilExt = new UtilitariosExt();
            UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Cancelar ?", "CliqueBotaoSimMensagemInclusaoComSucesso()", "");
            UtilExt = null;
        }


        protected void btnGravar_Click(object sender, Ext.Net.DirectEventArgs e)
        {

            //Armazenar na variável FormularioValido se o Form é válido ou não.
            bool FormularioValido = Convert.ToBoolean(e.ExtraParams["FormularioValido"]);

            if (FormularioValido == true)
            {
                Incluir();
            }

        }

        //Botão Gravar.

        /// <summary>
        /// Incluir um objeto no Banco.
        /// </summary>
        private void Incluir()
        {

            //Declara, Instancia, e Preenche a Entidade.
            CRJCartao objCRJCartao = new CRJCartao();
            objCRJCartao.IdPessoa = int.Parse(hdIdPessoa.Value.ToString());

            //Declarando e Instânciando a classe de Negócio para Persistir o objeto objCRJPessoa.
            CRJCartaoNegocio objCRJCartaoNegocio = new CRJCartaoNegocio();

            //Executando método para Incluir na Base de Dados o objeto objCRJPessoa e armazenando o resultado obtido na variável Resultado.
            string Retorno = objCRJCartaoNegocio.Incluir(objCRJCartao);


            //Exibe mensagem para o usuário.
            UtilitariosExt UtilExt = new UtilitariosExt();
            UtilExt.MensagemAlerta("Atenção", "Cartão habilitado com sucesso", "CliqueBotaoSimMensagemInclusaoComSucesso()");
            UtilExt = null;


            //Finalizando as variáveis de Negócio.
            objCRJCartaoNegocio = null;
        }

    }
}