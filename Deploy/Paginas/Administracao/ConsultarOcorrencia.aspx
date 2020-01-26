<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarOcorrencia.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.ConsultarOcorrencia" %>

<%@ Register Assembly="Ext.Net"     Namespace="Ext.Net"     TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
            <ext:GridPanel ID="GridPesquisaCRJPessoa" runat="server" StripeRows="true" Title="Ocorrências" Icon="Table" TrackMouseOver="true"
                 AnchorHorizontal="100%" Frame="true" ButtonAlign="Right" Height="400" >
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
					<ext:Store ID="StoreCRJOcorrencia" runat="server" >
						<Reader>
							<ext:JsonReader>
								<Fields>
									<ext:RecordField Name="IdPessoa"        Mapping="IdPessoa"          Type="Int" />
									<ext:RecordField Name="IdEscola"        Mapping="IdEscola"          Type="Int" />
									<ext:RecordField Name="Nome"            Mapping="Nome"              Type="String" />
									<ext:RecordField Name="Sexo"            Mapping="Sexo"              Type="String" />
									<ext:RecordField Name="Email"           Mapping="Email"             Type="String" />
									<ext:RecordField Name="DataNascimento"  Mapping="DataNascimento"    Type="Date" />
									<ext:RecordField Name="CPF"             Mapping ="CPF"              Type="String" />
									<ext:RecordField Name="Telefone"        Mapping="Telefone"          Type="String" />
									<ext:RecordField Name="Celular"         Mapping="Celular"           Type="String" />
									<ext:RecordField Name="CEP"             Mapping="CEP"               Type="String" />
									<ext:RecordField Name="Logradouro"      Mapping="Logradouro"        Type="String" />
									<ext:RecordField Name="Numero"          Mapping="Numero"            Type="String" />
									<ext:RecordField Name="Bairro"          Mapping="Bairro"            Type="String" />
									<ext:RecordField Name="Estado"          Mapping="Estado"            Type="String" />
									<ext:RecordField Name="Pais"            Mapping="Pais"              Type="String" />
									<ext:RecordField Name="Ativo"           Mapping="Ativo"/>
                                    <ext:RecordField Name="IdOcorrencia"      Mapping="IdOcorrencia" Type="Int"/>
                                    <ext:RecordField Name="Ocorrencia"      Mapping="Ocorrencia" Type="String"/>
                                    <ext:RecordField Name="Providencias"      Mapping="Providencias" Type="String"/>
                                    <ext:RecordField Name="DataOcorrencia"      Mapping="DataOcorrencia" Type="Date"/>
                                    <ext:RecordField Name="RA"      Mapping="RA" Type="String"/>
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>


				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
                       
                        <ext:Column ColumnID="Ocorrencia" Header="Ocorrência" DataIndex="Ocorrencia"  Align="Left"/>
                        <ext:Column ColumnID="Providencias" Header="Providência" DataIndex="Providencias"  Align="Left"/>
                        <ext:DateColumn ColumnID="DataOcorrencia" Header="Data" DataIndex="DataOcorrencia"  Align="Center" Format="dd/MM/yyyy"/>
                      

					</Columns>
				</ColumnModel>

				<SelectionModel>
					<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
				</SelectionModel>

                <View>
                    <ext:GridView ID="gvOcorrencia" runat="server" ForceFit="true"></ext:GridView>
                </View>

				<%--<DirectEvents>
					<Command OnEvent="LinhaGrid_DirectClick">
						<EventMask ShowMask="true" MinDelay="10" />
						<ExtraParams>
							<ext:Parameter Value="record.data.IdOcorrencia" Mode="Raw" Name="IdentificadorRegistroTabela"></ext:Parameter>
							<ext:Parameter Value="command" Mode="Raw" Name="IDObjeto"></ext:Parameter>
						</ExtraParams>
					</Command>
				</DirectEvents>--%>

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

								<SelectedItem Value="10" />

								<Listeners>
									<Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
									<AfterRender Handler="#{cboPageSize}.setValue(10);" ></AfterRender>
								</Listeners>
							</ext:ComboBox>

						</Items>
					</ext:PagingToolbar>
				</BottomBar>

			</ext:GridPanel>

</asp:Content>
