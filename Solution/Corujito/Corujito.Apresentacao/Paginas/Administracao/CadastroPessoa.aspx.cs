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
using Corujito.Entidade.Escola;
using Corujito.Negocio.Escola;

namespace Corujito.Apresentacao.Paginas.Administracao
{
    public partial class CadastroPessoa : System.Web.UI.Page
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
            Response.Redirect("CadastroPessoaPesquisa.aspx");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qID"></param>
        [DirectMethod]
        public void CliqueMensagemIncluidoComSucesso(int qID)
        {
            Response.Redirect("CadastroPessoa.aspx?qTela=Alterar&qID=" + qID.ToString());
        }

        [DirectMethod]
        public void CliqueBotaoSimMensagemExclusaoResponsavelAluno(int IdResponsavelAluno)
        {
            CRJPessoaNegocio objNegocio = new CRJPessoaNegocio();
            objNegocio.ExcluirResponsavelXAluno(IdResponsavelAluno);

            PopularGridResponsavelXAluno();
        }







        #endregion

        #region Métodos Privados da Página

        /// <summary>
        /// Método que cria e retorna a Entidade populada com os valores dos campos do Formulário.
        /// </summary>
        /// <returns>Entidate preenchida com os valores dos campos do Formulário.</returns>
        private CRJPessoa PopularEntidade()
        {
            //Declarando e Instânciando a Entidade.
            CRJPessoa objCRJPessoa = new CRJPessoa();

            ////Atribui os valores passados no página para as propriedades da Entidade.
            objCRJPessoa.IdPessoa = (Request.QueryString.Get("qID") == null ? 0 : int.Parse(Request.QueryString.Get("qID")));

            ////dados pessoais
            objCRJPessoa.Nome = txtNome.Text.Trim();
            objCRJPessoa.Email = txtEmail.Text.Trim();
            objCRJPessoa.Telefone = txtTelefone.Text.Trim();
            objCRJPessoa.Celular = txtCelular.Text.Trim();
            objCRJPessoa.CPF = txtCPF.Text.Trim();
            objCRJPessoa.DataNascimento = txtDataNascimento.SelectedDate;
            objCRJPessoa.RG = txtRG.Text;

            objCRJPessoa.Sexo = int.Parse(cboSexo.SelectedItem.Value) == 1 ? CRJPessoa.TipoSexo.M : CRJPessoa.TipoSexo.F;

            objCRJPessoa.Status = new CRJStatus();
            objCRJPessoa.Status.IdStatus = int.Parse(cboAtivo.SelectedItem.Value);

            ////endereço
            objCRJPessoa.CEP = txtCEP.Text.Trim();
            objCRJPessoa.Logradouro = txtLogradouro.Text.Trim();
            objCRJPessoa.Numero = txtNumero.Text.Trim();
            objCRJPessoa.Bairro = txtBairro.Text.Trim();

            objCRJPessoa.Cidade = txtCidade.SelectedItem.Text;
            objCRJPessoa.Estado = txtEstado.SelectedItem.Text;
            objCRJPessoa.Pais = txtPais.SelectedItem.Text;

            objCRJPessoa.Complemento = txtComplemento.Text;
            objCRJPessoa.URL = txtURL.Text;

            objCRJPessoa.TiposPessoa = new List<CRJTipoPessoa>();

            foreach (Control c in fdsTipoPessoa.Items)
            {
                if (c is Ext.Net.Checkbox)
                {
                    if (((Ext.Net.Checkbox)c).Checked)
                    {
                        int IdTipoPessoa = int.Parse(((Ext.Net.Checkbox)c).DirectEvents.Check.ExtraParams["IdTipoPessoa"]);
                        objCRJPessoa.TiposPessoa.Add(new CRJTipoPessoaNegocio().ObterCRJTipoPessoaPorId(IdTipoPessoa));
                    }
                }
            }


            return objCRJPessoa;
        }

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
                //ocultos
                txtIdPessoa.Text = objCRJPessoa.IdPessoa.ToString();

                //Dados pessoais                
                txtNome.Text = objCRJPessoa.Nome.ToString();
                txtEmail.Text = objCRJPessoa.Email;
                txtTelefone.Text = objCRJPessoa.Telefone;
                txtCelular.Text = objCRJPessoa.Celular;
                txtCPF.Text = objCRJPessoa.CPF;
                txtDataNascimento.SelectedDate = objCRJPessoa.DataNascimento;
                cboSexo.SelectedItem.Value = Convert.ToInt32(objCRJPessoa.Sexo).ToString();
                cboAtivo.SelectedItem.Value = objCRJPessoa.Status.IdStatus.ToString();
                txtRG.Text = objCRJPessoa.RG;

                //Endereço
                txtCEP.Text = objCRJPessoa.CEP;
                txtLogradouro.Text = objCRJPessoa.Logradouro;
                txtNumero.Text = objCRJPessoa.Numero;
                txtBairro.Text = objCRJPessoa.Bairro;
                //txtEstado.Text = objCRJPessoa.Estado;

                txtPais.Text = objCRJPessoa.Pais;
                txtEstado.SelectedItem.Text = objCRJPessoa.Estado;
                PopularCidade(null, null);
                txtCidade.SelectedItem.Text = objCRJPessoa.Cidade;

                txtIdAluno.Text = objCRJPessoa.IdAluno.ToString();

                txtURL.Text = objCRJPessoa.URL;
                txtComplemento.Text = objCRJPessoa.Complemento;

                if (objCRJPessoa.TiposPessoa.Where(x => x.IdTipoPessoa == (int)Constantes.TipoPessoa.Aluno).Count() > 0)
                {
                    PanelResponsaveis.Disabled = false;
                }
                else
                {
                    PanelResponsaveis.Disabled = true;
                }

                if (objCRJPessoa.TiposPessoa.Where(x => x.IdTipoPessoa == (int)Constantes.TipoPessoa.Responsavel).Count() > 0)
                {

                    PanelCadastroDependentes.Disabled = false;
                }
                else
                {

                    PanelCadastroDependentes.Disabled = true;
                }


                foreach (Control c in fdsTipoPessoa.Items)
                {
                    if (c is Ext.Net.Checkbox)
                    {
                        int IdTipoPessoa = int.Parse(((Ext.Net.Checkbox)c).DirectEvents.Check.ExtraParams["IdTipoPessoa"]);

                        if (objCRJPessoa.TiposPessoa.Find(delegate(CRJTipoPessoa p) { return p.IdTipoPessoa == IdTipoPessoa; }) != null)
                        {
                            ((Ext.Net.Checkbox)c).Checked = true;
                        }

                    }
                }


                PopularGridResponsavelXAluno();

                DesabilitarBotoes(objCRJPessoa);


            }
            else
            {
                //Exibe mensagem para o usuário.
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Atenção", MessageBox.Icon.WARNING, MessageBox.Button.OK, "Não existe um registro com o Identificador " + txtIdPessoa.RawText, "");
                UtilExt = null;

                txtIdPessoa.Text = "0";

            }
            //Finalizando os objetos.

            objCRJPessoa = null;
            objCRJPessoaNegocio = null;
        }

        /// <summary>
        /// Incluir um objeto no Banco.
        /// </summary>
        private void Incluir()
        {

            //Declara, Instancia, e Preenche a Entidade.
            CRJPessoa objCRJPessoa = PopularEntidade();

            //Declarando e Instânciando a classe de Negócio para Persistir o objeto objCRJPessoa.
            CRJPessoaNegocio objCRJPessoaNegocio = new CRJPessoaNegocio();

            //Executando método para Incluir na Base de Dados o objeto objCRJPessoa e armazenando o resultado obtido na variável Resultado.
            string Retorno = objCRJPessoaNegocio.Incluir(objCRJPessoa, txtSenha.Text);

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
                txtIdPessoa.Text = Retorno;

            }

            //Finalizando as variáveis de Negócio.
            objCRJPessoaNegocio = null;



        }

        /// <summary>
        /// Alterar um objeto no Banco.
        /// </summary>
        private void Alterar()
        {
            //Declara, Instancia, e Preenche a Entidade.
            CRJPessoa objCRJPessoa = PopularEntidade();

            //Declarando e Instânciando a classe de Negócio para Persistir o objeto objCRJPessoa.
            CRJPessoaNegocio objCRJPessoaNegocio = new CRJPessoaNegocio();

            //Executando método para Alterar na Base de Dados o objeto objCRJPessoa e armazenando o resultado obtido na variável Resultado.
            string Retorno = objCRJPessoaNegocio.Alterar(objCRJPessoa);


            //Se o Retorno do método Alterar for um valor númerico maior que 0, então significa Sucesso.
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
                UtilExt.MensagemAlerta("Atenção", "Registro salvo com sucesso.", "CliqueBotaoOkMensagemInclusaoSucesso()");
                UtilExt = null;
            }


            //Finalizando a classe de Negócio.
            objCRJPessoaNegocio = null;

        }

        private void PopularCboStatus()
        {
            List<CRJStatus> objStatus = new List<CRJStatus>();
            CRJStatusNegocio objStatusBO = new CRJStatusNegocio();

            objStatus = objStatusBO.ObterCRJStatus();

            if (objStatus != null)
            {
                storeSituacao.DataSource = objStatus;
                storeSituacao.DataBind();
            }
            objStatus = null;
            objStatusBO = null;
        }

        private void PopularGridResponsavelXAluno()
        {

            int IdPessoa = !string.IsNullOrEmpty(txtIdPessoa.Text) ? int.Parse(txtIdPessoa.Text) : 0;
            int IdAluno = !string.IsNullOrEmpty(txtIdAluno.Text) ? int.Parse(txtIdAluno.Text) : 0;

            StoreResponsaveis.DataSource = (new CRJPessoaNegocio().ObterResponsaveisPorDependente(IdAluno));
            StoreResponsaveis.DataBind();


            StoreDependentes.DataSource = (new CRJPessoaNegocio().ObterDependentesPorResponsavel(IdPessoa));
            StoreDependentes.DataBind();

        }

        protected void popularPessoas()
        {

            CRJPessoaNegocio PessoaBO = new CRJPessoaNegocio();
            List<CRJPessoa> PessoaColecao = new List<CRJPessoa>();

            PessoaColecao = PessoaBO.ObterCRJPessoa();

            StorePessoaDependente.DataSource = PessoaBO.ObterDependentesDisponiveis();
            StorePessoaDependente.DataBind();

            StorePessoaResponsavel.DataSource = PessoaBO.ObterResponsaveisDisponiveis();
            StorePessoaResponsavel.DataBind();

        }




        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            //Verifica se NÃO é um Requisição Ajax. Ou seja se é a primeira vez que a página é carregada.
            if (!X.IsAjaxRequest)
            {
                popularPessoas();
                PopularCboStatus();
                PopularComboEstado();

                //Verifica se existe um valor na QueryString vinda da página de pesquisa.
                //Se existir, então escreve no campo que é a Chave Primária da tabela.
                if (Request.QueryString.Get("qID") != null)
                {
                    txtIdPessoa.Text = Request.QueryString.Get("qID");
                    ObterDadosPorID(int.Parse(txtIdPessoa.Text));

                }
                else
                {
                    if (Session["Usuario"] != null)
                    {
                        Usuario objUsuarioLogado = (Usuario)Session["Usuario"];
                        if (objUsuarioLogado != null)
                        {
                            DesabilitarBotoes(null);
                        }
                    }
                }

                if (Request.QueryString.Get("qTela") == "Consultar")
                {

                    ToolbarDependenes.Hidden = true;
                    topbarResponsavel.Hidden = true;

                    foreach (Control item in fdsTipoPessoa.Items)
                    {
                        if (item is Ext.Net.Checkbox)
                        {
                            if (!((Ext.Net.Checkbox)item).Checked)
                            {
                                ((Ext.Net.Checkbox)item).Hidden = true;
                            }
                        }
                    }

                    int totalColunas = GridResponsaveis.ColumnModel.Columns.Count;
                    GridResponsaveis.ColumnModel.Columns[totalColunas - 1].Hidden = true;

                    totalColunas = GridPanelDependentes.ColumnModel.Columns.Count;
                    GridPanelDependentes.ColumnModel.Columns[totalColunas - 1].Hidden = true;


                    UtilitariosExt util = new UtilitariosExt();
                    util.DesabilitarControles(PanelCadastroPessoa, true);
                    btnCancelar.Hidden = true;
                    btnGravar.Hidden = true;
                    txtSenha.Hidden = true;

                }


            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            PopularTipoUsuario();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        private void DesabilitarBotoes(CRJPessoa User)
        {
            if (User != null)
            {
                txtEmail.Disabled = true;

                lkbAlterarSenha.Hidden = false;

                txtConfrimSenha.AllowBlank = true;
                txtSenha.AllowBlank = true;
            }
            else
            {

                lkbAlterarSenha.Hidden = true;
                txtConfrimSenha.Hidden = false;
                txtSenha.Hidden = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGravar_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            //Armazenar na variável FormularioValido se o Form é válido ou não.
            bool FormularioValido = Convert.ToBoolean(e.ExtraParams["FormularioValido"]);

            if (FormularioValido == true)
            {
                //Se a QueryString for NULL, então é uma Inclusão. Caso contrário é uma Alteração.
                if (Request.QueryString.Get("qID") == null && txtIdPessoa.Text == "0")
                {
                    if (txtSenha.Text == txtConfrimSenha.Text)
                    {
                        Incluir();
                    }
                    else
                    {
                        UtilitariosExt UtilExt = new UtilitariosExt();
                        UtilExt.MensagemAlerta("Atenção", "O campo senha deve ser igual ao campo confirmar senha.", "");
                        UtilExt = null;
                    }
                }
                else
                {
                    UtilitariosExt UtilExt = new UtilitariosExt();
                    UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Alterar o registro?", "CliqueBotaoSimMensagemAlteracao()", "");
                    UtilExt = null;
                }
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelar_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            CliqueBotaoOkMensagemInclusaoSucesso();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbAlterarSenha_Click(object sender, Ext.Net.DirectEventArgs e)
        {

            if (Request.QueryString.Get("qTela") != "Incluir")
            {
                bool Hidden = false;

                txtSenha.Hidden = Hidden;
                txtConfrimSenha.Hidden = Hidden;

                txtSenha.AllowBlank = Hidden;
                txtConfrimSenha.AllowBlank = Hidden;

                lkbAlterarSenha.Hidden = true;
                lkbCancelar.Hidden = false;

            }
            else
            {
                txtSenha.Hidden = false;
                txtConfrimSenha.Hidden = false;
                txtConfrimSenha.AllowBlank = false;
                txtSenha.AllowBlank = false;

                lkbAlterarSenha.Hidden = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbCancelar_Click(object sender, Ext.Net.DirectEventArgs e)
        {

            if (Request.QueryString.Get("qTela") != "Incluir")
            {
                bool Hidden = true;

                txtSenha.Clear();
                txtConfrimSenha.Clear();

                txtSenha.Hidden = Hidden;
                txtConfrimSenha.Hidden = Hidden;

                txtSenha.AllowBlank = Hidden;
                txtConfrimSenha.AllowBlank = Hidden;

                lkbAlterarSenha.Hidden = false;
                lkbCancelar.Hidden = true;
            }
            else
            {
                txtSenha.Hidden = false;
                txtConfrimSenha.Hidden = false;
                txtConfrimSenha.AllowBlank = false;
                txtSenha.AllowBlank = false;

                lkbAlterarSenha.Hidden = true;
            }
        }

        [DirectMethod]
        public void chkTipoPessoa_Check(object sender, DirectEventArgs e)
        {
            Checkbox chk = (Checkbox)sender;
            int IdTipoPessoa = int.Parse(e.ExtraParams["IdTipoPessoa"]);

            if (chk != null)
            {
                if (IdTipoPessoa == (int)Constantes.TipoPessoa.Aluno)
                    PanelResponsaveis.Disabled = !chk.Checked;

                if (IdTipoPessoa == (int)Constantes.TipoPessoa.Responsavel)
                    PanelCadastroDependentes.Disabled = !chk.Checked;
            }

        }


        private Ext.Net.Checkbox NewCheckBoxFrom(CRJTipoPessoa objTipoPessoa)
        {
            if (objTipoPessoa != null)
            {
                Ext.Net.Checkbox chk = new Checkbox();
                chk.ID = "Checkbox_" + objTipoPessoa.IdTipoPessoa.ToString();
                chk.BoxLabel = objTipoPessoa.Descricao;
                chk.StyleSpec = "margin-left:20px";
                chk.LabelAlign = LabelAlign.Left;

                chk.DirectEvents.Check.Event += new ComponentDirectEvent.DirectEventHandler(chkTipoPessoa_Check);
                chk.DirectEvents.Check.EventMask.ShowMask = true;
                chk.DirectEvents.Check.ExtraParams.Add(new Ext.Net.Parameter { Name = "IdTipoPessoa", Mode = ParameterMode.Value, Value = objTipoPessoa.IdTipoPessoa.ToString() });

                return chk;
            }
            else
            {
                return null;
            }
        }

        private void PopularTipoUsuario()
        {
            List<CRJTipoPessoa> listTipoPessoa = new List<CRJTipoPessoa>();
            CRJTipoPessoaNegocio objTipoPessoaBO = new CRJTipoPessoaNegocio();

            listTipoPessoa = objTipoPessoaBO.ObterCRJTipoPessoa();

            foreach (CRJTipoPessoa item in listTipoPessoa)
            {
                fdsTipoPessoa.Items.Add(NewCheckBoxFrom(item));
            }


        }

        public void PopularCidade(object sender, Ext.Net.DirectEventArgs e)
        {

            int idestado = 0;

            if (int.TryParse(txtEstado.SelectedItem.Value, out idestado) == false)
            {
                idestado = 0;
            }


            if (idestado > 0)
            {
                storeCidade.DataSource = (new CidadeNegocio().ObterCidade(idestado));
                storeCidade.DataBind();
                txtCidade.Clear();
            }
        }

        private void PopularComboEstado()
        {
            storeEstado.DataSource = (new EstadoNegocio().ObterEstado());
            storeEstado.DataBind();
        }

        public void txtCPF_Chance(object sender, Ext.Net.DirectEventArgs e)
        {

            if (!UtilitarioBO.CPFValido(txtCPF.Text))
            {
                if (!string.IsNullOrEmpty(txtCPF.Text))
                {
                    UtilitariosExt util = new UtilitariosExt();
                    util.MensagemAlerta("Atenção", "O CPF " + txtCPF.Text + " é inválido!", "");
                    util = null;
                    txtCPF.Clear();
                    txtCPF.Focus();
                }
            }


        }

        public void txtRG_Chance(object sender, Ext.Net.DirectEventArgs e)
        {
            if (!UtilitarioBO.RGValido(txtRG.Text))
            {
                if (!string.IsNullOrEmpty(txtRG.Text))
                {
                    UtilitariosExt util = new UtilitariosExt();
                    util.MensagemAlerta("Atenção", "O RG " + txtRG.Text + " é inválido!", "");
                    util = null;
                    txtRG.Clear();
                    txtRG.Focus();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinhaGrid_DirectClick(object sender, DirectEventArgs e)
        {
            //Obter o ID do registro selecionado na Grid.
            string IDTabela;
            IDTabela = e.ExtraParams["IdentificadorRegistroTabela"];

            //Se o click foi no botão Remover.
            if (e.ExtraParams["IDObjeto"] == "btnRemover")
            {
                UtilitariosExt UtilExt = new UtilitariosExt();
                UtilExt.MensagemAlerta("Confirmação", "Você tem certeza que deseja Excluir o registro?", "CliqueBotaoSimMensagemExclusaoResponsavelAluno(" + int.Parse(IDTabela) + ")", "");
                UtilExt = null;
            }

        }

        public void btnAddResponsavel_Click(object sender, DirectEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cboPessoaResponsavel.SelectedItem.Value))
                {
                    int IdAluno = !string.IsNullOrEmpty(txtIdAluno.Text) ? int.Parse(txtIdAluno.Text) : 0;
                    
                    int IdResponsavel = int.Parse(cboPessoaResponsavel.SelectedItem.Value);
                    CRJPessoaNegocio objBO = new CRJPessoaNegocio();

                    objBO.InserirResponsaveisXAluno(IdAluno, IdResponsavel);

                    PopularGridResponsavelXAluno();
                    cboPessoaResponsavel.Clear();
                }
                else
                {
                    UtilitariosExt util = new UtilitariosExt();
                    util.MensagemAlerta("Atenção", "Selecione uma pessoa e clique em adicionar.", "");
                    util = null;
                }
            }
            catch (Exception ex)
            {
                UtilitariosExt util = new UtilitariosExt();
                util.MensagemAlerta("Atenção", "Está pessoa já está relacionada como responsavel para este aluno.", "");
                util = null;
            }
        }

        public void btnAddDependente_Click(object sender, DirectEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cboPessoaDependente.SelectedItem.Value))
                {
                    int IdResponsavel = !string.IsNullOrEmpty(txtIdPessoa.Text) ? int.Parse(txtIdPessoa.Text) : 0;
                    int IdAluno = int.Parse(cboPessoaDependente.SelectedItem.Value);
                    CRJPessoaNegocio objBO = new CRJPessoaNegocio();

                    objBO.InserirResponsaveisXAluno(IdAluno, IdResponsavel);

                    PopularGridResponsavelXAluno();

                    cboPessoaDependente.Clear();
                }
                else
                {
                    UtilitariosExt util = new UtilitariosExt();
                    util.MensagemAlerta("Atenção", "Selecione uma pessoa e clique em adicionar.", "");
                    util = null;
                }
            }
            catch (Exception ex)
            {
                UtilitariosExt util = new UtilitariosExt();
                util.MensagemAlerta("Atenção", "Está pessoa já está relacionada como responsavel para este aluno.", "");
                util = null;
            }
        }

        public void btnConsultarCartao_Click(object sender, DirectEventArgs e)
        {
            string URL = "CadastroCartao.aspx?qID=" + txtIdPessoa.Text;
            URL += "&qTela=Consultar";
            ExibirModalCadastro("Cartão", URL, 450, 700, true, false, Icon.Money);
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


    }

}