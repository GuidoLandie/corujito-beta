<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForumTopico.aspx.cs" Inherits="Corujito.Apresentacao.ForumTopico" %>
<%@ Register Assembly="Ext.Net"     Namespace="Ext.Net"     TagPrefix="ext" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ext:Hidden ID="hdIdClasse" runat="server"></ext:Hidden>
<u>Home > Administração > Forum</u>

    <br />
    <br />
    
			<ext:GridPanel ID="GridPesquisaCRJForumTopico" runat="server" StripeRows="true" Title="Forum Tópico" Icon="Table" TrackMouseOver="true"
                 AnchorHorizontal="100%" AutoHeight="true" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:10px;" MinHeight="100">

				<Store>
					<ext:Store ID="StoreCRJForumTopico" runat="server" >
						<Reader>
							<ext:JsonReader>
								<Fields>
									<ext:RecordField Name="IdForumTopico"        Mapping="IdForumTopico"          Type="Int" />
									<ext:RecordField Name="Titulo"        Mapping="Titulo"          Type="String" />
                                    <ext:RecordField Name="Mensagem"        Mapping="Mensagem"          Type="String" />
									<ext:RecordField Name="DataCriacao"            Mapping="DataCriacao"              Type="Date" />
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>

				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
                        <ext:Column ColumnID="IdForumTopico" Header="ID" DataIndex="IdForumTopico"  Align="Left"/>
                    	<ext:Column ColumnID="Titulo" Header="Título" DataIndex="Titulo" Align="Left" Width="200"/>
                        <ext:Column ColumnID="Mensagem" Header="Mensagem" DataIndex="Mensagem" Width="580" Align="Left"/>
                        <ext:DateColumn ColumnID="DataCriacao" Header="Dt. Criação" DataIndex="DataCriacao"
                    Align="Left" Format="dd/MM/yyyy" />
                       
						<ext:ImageCommandColumn Width="25" ColumnID="BotaoVisualizar">
							<Commands>
								<ext:ImageCommand CommandName="btnVisualizar" Icon="Magnifier" Text="">
									<ToolTip Title="Visualizar:" Text="Visualizar o Registro Selecionado." />
								</ext:ImageCommand>
							</Commands>
						</ext:ImageCommandColumn>

					</Columns>
				</ColumnModel>

				<SelectionModel>
					<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
				</SelectionModel>

                <View>
                    <ext:GridView ID="gvOcorrencia" runat="server" ForceFit="true"></ext:GridView>
                </View>

				<DirectEvents>
					<Command OnEvent="LinhaGrid_DirectClick">
						<EventMask ShowMask="true" MinDelay="10" />
						<ExtraParams>
							<ext:Parameter Value="record.data.IdForumTopico" Mode="Raw" Name="IdentificadorRegistroTabela"></ext:Parameter>
							<ext:Parameter Value="command" Mode="Raw" Name="IDObjeto"></ext:Parameter>
						</ExtraParams>
					</Command>
				</DirectEvents>

				<BottomBar>
					<ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="5" EmptyMsg="Não existem dados para serem mostrados." DisplayMsg="<b>{0} a {1} de {2} registro(s)</b>">
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

								<SelectedItem Value="30" />

								<Listeners>
									<Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
									<AfterRender Handler="#{cboPageSize}.setValue(10);" ></AfterRender>
								</Listeners>
							</ext:ComboBox>

						</Items>
					</ext:PagingToolbar>
				</BottomBar>
			</ext:GridPanel>
             <br /><br />
               <ext:FormPanel ID="FormPanelCadastro" runat="server"  ButtonAlign="Right" Border="false" Frame="false" LabelWidth="40" >
            <Items>
             <ext:TextField ID="txtTitulo" runat="server" FieldLabel="Título" AllowBlank="false" width="754"> 
             </ext:TextField>
             <ext:TextArea ID="txtMensagem" runat="server" FieldLabel="" AllowBlank="false" width="754" Height="130"> 
             </ext:TextArea>
            </Items>
            <Buttons>
            <ext:Button ID="btnResponder" runat="server" Icon="Disk" Text="Novo Tópico" Height="25" Width="110"  >
				<DirectEvents>
						<Click OnEvent="btnGravar_Click" Before="var valid= #{FormPanelCadastro}.getForm().isValid(); return valid;">
						<EventMask ShowMask="true" />									
					</Click>
				</DirectEvents>
			</ext:Button> 
            </Buttons>
            </ext:FormPanel>



</asp:Content>
