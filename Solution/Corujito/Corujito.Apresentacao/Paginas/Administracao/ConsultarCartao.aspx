<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarCartao.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.ConsultarCartao" %>


<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <script type="text/javascript">
        
          function hideModal() {
        win = <%= ModalCadastro.ClientID %>;
        win.hide(null);
    };
      
    </script>
    
 <u>Home > Consultas > Cartão</u>


        <br />
        <br />
    <ext:GridPanel ID="GridPanelDependentes" runat="server" StripeRows="true" Title="Selecione um dependete para visualizar o seus cartão" Icon="Table" TrackMouseOver="true"
            AnchorHorizontal="100%" Height="350" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:10px;">
                      
				    <Store>
					    <ext:Store ID="StoreDependentes" runat="server" >
						    <Reader>
							    <ext:JsonReader>
								    <Fields>

									    <ext:RecordField Name="IdResponsavelXAluno"        Mapping="IdResponsavelXAluno"          Type="Int" />
                                        <ext:RecordField Name="IdPessoa"                Mapping="IdPessoa"          Type="Int" />									  
									    <ext:RecordField Name="Nome"                    Mapping="Nome"              Type="String" />
									    <ext:RecordField Name="Sexo"                    Mapping="SexoDescricao"     Type="String" />
									    <ext:RecordField Name="Email"                   Mapping="Email"             Type="String" />																		   
									    <ext:RecordField Name="Telefone"                Mapping="Telefone"          Type="String" />
									    <ext:RecordField Name="Celular"                 Mapping="Celular"           Type="String" />
									   									   
								    </Fields>
							    </ext:JsonReader>
						    </Reader>
					    </ext:Store>
				    </Store>


				    <ColumnModel ID="ColumnModel2" runat="server">
					    <Columns>
                    
                    	    <ext:Column ColumnID="Nome"         Header="Nome"       DataIndex="Nome"        Width="100" Align="Left"/>                        						
                            				
                            <ext:Column ColumnID="Email"        Header="Email"      DataIndex="Email"       Align="Left" Width="70" />	
                            <ext:Column ColumnID="Sexo"         Header="Sexo"       DataIndex="Sexo"        Align="Center" Width="70" Fixed="true" />	
                            <ext:Column ColumnID="Telefone"     Header="Telefone"   DataIndex="Telefone"    Align="Center" Width="100" Fixed="true" />	
                            <ext:Column ColumnID="Celular"      Header="Celular"    DataIndex="Celular"     Align="Center" Width="100" Fixed="true" />	
						
						  <ext:ImageCommandColumn Width="25" ColumnID="BotaoCartao">
							<Commands>
								<ext:ImageCommand CommandName="btnCartao" Icon="Money" Text="">
									<ToolTip Title="Cartão" Text="Cartão" />
								</ext:ImageCommand>
							</Commands>
						</ext:ImageCommandColumn>

					    </Columns>
				    </ColumnModel>

				    <SelectionModel>
					    <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true" />
				    </SelectionModel>

                    <View>
                        <ext:GridView ID="GridView1" runat="server" ForceFit="true"></ext:GridView>
                    </View>

				 	<DirectEvents>
					<Command OnEvent="LinhaGrid_DirectClick">
						<EventMask ShowMask="true" MinDelay="10" />
						<ExtraParams>
							<ext:Parameter Value="record.data.IdPessoa" Mode="Raw" Name="IdentificadorRegistroTabela"></ext:Parameter>
							<ext:Parameter Value="command" Mode="Raw" Name="IDObjeto"></ext:Parameter>
						</ExtraParams>
					</Command>
				</DirectEvents>		

			    </ext:GridPanel>

   <ext:Window ID="ModalCadastro" runat="server" BodyStyle="background-color: #FFFFFF;" Padding="10" Hidden="true">
		<Content>

		</Content>
		<%--<DirectEvents>
			<BeforeHide OnEvent="btnPesquisar_DirectClick"></BeforeHide>
		</DirectEvents>--%>
	</ext:Window>
</asp:Content>
