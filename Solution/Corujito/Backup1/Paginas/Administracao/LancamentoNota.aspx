<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="LancamentoNota.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.LancamentoNota" %>


<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <script type="text/javascript">
      var afterEdit = function (e) {

          CRJ.SetarPresenca(e.record.data.IdNotaAluno, e.record.data.Nota);

      };
    </script>


<form id="form1" runat="server">
        <ext:GridPanel ID="GridNotaAluno" runat="server" StripeRows="true" Title="Nota das Atividades"
            Icon="Table" TrackMouseOver="true" AnchorHorizontal="100%" Height="500" Frame="true" ButtonAlign="Right">
            
            <Store>
                <ext:Store ID="StoreNotaAluno" runat="server" ClientIDMode="Static" GroupField="Atividade">
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
                    
                    <ext:Column ColumnID="Atividade" Header="Atividade" DataIndex="Atividade"></ext:Column>

                    <ext:Column ColumnID="NomeAluno" Header="Aluno" DataIndex="NomeAluno" Width="200"/>
                    
                    <ext:NumberColumn ColumnID="Nota" Header="Nota" DataIndex="Nota" Width="100"  Editable="true" Align="Center" Format="0.000,00/i">
                        <Editor>
                            <ext:NumberField ID="txtNota" runat="server" DecimalPrecision="2" DecimalSeparator="," MaxLength="5">
                                <Listeners>
                                    <Change Handler="if(this.getValue() < 0 ) this.setValue(0);if(this.getValue() > 10 ) this.setValue(10);" />
                                </Listeners>
                            </ext:NumberField>
                        </Editor>
                    </ext:NumberColumn>                                      

                </Columns>
            </ColumnModel>

            <View>
                <ext:GroupingView ID="GridView1" runat="server" MarkDirty="false" ForceFit="true" HideGroupedColumn="true" StartCollapsed="true"  ShowGroupName="false"  ></ext:GroupingView>
            </View>

            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel" runat="server" SingleSelect="true"></ext:RowSelectionModel>
            </SelectionModel>

        </ext:GridPanel>

</form>

</asp:Content>
