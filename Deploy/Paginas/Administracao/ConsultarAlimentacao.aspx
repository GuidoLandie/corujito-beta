<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarAlimentacao.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.ConsultarAlimentacao" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <ext:ResourceManager ID="ResourceManager1" runat="server" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


 <u>Home > Consultas > Alimentação</u>


        <br />
        <br />

        <ext:GridPanel ID="gridPesquisaAlimentacao" runat="server" StripeRows="true" Title="Resultado da Pesquisa - Alimentação"
            Icon="Table" TrackMouseOver="true" AnchorHorizontal="100%" Height="440" Frame="true" ButtonAlign="Right">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                       
                        <ext:ComboBox ID="cboPessoaDependente" runat="server" Width="740"  DisplayField="Nome" ValueField="IdPessoa" FieldLabel="Aluno"
                            TypeAhead="true" Mode="Local" EmptyText="Selecione um aluno para visualizar as suas notas" ForceSelection="true" LabelWidth="50">                                        
                                <Store>
                                    <ext:Store ID="StorePessoaDependente" runat="server">
                                        <Reader>
                                            <ext:ArrayReader>
                                                <Fields>                                          
                                                    <ext:RecordField Name="IdPessoa"     Mapping="IdPessoa" />
                                                    <ext:RecordField Name="Nome"         Mapping="Nome" />
                                                </Fields>
                                            </ext:ArrayReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>       
                                <DirectEvents>
                                    <Select OnEvent="cboPessoaDependente_Select">
                                        <EventMask ShowMask="true" />
                                    </Select>
                                </DirectEvents>                                 
                            </ext:ComboBox>
                            
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Store>
                <ext:Store ID="StoreCRJEscola" runat="server" ClientIDMode="Static" GroupField="DataVenda">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>

                                <ext:RecordField Name="IdProdutoVendido"         Mapping="IdProdutoVendido"     Type="Int" />
                                <ext:RecordField Name="IdVendaProduto"       Mapping="IdVendaProduto"           Type="String" />
                                <ext:RecordField Name="IdProduto"       Mapping="IdProduto"                     Type="String" />
                                <ext:RecordField Name="Valor"           Mapping="Valor"                   Type="Float" />
                                <ext:RecordField Name="DataVenda"         Mapping="DataVenda"                 Type="Date" />
                                <ext:RecordField Name="Nome"           Mapping="Nome"                   Type="String" />
                                
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>            
            
           
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                                                          
                    <ext:Column ColumnID="Nome" Header="Produto" DataIndex="Nome" Width="200" Fixed="false" />                       
                     
                    <ext:NumberColumn ColumnID="Valor" Header="Valor" DataIndex="Valor"  Format="0.000,00/i" Align="Right"/>
                    
                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="DataVenda" Header="Data da Venda" DataIndex="DataVenda" Width="70" Fixed="true" />                    
                        
                    
                </Columns>
            </ColumnModel>


            <View>
                <ext:GroupingView ID="GridView1" runat="server" ForceFit="True" HideGroupedColumn="true"></ext:GroupingView>
            </View>

            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel" runat="server" SingleSelect="true"></ext:RowSelectionModel>
            </SelectionModel>

        </ext:GridPanel>

</asp:Content>
