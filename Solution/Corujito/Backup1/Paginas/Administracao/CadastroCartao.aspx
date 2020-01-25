<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="CadastroCartao.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroCartao" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	
    <form id="formCadastroCartao" runat="server">
    	<ext:Panel ID="PanelCadastro" runat="server" Title="Habilitar Cartão" Icon="ApplicationAdd" AnchorHorizontal="100%" Frame="true" >
               
                <Items>
				<ext:FormPanel ID="FormPanelCadastro" runat="server" LabelWidth="130" ButtonAlign="Right" Border="false" LabelAlign="Left" PaddingSummary="10px 15px 20px" >
	    			
                    <Items>
                    <ext:Hidden ID="hdIdPessoa" runat="server"></ext:Hidden>       
						  <ext:TextField ID="txtNome" runat="server" FieldLabel="Nome" AnchorHorizontal="70%" MaxLength="250" Truncate="true" AllowBlank="False" 
                            BlankText="O campo Nome é Obrigatório." Disabled="True">
						  </ext:TextField>
					</Items>

					<Buttons>                                                            
                        <ext:Button ID="btnCancelar" runat="server" Icon="PageBack" Text="Cancelar" Height="25" Width="110" 
                            ToolTip="Cancelar edição e voltar para a pagina de pesquisa.">
							<DirectEvents>
								<Click OnEvent="btnCancelar_Click">
									<EventMask ShowMask="true" />									
								</Click>
							</DirectEvents>
						</ext:Button>
                                                        	
						<ext:Button ID="btnGravar" runat="server" Icon="Disk" Text="Gerar Cartão" Height="25" Width="110" ToolTip="Gerar Cartão">
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
