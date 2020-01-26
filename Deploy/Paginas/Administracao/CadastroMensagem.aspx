<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroMensagem.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroMensagem" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<%@ Register Assembly="Ext.Net"     Namespace="Ext.Net"     TagPrefix="ext" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <u>Home > Administração > Enviar Email</u>

    <br />
    <br />
    
     <ext:Panel ID="pnlTituloPagina" runat="server" AnchorHorizontal="100%" Title="Enviar Email" Icon="User" Frame="true" Border="true"
        PaddingSummary="10px 10px 10px 10px" >
        <Items>
        <ext:TextField ID="txtRA" runat="server" FieldLabel="RA" AnchorHorizontal="100%" Disabled="true"></ext:TextField>
        
        <ext:TextField ID="txtNome" runat="server" FieldLabel="Nome" Width="740" Disabled="true"></ext:TextField>
        
        <ext:TextField ID="txtAssunto" runat="server" FieldLabel="Assunto" Width="740"></ext:TextField>
        
        <ext:TextArea ID="txtResponsaveis" runat="server" FieldLabel="Responsaveis" Width="740"  Height="100"  Disabled="true"></ext:TextArea>
        
        <ext:TextArea ID="txtMensagem" runat="server" FieldLabel="Mensagem" Width="740"  Height="200"></ext:TextArea>
	

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
                                                        	
						<ext:Button ID="btnGravar" runat="server" Icon="EmailAdd" Text="Enviar" Height="25" Width="110" ToolTip="Enviar.">
							<DirectEvents>
								<Click OnEvent="btnGravar_Click">
				                    <EventMask ShowMask="true" />	
								</Click>
							</DirectEvents>
						</ext:Button>

                        

					</Buttons>
    </ext:Panel>

</asp:Content>

