<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarAtividades.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.ConsultarAtividades" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <u>Home > Consultas > Atividades</u>


        <br />
        <br />

        <ext:GridPanel ID="GridPesquisaAtividade" runat="server" StripeRows="true" Title="Resultado da Pesquisa - Atividades"
            Icon="Table" TrackMouseOver="true" AnchorHorizontal="100%" Height="440" Frame="true" ButtonAlign="Right">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                       
                        <ext:ComboBox ID="cboPessoaDependente" runat="server" Width="740"  DisplayField="Nome" ValueField="IdAluno" FieldLabel="Aluno"
                            TypeAhead="true" Mode="Local" EmptyText="Selecione um aluno para visualizar as suas notas" ForceSelection="true" LabelWidth="50">                                        
                                <Store>
                                    <ext:Store ID="StorePessoaDependente" runat="server">
                                        <Reader>
                                            <ext:ArrayReader>
                                                <Fields>                                          
                                                    <ext:RecordField Name="IdAluno"              Mapping="IdAluno" />
                                                    <ext:RecordField Name="Nome"                 Mapping="Nome" />
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
                <ext:Store ID="StoreCRJEscola" runat="server" ClientIDMode="Static" GroupField="NomeMateria">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>

                                <ext:RecordField Name="IdAtividade"           Mapping="IdAtividade"                 Type="Int" />
                                <ext:RecordField Name="NomeAtividade"         Mapping="NomeAtividade"               Type="String" />
                                <ext:RecordField Name="TipoAtividade"   ServerMapping="TipoAtividade.Descricao"     Type="String" />
                                <ext:RecordField Name="Descricao"             Mapping="Descricao"                   Type="String" />
                                <ext:RecordField Name="Datainicial"           Mapping="Datainicial"                 Type="Date" />
                                <ext:RecordField Name="DataFinal"             Mapping="DataFinal"                   Type="Date" />
                                <ext:RecordField Name="NomeMateria"             Mapping="NomeMateria"               Type="String" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>            
            
           
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    
                    <ext:NumberColumn ColumnID="IdAtividade" Header="Atividade" DataIndex="Atividade" Format="0" Hidden="true"/>
                                      
                    <ext:Column ColumnID="NomeAtividade" Header="Nome da Atividade" DataIndex="NomeAtividade" Width="200" Fixed="true" />                       
                     
                    <ext:Column ColumnID="Descricao" Header="Descrição" DataIndex="Descricao" />

                    <ext:Column ColumnID="NomeMateria" Header="Matéria" DataIndex="NomeMateria" />
                    
                    <ext:Column ColumnID="Atividade" Header="Tipo de Atividade" DataIndex="TipoAtividade" Width="100" Fixed="true" />
                    
                    <ext:DateColumn Format="dd/m/yyyy" ColumnID="Datainicial" Header="Data Inicial" DataIndex="Datainicial" Width="70" Fixed="true" />                
                        
                    <ext:DateColumn Format="dd/m/yyyy" ColumnID="DataFinal" Header="Data Final" DataIndex="DataFinal" Width="70" Fixed="true" />                    
                        
                    
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
