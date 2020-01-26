﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="CadastroNota.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroNota" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

 <ext:panel id="PanelCadastrarNotaProfessor" runat="server" title="Cadastro de Nota"
        icon="add" width="760" height="400" frame="true" buttonalign="Right" collapsible="true" Layout="FormLayout">

			<Items>

				<ext:FormPanel ID="FormPanelCadastrarNotaProfessor" runat="server" LabelWidth="50"   ButtonAlign="Right" Border="false" 
                LabelAlign="left" PaddingSummary="10px 10px 0px" >
                <Items>
                <ext:Label ID="idProfXMateriaXClasse" runat="server" FieldLabel="Professor" StyleSpec="" ></ext:Label>
                <ext:Label ID="Ensino" runat="server" FieldLabel="Professor" StyleSpec="" ></ext:Label>
                <ext:Label ID="Materia" runat="server" FieldLabel="Professor" StyleSpec="" ></ext:Label>
                <ext:Label ID="Classe" runat="server" FieldLabel="Professor" StyleSpec="" ></ext:Label>


          <ext:GridPanel ID="GridNota" runat="server" StripeRows="true" Title="Listagem das Ações." Icon="Table" TrackMouseOver="true"
                 AnchorHorizontal="100%" Height="300" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:10px;">
                 
				<Store>
					<ext:Store ID="StoreNota" runat="server" >
						<Reader>
							<ext:JsonReader>
								<Fields>
                                
									<ext:RecordField Name="idAluno"             Mapping="idProfXMateriaXClasse"       Type="Int"/>
                                    <ext:RecordField Name="Nota"                      ServerMapping="Classe.Ensino.DescEnsino"    Type="String" />
                                </Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
              

				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
                   
                    	<ext:Column     ColumnID="Nome"           Header="Nome"     DataIndex="Nome"    Align="Center" />                        						
                        <ext:Column     ColumnID="Nota"          Header="Nota"    DataIndex="Nota"   Align="Left" />	
                                                                       				                                                			                                                                          

				<SelectionModel>
					<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
				</SelectionModel>

                <View>
                    <ext:GridView ID="GridView1" runat="server" ForceFit="true"></ext:GridView>
                </View>

				<DirectEvents>
					<Command OnEvent="LinhaGrid_DirectClick">
						<EventMask ShowMask="true" MinDelay="10" />
						<ExtraParams>
							<ext:Parameter Value="record.data.idProfXMateriaXClasse" Mode="Raw" Name="idProfXMateriaXClasse" />                                                        
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