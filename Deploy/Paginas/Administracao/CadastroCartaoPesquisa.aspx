<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroCartaoPesquisa.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroCartaoPesquisa" %>

<%@ Register Assembly="Ext.Net"     Namespace="Ext.Net"     TagPrefix="ext" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <u>Home > Administração > Cadastro Cartão</u>

    <br />
    <br />
    
     <ext:Panel ID="pnlTituloPagina" runat="server" AnchorHorizontal="100%" Title="Cartão" Icon="User" Frame="true" Border="true"
        PaddingSummary="10px 0px 10px 0px" >
        <Items>
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
                                        <ext:TextField ID="txtCPF"          runat="server" FieldLabel="CPF"    Width="140"      MaxLength="20" EmptyText="___.___.-__-__"/>
                                    </Items>
                                </ext:Container>
                                  <ext:Container ID="container3" runat="server" Layout="FormLayout" ColumnWidth="0.35" >
                                    <Items>
                                        <ext:TextField ID="txtTelefone"     runat="server" FieldLabel="Telefone"     Width="140"      MaxLength="20"  EmptyText="(__)____-____" />
                                    </Items>
                                </ext:Container>
                                  <ext:Container ID="container4" runat="server" Layout="FormLayout" ColumnWidth="0.3" >
                                    <Items>
                                        <ext:TextField ID="txtRA"           runat="server" FieldLabel="Registro"    Width="140"      MaxLength="20" />
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

	

			<ext:GridPanel ID="GridPesquisaCRJCartao" runat="server" StripeRows="true" Title="Resultados da pesquisa - Cadastro de Cartão" Icon="Table" TrackMouseOver="true"
                 AnchorHorizontal="100%" Height="350" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:10px;">

				<Store>
					<ext:Store ID="StoreCRJCartao" runat="server" >
						<Reader>
							<ext:JsonReader>
								<Fields>
									<ext:RecordField Name="IdPessoa"        Mapping="IdPessoa"          Type="Int" />
									<ext:RecordField Name="IdEscola"        Mapping="IdEscola"          Type="Int" />
									<ext:RecordField Name="Nome"            Mapping="Nome"              Type="String" />
									<ext:RecordField Name="Sexo"            Mapping="Sexo"              Type="String" />
									<ext:RecordField Name="Email"           Mapping="Email"             Type="String" />
									<ext:RecordField Name="DataNascimento"  Mapping="DataNascimento"    Type="Date" />
									<ext:RecordField Name="CPF"             Mapping="CPF"              Type="String" />
									<ext:RecordField Name="Telefone"        Mapping="Telefone"          Type="String" />
									<ext:RecordField Name="Celular"         Mapping="Celular"           Type="String" />
									<ext:RecordField Name="CEP"             Mapping="CEP"               Type="String" />
									<ext:RecordField Name="Logradouro"      Mapping="Logradouro"        Type="String" />
									<ext:RecordField Name="Numero"          Mapping="Numero"            Type="String" />
									<ext:RecordField Name="Bairro"          Mapping="Bairro"            Type="String" />
									<ext:RecordField Name="Estado"          Mapping="Estado"            Type="String" />
									<ext:RecordField Name="Pais"            Mapping="Pais"              Type="String" />
									<ext:RecordField Name="Ativo"           Mapping="Ativo" />
                                    <ext:RecordField Name="IdLancamentoCartao"        Mapping="IdLancamentoCartao" Type="Int" />
                                    <ext:RecordField Name="Valor"        Mapping="Valor" Type="Float" />
                                    <ext:RecordField Name="DataLancamento"        Mapping="DataLancamento" Type="Date" />
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>


				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
                        <ext:Column ColumnID="IdLancamentoCartao" Header="Cartão" DataIndex="IdLancamentoCartao" Align="Left"/>
                        <ext:Column ColumnID="CPF" Header="CPF" DataIndex="CPF" Align="Left"/>
                    	<ext:Column ColumnID="Nome" Header="Nome" DataIndex="Nome" Align="Left"/>
                        <ext:Column ColumnID="Valor" Header="Valor" DataIndex="Valor" Align="Left"/>
                        <ext:Column ColumnID="DataLancamento" Header="Data de Lancamento" DataIndex="DataLancamento" Align="Left"/>
                    
						<ext:ImageCommandColumn Width="25" ColumnID="BotaoAlterar">
							<Commands>
								<ext:ImageCommand CommandName="btnAlterar" Icon="Magnifier" Text="">
									<ToolTip Title="Alteração:" Text="Alterar o Registro Selecionado." />
								</ext:ImageCommand>
							</Commands>
						</ext:ImageCommandColumn>

					</Columns>
				</ColumnModel> 

				<SelectionModel>
                    <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi"   />
					<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
				</SelectionModel>

                <View>
                    <ext:GridView ID="gvCartao" runat="server" ForceFit="true"></ext:GridView>
                </View>

				<DirectEvents>
					<Command OnEvent="LinhaGrid_DirectClick">
						<EventMask ShowMask="true" MinDelay="10" />
						<ExtraParams>
							<ext:Parameter Value="record.data.IdCartao" Mode="Raw" Name="IdentificadorRegistroTabela"></ext:Parameter>
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

</asp:Content>
