using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Negocio;
using System.Data;
using Ext.Net;
using Corujito.Entidade;
using Corujito.Negocio.Escola;
using Corujito.Entidade.Escola;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class ConsultarOcorrencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                PopularCboDependentes();
            }
        }

        /// <summary>
        /// Método para carregar a grid com os dados da Coleção de CRJPessoa
        /// </summary>
        private void PopularOcorrencia(int IdAluno)
        {
            //Atribuindo a Grid a páginação informada pelo usuário
            this.PagingToolbar1.PageSize = int.Parse(cboPageSize.Text);

            //Declarando e Instanciando o Objeto de Negócio e Coleção de Entidades.
            CRJOcorrenciaNegocio objCRJOcorrenciaNegocio = new CRJOcorrenciaNegocio();


            //Atribuindo ao objeto de coleção os registros encontrados na pesquisa.
            DataTable dtOcorrencia = objCRJOcorrenciaNegocio.ObterCRJOcorrenciaByAluno(IdAluno);

            //Verifica se o retorno do método é diferente de Null. SE FOR popula a grid. SE NÃO FOR exibe mensagem de erro.
            if (dtOcorrencia != null && dtOcorrencia.Rows.Count > 0)
            {


                if (dtOcorrencia.Rows[0]["idOcorrencia"] != null)
                {
                    gvOcorrencia.Visible = true;
                    StoreCRJOcorrencia.DataSource = dtOcorrencia;
                    StoreCRJOcorrencia.DataBind();
                }
                else
                {
                    gvOcorrencia.Visible = false;
                }
            }


            //Finalizando os objetos
            dtOcorrencia = null;
            objCRJOcorrenciaNegocio = null;
        }

        protected void cboPessoaDependente_Select(object sender, DirectEventArgs e)
        {
            if (!string.IsNullOrEmpty(cboPessoaDependente.SelectedItem.Value))
            {
                PopularOcorrencia(int.Parse(cboPessoaDependente.SelectedItem.Value));
            }
        }

        private void PopularCboDependentes()
        {
            Usuario UserLogin = (Usuario)Session["Usuario"];

            List<CRJPessoa> objPessoa = (new CRJPessoaNegocio()).ObterDependentesPorResponsavel(UserLogin.DadosPessoais.IdPessoa);

            if (objPessoa != null && objPessoa.Count > 0)
            {
                StorePessoaDependente.DataSource = objPessoa;
                StorePessoaDependente.DataBind();
            }
            else
            {
                cboPessoaDependente.Text = UserLogin.DadosPessoais.Nome;
                cboPessoaDependente.ReadOnly = true;
                PopularOcorrencia(UserLogin.DadosPessoais.IdAluno);
            }

        }
    }
}