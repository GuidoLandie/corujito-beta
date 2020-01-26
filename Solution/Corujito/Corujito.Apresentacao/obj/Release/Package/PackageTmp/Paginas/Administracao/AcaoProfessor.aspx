<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AcaoProfessor.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.AcaoProfessor" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <u>Home > Controle de Sala </u>

    <br />
    <br />
    
    <ext:panel id="PanelPesquisaParametrosProfessor" runat="server" title="Controle de Sala e Matérias do Professor"
     icon="Magnifier" width="760" height="400" frame="true" buttonalign="Right" collapsible="true" Layout="FormLayout">

		<Items>

				<ext:FormPanel ID="FormPanelPesquisaParametrosProfessor" runat="server" LabelWidth="70"   ButtonAlign="Right" Border="false" 
                LabelAlign="left" PaddingSummary="10px 10px 0px" >
                <Items>

                <ext:Label ID="lblprofessor" runat="server" FieldLabel="Professor" StyleSpec="" ></ext:Label>


                 
          <ext:GridPanel ID="GridProfAcao" runat="server" StripeRows="true" Title="Listagem de materias" Icon="Table" TrackMouseOver="true"
                 AnchorHorizontal="100%" Height="300" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:10px;">
                 
				<Store>
					<ext:Store ID="StoreProfMateria" runat="server" GroupField="Classe" >
						<Reader>
							<ext:JsonReader>
								<Fields>
                                
									<ext:RecordField Name="idProfXMateriaXClasse"             Mapping="idProfXMateriaXClasse"       Type="Int"/>
                                    <ext:RecordField Name="Ensino"                      ServerMapping="Classe.Ensino.DescEnsino"    Type="String" />
                                    <ext:RecordField Name="Materia"                     ServerMapping="Materia.Descricao"           Type="String" />
									<ext:RecordField Name="Classe"                      ServerMapping="Classe.NomeTurma"            Type="String" />
                                    <ext:RecordField Name="IdClasse"                      ServerMapping="Classe.idClasses"          Type="Int" />
                                    <ext:RecordField Name="Serie"                      ServerMapping="Classe.Serie.Descricao"       Type="String" />
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
              

				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
                   
                    	<ext:Column     ColumnID="Ensino"           Header="Ensino"     DataIndex="Ensino"    Align="Center" />                        						
                        <ext:Column     ColumnID="Materia"          Header="Matéria"    DataIndex="Materia"   Align="Left" />	
                        <ext:Column     ColumnID="Classe"           Header="Classe"     DataIndex="Classe"    Align="Left" />
                         <ext:Column     ColumnID="Serie"           Header="Série"     DataIndex="Serie"    Align="Left" />
                                                				                                                			                                                                          

						
                         <%--<ext:ImageCommandColumn Width="23" ColumnID="BotaoAlunos" Align="Center">
							<Commands>								
                                <ext:ImageCommand CommandName="btnConsultarFrquencia" Icon="Group">
									<ToolTip Title="Alunos:" Text="Visualizar alunos." />
								</ext:ImageCommand>
							</Commands>
						</ext:ImageCommandColumn>--%>

                        <ext:ImageCommandColumn Width="23" ColumnID="BotaoFreq"  Align="Center">
							<Commands>								
                                <ext:ImageCommand CommandName="btnFrquencia" Icon="TableEdit" Text="">
									<ToolTip Title="Frequencia:" Text="Lançar / Consultar frequência." />
								</ext:ImageCommand>
							</Commands>
						</ext:ImageCommandColumn>

                          <ext:ImageCommandColumn Width="23" ColumnID="BotaoNota"  Align="Center">
							<Commands>							
                                <ext:ImageCommand CommandName="btnNotas" Icon="Sum" >
									<ToolTip Title="Notas:" Text="Adicione notas as atividades." />
								</ext:ImageCommand>
							</Commands>
						</ext:ImageCommandColumn>

                          <ext:ImageCommandColumn Width="23" ColumnID="BotaoAtividade"  Align="Center">
							<Commands>								
                                <ext:ImageCommand CommandName="btnConsultarAtividade" Icon="FolderPage">
									<ToolTip Title="Atividade:" Text="Adicione/edite uma atividade de sala" />
								</ext:ImageCommand>
							</Commands>
						</ext:ImageCommandColumn>

                       </Columns>
				</ColumnModel>

				<SelectionModel>
					<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
				</SelectionModel>

                <View>
                    <ext:GroupingView ID="GridView1" runat="server" ForceFit="true" HideGroupedColumn="true"></ext:GroupingView>
                </View>

				<DirectEvents>
					<Command OnEvent="LinhaGrid_DirectClick">
						<EventMask ShowMask="true" MinDelay="10" />
						<ExtraParams>
							<ext:Parameter Value="record.data.idProfXMateriaXClasse" Mode="Raw" Name="idProfXMateriaXClasse" /> 
                            <ext:Parameter Value="record.data.IdClasse" Mode="Raw" Name="IdClasse" /> 
                            <ext:Parameter Value="record.data.Materia + ' - ' + record.data.Classe" Mode="Raw" Name="Titulo" />                                                        
							<ext:Parameter Value="command" Mode="Raw" Name="IDObjeto"></ext:Parameter>
						</ExtraParams>
					</Command>
				</DirectEvents>				

			</ext:GridPanel>


               </Items>
               </ext:FormPanel>
             </Items>
      </ext:panel>   
 
    <ext:Window ID="ModalCadastro" runat="server" BodyStyle="background-color: #FFFFFF;"        
        PaddingSummary="10px 10px 10px 10px" Hidden="true">
        <Content>
        </Content>
     <%--   <DirectEvents>
				<BeforeHide OnEvent="ModalCadastro_BeforeHide"></BeforeHide>
			</DirectEvents>--%>
    </ext:Window>
                                    
</asp:Content>

