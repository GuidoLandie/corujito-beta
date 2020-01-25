using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Entidade.Escola;
using Corujito.Negocio.Escola;
using Ext.Net;
using Corujito.Entidade;
using Corujito.Apresentacao.UtilitarioExt;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class LancamentoFrequencia : System.Web.UI.Page
    {
        [DirectMethod(Namespace = "CRJ", ShowMask = true)]
        public void SetarPresenca(int IdFrequencia, bool Presente)
        {
            CRJFrequenciaNegocio obj = new CRJFrequenciaNegocio();

            Usuario UserLogin = (Usuario)Session["Usuario"];

            obj.Alterar(IdFrequencia, Presente, UserLogin.DadosPessoais.IdPessoa);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                PopularGrid();

                btnAddAtvidade.Disabled = true;
            }
        }

        protected void btnAddAtvidade_Click(object sender, DirectEventArgs e)
        {

            if (dtPresenca.SelectedDate != DateTime.MinValue)
            {
                Usuario UserLogin = (Usuario)Session["Usuario"];

                int Id = int.Parse(Request.QueryString.Get("IdProf"));

                CRJFrequenciaNegocio objBO = new CRJFrequenciaNegocio();

                objBO.IncluirFrequencia(Id, dtPresenca.SelectedDate, UserLogin.DadosPessoais.IdPessoa);

                dtPresenca.Clear();
                btnAddAtvidade.Disabled = true;
                PopularGrid();
            }

        }

        protected void dtPresenca_Select(object sender, DirectEventArgs e)
        {
            if (dtPresenca.SelectedDate != DateTime.MinValue)
            {
                btnAddAtvidade.Disabled = false;
            }
        }

        private void PopularGrid()
        {
            int Id = int.Parse(Request.QueryString.Get("IdProf"));

            List<CRJFrequencia> objFreq = (new CRJFrequenciaNegocio().ObterCRJFrequencia(Id));

            StoreFrequencia.DataSource = objFreq;
            StoreFrequencia.DataBind();

            DesabilitarDatas(objFreq);
        }


        private void DesabilitarDatas(List<CRJFrequencia> objFreq)
        {

            foreach (CRJFrequencia item in objFreq)
            {
                if (!dtPresenca.DisabledDates.Contains(new DisabledDate(item.DataAula.AddDays(1))))
                    dtPresenca.DisabledDates.Add(new DisabledDate(item.DataAula.AddDays(1)));
            }

        }
    }
}