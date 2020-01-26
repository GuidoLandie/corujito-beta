<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarNotas.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.ConsultarNotas" %>

<%@ Register Assembly="Ext.Net"     Namespace="Ext.Net"     TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <u>Home > Consultas > Notas</u>


        <br />
        <br />
    
    
        <ext:GridPanel ID="GridNotaAluno" runat="server"   runat="server" StripeRows="true" Title="Notas"
            Icon="Sum" TrackMouseOver="true" Width="760" Height="350" Frame="true" ButtonAlign="Right">
            
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
                <ext:Store ID="StoreNotaAluno" runat="server" ClientIDMode="Static" GroupField="Materia">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="IdNotaAluno"         Mapping="IdNotaAluno"           Type="Int" />
                                <ext:RecordField Name="IdAtividade"         Mapping="IdAtividade"           Type="Int" />
                                <ext:RecordField Name="IdMatricula"         Mapping="IdMatricula"           Type="Int" />
                                <ext:RecordField Name="IdProfXMatXClasse"   Mapping="IdProfXMatXClasse"     Type="Int" />
                                <ext:RecordField Name="Nota"                Mapping="Nota"                  Type="Float" />
                                <ext:RecordField Name="DataNota"            Mapping="DataNota"              Type="Date" />
                                <ext:RecordField Name="Atribuidor"          Mapping="Atribuidor"            Type="Int" />
                                <ext:RecordField Name="NomeAluno"           Mapping="NomeAluno"             Type="String" />
                                <ext:RecordField Name="Atividade"           Mapping="Atividade"             Type="String" />
                                <ext:RecordField Name="Materia"           Mapping="Materia"             Type="String" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>            
            
            <ColumnModel ID="ColumnModel2" runat="server">
                <Columns>
                    <ext:Column ColumnID="Materia" Header="Matéria" DataIndex="Materia"></ext:Column>

                    <ext:Column ColumnID="Atividade" Header="Atividade" DataIndex="Atividade"></ext:Column>
                    
                    <ext:NumberColumn ColumnID="Nota" Header="Nota" DataIndex="Nota" Width="100" Align="Center" Format="0.000,00/i">
                        
                    </ext:NumberColumn>                                      

                </Columns>
            </ColumnModel>

            <View>
                <ext:GroupingView ID="GridView1" runat="server" ForceFit="true" HideGroupedColumn="true" StartCollapsed="false"  ShowGroupName="false"  ></ext:GroupingView>
            </View>

            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel" runat="server" SingleSelect="true"></ext:RowSelectionModel>
            </SelectionModel>

            

        </ext:GridPanel>



</asp:Content>
