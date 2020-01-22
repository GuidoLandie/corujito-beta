using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Entidade.Escola;
using Ext.Net;
using Corujito.Negocio.Escola;
using Corujito.Entidade;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class LancamentoNota : System.Web.UI.Page
    {
        [DirectMethod(Namespace = "CRJ", ShowMask = true)]
        public void SetarPresenca(int IdNotaAluno, float Nota)
        {
            CRJNotaAlunoNegocio obj = new CRJNotaAlunoNegocio();

            if (Nota < 0) Nota = 0;

            Usuario UserLogin = (Usuario)Session["Usuario"];

            obj.Alterar(IdNotaAluno, Nota, UserLogin.DadosPessoais.IdPessoa);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                PopularGrid();
            }
        }

        private void PopularGrid()
        {
            int Id = int.Parse(Request.QueryString.Get("IdProf"));

            List<CRJNotaAluno> objFreq = (new CRJNotaAlunoNegocio().ObterCRJNotaAluno(Id));

            StoreNotaAluno.DataSource = objFreq;
            StoreNotaAluno.DataBind();
        }
    }
}