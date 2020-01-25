<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroEscolaPesquisa.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroEscolaPesquisa" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
   
    
    <ext:Button ID="btnCadastrarNovo" runat="server" Icon="Add" Text="Cadastrar Novo"
        Height="20" Width="150" ToolTip="Cadastrar um registro Novo." >
        <DirectEvents>
				<Click OnEvent="btnCadastrarNovo_DirectClick">
					<EventMask ShowMask="true" MinDelay="10"/>
				</Click>
			</DirectEvents>
    </ext:Button>
    
    <br />

    <ext:KeyMap ID="KeyMapPesquisa" runat="server" Target="Ext.getBody()">
        <ext:KeyBinding>
            <Keys>
                <ext:Key Code="ENTER" />
            </Keys>
            <Listeners>
					<Event Handler="#{btnPesquisar}.fireEvent('click');" />
				</Listeners>
        </ext:KeyBinding>
    </ext:KeyMap>

    <ext:Panel ID="PanelParametrosPesquisa" runat="server" Title="Parâmetros da Pesquisa"
        Icon="Magnifier" AnchorHorizontal="95%" Height="130" Frame="true" ButtonAlign="Right"
        Collapsible="true">
        <Items>
            <ext:FormPanel ID="FormPanelParametrosPesquisa" runat="server" LabelWidth="100" ButtonAlign="Right"
                Border="false" LabelAlign="Top" PaddingSummary="0px 0px 0px">
                <Defaults>
                    <ext:Parameter Name="MsgTarget" Value="side" />
                </Defaults>
                <Items>
                    <ext:TextField ID="txtParametroPesquisa" runat="server" AnchorHorizontal="100%" MaxLength="50"
                        FieldLabel="Pesquisar" LabelWidth="100">
                    </ext:TextField>
                </Items>
                <Buttons>
                    <ext:Button ID="btnPesquisar" runat="server" Icon="Magnifier" Text="Pesquisar" Height="20"
                        Width="110" ToolTip="Pesquisar registros.">
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
    <br />
    <div>
        <ext:GridPanel ID="GridPesquisaCRJEscola" runat="server" StripeRows="true" Title="Resultado da Pesquisa - Cadastro de Escola"
            Icon="Table" TrackMouseOver="true" AnchorHorizontal="100%" Height="350" Frame="true" ButtonAlign="Right">
            <Store>
                <ext:Store ID="StoreCRJEscola" runat="server">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="IdEscola" Mapping="IdEscola" Type="Int" />
                                <ext:RecordField Name="RazaoSocial" Mapping="RazaoSocial" Type="String" />
                                <ext:RecordField Name="Nome" Mapping="Nome" Type="String" />
                                <ext:RecordField Name="CNPJ" Mapping="CNPJ" Type="String" />
                                <ext:RecordField Name="InscEstadual" Mapping="InscEstadual" Type="String" />
                                <ext:RecordField Name="Logradouro" Mapping="Logradouro" Type="String" />
                                <ext:RecordField Name="Bairro" Mapping="Bairro" Type="String" />
                                <ext:RecordField Name="Cidade" Mapping="Cidade" Type="String" />
                                <ext:RecordField Name="Estado" Mapping="Estado" Type="String" />
                                <ext:RecordField Name="CEP" Mapping="CEP" Type="String" />
                                <ext:RecordField Name="TelefonePrincipal" Mapping="TelefonePrincipal" Type="String" />
                                <ext:RecordField Name="TelefoneSecundario" Mapping="TelefoneSecundario" Type="String" />
                                <ext:RecordField Name="Email" Mapping="Email" Type="String" />
                                <ext:RecordField Name="DataAbertura" Mapping="DataAbertura" Type="Date" />
                                <ext:RecordField Name="Missao" Mapping="Missao" Type="String" />
                                <ext:RecordField Name="IdStatus" Mapping="IdStatus" Type="Int" />
                                <ext:RecordField Name="Observacao" Mapping="Observacao" Type="String" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:NumberColumn ColumnID="IdEscola" Header="IdEscola" DataIndex="IdEscola" Format="0" Hidden="true" />
                    
                    <ext:Column ColumnID="Nome" Header="Escola" DataIndex="Nome" />
                   
                    <ext:Column ColumnID="CNPJ" Header="CNPJ" DataIndex="CNPJ"  Width="200" Fixed="true" Align="Center"/>

                                       
                    
                    
                    <ext:Column ColumnID="IdStatus" Header="Situação" DataIndex="IdStatus"   Width="50" Fixed="true"/>
                   
                    
                    
                    <ext:ImageCommandColumn Width="25" ColumnID="BotaoVisualizar" Fixed="true">
                        <Commands>
                            <ext:ImageCommand CommandName="btnVisualizar" Icon="Magnifier" Text="">
                                <ToolTip Title="Visualização:" Text="Visualizar o Registro Selecionado." />
                            </ext:ImageCommand>
                        </Commands>
                    </ext:ImageCommandColumn>
                    <ext:ImageCommandColumn Width="25" ColumnID="BotaoAlterar" Fixed="true">
                        <Commands>
                            <ext:ImageCommand CommandName="btnAlterar" Icon="PageWhiteEdit" Text="">
                                <ToolTip Title="Alteração:" Text="Alterar o Registro Selecionado." />
                            </ext:ImageCommand>
                        </Commands>
                    </ext:ImageCommandColumn>
                    <ext:ImageCommandColumn Width="25" ColumnID="BotaoRemover" Fixed="true">
                        <Commands>
                            <ext:ImageCommand CommandName="btnRemover" Icon="Delete" Text="">
                                <ToolTip Title="Exclusão:" Text="Remove o Registro Selecionado." />
                            </ext:ImageCommand>
                        </Commands>
                    </ext:ImageCommandColumn>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
            </SelectionModel>

            <View>
                <ext:GridView ID="GridView1" runat="server" ForceFit="true"></ext:GridView>
            </View>

            <DirectEvents>
					<Command OnEvent="LinhaGrid_DirectClick">
						<EventMask ShowMask="true" MinDelay="10" />
						<ExtraParams>
							<ext:Parameter Value="record.data.IdEscola" Mode="Raw" Name="IdentificadorRegistroTabela"></ext:Parameter>
							<ext:Parameter Value="command" Mode="Raw" Name="IDObjeto"></ext:Parameter>
						</ExtraParams>
					</Command>
				</DirectEvents>
            
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="5" EmptyMsg="Não existem dados para serem mostrados."
                    DisplayMsg="<b>{0} a {1} de {2} registro(s)</b>">
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
    </div>
    <ext:Window ID="ModalCadastro" runat="server" BodyStyle="background-color: #FFFFFF;"
        Padding="10" Hidden="true">
        <Content>
        </Content>
        <%--<DirectEvents>
				<BeforeHide OnEvent="btnPesquisar_DirectClick"></BeforeHide>
			</DirectEvents>--%>
    </ext:Window>
  
</asp:Content>
