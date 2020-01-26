<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="SituacaoAcademica.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.SituacaoAcademica" %>
<%@ Register Assembly="Ext.Net"     Namespace="Ext.Net"     TagPrefix="ext" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <ext:Panel ID="pnlTituloPagina" runat="server" AnchorHorizontal="100%" Title="Ocorrências" Icon="User" Frame="true" Border="true"
        PaddingSummary="10px 0px 10px 0px" AutoHeight="true">
        <Items>

        <ext:TextField ID="txtRA" runat="server" FieldLabel="RA" AnchorHorizontal="100%" Disabled="true"></ext:TextField>
        <ext:TextField ID="txtNome" runat="server" FieldLabel="Nome" AnchorHorizontal="100%" Disabled="true" Width="400"></ext:TextField>

			<ext:GridPanel ID="GridPesquisaCRJPessoa" runat="server" StripeRows="true" Title="Ocorrências" Icon="Table" TrackMouseOver="true"
                 AnchorHorizontal="100%" AutoHeight="true" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:10px;">

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
                       
                        <ext:Column ColumnID="Ocorrencia" Header="Ocorrencia" DataIndex="Ocorrencia"  Align="Left"/>
                        <ext:Column ColumnID="Providencias" Header="Providencia" DataIndex="Providencias"  Align="Left"/>
                        <ext:Column ColumnID="DataOcorrencia" Header="DataOcorrencia" DataIndex="DataOcorrencia"  Align="Left"/>
                      

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
            
            <ext:GridPanel ID="GridNotaAluno" runat="server" StripeRows="true" Title="Notas" 
            Icon="Table" TrackMouseOver="true" AnchorHorizontal="100%" AutoHeight="true" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:20px;">
            
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
                    
                    <ext:NumberColumn ColumnID="Nota" Header="Nota" DataIndex="Nota" Width="100"  Editable="true" Align="Center" Format="0.000,00/i">
                        
                    </ext:NumberColumn>                                      

                </Columns>
            </ColumnModel>

            <View>
                <ext:GroupingView ID="GridView1" runat="server" MarkDirty="false" ForceFit="true" HideGroupedColumn="true" StartCollapsed="true"  ShowGroupName="false"  ></ext:GroupingView>
            </View>

            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel" runat="server" SingleSelect="true"></ext:RowSelectionModel>
            </SelectionModel>

            <BottomBar>
					<ext:PagingToolbar ID="PagingToolbar3" runat="server" PageSize="5" EmptyMsg="Não existem dados para serem mostrados." DisplayMsg="<b>{0} a {1} de {2} registro(s)</b>">
						<Items>
							<ext:ToolbarSpacer ID="ToolbarSpacer3" runat="server" Width="10" />

							<ext:ComboBox ID="ComboBox2" runat="server" Grow="true" FieldLabel="Registros por página">
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
        
            <ext:GridPanel ID="gvFrequencia" runat="server" StripeRows="true" Title="Frequência" Icon="Table" TrackMouseOver="true"
                 AnchorHorizontal="100%" AutoHeight="true" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:30px;">

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
					<ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="5" EmptyMsg="Não existem dados para serem mostrados." DisplayMsg="<b>{0} a {1} de {2} registro(s)</b>">
						<Items>
							<ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />

							<ext:ComboBox ID="ComboBox1" runat="server" Grow="true" FieldLabel="Registros por página">
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


        </Items>
    </ext:Panel>

    	   
</asp:Content>


