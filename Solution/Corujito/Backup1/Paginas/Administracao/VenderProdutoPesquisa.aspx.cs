using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Corujito.Negocio;
using Corujito.Entidade;
using Corujito.Negocio.Escola;
using Corujito.Entidade.Escola;
using Ext.Net;
using Corujito.Apresentacao.UtilitarioExt;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class VendaProduto : System.Web.UI.Page
    {
        [DirectMethod(Namespace = "CompanyX", ShowMask = true)]
        public void afterEdit_AtualizarValor()
        {
            AtualizarTotal();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                popularProdutos();
                popularPessoas();

                StoreCRJProdutoVendido.DataSource = new List<CRJProdutoVendido>();
                StoreCRJProdutoVendido.DataBind();
            }
        }

        protected void popularProdutos()
        {

            CRJProdutoNegocio ProdutoBO = new CRJProdutoNegocio();
            List<CRJProduto> ProdutoColecao = new List<CRJProduto>();

            ProdutoColecao = ProdutoBO.ObterCRJProduto();

            StoreProduto.DataSource = ProdutoColecao;
            StoreProduto.DataBind();

        }

        protected void popularPessoas()
        {

            CRJPessoaNegocio PessoaBO = new CRJPessoaNegocio();
            List<CRJPessoa> PessoaColecao = new List<CRJPessoa>();

            PessoaColecao = PessoaBO.ObterCRJPessoa();

            StorePessoa.DataSource = PessoaColecao;
            StorePessoa.DataBind();

        }

        protected void cboPessoa_Select(object e, Ext.Net.DirectEventArgs sender)
        {

            CRJPessoaNegocio PessoaBO = new CRJPessoaNegocio();
            List<CRJPessoa> PessoaColecao = new List<CRJPessoa>();

            nomepessoa.Text = PessoaBO.ObterCRJPessoaPorId(int.Parse(cboPessoa.Value.ToString())).Nome;

        }

        protected void cboProduto_TriggerClick(object e, Ext.Net.DirectEventArgs sender)
        {
            if (!string.IsNullOrEmpty(cboProduto.SelectedItem.Value))
            {
                int addproduto = int.Parse(cboProduto.SelectedItem.Value);


                CRJProdutoNegocio ProdutoBO = new CRJProdutoNegocio();
                CRJProduto ProdutoColecao = new CRJProduto();

                ProdutoColecao = ProdutoBO.ObterCRJProdutoPorId(addproduto);

                CRJProdutoVendido produtovenda = new CRJProdutoVendido();

                produtovenda.Produto = ProdutoColecao;
                produtovenda.Nome = ProdutoColecao.Nome;
                produtovenda.Preco = ProdutoColecao.Preco;
                produtovenda.IdProduto = ProdutoColecao.IdProduto;

                GridCRJProdutoVendido.AddRecord(produtovenda, true);
                GridCRJProdutoVendido.GetView().Refresh();

                //StoreCRJProdutoVendido.AddRecord(produtovenda, true);

                cboProduto.Clear();
            }
        }

        private List<CRJProdutoVendido> PopularEntidadeProdutos(string strSjon)
        {
            List<CRJProdutoVendido> listProdutos = new List<CRJProdutoVendido>();

            listProdutos = JSON.Deserialize<List<CRJProdutoVendido>>(strSjon);

            return listProdutos;


        }

        private float AtualizarTotal()
        {
            List<CRJProdutoVendido> listProdutos = PopularEntidadeProdutos(GridData.Text);

            float valorTotal = 0;
            int qtd = 0;

            foreach (CRJProdutoVendido item in listProdutos)
            {
                valorTotal += item.ValorTotal;
                qtd += item.Quantidade;
            }

            lblValorTotal.Text = string.Format("{0:c2}", valorTotal);

            return valorTotal;
        }

        public void btnVender_Click(object sender, Ext.Net.DirectEventArgs e)
        {

            UtilitariosExt util = new UtilitariosExt();
            util.MensagemAlerta("Atenção", "Você tem certeza que deseja finalizar a venda?", "Incluir()", "");

        }


        [DirectMethod(ShowMask = true)]
        public void Incluir()
        {
            List<CRJProdutoVendido> listProdutos = PopularEntidadeProdutos(GridData.Text);
            CRJVendaProduto Venda = new CRJVendaProduto();

            Venda.DataVenda = DateTime.Now;
            Venda.IdPessoa = int.Parse(cboPessoa.SelectedItem.Value);
            Venda.ValorTotal = AtualizarTotal();


            CRJVendaProdutoNegocio objProdutoBO = new CRJVendaProdutoNegocio();

            objProdutoBO.Incluir(Venda, listProdutos);


            UtilitariosExt util = new UtilitariosExt();
            util.MensagemAlerta("Atenção", "Venda realizada com sucesso!", "CliqueBotaoSim()");
            util = null;

        }

        [DirectMethod]
        public void CliqueBotaoSim()
        {
            X.Redirect("VenderProdutoPesquisa.aspx", "Carregando...");
        }
    }
}