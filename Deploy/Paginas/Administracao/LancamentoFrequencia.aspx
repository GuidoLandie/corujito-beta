<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="LancamentoFrequencia.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.LancamentoFrequencia" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <script type="text/javascript">
      var afterEdit = function (e) {

          CRJ.SetarPresenca(e.record.data.IdFrequencia, e.record.data.Presente);

      };
    </script>


<form id="form1" runat="server">
        <ext:GridPanel ID="GridFrequencia" runat="server" StripeRows="true" Title="Listagem de Presença"
            Icon="Table" TrackMouseOver="true" AnchorHorizontal="100%" Height="500" Frame="true" ButtonAlign="Right">

            <TopBar>
                <ext:Toolbar ID="toolbarGrid" runat="server">
                    <Items>
                         <ext:DateField ID="dtPresenca" runat="server" DisabledDatesText="Data já utilizada!" DisabledDays="0,6">
                            <DirectEvents>
                                <Select OnEvent="dtPresenca_Select"></Select>
                            </DirectEvents>
                         </ext:DateField>
                        <ext:Button ID="btnAddAtvidade" runat="server" Text="Adicionar" Icon="PageAdd" ToolTip="Selecione uma data e clique em adicionar!">
                             <DirectEvents>
                                 <Click OnEvent="btnAddAtvidade_Click"></Click>
                             </DirectEvents>
                        </ext:Button>

                    </Items>
                </ext:Toolbar>
            </TopBar>

            <Store>
                <ext:Store ID="StoreFrequencia" runat="server" ClientIDMode="Static" GroupField="DataAula">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>

                                <ext:RecordField Name="IdFrequencia"        Mapping="IdFrequencia"         Type="Int" />
                                <ext:RecordField Name="IdCRJMatricula"      Mapping="IdCRJMatricula"       Type="Int" />
                                <ext:RecordField Name="IdProfXMatXClasse"   Mapping="IdProfXMatXClasse"    Type="Int" />
                                <ext:RecordField Name="DataAula"            Mapping="DataAula"             Type="Date" />
                                <ext:RecordField Name="Presente"            Mapping="Presente"             Type="Boolean" />
                                <ext:RecordField Name="NomeAluno"           Mapping="NomeAluno"            Type="String" />

                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>            
             <Listeners>
                <AfterEdit Fn="afterEdit" />
             </Listeners>   
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    
                    <ext:DateColumn ColumnID="DataAula" Header="Data" DataIndex="DataAula" Format="dd/MM/yyyy"></ext:DateColumn>

                    <ext:Column ColumnID="NomeAluno" Header="Aluno" DataIndex="NomeAluno" Width="200"/>
                    
                    <ext:CheckColumn ColumnID="Presente" Header="Presente" DataIndex="Presente" Width="100" Fixed="true" Editable="true" Align="Center">
                        <Editor>
                            <ext:Checkbox runat="server" ID="Checkbox1"></ext:Checkbox>
                        </Editor>
                    </ext:CheckColumn>                                      

                </Columns>
            </ColumnModel>

            <View>
                <ext:GroupingView ID="GridView1" runat="server" MarkDirty="false" ForceFit="true" HideGroupedColumn="true" StartCollapsed="true" ></ext:GroupingView>
            </View>

            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel" runat="server" SingleSelect="true"></ext:RowSelectionModel>
            </SelectionModel>

        </ext:GridPanel>

</form>

</asp:Content>
