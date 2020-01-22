using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Entidade;
using Corujito.Entidade.Escola;
using Corujito.Negocio;
using Ext.Net;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class AcaoProfessor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario UserLogin = (Usuario)Session["Usuario"];

            lblprofessor.Html = " <h1>" + UserLogin.DadosPessoais.Nome + "</h1>";

            PopularGrid(UserLogin.DadosPessoais.IdPessoa);

        }

        private void PopularGrid(int IdPessoa)
        {

            List<CRJProfXMateriaXClasse> listMaterias = new List<CRJProfXMateriaXClasse>();
            CRJProfXMateriaXClasseBO objMateriaBO = new CRJProfXMateriaXClasseBO();


            listMaterias = objMateriaBO.ObterCRJProfXMateriaXClassePorProfessor(IdPessoa);


            StoreProfMateria.DataSource = listMaterias;
            StoreProfMateria.DataBind();




        }

        /// <summary>
        /// Método para Exibir a Tela de Cadastro de em Modal.
        /// </summary>
        /// <param name="pTitulo">Titulo da Janela Modal.</param>
        /// <param name="pURL">URL que a Modal irá chamar.</param>
        /// <param name="pAltura">Altura da Janela.</param>
        /// <param name="pLargura">Largura da Janela.</param>
        /// <param name="pModal">Indica se a janela será modal ou não. Podendo ser True para ser Modal, e False para Não ser Modal.</param>
        /// <param name="pResizable">Indica ser a janela poderá ser redimensionada. Podendo ser True para ser, e False para não ser redimensionada.</param>
        /// <param name="pIcon">Ícone da aplicação.</param>
        private void ExibirModalCadastro(string pTitulo, string pURL, int pAltura, int pLargura, bool pModal, bool pResizable, Icon pIcon)
        {
            this.ModalCadastro.Title = pTitulo;
            this.ModalCadastro.Icon = pIcon;
            this.ModalCadastro.AutoLoad.Url = pURL;
            this.ModalCadastro.AutoLoad.Mode = LoadMode.IFrame;
            this.ModalCadastro.Height = pAltura;
            this.ModalCadastro.Width = pLargura;
            this.ModalCadastro.Modal = pModal;
            this.ModalCadastro.Resizable = pResizable;
            this.ModalCadastro.Draggable = false;

            ModalCadastro.Render(this.Form, RenderMode.RenderTo);
            this.ModalCadastro.Show();
        }


        public void LinhaGrid_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {

            string idProfXMateriaXClasse = e.ExtraParams["idProfXMateriaXClasse"];
            string TitulodaPagina = e.ExtraParams["Titulo"];
            string IdClasse = e.ExtraParams["IdClasse"];

            if (e.ExtraParams["IDObjeto"] == "btnConsultarAtividade")
            {
                string URL = "PesquisaAtividade.aspx?IdProf=" + idProfXMateriaXClasse;
                URL += "&TitulodaPagina=" + TitulodaPagina;
                URL += "&IdClasse=" + e.ExtraParams["IdClasse"]; ;

                ExibirModalCadastro("Atividades", URL, 500, 790, true, true, Icon.FolderPage);
            }


            if (e.ExtraParams["IDObjeto"] == "btnFrquencia")
            {
                string URL = "LancamentoFrequencia.aspx?IdProf=" + idProfXMateriaXClasse;
                URL += "&TitulodaPagina=" + TitulodaPagina;
                URL += "&IdClasse=" + e.ExtraParams["IdClasse"];

                ExibirModalCadastro("Frequência - " + TitulodaPagina, URL, 560, 790, true, true, Icon.TableEdit);
            }

            if (e.ExtraParams["IDObjeto"] == "btnNotas")
            {
                string URL = "LancamentoNota.aspx?IdProf=" + idProfXMateriaXClasse;
                URL += "&TitulodaPagina=" + TitulodaPagina;
                URL += "&IdClasse=" + e.ExtraParams["IdClasse"];

                ExibirModalCadastro("Notas - " + TitulodaPagina, URL, 560, 790, true, true, Icon.Sum);
            }


        }

    }
}