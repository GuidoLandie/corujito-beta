﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Corujito.Apresentacao.UtilitarioExt;
using Corujito.Entidade;
using Corujito.Negocio;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroLancamentoCartao : System.Web.UI.Page
    {
        #region Direct Metodos

        [DirectMethod]
        public void CliqueBotaoSimMensagemAlteracao()
        {
            Alterar();
        }

        [DirectMethod]
        public void CliqueBotaoSimMensagemInclusaoComSucesso()
        {
            Response.Redirect("CadastroLancamentoCartaoPesquisa.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!X.IsAjaxRequest)
            {
                
                if (Request.QueryString["qID"] != null)
                {
                    string id = Request.QueryString["qID"].ToString();
                    ObterDadosPorId(id);
                }
                else
                {
                    txtIdLancamentoCartao.Text = "0";
                }
            }


        }

        private void ObterDadosPorId(string id)
        {
            CRJLancamentoCartao objCRJLancamentoCartao = new CRJLancamentoCartaoNegocio().ObterCRJLancamentoCartao(int.Parse(id)).First();
            txtIdLancamentoCartao.Text = objCRJLancamentoCartao.IdLancamentoCartao.ToString();
            txtValor.Text = objCRJLancamentoCartao.Valor.ToString();
 
        }

        protected void btnCancelar_Click(object sender, DirectEventArgs e)
        {
            UtilitariosExt UtilExt = new UtilitariosExt();
            UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Cancelar a Alteração?", "CliqueBotaoSimMensagemInclusaoComSucesso()", "");
            UtilExt = null;
        }


        protected void btnGravar_Click(object sender, Ext.Net.DirectEventArgs e)
        {

            //Armazenar na variável FormularioValido se o Form é válido ou não.
            bool FormularioValido = Convert.ToBoolean(e.ExtraParams["FormularioValido"]);

            if (FormularioValido == true)
            {
                //Se a QueryString for NULL, então é uma Inclusão. Caso contrário é uma Alteração.
                if (txtIdLancamentoCartao.Text == "0")
                {
                    Usuario UserLogin = (Usuario)Session["Usuario"];

                    //Declara, Instancia, e Preenche a Entidade.
                    CRJLancamentoCartao objCRJLancamentoCartao = new CRJLancamentoCartao();
                    objCRJLancamentoCartao.Valor = double.Parse(txtValor.Text);
                    objCRJLancamentoCartao.IdLancador = UserLogin.DadosPessoais.IdPessoa;


                    //Declarando e Instânciando a classe de Negócio para Persistir o objeto objCRJPessoa.
                    CRJLancamentoCartaoNegocio objCRJLancamentoCartaoNegocio = new CRJLancamentoCartaoNegocio();
                   
                    //Executando método para Incluir na Base de Dados o objeto objCRJPessoa e armazenando o resultado obtido na variável Resultado.
                    string Retorno = objCRJLancamentoCartaoNegocio.Incluir(objCRJLancamentoCartao);

                    //Se o Retorno do método Incluir for um valor númerico maior que 0, então significa Sucesso.
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
                        UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.WARNING, MessageBox.Button.OK, "Ocorreu um erro ao tentar salvar o registro.", "");
                        UtilExt = null;
                    }
                    else if (LinhasAfetadas >= 1)
                    {
                        //Exibe mensagem para o usuário.
                        UtilitariosExt UtilExt = new UtilitariosExt();
                        UtilExt.MensagemAlerta("Atenção", "Registro incluido com sucesso, adicione as informações adicionais para esta pessoa.", "CliqueMensagemIncluidoComSucesso(" + Retorno + ")");
                        UtilExt = null;

                        //Codigo que acabou de ser inserido
                        txtIdLancamentoCartao.Text = Retorno;

                    }

                    //Finalizando as variáveis de Negócio.
                    objCRJLancamentoCartao = null;

                }
                else
                {
                    UtilitariosExt UtilExt = new UtilitariosExt();
                    UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Alterar o registro?", "CliqueBotaoSimMensagemAlteracao()", "");
                    UtilExt = null;
                }


            }

        }
        #endregion

        #region Metodos Privados

        /// <summary>
        /// Metodo que busca um registro
        /// </summary>
        /// <param name="pId"></param>
        private void ObterDadosPorId(int pId)
        {
            // //CRJPessoaMDL objCRJPessoaMDL = new CRJPessoaMDL();
            // //CRJPessoaBLL objCRJPessoaBLL = new CRJPessoaBLL();

            // //objCRJPessoaMDL.idCRJPessoa = pId;

            // //objCRJPessoaBLL.Select(ref objCRJPessoaMDL);

            //// if (objCRJPessoaMDL != null)
            // //{
            //     CRJEscolaBLL objCRJEscolaBLL = new CRJEscolaBLL();

            //     CRJEscolaMDL objCRJEscolaMDL = new CRJEscolaMDL();
            //     objCRJEscolaMDL.IdEscola = pId;

            //     objCRJEscolaBLL.Select(ref objCRJEscolaMDL);

            //     if (objCRJEscolaMDL != null)
            //     {
            //         txtIdEscola.Text = pId.ToString();
            //         txtRazaoSocial.Text = objCRJEscolaMDL.RazaoSocial;
            //         txtNome.Text = objCRJEscolaMDL.Nome;
            //         txtCNPJ.Text = objCRJEscolaMDL.CNPJ;
            //         txtInscEstadual.Text = objCRJEscolaMDL.InscEstadual;
            //         txtLogradouro.Text = objCRJEscolaMDL.Logradouro;
            //         txtBairro.Text = objCRJEscolaMDL.Bairro;
            //         txtCidade.Text = objCRJEscolaMDL.Cidade;
            //         txtEstado.Text = objCRJEscolaMDL.Estado;
            //         txtCEP.Text = objCRJEscolaMDL.CEP;
            //         txtTelefonePrincipal.Text = objCRJEscolaMDL.TelefonePrincipal;
            //         txtTelefoneSecundario.Text = objCRJEscolaMDL.TelefoneSecundario;
            //         txtEmail.Text = objCRJEscolaMDL.Email;
            //         txtMissao.Text = objCRJEscolaMDL.Missao;
            //         txtObservacao.Text = objCRJEscolaMDL.Observacao;
            //     }
            //     else
            //     {
            //         UtilitariosExt Util = new UtilitariosExt();
            //         Util.MensagemAlerta("Atenção", "Não foi enconrado nenhum registro com o idendificador indicado.", "");
            //     }


        }

        /// <summary>
        /// metodo que altera um registro
        /// </summary>
        private void Alterar()
        {
            Usuario UserLogin = (Usuario)Session["Usuario"];

            int id = int.Parse(txtIdLancamentoCartao.Text);

            //Declarando e Instânciando a classe de Negócio para Persistir o objeto objCRJPessoa.
            CRJLancamentoCartaoNegocio objCRJLancamentoCartaoNegocio = new CRJLancamentoCartaoNegocio();

            //Declara, Instancia, e Preenche a Entidade.
            //CRJLancamentoCartao objCRJLancamentoCartao = objCRJLancamentoCartaoNegocio.ObterCRJLancamentoCartao(id);
            CRJLancamentoCartao objCRJLancamentoCartao = new CRJLancamentoCartaoNegocio().ObterCRJLancamentoCartao(int.Parse(hdIdAluno.Value.ToString())).First();
            objCRJLancamentoCartao.Valor = double.Parse(txtValor.Text);


            //Executando método para Incluir na Base de Dados o objeto objCRJPessoa e armazenando o resultado obtido na variável Resultado.
            string Retorno = objCRJLancamentoCartaoNegocio.Incluir(objCRJLancamentoCartao);

            //Se o Retorno do método Incluir for um valor númerico maior que 0, então significa Sucesso.
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
                UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.WARNING, MessageBox.Button.OK, "Ocorreu um erro ao tentar salvar o registro.", "");
                UtilExt = null;
            }
            else if (LinhasAfetadas >= 1)
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", "Registro incluido com sucesso, adicione as informações adicionais para esta pessoa.", "CliqueMensagemIncluidoComSucesso(" + Retorno + ")");
                UtilExt = null;

                //Codigo que acabou de ser inserido
                txtIdLancamentoCartao.Text = Retorno;

            }

            //Finalizando as variáveis de Negócio.
            objCRJLancamentoCartao = null;

        }

        private void Incluir()
        {
            //CRJEscolaBLL objCRJEscolaBLL = new CRJEscolaBLL();
            //CRJEscolaMDL objCRJEscolaMDL = new CRJEscolaMDL();

            //objCRJEscolaMDL = PopularEntidade();



            //objCRJEscolaBLL.Insert(objCRJEscolaMDL);
        }

        //private CRJEscolaMDL PopularEntidade()
        //{
        //    CRJEscolaMDL objCRJEscolaMDL = new CRJEscolaMDL();


        //    objCRJEscolaMDL.IdEscola            = int.Parse(txtIdEscola.Text.ToString());
        //    objCRJEscolaMDL.RazaoSocial         = txtRazaoSocial.Text;
        //    objCRJEscolaMDL.Nome                = txtNome.Text;
        //    objCRJEscolaMDL.CNPJ                = txtCNPJ.Text;
        //    objCRJEscolaMDL.InscEstadual        = txtInscEstadual.Text;
        //    objCRJEscolaMDL.Logradouro          = txtLogradouro.Text;
        //    objCRJEscolaMDL.Bairro              = txtBairro.Text;
        //    objCRJEscolaMDL.Cidade              = txtCidade.Text;
        //    objCRJEscolaMDL.Estado              = txtEstado.Text;
        //    objCRJEscolaMDL.CEP                 = txtCEP.Text;
        //    objCRJEscolaMDL.TelefonePrincipal   = txtTelefonePrincipal.Text;
        //    objCRJEscolaMDL.TelefoneSecundario  = txtTelefoneSecundario.Text;
        //    objCRJEscolaMDL.Email               = txtEmail.Text;
        //    objCRJEscolaMDL.DataAbertura        = txtDataAbertura.SelectedDate;
        //    objCRJEscolaMDL.Missao              = txtMissao.Text;
        //    objCRJEscolaMDL.IdStatus            = int.Parse(cboSitucao.SelectedItem.Value);
        //    objCRJEscolaMDL.Observacao          = txtObservacao.Text;

        //    return objCRJEscolaMDL;
        //}

        #endregion

        

        //Botão Gravar.
        

        
    }
}