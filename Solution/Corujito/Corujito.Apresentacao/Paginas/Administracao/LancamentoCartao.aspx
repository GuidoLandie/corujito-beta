<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true"
    CodeBehind="LancamentoCartao.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.LancamentoCartao" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <form id="formLancamentoCartao" runat="server">

    <ext:NumberField ID="txtNumeroCartao" runat="server" FieldLabel="Número do Cartão" Width="140" MaxLength="20" Disabled="true" Hidden="true" />

    <ext:GridPanel ID="GridPesquisaCRJProduto" runat="server" StripeRows="true" Icon="Table" Title="Extrato cartão"
        TrackMouseOver="true" AnchorHorizontal="100%" Height="390" Frame="true" ButtonAlign="Right">
        <TopBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    
                     <ext:NumberField ID="txtValor" runat="server" FieldLabel="Adicionár crédito" Width="200" LabelWidth="100" EmptyText="Valor"  />

                    <ext:ToolbarSeparator />
                    
                    <ext:TextField ID="txtDescricao" runat="server" Width="150" HideLabel="true" EmptyText="Descrição"></ext:TextField>


                     <ext:ToolbarSeparator />                     
                    
                    <ext:Button ID="btnAdicionarCredito" runat="server" Icon="Add" Text="Adicionár crédito"
                        Height="20" Width="110" ToolTip="Adicionar créditos no cartão">
                        <DirectEvents>
                            <Click OnEvent="btnPesquisar_DirectClick">
                                <EventMask ShowMask="true" MinDelay="10" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>

                    <ext:ToolbarFill />

                    <ext:Label ID="lblSaldo" runat="server" FieldLabel="Saldo" Text="0,00"></ext:Label>

                </Items>
            </ext:Toolbar>
        </TopBar>
        <Store>
            <ext:Store ID="StoreCRJProduto" runat="server" GroupField="DataLancamento" GroupDir="DESC">
                <Reader>
                    <ext:JsonReader>
                        <Fields>
                            <ext:RecordField Name="IdPessoa" Mapping="IdPessoa" Type="Int" />
                            <ext:RecordField Name="IdEscola" Mapping="IdEscola" Type="Int" />
                            <ext:RecordField Name="Nome" Mapping="Nome" Type="String" />
                            <ext:RecordField Name="Sexo" Mapping="Sexo" Type="String" />
                            <ext:RecordField Name="Email" Mapping="Email" Type="String" />
                            <ext:RecordField Name="DataNascimento" Mapping="DataNascimento" Type="Date" />
                            <ext:RecordField Name="CPF" Mapping="CPF" Type="String" />
                            <ext:RecordField Name="Telefone" Mapping="Telefone" Type="String" />
                            <ext:RecordField Name="Celular" Mapping="Celular" Type="String" />
                            <ext:RecordField Name="CEP" Mapping="CEP" Type="String" />
                            <ext:RecordField Name="Logradouro" Mapping="Logradouro" Type="String" />
                            <ext:RecordField Name="Numero" Mapping="Numero" Type="String" />
                            <ext:RecordField Name="Bairro" Mapping="Bairro" Type="String" />
                            <ext:RecordField Name="Estado" Mapping="Estado" Type="String" />
                            <ext:RecordField Name="Pais" Mapping="Pais" Type="String" />
                            <ext:RecordField Name="Ativo" Mapping="Ativo" />
                            
                            
                            <ext:RecordField Name="IdLancamentoCartao"  Mapping="IdLancamentoCartao" Type="Int" />
                            <ext:RecordField Name="Valor"                Mapping="Valor"            Type="Float" />
                            <ext:RecordField Name="DataLancamento"      Mapping="DataLancamento"    Type="Date" />
                            <ext:RecordField Name="Descricao"           Mapping="Descricao"         Type="String" />


                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
        </Store>
        <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>
                
                <ext:NumberColumn ColumnID="IdLancamentoCartao"     Header="IdLancamentoCartao"     DataIndex="IdLancamentoCartao"  Align="Left" Hidden="true"/>
                <ext:Column ColumnID="Descricao"                    Header="Descricao"              DataIndex="Descricao"  Align="Left" />
                <ext:NumberColumn ColumnID="Valor"                  Header="Valor"                  DataIndex="Valor"               Width="100" Fixed="true" Align="Right" Format="0.000,00/i" />
                <ext:DateColumn ColumnID="DataLancamento"           Header="Data de Lançamento"     DataIndex="DataLancamento"      Width="110" Fixed="true" Align="Center" Format="dd/MM/yyyy" />
                
                <ext:ImageCommandColumn Width="25" ColumnID="BotaoAlterar" Hidden="true">
                    <Commands>
                        <ext:ImageCommand CommandName="btnAlterar" Icon="PageWhiteEdit" Text="">
                            <ToolTip Title="Alteração:" Text="Alterar o Registro Selecionado." />
                        </ext:ImageCommand>
                    </Commands>
                </ext:ImageCommandColumn>
            
            </Columns>
        </ColumnModel>
        <LoadMask ShowMask="true" />

        <Plugins>
            <ext:GridFilters runat="server" ID="GridFilters1" Local="true" FiltersText="Filtros">
                <Filters>
                  
                    <ext:StringFilter   DataIndex="Descricao" />
                    <ext:NumericFilter  DataIndex="Valor" />
                    <ext:DateFilter     DataIndex="DataLancamento" />
                    
                </Filters>
            </ext:GridFilters>
        </Plugins>
        
        <SelectionModel>
            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
        </SelectionModel>
        
        <View>
            <ext:GroupingView ID="GridViewProduto" runat="server" ForceFit="true">
            </ext:GroupingView>
        </View>
        
        <DirectEvents>
            <Command OnEvent="LinhaGrid_DirectClick">
                <EventMask ShowMask="true" MinDelay="10" />
                <ExtraParams>
                    <ext:Parameter Value="record.data.IdLancamentoCartao" Mode="Raw" Name="IdentificadorRegistroTabela">
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

</form>
</asp:Content>
