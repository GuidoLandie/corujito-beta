<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroCargo.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroCargo" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <form id="FormCadastroCargo" runat="server">
   
    <ext:Panel ID="PanelCadastro" runat="server" Title="Cadastro Cargo" Icon="ApplicationAdd"
        AnchorHorizontal="95%" Frame="true" Hidden="false" AutoHeight="true">
        <Items>
              <ext:FormPanel ID="FormPanelCadastroCargo" runat="server" LabelWidth="50" Border="false" ButtonAlign="Right"  PaddingSummary="10px 15px 20px" >
                <Items>
                    <ext:TextField ID="txtIDEscola" runat="server" FieldLabel="Cargo" AnchorHorizontal="35%"
                        MaxLength="250" AllowBlank="false" BlankText="O campo Nome do Cargo é Obrigatório."
                        Disabled="False">
                    </ext:TextField>
                    <ext:ComboBox ID="cbxSituação" runat="server" FieldLabel="Situação" AllowBlank="false"
                        BlankText="O campo Situação é obrigatório." AnchorHorizontal="17%">
                        <Items>
                            <ext:ListItem Text="Ativa" Value="1" />
                            <ext:ListItem Text="Inativa" Value="0" />
                        </Items>
                    </ext:ComboBox>
                </Items>
                   <Buttons>
                    <ext:Button ID="btnCancelar" runat="server" Icon="PageBack" Text="Cancelar" Height="25"
                        Width="110" ToolTip="Cancelar edição e voltar para a pagina de pesquisa.">
                        <%--<DirectEvents>
								<Click OnEvent="btnCancelar_Click">
									<EventMask ShowMask="true" />									
								</Click>
							</DirectEvents>--%>
                    </ext:Button>
                    <ext:Button ID="btnGravar" runat="server" Icon="Disk" Text="Gravar" Height="25" Width="110"
                        ToolTip="Gravar dados.">
                        <%--<DirectEvents>
								<Click OnEvent="btnGravar_Click" Before="var valid= #{FormPanelCadastro}.getForm().isValid(); return valid;">
									<EventMask ShowMask="true" MinDelay="1000" Target="CustomTarget" CustomTarget="={#{FormPanelCadastro}.getEl()}"/>
									<ExtraParams>
										<ext:Parameter Value="#{FormPanelCadastro}.getForm().isValid()" Mode="Raw" Name="FormularioValido"></ext:Parameter>
									</ExtraParams>
								</Click>
							</DirectEvents>--%>
                    </ext:Button>
                </Buttons> 
        
                <BottomBar>
                    <ext:StatusBar ID="FormStatusBar" runat="server" DefaultText="." Flat="true">
                        <Plugins>
                            <ext:ValidationStatus ID="ValidationStatus1" runat="server" FormPanelID="FormPanelCadastroCargo"
                                ValidIcon="Accept" ErrorIcon="Exclamation" ShowText="<b>ATENÇÃO: Existem campos que possuem informações inconsistentes. Clique aqui para saber quais são.</b>"
                                HideText="<b>Clique aqui para ocultar a lista de campos com informações inconsistentes.</b>" />
                        </Plugins>
                    </ext:StatusBar>
                </BottomBar>
            </ext:FormPanel>
        </Items>
    </ext:Panel>
    </form>
</asp:Content>
