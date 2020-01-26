<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroPessoaPesquisa.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroPessoaPesquisa" %>

<%@ Register Assembly="Ext.Net"     Namespace="Ext.Net"     TagPrefix="ext" %>
<%@ Register Assembly="Ext.Net.UX"  Namespace="Ext.Net.UX"  TagPrefix="ux" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        
          function hideModal() {
        win = <%= ModalCadastro.ClientID %>;
        win.hide(null);
    };
      
    </script>

   

       <u>Home > Administração > Cadastro Pessoa</u>

    <br />
    <br />
    
     <ext:Panel ID="pnlTituloPagina" runat="server" AnchorHorizontal="100%" Title="Pessoas" Icon="User" Frame="true" Border="true"
        PaddingSummary="10px 0px 10px 0px" >
        <Items>


        <ext:Button ID="btnCadastrarNovo" runat="server" Icon="Add" Text="Cadastrar Novo" Height="20" Width="150" ToolTip="Cadastrar um registro Novo." >
			<DirectEvents>
				<Click OnEvent="btnCadastrarNovo_DirectClick">
					<EventMask ShowMask="true" MinDelay="10"/>
				</Click>
			</DirectEvents>
		</ext:Button>

				

		<ext:Panel ID="PanelParametrosPesquisa" runat="server" Title="Parâmetros da Pesquisa" Icon="Magnifier" AnchorHorizontal="100%"
            Frame="true" ButtonAlign="Right" Collapsible="true" StyleSpec="margin-top:10px;" Height="170">

			<Items>

				<ext:FormPanel ID="FormPanelParametrosPesquisa" runat="server" LabelWidth="70" ButtonAlign="Right" Border="false" LabelAlign="Left" 
                    PaddingSummary="10px 10px 0px" AnchorHorizontal="100%" >
					<Items>

                        <ext:TextField ID="txtNome"         runat="server" FieldLabel="Nome"    AnchorHorizontal="98.2%"       MaxLength="255"  />
                        <ext:TextField ID="txtEmail"        runat="server" FieldLabel="E-mail"  AnchorHorizontal="98.2%"      MaxLength="255"/>
                        
                        <ext:Container ID="container1" runat="server" Layout="ColumnLayout" Height="30">
                            <Items>
                                <ext:Container ID="container2" runat="server" Layout="FormLayout" ColumnWidth="0.35" >
                                    <Items>
                                        <ext:TextField ID="txtCPF"          runat="server" FieldLabel="CPF"    Width="140"      MaxLength="20" EmptyText="___.___.___-__">
                                            <Plugins>
                                                <ux:InputTextMask Id="InputTextMask3" runat="server" Mask="999.999.999-99"></ux:InputTextMask>
                                            </Plugins>
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                  <ext:Container ID="container3" runat="server" Layout="FormLayout" ColumnWidth="0.35" >
                                    <Items>
                                        <ext:TextField ID="txtTelefone"     runat="server" FieldLabel="Telefone"     Width="140"      MaxLength="20"  EmptyText="(__)____-____" >
                                            <Plugins>
                                                <ux:InputTextMask Id="InputTextMask1" runat="server" Mask="(99)9999-9999"></ux:InputTextMask>
                                            </Plugins> 
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                  <ext:Container ID="container4" runat="server" Layout="FormLayout" ColumnWidth="0.3" >
                                    <Items>
                                        <ext:TextField ID="txtRA"           runat="server" FieldLabel="Registro"    Width="140"      MaxLength="20" Hidden="true" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>

                    </Items>

					<Buttons>

						<ext:Button ID="btnPesquisar" runat="server" Icon="Magnifier" Text="Pesquisar" Height="20" Width="110" ToolTip="Pesquisar registros."  >
							<DirectEvents>
								<Click OnEvent="btnPesquisar_DirectClick">
									<EventMask ShowMask="true" MinDelay="10" />
								</Click>
							</DirectEvents>
						</ext:Button>


					</Buttons>


				</ext:FormPanel>

			</Items>

		</ext:Panel>

	

			<ext:GridPanel ID="GridPesquisaCRJPessoa" runat="server" StripeRows="true" Title="Resultados da pesquisa - Cadastro de Pessoas" Icon="Table" TrackMouseOver="true"
                 AnchorHorizontal="100%" Height="350" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:10px;">

				<Store>
					<ext:Store ID="StoreCRJPessoa" runat="server" >
						<Reader>
							<ext:JsonReader>
								<Fields>
									<ext:RecordField Name="IdPessoa"        Mapping="IdPessoa"          Type="Int" />
									<ext:RecordField Name="IdEscola"        Mapping="IdEscola"          Type="Int" />
									<ext:RecordField Name="Nome"            Mapping="Nome"              Type="String" />
									<ext:RecordField Name="Sexo"            Mapping="SexoDescricao"     Type="String" />
									<ext:RecordField Name="Email"           Mapping="Email"             Type="String" />
									<ext:RecordField Name="DataNascimento"  Mapping="DataNascimento"    Type="Date" />
									<ext:RecordField Name="CPF"             Mapping ="CPF"              Type="String" />
									<ext:RecordField Name="Telefone"        Mapping="Telefone"          Type="String" />
									<ext:RecordField Name="Celular"         Mapping="Celular"           Type="String" />
									<ext:RecordField Name="CEP"             Mapping="CEP"               Type="String" />
									<ext:RecordField Name="Logradouro"      Mapping="Logradouro"        Type="String" />
									<ext:RecordField Name="Numero"          Mapping="Numero"            Type="String" />
									<ext:RecordField Name="Bairro"          Mapping="Bairro"            Type="String" />
									<ext:RecordField Name="Estado"          Mapping="Estado"            Type="String" />
									<ext:RecordField Name="Pais"            Mapping="Pais"              Type="String" />
									<ext:RecordField Name="Situacao"  ServerMapping="Status.Descricao" Type="String"/>
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>


				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
                    
                    	<ext:Column ColumnID="Nome"     Header="Nome"       DataIndex="Nome"  Width="435" Align="Left"/>
                        						
                        <ext:Column ColumnID="Sexo"     Header="Sexo"       DataIndex="Sexo" Align="Center" Width="70" >					
                        
                        </ext:Column>
						
                        <ext:DateColumn ColumnID="DataNascimento"   Header="Data de Nascimento" DataIndex="DataNascimento" Format="dd/MM/yyyy" Align="Center" Width="110"/>
						
                        <ext:Column ColumnID="Situacao"    Header="Situação"  DataIndex="Situacao"  Width="70" Align="Center">
                           
                        </ext:Column>

						<ext:ImageCommandColumn Width="25" ColumnID="BotaoVisualizar">
							<Commands>
								<ext:ImageCommand CommandName="btnVisualizar" Icon="Magnifier" Text="">
									<ToolTip Title="Visualização:" Text="Visualizar o Registro Selecionado." />
								</ext:ImageCommand>
							</Commands>
						</ext:ImageCommandColumn>

						<ext:ImageCommandColumn Width="25" ColumnID="BotaoAlterar">
							<Commands>
								<ext:ImageCommand CommandName="btnAlterar" Icon="PageWhiteEdit" Text="">
									<ToolTip Title="Alteração:" Text="Alterar o Registro Selecionado." />
								</ext:ImageCommand>
							</Commands>
						</ext:ImageCommandColumn>

                        
						<ext:ImageCommandColumn Width="25" ColumnID="BotaoCartao">
							<Commands>
								<ext:ImageCommand CommandName="btnCartao" Icon="Money" Text="">
									<ToolTip Title="Cartão" Text="Cartão" />
								</ext:ImageCommand>
							</Commands>
						</ext:ImageCommandColumn>
						<%--<ext:ImageCommandColumn Width="25" ColumnID="BotaoRemover">
							<Commands>
								<ext:ImageCommand CommandName="btnRemover" Icon="Delete" Text="">
									<ToolTip Title="Exclusão:" Text="Remove o Registro Selecionado." />
								</ext:ImageCommand>
							</Commands>
						</ext:ImageCommandColumn>--%>

					</Columns>
				</ColumnModel>

				<SelectionModel>
					<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
				</SelectionModel>

				<DirectEvents>
					<Command OnEvent="LinhaGrid_DirectClick">
						<EventMask ShowMask="true" MinDelay="10" />
						<ExtraParams>
							<ext:Parameter Value="record.data.IdPessoa" Mode="Raw" Name="IdentificadorRegistroTabela"></ext:Parameter>
							<ext:Parameter Value="command" Mode="Raw" Name="IDObjeto"></ext:Parameter>
						</ExtraParams>
					</Command>
				</DirectEvents>

				<BottomBar>
					<ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="5" EmptyMsg="Não existem dados para serem mostrados." DisplayMsg="<b>{0} a {1} de {2} registro(s)</b>">
						<Items>
							<ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />

							<ext:ComboBox ID="cboPageSize" runat="server" Grow="true" FieldLabel="Registros por página">
								<Items>
									<ext:ListItem Text="1" />
									<ext:ListItem Text="5" />
									<ext:ListItem Text="10" />
									<ext:ListItem Text="15" />
									<ext:ListItem Text="20" />
									<ext:ListItem Text="100" />
							</Items>

								<SelectedItem Value="10" />

								<Listeners>
									<Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
									<AfterRender Handler="#{cboPageSize}.setValue(10);" ></AfterRender>
								</Listeners>
							</ext:ComboBox>

						</Items>
					</ext:PagingToolbar>
				</BottomBar>

			</ext:GridPanel>

        </Items>
    </ext:Panel>
    
    <ext:Window ID="ModalCadastro" runat="server" BodyStyle="background-color: #FFFFFF;"        
        PaddingSummary="10px 10px 10px 10px" Hidden="true">
        <Content>
        </Content>
     <%--   <DirectEvents>
				<BeforeHide OnEvent="ModalCadastro_BeforeHide"></BeforeHide>
			</DirectEvents>--%>
    </ext:Window>


</asp:Content>
