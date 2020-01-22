using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Corujito.Entidade;
using Corujito.Negocio;
using System.Configuration;
using Corujito.Apresentacao.UtilitarioExt;
using Corujito.Negocio.Escola;
using Corujito.Entidade.Escola;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroProduto : System.Web.UI.Page
    {

        #region ExtNet - DirectMethod

        /// <summary>
        /// Método que é disparado ao clicar no botão Sim da Mensagem de Alteração do Registro.
        /// </summary>
        [DirectMethod]
        public void CliqueBotaoSimMensagemAlteracao()
        {
            Alterar();
        }


        /// <summary>
        /// Método que é disparado ao clicar no botão OK da Mensagem Inclusão do Registro com Sucesso.
        /// </summary>
        [DirectMethod]
        public void CliqueBotaoOkMensagemInclusaoSucesso()
        {
            LimparTela();
        }

        #endregion

        #region Métodos Privados da Página


        /// <summary>
        /// Método que cria e retorna a Entidade populada com os valores dos campos do Formulário.
        /// </summary>
        /// <returns>Entidate preenchida com os valores dos campos do Formulário.</returns>
        private CRJProduto PopularEntidade()
        {
            //Declarando e Instânciando a Entidade.
            CRJProduto objCRJProduto = new CRJProduto();

            //Atribui os valores passados no página para as propriedades da Entidade.
            objCRJProduto.IdProduto = (Request.QueryString.Get("qID") == null ? 0 : int.Parse(Request.QueryString.Get("qID")));
            objCRJProduto.Tipo = new CRJTipoProduto();
            objCRJProduto.Tipo.IdTipoProduto = int.Parse(cboTipoProduto.SelectedItem.Value);
            objCRJProduto.Cod_Barra = txtCod_Barra.RawText.Trim();
            objCRJProduto.Nome = txtNome.RawText.Trim();
            objCRJProduto.Descricao = txtDescricao.RawText.Trim();
            objCRJProduto.Quantidade = int.Parse(txtQuantidade.RawText.Trim());
            objCRJProduto.Preco = float.Parse(txtPreco.RawText.Trim());
            objCRJProduto.Status = new CRJStatus();
            objCRJProduto.Status.IdStatus = int.Parse(cboIdStatus.SelectedItem.Value);

            return objCRJProduto;
        }


        /// <summary>
        /// Obter os dados do objeto CRJProduto a partir da chave primária da tabela.
        /// </summary>
        /// <param name="pID">Identificador único do objeto.</param>
        private void ObterDadosPorID(int pID)
        {
            CRJProdutoNegocio objCRJProdutoNegocio = new CRJProdutoNegocio();
            CRJProduto objCRJProduto = new CRJProduto();

            objCRJProduto = objCRJProdutoNegocio.ObterCRJProdutoPorId(pID);


            

            if (objCRJProduto != null)
            {
                //txtIdProduto.Value = objCRJProdutoColecao[0].IdProduto != null ? objCRJProdutoColecao[0].IdProduto.ToString() : string.Empty;
                cboTipoProduto.SelectedItem.Value = objCRJProduto.Tipo.IdTipoProduto.ToString();
                txtCod_Barra.Value = objCRJProduto.Cod_Barra != null ? objCRJProduto.Cod_Barra.ToString() : string.Empty;
                txtNome.Value = objCRJProduto.Nome != null ? objCRJProduto.Nome.ToString() : string.Empty;
                txtDescricao.Value = objCRJProduto.Descricao != null ? objCRJProduto.Descricao.ToString() : string.Empty;
                txtQuantidade.Value = objCRJProduto.Quantidade != null ? objCRJProduto.Quantidade.ToString() : string.Empty;
                txtPreco.Value = objCRJProduto.Preco != null ? objCRJProduto.Preco.ToString() : string.Empty;
                cboIdStatus.SelectedItem.Value = objCRJProduto.Status.IdStatus.ToString();
            }
            else
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.WARNING, MessageBox.Button.OK, "Não existe um registro com o Identificador " + txtIdProduto.RawText, "btnGravar");
                UtilExt = null;

                txtIdProduto.Value = null;

            }
            //Finalizando os objetos.

            objCRJProduto = null;
            objCRJProdutoNegocio = null;
        }


        /// <summary>
        /// Método para limpar o conteúdo dos campos da tela.
        /// </summary>
        private void LimparTela()
        {
            //Retirando a obrigatoriedade de preenchimento dos campos. Essa operação deverá ser feita para que a mensagem de Inconsistência não seja mostrada ao limpar os campos da tela.
            txtIdProduto.AllowBlank = true;
            
            //txtIdStatus.AllowBlank = true;

            //Limpando os campos.
            if (Request.QueryString.Get("qID") == null)
            {
                txtIdProduto.Value = null;
            }

            txtCod_Barra.Value = null;
            txtNome.Value = null;
            txtDescricao.Value = null;
            txtQuantidade.Value = null;
            txtPreco.Value = null;
            //txtIdStatus.Value = null;

            //Atribuindo de volta a obrigatoriedade de preenchimento do campo. Essa operação deverá ser feita após limpar os campos.
            txtIdProduto.AllowBlank = false;
           
           // txtIdStatus.AllowBlank = false;


        }


        /// <summary>
        /// Incluir um objeto no Banco.
        /// </summary>
        private void Incluir()
        {


            //Declara, Instancia, e Preenche a Entidade.
            CRJProduto objCRJProduto = PopularEntidade();

            //Declarando e Instânciando a classe de Negócio para Persistir o objeto objCRJProduto.
            CRJProdutoNegocio objCRJProdutoNegocio = new CRJProdutoNegocio();

            //Executando método para Incluir na Base de Dados o objeto objCRJProduto e armazenando o resultado obtido na variável Resultado.
            string Retorno =  objCRJProdutoNegocio.Incluir(objCRJProduto);


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
            objCRJProdutoNegocio = null;


        }


        /// <summary>
        /// Alterar um objeto no Banco.
        /// </summary>
        private void Alterar()
        {

            //Declara, Instancia, e Preenche a Entidade.
            CRJProduto objCRJProduto = PopularEntidade();


            CRJProdutoNegocio objCRJProdutoNegocio = new CRJProdutoNegocio();

            //Executando método para Alterar na Base de Dados o objeto objCRJProduto e armazenando o resultado obtido na variável Resultado.
            string Retorno = objCRJProdutoNegocio.Alterar(objCRJProduto);


            //Se o Retorno do método Alterar for um valor númerico maior que 0, então significa Sucesso.
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
                UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.WARNING, MessageBox.Button.OK, "erro", "btnGravar");
                UtilExt = null;
            }
            else if (LinhasAfetadas >= 1)
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.INFO, MessageBox.Button.OK, "Alterado com sucesso!", "btnGravar");
                UtilExt = null;
            }


            //Finalizando a classe de Negócio.
            objCRJProdutoNegocio = null;


        }


        #endregion

        //Evento Load da Página.
        protected void Page_Load(object sender, EventArgs e)
        {
            //popularIdStatus();
            //popularTipoProduto();

            //Se for modo consulta, bloqueia o painel e oculta os botões.
            if (Request.QueryString.Get("qTela") == "Consultar")
            {
                //Desabilitar os controles do Panel.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.DesabilitarControlesDoPanel(PanelCadastro);
                UtilExt = null;

                //Ocultar os Botões.
                btnGravar.Visible = false;
                btnLimparTela.Visible = false;
            }

            //Verifica se NÃO é um Requisição Ajax. Ou seja se é a primeira vez que a página é carregada.
            if (!X.IsAjaxRequest)
            {

                popularTipoProduto();
                popularIdStatus();

                //Verifica se existe um valor na QueryString vinda da página de pesquisa.
                //Se existir, então escreve no campo que é a Chave Primária da tabela.
                if (Request.QueryString.Get("qID") != null)
                {
                    txtIdProduto.RawText = Request.QueryString.Get("qID");
                    ObterDadosPorID(int.Parse(txtIdProduto.RawText));
                }

            }
        }

        //Botão Limpar Tela.
        protected void btnLimparTela_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            LimparTela();
        }

        //Botão Gravar.
        protected void btnGravar_Click(object sender, Ext.Net.DirectEventArgs e)
        {

            //Armazenar na variável FormularioValido se o Form é válido ou não.
            bool FormularioValido = Convert.ToBoolean(e.ExtraParams["FormularioValido"]);

            if (FormularioValido == true)
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

        private void popularTipoProduto()
        {

            CRJTipoProdutoNegocio TipoProdutoBO = new CRJTipoProdutoNegocio();
            List<CRJTipoProduto> TipoProdutoColecao = new List<CRJTipoProduto>();

            TipoProdutoColecao = TipoProdutoBO.ObterCRJTipoProduto();

            StoreTipoProduto.DataSource = TipoProdutoColecao;
            StoreTipoProduto.DataBind();
        
        }

        private void popularIdStatus()
        {

            CRJStatusNegocio StatusBO = new CRJStatusNegocio();
            List<CRJStatus> StatusColecao = new List<CRJStatus>();

            StatusColecao = StatusBO.ObterCRJStatus();

            StoreStatus.DataSource = StatusColecao;
            StoreStatus.DataBind();

        }




    }
}