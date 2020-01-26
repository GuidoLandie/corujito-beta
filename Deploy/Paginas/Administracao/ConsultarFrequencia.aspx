<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarFrequencia.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.ConsultarFrequencia" %>

<%@ Register Assembly="Ext.Net"     Namespace="Ext.Net"     TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <u>Home > Consultas > Frequência</u>


        <br />
        <br />
        
        <ext:GridPanel ID="gvFrequencia" runat="server" Title="Consulta de Frequência" Icon="TableEdit" 
                 AnchorHorizontal="100%" Frame="true" Height="400" >

                 
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
					<ext:Store ID="StoreFrequencia" runat="server" >
						<Reader>
							<ext:JsonReader>
								<Fields>
									<ext:RecordField Name="Nome"        Mapping="Nome"          Type="String" />
									<ext:RecordField Name="Descricao"        Mapping="Descricao"          Type="String" />
									<ext:RecordField Name="Frequentadas"            Mapping="Frequentadas"              Type="String" />
									<ext:RecordField Name="Total"            Mapping="Total"              Type="Int" />
									<ext:RecordField Name="Porcentagem"           Mapping="Porcentagem"             Type="Int" />
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>


				<ColumnModel ID="ColumnModel3" runat="server">
					<Columns>
                       
                        <ext:Column ColumnID="Descricao" Header="Matéria" DataIndex="Descricao"  Align="Left"/>
                        <ext:Column ColumnID="Frequentadas" Header="Presenças" DataIndex="Frequentadas"  Align="Left"/>
                        <ext:Column ColumnID="Total" Header="Aulas" DataIndex="Total"  Align="Left"/>
                        <ext:Column ColumnID="Porcentagem" Header="Porcentagem" DataIndex="Porcentagem"  Align="Left"/>
                       
						
					</Columns>
				</ColumnModel>

				<SelectionModel>
					<ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true" />
				</SelectionModel>

                <View>
                    <ext:GridView ID="GridView2" runat="server" ForceFit="true"></ext:GridView>
                </View>

				
				

			</ext:GridPanel>

</asp:Content>
