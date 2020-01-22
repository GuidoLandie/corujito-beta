<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="VenderProdutoPesquisa.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.VendaProduto" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
 <script type="text/javascript">
     var afterEdit = function (e) {
       
         e.record.data.ValorTotal = e.record.data.Preco * e.record.data.Quantidade;

         var grid = GridCRJProdutoVendido;

         grid.getView().refresh(true);
         saveData();         
     };
     
     function saveData() {
         
         GridData.setValue(Ext.encode(GridCRJProdutoVendido.getRowsValues({ selectedOnly: false })));         
         CompanyX.afterEdit_AtualizarValor();
         
     };

    </script>

    <ext:Panel ID="PanelCadastro" runat="server" Title="Venda de Produto"
        Icon="Application" Width="760" Frame="true" Height="200">

        <Items>
            <ext:FormPanel ID="FormPanelVenda" runat="server" LabelWidth="110" ButtonAlign="Right"
                Border="false" LabelAlign="Top" PaddingSummary="10px 15px 20px">
                
                <Items>
                                        
                     <ext:ComboBox ID="cboPessoa" runat="server" width="720"  DisplayField="Nome" ValueField="IdPessoa" 
                     FieldLabel="Selecione a pessoa que está comprando" TypeAhead="true" Mode="Local"
                             ForceSelection="false" Resizable="true" HideTrigger="true">
                        <Store>
                            <ext:Store ID="StorePessoa" runat="server">
                                <Reader>
                                    <ext:ArrayReader>
                                        <Fields>                                          
                                            <ext:RecordField Name="IdPessoa"              Mapping="IdPessoa" />
                                            <ext:RecordField Name="Nome"                  Mapping="Nome" />
                                        </Fields>
                                    </ext:ArrayReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <DirectEvents>
                           <Change OnEvent="cboPessoa_Select">
                                <EventMask ShowMask="true" />
                           </Change>
                           
                        </DirectEvents> 

                    </ext:ComboBox>

                     <ext:Label ID="nomepessoa" runat="server" FieldLabel="Solicitante">
                                 
                       </ext:Label>
                               
             
                

                    <ext:ComboBox ID="cboProduto" runat="server" width="720" AllowBlank="false" DisplayField="Nome" ValueField="IdProduto" 
                        TypeAhead="true" Mode="Local" FieldLabel="Produtos" Resizable="true" ForceSelection="false" HideTrigger="true">

                        <Triggers>
                             <ext:FieldTrigger Icon="SimplePlus" />
                        </Triggers>
                        <Store>
                            <ext:Store ID="StoreProduto" runat="server">
                                <Reader>
                                    <ext:ArrayReader>
                                        <Fields>                                          
                                            <ext:RecordField Name="IdProduto"              Mapping="IdProduto" />
                                            <ext:RecordField Name="Nome"                   Mapping="Nome" />
                                            
                                        </Fields>
                                    </ext:ArrayReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <DirectEvents>
                            <TriggerClick OnEvent="cboProduto_TriggerClick"></TriggerClick>
                        </DirectEvents>
                    </ext:ComboBox>

                    

        
   
               </Items>
               </ext:FormPanel>

         </Items>            
     </ext:Panel>

     
     <div> 

            <ext:Hidden ID="GridData" runat="server" ClientIDMode="Static" />

          <ext:gridpanel id="GridCRJProdutoVendido" runat="server" striperows="true"  Title="Listagem dos produtos selecionados"
            icon="Table"  width="760" height="350" frame="true" buttonalign="Right" ClientIDMode="Static" StyleSpec="margin-top:10px">
            <TopBar>
                <ext:Toolbar ID="Toolbar2" Align="right" runat="server">
                    <Items>
                        
                        <ext:Label ID="lblValorTotal" runat="server" LabelAlign="Right" FieldLabel="Total"></ext:Label>
                    
                        <ext:ToolbarFill />

                    <ext:Button ID="btnVender" runat="server" Icon="Disk" Text="Finalizar venda" Height="25" Width="110"
                        ToolTip="Gravar dados.">
                        <DirectEvents>
                            <Click OnEvent="btnVender_Click">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>

                    </Items>
                
                </ext:Toolbar>
            </TopBar>
				<Store>
					<ext:Store ID="StoreCRJProdutoVendido" runat="server" ClientIDMode="Predictable">
						<Reader>
							<ext:JsonReader>
								<Fields>
									<ext:RecordField Name="IdProdutoVendido"       Mapping="IdProdutoVendido"        Type="Int" />
                                    <ext:RecordField Name="IdVendaProduto"         Mapping="IdVendaProduto"          Type="Int" />
                                    <ext:RecordField Name="IdProduto"         Mapping="IdProduto"          Type="Int" />
                                    <ext:RecordField Name="Nome"                   Mapping="Nome"            Type="String"/>
                                    <ext:RecordField Name="ValorTotal"             Mapping="ValorTotal"              Type="Float"/>
                                    <ext:RecordField Name="Quantidade"             Mapping="Quantidade"              Type="Int" />
                                    <ext:RecordField Name="Preco"                  Mapping="Preco"           Type="String"/>
									
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>

                <Listeners>
                     
                     <AfterEdit Fn="afterEdit" />
               </Listeners>


				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>

				
						<ext:Column       ColumnID="Nome"           Header="Nome"                DataIndex="Nome"                           Align="Center"/>                      
				        
						<ext:NumberColumn ColumnID="Quantidade"     Header="Quantidade"          DataIndex="Quantidade" Format="0"             Align="Center">
                            <Editor>
                                <ext:NumberField ID="EditorQuantidade" runat="server">
                                </ext:NumberField>
                            </Editor>
                        </ext:NumberColumn>
						<ext:NumberColumn ColumnID="Preco"          Header="Preço"               DataIndex="Preco"      Format="R$ 0.000,00/i" Align="Center"/>
                        <ext:NumberColumn ColumnID="ValorTotal"     Header="Valor Total"         DataIndex="ValorTotal" Format="R$ 0.000,00/i" Align="Center"/>
						
                         
					

					</Columns>
				</ColumnModel>

        

   


                 <LoadMask ShowMask="true" />
             

				<SelectionModel>
					<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
				</SelectionModel>

                <view>
                     <ext:GridView ID="GridViewProduto" runat="server" ForceFit="true" MarkDirty="false" ></ext:GridView>
                </view>

				

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

			</ext:gridpanel>

            
     </div>



     
</asp:Content>
