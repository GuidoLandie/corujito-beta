<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="CadastroGrupo.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroGrupo" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    	<ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <form id="form1" runat="server">
    
		<ext:Panel ID="PanelCadastro" runat="server" Title="Grupo" Icon="Group" Width="745" Height="305" Frame="true" >
			<Items>
				<ext:FormPanel ID="FormPanelCadastro" runat="server" LabelWidth="110" ButtonAlign="Right" Border="false" LabelAlign="Top" PaddingSummary="10px 15px 20px" >
	    			                    
                    <Items>
                        <ext:TextField ID="txtNome" runat="server" FieldLabel="Nome" AnchorHorizontal="100%" 
                             AllowBlank="False" BlankText="O campo Nome é Obrigatório." Disabled="False" MaxLength="255">
						</ext:TextField>

                        <ext:TextArea ID="txtDescricao" runat="server" FieldLabel="Descrição" AnchorHorizontal="100%"
                            AllowBlank="False" BlankText="O campo Descrição é Obrigatório." Disabled="False" MaxLength="255">
                        </ext:TextArea>

                        <ext:ComboBox ID="cboTipoPessoa" runat="server" FieldLabel="Tipo de Pessoa" Width="200"
                            DisplayField="Descricao" ValueField="IdTipoPessoa" ForceSelection="true" AllowBlank="false"
                            BlankText="O campo Tipo de Pessoa é obrigatório.">
                            <Items>
                                <ext:ListItem Text="Nenhum" Value="0" />
                            </Items>
                            <Store>
                                <ext:Store ID="storeTipoPessoa" runat="server">
                                    <Reader>
                                        <ext:JsonReader>                                           
                                            <Fields>
                                                <ext:RecordField Name="IdTipoPessoa" Mapping="IdTipoPessoa" />
                                                <ext:RecordField Name="Descricao" Mapping="Descricao" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>

            
					</Items>
					                                        
                    <Buttons>

                        <ext:Button ID="btnCancelar" runat="server" Icon="Cancel" Text="Cancelar" Height="25" Width="110" ToolTip="Cancelar Alteração.">
							<Listeners>
                                <Click Handler="parent.hideModal();" />
                            </Listeners>
						</ext:Button>

						<ext:Button ID="btnGravar" runat="server" Icon="Disk" Text="Gravar" Height="25" Width="110" ToolTip="Gravar dados.">
							<DirectEvents>
								<Click OnEvent="btnGravar_Click" Before="var valid= #{FormPanelCadastro}.getForm().isValid(); return valid;">
									<EventMask ShowMask="true" MinDelay="1000" Target="CustomTarget" CustomTarget="={#{FormPanelCadastro}.getEl()}"/>
									<ExtraParams>
										<ext:Parameter Value="#{FormPanelCadastro}.getForm().isValid()" Mode="Raw" Name="FormularioValido"></ext:Parameter>
									</ExtraParams>
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
