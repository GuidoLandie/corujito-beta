<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="CadastroGrupoUsuarios.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroGrupoUsuarios" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <ext:Panel ID="PanelCadastro" runat="server" AnchorHorizontal="100%" Frame="true" >
			<Items>
				<ext:FormPanel ID="FormPanelCadastro" runat="server" LabelWidth="120" ButtonAlign="Right" Border="true" LabelAlign="Left"
                     PaddingSummary="0px 0px 0px 0px" Title="Nome do grupo" Frame="true" >	    			                    
                    <Items> 

                       <ext:Container ID="container2" runat="server" Layout="ColumnLayout" Height="25">
                            <Items>
                                <ext:Container ID="container3" runat="server" Layout="FormLayout" ColumnWidth="0.85" LabelWidth="120"  >
                                    <Items>
                                    <ext:ComboBox ID="cboUsers" runat="server"  AnchorHorizontal="95%" FieldLabel="Adicionar usuario" DisplayField="Nome"   ValueField="UserLogin" 
                                          TypeAhead="true" Mode="Local" ForceSelection="false"  EmptyText="Digite o nome da usuário para encontrar"
                                         HideTrigger="true">
                                            <Store>
                                                  <ext:Store ID="StoreUsuarios" runat="server">
                                                        <Reader>
                                                            <ext:JsonReader>
                                                                <Fields>

                                                                    <ext:RecordField Name="UserLogin" Mapping="Email"               Type="String"/>
                                                                    <ext:RecordField Name="Nome"      Mapping="Nome"     Type="String" />
                                               
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>            
                                                    </ext:Store>                        
                                            </Store>
                                            <%--<Template ID="Template1" runat="server">
                                                <Html>                                
					                                <tpl for=".">
						                                <div class="list-item">							             
							                                 {Nome} ---
                                                             {UserLogin}
						                                </div>
					                                </tpl>
				                                </Html>
                                            </Template>--%>    
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="container1" runat="server" Layout="FormLayout" ColumnWidth="0.2" LabelWidth="120"  >
                                    <Items>
                                        <ext:Button ID="btnAddUsuario" runat="server" Text="Adicionar" Icon="UserAdd" ToolTip="Adicionar usuario selecionado no para o grupo."
                                            Width="100" Height="25">
                                            <DirectEvents>
                                                <Click OnEvent="btnAddUsuario_Click">
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>

                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>


                     
                         

                    



                    <ext:GridPanel ID="GridPesquisaCRJPessoa" runat="server" StripeRows="true" Title="Usuarios do Grupo" Icon="Group" TrackMouseOver="true"
                        AnchorHorizontal="100%" Height="365" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:10px;">

				<Store>
					<ext:Store ID="StoreCRJPessoa" runat="server" >
						<Reader>
							<ext:JsonReader>
								<Fields>
														
									<ext:RecordField Name="Nome"            ServerMapping="DadosPessoais.Nome"  Type="String" />									
									<ext:RecordField Name="Email"           Mapping="UserLogin"                 Type="String" />
								
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>


				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
                    
                    	<ext:Column ColumnID="Nome"     Header="Nome"       DataIndex="Nome"      Width="350" Align="Left"/>
                       	<ext:Column ColumnID="Email"  Header="E-mail"       DataIndex="Email"     Width="300" Align="Left"/>			
                       
						
                        

						<ext:ImageCommandColumn Width="25" ColumnID="BotaoRemover">
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

				<DirectEvents>
					<Command OnEvent="LinhaGrid_DirectClick">
						<EventMask ShowMask="true" MinDelay="10" />
						<ExtraParams>
							<ext:Parameter Value="record.data.Email" Mode="Raw" Name="IdentificadorRegistroTabela"></ext:Parameter>
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
                </ext:FormPanel>
            </Items>
        </ext:Panel>

</asp:Content>
