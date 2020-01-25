<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="CadastroAtividade.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroAtividade" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <script type="text/javascript">
      var onKeyUp = function (field) {
          var v = this.processValue(this.getRawValue()),
                field;

          if (this.startDateField) {
              field = Ext.getCmp(this.startDateField);
              field.setMaxValue();
              this.dateRangeMax = null;
          } else if (this.endDateField) {
              field = Ext.getCmp(this.endDateField);
              field.setMinValue();
              this.dateRangeMin = null;
          }

          field.validate();
      };
    </script>

     <form id="FormCadastroAtividade" runat="server">

       <ext:Panel ID="PanelCadastroAtividades" runat="server" Title="Lancar Atividade" Icon="ApplicationAdd" AnchorHorizontal="100%" Frame="true" >

			<Items>

				<ext:FormPanel ID="FormPanelCadastro" runat="server" LabelWidth="100" ButtonAlign="Left" Border="false" LabelAlign="Top"  PaddingSummary="10px 15px 20px" >

	    			<Items >
                       
                       <ext:TextField ID="txtAtividade" runat="server" EmptyText="Insira o Nome" AnchorHorizontal="90%" MaxLength="50" FieldLabel="Nome" LabelWidth="30">
						</ext:TextField>
                       
                       <%--Combo Atividade--%>
                       <ext:ComboBox ID="cboTipoatividade" runat="server" Editable="false" AllowBlank="false" BlankText="O campo Tipo de Atividade é Obrigatório."
                        DisplayField="Descricao" ValueField="IdTipoAtividade" TypeAhead="true" Mode="Local" ForceSelection="true"
                        EmptyText="Selecione um tipo" fieldlabel="TipoAtividade" Resizable="true" SelectOnFocus="true" AnchorHorizontal="60%" >
                        <Store>
                            <ext:Store ID="StoreTipoAtividade" runat="server">
                                <Reader>
                                    <ext:ArrayReader>
                                        <Fields>                                          
                                             <ext:RecordField Name="IdTipoAtividade" Mapping="IdTipoAtividade" />
                                            <ext:RecordField Name="Descricao"      Mapping="Descricao" />
                                        </Fields>
                                    </ext:ArrayReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                       <%-- <DirectEvents>
								    <Select OnEvent="cboTipoatividade_Select">
									<EventMask ShowMask="true" />									
								</Select>
							</DirectEvents>--%>
                    </ext:ComboBox>

                    <ext:DateField ID="dtini" runat="server" Vtype="daterange" FieldLabel="De" Width="176" EnableKeyEvents="true">  
                        <CustomConfig>
                            <ext:ConfigItem Name="endDateField" Value="#{dtFim}" Mode="Value" />
                        </CustomConfig>
                        <Listeners>
                            <KeyUp Fn="onKeyUp" />
                        </Listeners>
                    </ext:DateField>
                

                 <ext:DateField ID="dtFim" runat="server" Vtype="daterange" FieldLabel="Até" Width="176" EnableKeyEvents="true">    
                    <CustomConfig>
                        <ext:ConfigItem Name="startDateField" Value="#{dtini}" Mode="Value" />
                    </CustomConfig>
                    <Listeners>
                        <KeyUp Fn="onKeyUp" />
                    </Listeners>
                </ext:DateField>



                <%--Caixa de Desc--%>
                    
                <ext:TextArea ID="txtDesc" runat="server" FieldLabel="Descrição de Atividade" AllowBlank="false" AnchorHorizontal="60%" > 
                </ext:TextArea>


                    



					</Items>

			<Buttons>
								                                                               
                        <ext:Button ID="btnVoltar" runat="server" Icon="PageBack" Text="Cancelar" Height="25" Width="110" 
                            ToolTip="Todos os dados da tela seram apagados.">
							<%--<DirectEvents>
								    <Click OnEvent="btnVoltar_Click">
									<EventMask ShowMask="true" />									
								</Click>
							</DirectEvents>--%>
						</ext:Button> 
                                        

					</Buttons>
             <Buttons>
								                                                               
                        <ext:Button ID="btnSalvar" runat="server" Icon="Add" Text="Salvar" Height="25" Width="110" 
                            ToolTip="Todos os dados da tela seram Salvos.">
							<DirectEvents>
								    <Click OnEvent="btnGravar_Click">
									<EventMask ShowMask="true" />									
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