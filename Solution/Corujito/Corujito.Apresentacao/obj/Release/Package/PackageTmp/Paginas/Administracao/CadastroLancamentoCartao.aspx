<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroLancamentoCartao.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroLancamentoCartao" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


		<ext:Panel ID="PanelCadastro" runat="server" Title="Cadastro de Ocorrência" Icon="ApplicationAdd" AnchorHorizontal="100%" Frame="true" >

			<Items>
                <ext:Hidden ID="hdIdAluno" runat="server"></ext:Hidden>
				<ext:FormPanel ID="FormPanelCadastro" runat="server" LabelWidth="130" ButtonAlign="Right" Border="false" LabelAlign="Left" PaddingSummary="10px 15px 20px" >

	    			<Items>
						<ext:NumberField ID="txtIdLancamentoCartao" runat="server" FieldLabel="IdLancamentoCartao" AnchorHorizontal="30%"
                             BlankText="O campo IdLancamentoCartao é Obrigatório." Disabled="True" Hidden="true">
						</ext:NumberField>

						<ext:NumberField ID="txtValor" runat="server" FieldLabel="Valor" AnchorHorizontal="95%" MaxLength="1000" 
                            Truncate="true" AllowBlank="false" BlankText="O campo Valor é Obrigatório." Disabled="False">
						</ext:NumberField>

                        <ext:NumberField ID="txtIdCartao" runat="server" FieldLabel="IdCartao" AnchorHorizontal="95%" MaxLength="1000" 
                            Truncate="true"  Disabled="true">
						</ext:NumberField>

                       
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

</asp:Content>
