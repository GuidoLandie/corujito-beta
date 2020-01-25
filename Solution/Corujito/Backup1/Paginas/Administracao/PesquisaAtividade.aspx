<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="PesquisaAtividade.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.PesquisaAtividade" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      
    <script type="text/javascript">
        var afterEdit = function (e) {


                                    //IdAtividade,                       NomeAtividade,               TipoAtividade,          Descricao,          Datainicial,                    DataFinal
            CompanyX.AfterEdit(e.record.data.IdAtividade, e.record.data.NomeAtividade, e.record.data.TipoAtividade, e.record.data.Descricao, e.record.data.Datainicial, e.record.data.DataFinal);
        };
    </script>

      <ext:XScript ID="XScript1" runat="server">
        <script type="text/javascript">
            var addEmployee = function () {
                var grid = #{GridPesquisaAtividade};
                grid.getRowEditor().stopEditing();
                
                grid.insertRecord(0, {
                    NomeAtividade   : ""                   
                });
                
                grid.getView().refresh();
                grid.getSelectionModel().selectRow(0);
                grid.getRowEditor().startEditing(0);
            }
            
            var removeEmployee = function () {
                var grid = #{GridPesquisaAtividade};
                grid.getRowEditor().stopEditing();
                
                var s = grid.getSelectionModel().getSelections();
                
                for (var i = 0, r; r = s[i]; i++) {                    
                    CompanyX.btnExcluir(r.data.IdAtividade);        
                }
            }
        </script>
    </ext:XScript>

        <ext:GridPanel ID="GridPesquisaAtividade" runat="server" StripeRows="true" Title="Resultado da Pesquisa - Atividades"
            Icon="Table" TrackMouseOver="true" AnchorHorizontal="100%" Height="440" Frame="true" ButtonAlign="Right">
            <TopBar>
                <ext:Toolbar ID="toolbarGrid" runat="server">
                    <Items>
                        <ext:Button ID="btnAddAtvidade" runat="server" Text="Adicionar" Icon="PageAdd">
                              <Listeners>
                                <Click Fn="addEmployee" />
                            </Listeners>
                        </ext:Button>

                        <ext:Button ID="Button1" runat="server" Text="Remover" Icon="PageDelete">
                            <Listeners>
                                <Click Fn="removeEmployee" />
                            </Listeners>
                        </ext:Button>

                        <ext:ToolbarFill />

                        <ext:Label ID="lblInfo" runat="server" Text="Duplo clique para editar" />

                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Store>
                <ext:Store ID="StoreCRJEscola" runat="server" ClientIDMode="Static">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>

                                <ext:RecordField Name="IdAtividade"           Mapping="IdAtividade"                 Type="Int" />
                                <ext:RecordField Name="NomeAtividade"         Mapping="NomeAtividade"               Type="String" />
                                <ext:RecordField Name="TipoAtividade"   ServerMapping="TipoAtividade.Descricao"     Type="String" />
                                <ext:RecordField Name="Descricao"             Mapping="Descricao"                   Type="String" />
                                <ext:RecordField Name="Datainicial"           Mapping="Datainicial"                 Type="Date" />
                                <ext:RecordField Name="DataFinal"             Mapping="DataFinal"                   Type="Date" />

                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>            
            
            <Plugins>
                <ext:RowEditor ID="RowEditor1" runat="server" SaveText="Salvar" CancelText="Cancelar" ErrorSummary="false" >
                    <Listeners>             
                            <AfterEdit Fn="afterEdit" />             
                    </Listeners>
                </ext:RowEditor>
            </Plugins>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    
                    <ext:NumberColumn ColumnID="IdAtividade" Header="Atividade" DataIndex="Atividade" Format="0" Hidden="true"/>
                                      
                    <ext:Column ColumnID="NomeAtividade" Header="Nome da Atividade" DataIndex="NomeAtividade" Width="200" Fixed="true">  
                      <Editor>
                            <ext:TextField ID="TextField5" runat="server" AllowBlank="false" />
                     </Editor>
                     </ext:Column>

                      <ext:Column ColumnID="Descricao" Header="Descrição" DataIndex="Descricao">
                        <Editor>
                            <ext:TextField ID="TextField2" runat="server" AllowBlank="false" />
                        </Editor>
                    </ext:Column>   


                    <ext:Column ColumnID="Atividade" Header="Tipo de Atividade" DataIndex="TipoAtividade" Width="100" Fixed="true">
                     <Editor>
                        <ext:ComboBox ID="cboTipoatividade" runat="server" Editable="true" AllowBlank="false"
                          BlankText="O campo Tipo de Atividade é Obrigatório." DisplayField="Descricao" ValueField="Descricao" Mode="Local">
                            <Store>
                                <ext:Store ID="StoreTipoAtividade" runat="server">
                                    <Reader>
                                        <ext:ArrayReader>
                                            <Fields>                                          
                                                 <ext:RecordField Name="IdTipoAtividade" Mapping="IdTipoAtividade" />
                                                <ext:RecordField Name="Descricao"      Mapping="Descricao" />
                                            </Fields>
                                        </ext:ArrayReader>
                                    </Reader>
                                </ext:Store>
                            </Store>                    
                        </ext:ComboBox>
                     </Editor>
                     </ext:Column>
                      
                    
                                 
                    <ext:DateColumn Format="dd/m/yyyy" ColumnID="Datainicial" Header="Data Inicial" DataIndex="Datainicial" Width="70" Fixed="true">                
                        <Editor>
                                <ext:DateField ID="TextField3" runat="server" AllowBlank="false" />
                         </Editor>
                    </ext:DateColumn> 

                    <ext:DateColumn Format="dd/m/yyyy" ColumnID="DataFinal" Header="Data Final" DataIndex="DataFinal" Width="70" Fixed="true">                    
                        <Editor>
                          <ext:DateField ID="TextField4" runat="server" AllowBlank="false" />
                         </Editor>
                     </ext:DateColumn>
                </Columns>
            </ColumnModel>


            <View>
                <ext:GridView ID="GridView1" runat="server" MarkDirty="false" ForceFit="True"></ext:GridView>
            </View>

            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel" runat="server" SingleSelect="true"></ext:RowSelectionModel>
            </SelectionModel>

        </ext:GridPanel>
   
 
</asp:Content>
