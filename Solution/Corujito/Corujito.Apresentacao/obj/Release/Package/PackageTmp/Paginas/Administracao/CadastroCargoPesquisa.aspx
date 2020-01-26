<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroCargoPesquisa.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroCargoPesquisa" %>
    <%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="formCRJEscolaPesquisa" runat="server">
       <H1> Pesquisa de Cargos</H1>
       <ext:Button ID="btnCadastrarCargo" runat="server" Icon="Add" Text="Cadastrar Novo"
       Height="20" Width="150" ToolTip="Cadastrar novo usuario">
       <DirectEvents>
          <Click OnEvent="btnCadastrarCargo_DirectClick">
            <EventMask ShowMask="true" MinDelay="10" />
          </Click>
       </DirectEvents>
    </ext:Button>
       <br/>
       <ext:Panel ID="PanelParametrosPesquisaCargo" runat="server" Title="Parametros de Pesquisa"
       icon="Magnifier" AnchorHorizontal="95%" Height="130" Frame="true" ButtonAlign="Right">
       
       <Items>
       <ext:FormPanel ID="FormPanelParametrosPesquisaCargo" runat="server" LabelWidth="100" ButtonAlign="Right" Border="false" LabelAlign="Right" PaddingSummary="0px 0px 0px">
           <Items>
               <ext:TextField ID="txtParametrosPesquisa" runat="server" AnchorHorizontal="30%" MaxLength="50" FieldLabel="Cargo" LabelWidth="100"  Text="Todos">
               </ext:TextField>
      
                      <ext:ComboBox ID="cbxCargoEstado" runat="server" FieldLabel="Estado" AnchorHorizontal="25%" SelectedIndex="2" >
                          <Items>
                               <ext:ListItem  Text="Inativo" Value="1" />
                               <ext:ListItem  Text="Ativo"   Value="2" />
                               <ext:ListItem  Text="Todos"   Value="3" />
                          </Items>
                      </ext:ComboBox>
           </Items>
           <Buttons>
       
                    <ext:Button ID="btnPesquisarCargo" runat="server" Icon="Magnifier" Text="Pesquisar" Height="30" Width="150">
                            <DirectEvents>
                            <Click OnEvent="btnPesquisarCargo_DirectClicar">
                               <EventMask Showmask="true" MinDelay="10" /> 
                            </Click>              
                            </DirectEvents>
                    </ext:Button>
           </Buttons>
       </ext:FormPanel>
       </Items>
       
       
       </ext:Panel>
           <ext:GridPanel ID="GridPesquisaCargo" runat="server" StripeRows="true" Title="Resultado da Pesquisa - Cargos"
            Icon="Table" TrackMouseOver="true"  AnchorHorizontal="100%" Height="350" Frame="true" ButtonAlign="Right">
            <Store>
                <ext:Store ID="StoreCargo" runat="server">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="IdCargo"     Mapping="Cargo" Type="Int" />
                                <ext:RecordField Name="StatusCargo" Mapping="Status" Type="String"/>
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:NumberColumn ColumnID="IdCargo" Header="IdCargo" DataIndex="IdCargo" Hidden="true" />
                    
                    <ext:Column ColumnID="Cargo" Header="Cargo" DataIndex="Cargo" Width="10"/>
                   
                    <ext:Column ColumnID="StatusCargo" Header="StatusCargo" DataIndex="StatusCargo" Align="Center" Width="10"/>

                              
                    
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


            <%--<DirectEvents>
					<Command OnEvent="LinhaGrid_DirectClick">
						<EventMask ShowMask="true" MinDelay="10" />
						<ExtraParams>
							<ext:Parameter Value="record.data.IdEscola" Mode="Raw" Name="IdentificadorRegistroTabela"></ext:Parameter>
							<ext:Parameter Value="command" Mode="Raw" Name="IDObjeto"></ext:Parameter>
						</ExtraParams>
					</Command>
				</DirectEvents>--%>
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
       
        
    </form>
</asp:Content>
