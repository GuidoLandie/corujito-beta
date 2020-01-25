<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true"
    CodeBehind="CadastroProduto.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroProduto" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <form id="fomr1" runat="server">
    
   
    <ext:Panel ID="PanelCadastro" runat="server" Title="Cadastro - CRJProdutoCadastro"
        Icon="Application" Width="680" Frame="true" Height="480">
        <Items>
            <ext:FormPanel ID="FormPanelCadastro" runat="server" LabelWidth="110" ButtonAlign="Right"
                Border="false" LabelAlign="Top" PaddingSummary="10px 15px 20px">
                <Items>
                   
                    
                    <ext:NumberField ID="txtIdProduto" runat="server" FieldLabel="IdProduto" AnchorHorizontal="30%"
                        MaxLength="4" AllowBlank="False" BlankText="O campo IdProduto é Obrigatório."
                        Disabled="True" Hidden="true">
                    </ext:NumberField>

                    <ext:ComboBox ID="cboTipoProduto" runat="server" Editable="false" AllowBlank="false" BlankText="O campo Tipo de Produto é Obrigatório."
                        DisplayField="Nome" ValueField="IdTipoProduto" TypeAhead="true" Mode="Local" ForceSelection="true"
                        EmptyText="Selecione um tipo" fieldlabel="Tipo do Produto" Resizable="true" SelectOnFocus="true">
                        <Store>
                            <ext:Store ID="StoreTipoProduto" runat="server">
                                <Reader>
                                    <ext:ArrayReader>
                                        <Fields>                                          
                                            <ext:RecordField Name="IdTipoProduto" Mapping="IdTipoProduto" />
                                            <ext:RecordField Name="Nome"          Mapping="Nome" />
                                        </Fields>
                                    </ext:ArrayReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>

                    <ext:Textfield ID="txtCod_Barra" runat="server" FieldLabel="Código de Barra" AnchorHorizontal="95%"
                        MaxLength="100" Truncate="false" AllowBlank="false" BlankText="O campo Código de Barra é Obrigatório."
                        Disabled="False" MaskRe="[0-9]" >
                    </ext:Textfield>
                    
                    <ext:Textfield ID="txtNome" runat="server" FieldLabel="Nome" AnchorHorizontal="95%"
                        MaxLength="250"  AllowBlank="false" BlankText="O campo Nome é Obrigatório."
                        Disabled="False">
                    </ext:Textfield>
                    
                    <ext:Textfield ID="txtDescricao" runat="server" FieldLabel="Descrição" AnchorHorizontal="95%"
                        MaxLength="500" Truncate="false" AllowBlank="false" BlankText="O campo Descrição é Obrigatório."
                        Disabled="False">
                    </ext:Textfield>
                    
                    <ext:NumberField ID="txtQuantidade" runat="server" FieldLabel="Quantidade" AnchorHorizontal="30%"
                        MaxLength="4"  BlankText="O campo Quantidade é Obrigatório."  AllowBlank="false"
                        Disabled="False">
                    </ext:NumberField>
                    
                    <ext:NumberField ID="txtPreco" runat="server" FieldLabel="Preço" AnchorHorizontal="30%"
                        MaxLength="7" AllowBlank="false" BlankText="O campo Preço é Obrigatório." Disabled="False"
                        DecimalPrecision="2" DecimalSeparator=",">
                    </ext:NumberField>
                    
                    <ext:ComboBox ID="cboIdStatus" runat="server" Editable="false" AllowBlank="false"
                        DisplayField="Descricao" ValueField="IdStatus" TypeAhead="true" Mode="Local" ForceSelection="true"
                        EmptyText="Selecione o status" fieldlabel="Status" Resizable="true" SelectOnFocus="true">
                        <Store>
                            <ext:Store ID="StoreStatus" runat="server">
                                <Reader>
                                    <ext:ArrayReader>
                                        <Fields>                                          
                                            <ext:RecordField Name="IdStatus" Mapping="IdStatus" />
                                            <ext:RecordField Name="Descricao" Mapping="Descricao" />
                                        </Fields>
                                    </ext:ArrayReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
                </Items>


                <Buttons>
                    <ext:Button ID="btnLimparTela" runat="server" Icon="PageWhite" Text="Limpar Tela"
                       Height="25" Width="110" ToolTip="Limpar os campos da tela." OnDirectClick="btnLimparTela_DirectClick">
                    </ext:Button>
                    <ext:Button ID="btnGravar" runat="server" Icon="Disk" Text="Gravar" Height="25" Width="110"
                        ToolTip="Gravar dados.">
                        <DirectEvents>
                            <Click OnEvent="btnGravar_Click" Before="var valid= #{FormPanelCadastro}.getForm().isValid(); return valid;">
                                <EventMask ShowMask="true" MinDelay="1000" Target="CustomTarget" CustomTarget="={#{FormPanelCadastro}.getEl()}" />
                                <ExtraParams>
                                    <ext:Parameter Value="#{FormPanelCadastro}.getForm().isValid()" Mode="Raw" Name="FormularioValido">
                                    </ext:Parameter>
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
                    <ext:ValidationStatus ID="ValidationStatus1" runat="server" FormPanelID="FormPanelCadastro"
                        ValidIcon="Accept" ErrorIcon="Exclamation" ShowText="<b>ATENÇÃO: Existem campos que possuem informações inconsistentes. Clique aqui para saber quais são.</b>"
                        HideText="<b>Clique aqui para ocultar a lista de campos com informações inconsistentes.</b>" />
                </Plugins>
            </ext:StatusBar>
        </BottomBar>
    </ext:Panel>
</form>

</asp:Content>
