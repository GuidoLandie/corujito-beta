<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroProdutoPesquisa.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroProdutoPesquisa" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <u>Home > Cantina > Cadastrar Produto</u><br />
    <br />
   
                    <ext:Button ID="btnCadastrarNovo" runat="server" Icon="Add" Text="Cadastrar Novo"
                        Height="20" Width="150" ToolTip="Cadastrar um registro Novo." OnDirectClick="btnCadastrarNovo_DirectClick">
                        <DirectEvents>
                            <Click OnEvent="btnCadastrarNovo_DirectClick">
                                <EventMask ShowMask="true" MinDelay="10" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>                                       

    <br />

    <ext:KeyMap ID="KeyMapPesquisa" runat="server" Target="Ext.getBody()">
        <ext:KeyBinding>
            <Keys>
                <ext:Key Code="ENTER" />
            </Keys>
            <Listeners>
                <Event Handler="#{btnPesquisar}.fireEvent('click');" />
            </Listeners>
        </ext:KeyBinding>
    </ext:KeyMap>
    <ext:Panel ID="PanelParametrosPesquisa" runat="server" Title="Parâmetros da Pesquisa"
        Icon="Magnifier" Width="760" Height="130" Frame="true" ButtonAlign="Right" Collapsible="true"
        Layout="FormLayout">
        <Items>
            <ext:FormPanel ID="FormPanelParametrosPesquisa" runat="server" LabelWidth="100" ButtonAlign="Right"
                Border="false" LabelAlign="Top" PaddingSummary="10px 10px 0px">
                <Items>
                    <ext:Container ID="container2" runat="server" Layout="ColumnLayout" Height="100">
                        <Items>
                            <ext:Container ID="container3" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                                LabelWidth="120">
                                <Items>
                                    <ext:TextField ID="txtNomePesquisa" runat="server" AnchorHorizontal="95%" MaxLength="50"
                                        FieldLabel="Nome" LabelWidth="30" EmptyText="Nome do produto">
                                    </ext:TextField>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="container1" runat="server" Layout="FormLayout" ColumnWidth="0.25">
                                <Items>
                                    <ext:ComboBox ID="cboIdStatus" runat="server" Editable="false" Height="50" DisplayField="Descricao"
                                        ValueField="IdStatus" TypeAhead="true" Mode="Local" ForceSelection="true" EmptyText="Selecione o status"
                                        FieldLabel="Status" Resizable="true" SelectOnFocus="true">
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
                            </ext:Container>
                            <ext:Container ID="container4" runat="server" Layout="FormLayout" ColumnWidth="0.3"
                                LabelWidth="120">
                                <Items>
                                    <ext:ComboBox ID="cboTipoProduto" runat="server" Editable="false" DisplayField="Nome"
                                        ValueField="IdTipoProduto" TypeAhead="true" Mode="Local" ForceSelection="true"
                                        EmptyText="Selecione um tipo" FieldLabel="Tipo do Produto" Resizable="true" SelectOnFocus="true">
                                        <Store>
                                            <ext:Store ID="StoreTipoProduto" runat="server">
                                                <Reader>
                                                    <ext:ArrayReader>
                                                        <Fields>
                                                            <ext:RecordField Name="IdTipoProduto" Mapping="IdTipoProduto" />
                                                            <ext:RecordField Name="Nome" Mapping="Nome" />
                                                        </Fields>
                                                    </ext:ArrayReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                    </ext:ComboBox>

                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                </Items>
                
            </ext:FormPanel>
        </Items>
        <Buttons>


                    <ext:Button ID="btnPesquisar" runat="server" Icon="Magnifier" Text="Pesquisar" Height="20"
                        Width="110" ToolTip="Pesquisar registros." OnDirectClick="btnPesquisar_DirectClick">
                        <DirectEvents>
                            <Click OnEvent="btnPesquisar_DirectClick">
                                <EventMask ShowMask="true" MinDelay="10" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>

                </Buttons>
    </ext:Panel>
    <br />
    <div>
        <ext:GridPanel ID="GridPesquisaCRJProduto" runat="server" StripeRows="true" Title="Resultado da Pesquisa"
            Icon="Table" TrackMouseOver="true" Width="760" Height="350" Frame="true" ButtonAlign="Right">
            <Store>
                <ext:Store ID="StoreCRJProduto" runat="server" OnRefreshData="MyData_Refresh">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="IdProduto" Mapping="IdProduto" Type="Int" />
                                <ext:RecordField Name="IdTipoProduto" ServerMapping="Tipo.Nome" Type="String" />
                                <ext:RecordField Name="Cod_Barra" Mapping="Cod_Barra" Type="String" />
                                <ext:RecordField Name="Nome" Mapping="Nome" Type="String" />
                                <ext:RecordField Name="Descricao" Mapping="Descricao" Type="String" />
                                <ext:RecordField Name="Quantidade" Mapping="Quantidade" Type="Int" />
                                <ext:RecordField Name="Preco" Mapping="Preco" Type="Float" />
                                <ext:RecordField Name="IdStatus" ServerMapping="Status.Descricao" Type="String" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:Column ColumnID="IdTipoProduto" Header="Tipo" DataIndex="IdTipoProduto" Align="Center" />
                    <ext:Column ColumnID="Nome" Header="Nome" DataIndex="Nome" Align="Center" />
                    <ext:NumberColumn ColumnID="Quantidade" Header="Quantidade" DataIndex="Quantidade"
                        Format="0" Align="Center" />
                    <ext:NumberColumn ColumnID="Preco" Header="Preço" DataIndex="Preco" Format="R$ 0.000,00/i"
                        Align="Center" />
                    <ext:Column ColumnID="IdStatus" Header="Status" DataIndex="IdStatus" Align="Center" />
                    <ext:ImageCommandColumn Width="25" ColumnID="BotaoVisualizar">
                        <Commands>
                            <ext:ImageCommand CommandName="btnVisualizar" Icon="Magnifier" Text="">
                                <ToolTip Title="Visualização:" Text="Visualizar o Registro Selecionado." />
                            </ext:ImageCommand>
                        </Commands>
                    </ext:ImageCommandColumn>
                    <ext:ImageCommandColumn Width="25" ColumnID="BotaoAlterar">
                        <Commands>
                            <ext:ImageCommand CommandName="btnAlterar" Icon="PageWhiteEdit" Text="">
                                <ToolTip Title="Alteração:" Text="Alterar o Registro Selecionado." />
                            </ext:ImageCommand>
                        </Commands>
                    </ext:ImageCommandColumn>
                    <ext:ImageCommandColumn Width="25" ColumnID="BotaoRemover">
                        <Commands>
                            <ext:ImageCommand CommandName="btnRemover" Icon="Delete" Text="">
                                <ToolTip Title="Exclusão:" Text="Remove o Registro Selecionado." />
                            </ext:ImageCommand>
                        </Commands>
                    </ext:ImageCommandColumn>
                </Columns>
            </ColumnModel>
            <LoadMask ShowMask="true" />
            <Plugins>
                <ext:GridFilters runat="server" ID="GridFilters1" Local="true" FiltersText="Filtros">
                    <Filters>
                        <ext:NumericFilter DataIndex="IdTipoProduto" />
                        <ext:StringFilter DataIndex="Cod_Barra" />
                        <ext:StringFilter DataIndex="Nome" />
                        <ext:StringFilter DataIndex="Descricao" />
                        <ext:NumericFilter DataIndex="Quantidade" />
                        <ext:NumericFilter DataIndex="Preco" />
                        <ext:NumericFilter DataIndex="IdStatus" />
                        <ext:ListFilter DataIndex="Size" Options="extra small,small,medium,large,extra large" />
                        <ext:BooleanFilter DataIndex="Visible" />
                    </Filters>
                </ext:GridFilters>
            </Plugins>
            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
            </SelectionModel>
            <View>
                <ext:GridView ID="GridViewProduto" runat="server" ForceFit="true">
                </ext:GridView>
            </View>
            <DirectEvents>
                <Command OnEvent="LinhaGrid_DirectClick">
                    <EventMask ShowMask="true" MinDelay="10" />
                    <ExtraParams>
                        <ext:Parameter Value="record.data.IdProduto" Mode="Raw" Name="IdentificadorRegistroTabela">
                        </ext:Parameter>
                        <ext:Parameter Value="command" Mode="Raw" Name="IDObjeto">
                        </ext:Parameter>
                    </ExtraParams>
                </Command>
            </DirectEvents>
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="5" EmptyMsg="Não existem dados para serem mostrados."
                    DisplayMsg="<b>{0} a {1} de {2} registro(s)</b>">
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
                                <AfterRender Handler="#{cboPageSize}.setValue(10);"></AfterRender>
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                </ext:PagingToolbar>
            </BottomBar>
        </ext:GridPanel>
    </div>
    <ext:Window ID="ModalCadastro" runat="server" BodyStyle="background-color: #FFFFFF;"
        Padding="10" Hidden="true">
        <Content>
        </Content>
        <DirectEvents>
            <BeforeHide OnEvent="btnPesquisar_DirectClick">
                <EventMask ShowMask="true" />
            </BeforeHide>
        </DirectEvents>
    </ext:Window>
</asp:Content>
