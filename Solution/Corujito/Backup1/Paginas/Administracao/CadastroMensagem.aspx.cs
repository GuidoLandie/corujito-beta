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
using System.Net.Mail;
using Corujito.Negocio.Escola;
using Corujito.Entidade.Escola;
using System.Data;
using System.Net;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroMensagem : System.Web.UI.Page
    {
        public int IdAluno
        {
            get { return int.Parse(ViewState["IdAluno"].ToString()); }
            set { ViewState["IdAluno"] = value; }
        }

        #region Métodos Privados

        [DirectMethod]
        public void CliqueMensagemIncluidoComSucesso()
        {
            Response.Redirect("AlunosPesquisa.aspx");
        }

        /// <summary>
        /// Método para carregar a grid com os dados da Coleção de CRJPessoa
        /// </summary>
        private void PopularGrid()
        {

            //Declarando e Instanciando o Objeto de Negócio e Coleção de Entidades.
            CRJAlunoNegocio objAlunoNegocio = new CRJAlunoNegocio();


            //Atribuindo ao objeto de coleção os registros encontrados na pesquisa.
            DataTable dtAluno = objAlunoNegocio.ObterCRJAluno("", "", "", "", "", IdAluno.ToString());

            DataTable dtResponsaveis = objAlunoNegocio.ObterResponsaveisByAluno(IdAluno);
            if (dtResponsaveis != null && dtResponsaveis.Rows.Count > 0)
            {
                for (int i = 0; i < dtResponsaveis.Rows.Count; i++)
                {
                    txtResponsaveis.Text += dtResponsaveis.Rows[i]["Nome"].ToString() + " - " + dtResponsaveis.Rows[i]["Email"].ToString() + "\n";
                }
            }
            else
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", "Nenhum responsavel encontrado", "");
                UtilExt = null;
            }

            //Verifica se o retorno do método é diferente de Null. SE FOR popula a grid. SE NÃO FOR exibe mensagem de erro.
            if (dtAluno != null)
            {

                txtRA.Text = dtAluno.Rows[0]["RA"].ToString();
                txtNome.Text = dtAluno.Rows[0]["Nome"].ToString();
            }
            else
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", "Ocorreu um erro ao tentar obter os dados tente novamente.", "CliqueBotaoSimMensagemInclusaoComSucesso()");
                UtilExt = null;
            }

            //Finalizando os objetos
            dtAluno = null;
            objAlunoNegocio = null;
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
                IdAluno = int.Parse(Request.QueryString["qIDAluno"].ToString());
                PopularGrid();
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
            try
            {
                Usuario UserLogin = (Usuario)Session["Usuario"];

                MailMessage message = new MailMessage();

                message.From = new MailAddress("kauan.lg@gmail.com");

                //Declarando e Instanciando o Objeto de Negócio e Coleção de Entidades.
                CRJAlunoNegocio objAlunoNegocio = new CRJAlunoNegocio();


                //Atribuindo ao objeto de coleção os registros encontrados na pesquisa.
                DataTable dtAluno = objAlunoNegocio.ObterCRJAluno("", "", "", "", "", IdAluno.ToString());

                DataTable dtResponsaveis = objAlunoNegocio.ObterResponsaveisByAluno(IdAluno);
                if (dtResponsaveis != null && dtResponsaveis.Rows.Count > 0)
                {
                    for (int i = 0; i < dtResponsaveis.Rows.Count; i++)
                    {
                        message.To.Add(new MailAddress(dtResponsaveis.Rows[i]["Email"].ToString()));
                    }

                    //message.CC.Add(new MailAddress("carboncopy@foo.bar.com"));

                    message.Subject = txtAssunto.Text;
                    message.Body += txtMensagem.Text;
                    message.Body += "<br/><br/>";
                    message.Body += UserLogin.DadosPessoais.Nome;
                    message.Body += "<br/>";
                    message.Body += UserLogin.DadosPessoais.Email;
                    message.CC.Add(UserLogin.DadosPessoais.Email);
                    message.IsBodyHtml = true;



                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    client.Port = 587;
                    //client.Credentials = new NetworkCredential("kauan.lg@gmail.com", "senha");
                    client.EnableSsl = true;

                    client.Send(message);

                    UtilitariosExt UtilExt = new UtilitariosExt();
                    UtilExt.MensagemAlerta("Enviado", "Email enviado com sucesso", "");
                    UtilExt = null;

                    CliqueMensagemIncluidoComSucesso();
                }


            }
            catch (Exception ex)
            {
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Enviado", "Email enviado com sucesso", "CliqueMensagemIncluidoComSucesso()");
                UtilExt = null;
            }

        }

    }
}
