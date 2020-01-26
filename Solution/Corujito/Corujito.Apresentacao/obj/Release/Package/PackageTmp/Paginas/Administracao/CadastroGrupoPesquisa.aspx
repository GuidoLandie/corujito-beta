<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroGrupoPesquisa.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroGrupoPesquisa" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
<script type="text/javascript">
    function hideModal() {
    win = <%= ModalCadastro.ClientID %>;
    win.hide(null);
    }
</script>

      <u>Home > Administração > Controle de Acessos > Grupos ></u>
    
    <br />
    <br />
    
    <ext:Panel ID="pnlTituloPagina" runat="server" AnchorHorizontal="100%" Title="Grupos de Permissão" Icon="Group" Frame="true" Border="true"
        PaddingSummary="10px 0px 10px 0px">
        <Items>
            
            <ext:Button ID="btnCadastrarNovo" runat="server" Icon="Add" Text="Cadastrar Novo"
                Height="20" Width="150" ToolTip="Cadastrar um registro Novo.">
                <DirectEvents>
                    <Click OnEvent="btnCadastrarNovo_Click"></Click>
                </DirectEvents>
            </ext:Button>
            
            <ext:GridPanel ID="GridPesquisa" runat="server" StripeRows="true" Title="Grupos de Permissões Cadastrados"
                Icon="GroupGear" TrackMouseOver="true" AnchorHorizontal="100%" Height="350" Frame="true" StyleSpec="margin-top:10px;"
                ButtonAlign="Right">
                <Store>
                    <ext:Store ID="StoreCRJEscola" runat="server">
                        <Reader>
                            <ext:JsonReader>
                                <Fields>
                                    <ext:RecordField Name="IdEscola"    Mapping="IdEscola"  Type="Int" />
                                    <ext:RecordField Name="IdGrupo"     Mapping="IdGrupo"   Type="Int" />
                                    <ext:RecordField Name="Nome"        Mapping="Nome"      Type="String" />
                                    <ext:RecordField Name="Descricao"   Mapping="Descricao" Type="String" />
                                    <ext:RecordField Name="TipoPessoa"   ServerMapping="TipoPessoa.Descricao" Type="String" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>

                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        
                        <ext:NumberColumn   ColumnID="IdGrupo"      Header="IdGrupo"    DataIndex="IdGrupo" Format="0" Hidden="true" />
                        <ext:Column         ColumnID="Nome"         Header="Grupo"      DataIndex="Nome" />
                        <ext:Column         ColumnID="Descricao"    Header="Descrição"  DataIndex="Descricao" />
                        <ext:Column         ColumnID="TipoPessoa"    Header="Tipo de Usuário"  DataIndex="TipoPessoa" />
                        
                      
                       <ext:ImageCommandColumn Width="25" ColumnID="BotaoAddPermissao" Fixed="true">
                            <Commands>
                                <ext:ImageCommand CommandName="btnAddPermissao" Icon="Key" Text="">
                                    <ToolTip Title="Permissões:" Text="Controle das Permissões que este grupo possui." />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:ImageCommandColumn>

                       <ext:ImageCommandColumn Width="25" ColumnID="BotaoAddUser" Fixed="true">
                            <Commands>
                                <ext:ImageCommand CommandName="btnAddUser" Icon="Group" Text="">
                                    <ToolTip Title="Usuários:" Text="Adicione os usuários que estão vinculados a este grupo." />
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
                    <ext:GridView ID="GridView1" runat="server" ForceFit="true">
                    </ext:GridView>
                </View>
                <DirectEvents>
                    <Command OnEvent="LinhaGrid_DirectClick">
						<EventMask ShowMask="true" MinDelay="10" />
						<ExtraParams>
							<ext:Parameter Value="record.data.IdGrupo" Mode="Raw" Name="IdentificadorRegistroTabela"></ext:Parameter>
                            <ext:Parameter Value="record.data.Nome" Mode="Raw" Name="NomeGrupo"></ext:Parameter>
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
                                    <AfterRender Handler="#{cboPageSize}.setValue(10);"></AfterRender>
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
        <DirectEvents>
				<BeforeHide OnEvent="ModalCadastro_BeforeHide"></BeforeHide>
			</DirectEvents>
    </ext:Window>
</asp:Content>
