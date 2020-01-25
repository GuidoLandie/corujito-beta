<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="CadastroPermissaoUsuario.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroPermissaoUsuario" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
 <script type="text/javascript">
     var afterEdit = function (e) {
         /*
         Properties of 'e' include:
         e.grid - This grid
         e.record - The record being edited
         e.field - The field name being edited
         e.value - The value being set
         e.originalValue - The original value for the field, before the edit.
         e.row - The grid row index
         e.column - The grid column index
         */

         // Call DirectMethod
         Corujito.AfterEdit(e.record.data.PossuiPermissao, e.record.data.IdAplicacao, e.record.data.IdFuncionalidade);
     };
    </script>
       <form id="form1" runat="server">
        
        <ext:Panel ID="PanelCadastro" runat="server" Width="745" Frame="true" >
			<Items>
				<ext:FormPanel ID="FormPanelCadastro" runat="server" LabelWidth="70" ButtonAlign="Right" Border="false" LabelAlign="Left" PaddingSummary="0px 0px 0px 0px" >	    			                    
                    <Items>                       

                      <ext:GridPanel ID="GridFuncionalidades" runat="server" StripeRows="true" Title="Permissões"
                            Icon="ApplicationKey" TrackMouseOver="true" AnchorHorizontal="100%" Height="265" Frame="true" StyleSpec="margin-top:10px;"
                            ButtonAlign="Right">
                            <Store>
                                <ext:Store ID="StoreFuncionalidades" runat="server" GroupField="NomeAplicacao" GroupDir="ASC">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                
                                                <ext:RecordField Name="PossuiPermissao"       Mapping="PossuiPermissao"     Type="Boolean" />                                                
                                                <ext:RecordField Name="IdFuncionalidade"      Mapping="IdFuncionalidade"    Type="Int" />                                                
                                                <ext:RecordField Name="IdAplicacao"           Mapping="IdAplicacao"         Type="Int" />       
                                                <ext:RecordField Name="Descricao"             Mapping="Descricao"           Type="String" />
                                                <ext:RecordField Name="NomeAplicacao"         Mapping="NomeAplicacao"       Type="String" />
                                                
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
                                    
                                    <ext:CheckColumn ColumnID="PossuiPermissao" DataIndex="PossuiPermissao" Width="5" Editable="true">
                                        <Editor>
                                            <ext:Checkbox ID="chkPossuiPermissao" runat="server" Width="5" >                                            
                                            </ext:Checkbox>
                                        </Editor>
                                    </ext:CheckColumn>

                                    <ext:Column     ColumnID="NomeAplicacao"        Header="Aplicação"          DataIndex="NomeAplicacao" />            
                                    <ext:Column     ColumnID="Descricao"            Header="Funcionálidade"     DataIndex="Descricao" />
                                    <ext:Column     ColumnID="IdFuncionalidade"     Header="IdFuncionalidade"   DataIndex="IdFuncionalidade"  Hidden="true"/>
                                    <ext:Column     ColumnID="IdAplicacao"          Header="IdAplicacao"        DataIndex="IdAplicacao" Hidden="true" />                                                  

                                </Columns>
                            </ColumnModel>

                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                            </SelectionModel>

                            <View>
                                <ext:GroupingView id="GroupingView" runat="server" ForceFit="true" HideGroupedColumn="true" >
                                </ext:GroupingView>
                            </View>
                            
                        </ext:GridPanel>

					</Items>
					                                        
                    <Buttons>

                        <ext:Button ID="btnCancelar" runat="server" Icon="Cancel" Text="Cancelar" Height="25" Width="110" ToolTip="Cancelar Alteração."  >
							<Listeners>
                                <Click Handler="parent.hideModal();" />
                            </Listeners>
						</ext:Button>

						<ext:Button ID="btnGravar" runat="server" Icon="Disk" Text="Gravar" Height="25" Width="110" ToolTip="Gravar dados." >
							<DirectEvents>
								<Click OnEvent="btnGravar_Click">	                                    
                                    					
								</Click>
							</DirectEvents>
						</ext:Button>
					</Buttons>
				</ext:FormPanel>
			</Items>
			<BottomBar>
				<ext:StatusBar ID="FormStatusBar" runat="server" DefaultText="." Flat="true">
					<Plugins>
						<ext:ValidationStatus ID="ValidationStatus1"
							runat="server"
							FormPanelID="FormPanelCadastro"
							ValidIcon="Accept"
							ErrorIcon="Exclamation"
							ShowText="<b>ATENÇÃO: Existem campos que possuem informações inconsistentes. Clique aqui para saber quais são.</b>"
							HideText="<b>Clique aqui para ocultar a lista de campos com informações inconsistentes.</b>"
						/>
					</Plugins>
				</ext:StatusBar>
			</BottomBar>
		</ext:Panel>

       </form>

</asp:Content>