<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Corujito.Apresentacao.Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Corujito - Área de Login</title>

    <link REL="Shortcut Icon" HREF="Imagens/favicon.ico">

</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <form id="form1" runat="server">
    <div>
        <ext:Window ID="Window1" runat="server" Closable="false" Resizable="false" Height="150"
            Icon="Lock" Title="Login" Draggable="false" Width="350" Modal="true" Padding="5"
            Layout="Form">
            <Items>
                
                <ext:TextField ID="txtUsername" runat="server" FieldLabel="E-mail" AllowBlank="false"                
                    BlankText="O campo E-mail é obrigatório" AnchorHorizontal="100%" Text="guidolandie@yahoo.com.br" />
                
                <ext:TextField ID="txtPassword" runat="server" InputType="Password" FieldLabel="Senha"
                    AllowBlank="false" BlankText="O campo senha é obrigatório." AnchorHorizontal="100%" Text="senha" />
            </Items>
            <Buttons>
                <ext:Button ID="btnLogin" runat="server" Text="Login" Icon="Accept">
                    <Listeners>
                        <Click Handler="
                            if (!#{txtUsername}.validate() || !#{txtPassword}.validate()) {
                                Ext.Msg.alert('Erro','Os campos E-mail e Senha são obrigatórios.');                                
                                return false; 
                            }" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnLogin_Click">
                            <EventMask ShowMask="true" Msg="Autenticando..." MinDelay="500" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnSenha" runat="server" Text="Esqueci minha senha" Icon="KeyDelete" ToolTip="Caso tenha esquecido sua senha, clique aqui para recuperar">
                </ext:Button>
            </Buttons>
        </ext:Window>
    </div>
    </form>
</body>
</html>
