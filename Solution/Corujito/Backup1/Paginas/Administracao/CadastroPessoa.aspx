<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroPessoa.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroPessoa" %>

<%@ Register Assembly="Ext.Net"     Namespace="Ext.Net"     TagPrefix="ext" %>
<%@ Register Assembly="Ext.Net.UX"  Namespace="Ext.Net.UX"  TagPrefix="ux" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
       <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="tem mxt/javascript">
    function hideModal() {
    win = <%= ModalCadastro.ClientID %>;
    win.hide(null);
    }


</script>

    <u>Home > Administração > Cadastro Pessoa > Incluir</u>


        <br />
        <br />
    
    
        

     <ext:Panel ID="pnlTituloPagina" runat="server" AnchorHorizontal="100%" Title="Cadastro de Pessoas" Icon="User" Frame="true" Border="true"
        PaddingSummary="10px 0px 10px 0px" >
        <Items>
        
        <ext:FormPanel ID="FormPanelCadastro" runat="server"  ButtonAlign="Right" Border="false" Frame="false" >
            <Items>
           
           
        <ext:TabPanel ID="TabPanelCadastro" runat="server" AnchorHorizontal="100%"  PaddingSummary="0px 0px 0px 0px" Frame="true" Border="false" AutoHeight="true">
            <Items>

             <ext:Panel ID="PanelCadastroPessoa" runat="server" Title="Dados Pessoais" Frame="true" Border="true" AnchorHorizontal="100%"
                 PaddingSummary="0px 0px 0px 0px" LabelAlign="Left" LabelWidth="120" Layout="FormLayout" Height="500">

					<Items>

						<ext:NumberField ID="txtIdPessoa" runat="server" FieldLabel="Codigo da Pessoa" AnchorHorizontal="30%" MaxLength="4" 
                                AllowBlank="False" BlankText="O campo Codigo da Pessoa é Obrigatório." Disabled="True" Hidden="true" Text="0">
						</ext:NumberField>					

                        <ext:Hidden ID="txtIdAluno" runat="server" Text="0" ></ext:Hidden>

						<ext:TextField ID="txtNome" runat="server" FieldLabel="Nome" AnchorHorizontal="100%" MaxLength="255" AllowBlank="False"
                             BlankText="O campo Nome é Obrigatório." >						    
                        </ext:TextField>

                        <ext:TextField ID="txtEmail" runat="server" FieldLabel="Email" AnchorHorizontal="97%" MaxLength="255" AllowBlank="false" 
                            BlankText="O campo Email é Obrigatório." Disabled="False" Vtype="email" IndicatorIcon="Information" IndicatorTip="E-mail que será utilizado para logar no sistema.">
						</ext:TextField>

                        
                        <ext:Container ID="container2" runat="server" Layout="ColumnLayout" Height="25">
                            <Items>
                                <ext:Container ID="container3" runat="server" Layout="FormLayout" ColumnWidth="0.611" LabelWidth="120"  >
                                    <Items>
						                <ext:TextField ID="txtTelefone" runat="server" FieldLabel="Telefone" Width="177" MaxLength="255"  
                                            AllowBlank="False" BlankText="O campo Telefone é Obrigatório." Disabled="False" EmptyText="(__)____-____">
						                    <Plugins>
                                                <ux:InputTextMask Id="InputTextMask1" runat="server" Mask="(99)9999-9999"></ux:InputTextMask>
                                            </Plugins> 
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="container4" runat="server" Layout="FormLayout" ColumnWidth="0.35" >
                                    <Items>            
                                        <ext:TextField ID="txtCelular" runat="server" FieldLabel="Celular" Width="177" MaxLength="255"
                                            AllowBlank="True" BlankText="O campo Celular é Obrigatório." Disabled="False" EmptyText="(__)____-____">
						                    <Plugins>
                                                <ux:InputTextMask Id="InputTextMask2" runat="server" Mask="(99)9999-9999"></ux:InputTextMask>
                                            </Plugins> 
                                        </ext:TextField>                       
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>

                         <ext:Container ID="container11" runat="server" Layout="ColumnLayout" Height="25">
                            <Items>
                                <ext:Container ID="container13" runat="server" Layout="FormLayout" ColumnWidth="0.611" LabelWidth="120"  >
                                    <Items>

                                        <ext:TextField ID="txtCPF" runat="server" FieldLabel="CPF" Width="177" MaxLength="255" 
                                             BlankText="O campo CPF é Obrigatório." Disabled="False" AllowBlank="false" EmptyText="___.___.___-_" >
                                            <Plugins>
                                                <ux:InputTextMask Id="InputTextMask3" runat="server" Mask="999.999.999-99"></ux:InputTextMask>
                                            </Plugins>
                                            <DirectEvents>
                                                <Change OnEvent="txtCPF_Chance">
                                                    <EventMask ShowMask="true" />
                                                </Change>
                                            </DirectEvents>                        
                                        </ext:TextField>

                                     </Items>
                                </ext:Container>
                                <ext:Container ID="container14" runat="server" Layout="FormLayout" ColumnWidth="0.35" >
                                    <Items>      
                                    
                                     <ext:TextField ID="txtRG" runat="server" FieldLabel="RG" Width="177" MaxLength="255" 
                                             BlankText="O campo RG é Obrigatório." Disabled="False" AllowBlank="false" EmptyText="__.___.___-_" >
                                            <Plugins>
                                                <ux:InputTextMask Id="InputTextMask4" runat="server" Mask="99.999.999-9"></ux:InputTextMask>
                                            </Plugins>
                                            <DirectEvents>
                                                <Change OnEvent="txtRG_Chance">
                                                    <EventMask ShowMask="true" />
                                                </Change>
                                            </DirectEvents>                        
                                        </ext:TextField>
                                          
                                      </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>

                        

                        <ext:DateField ID="txtDataNascimento" runat="server" FieldLabel="Data de Nascimento" 
                             MaxLength="10" 
                             MaxLengthText="10" 
                             Format="dd/MM/yyyy" 
                             TodayText="Hoje" 
                             InvalidText="Digite uma data válida no formato dd/MM/yyyy" DisabledDaysText="Data Desabilitada."  
                             AllowBlank="False" BlankText="O campo Data de Nascimento é Obrigatório." 
                             EmptyText="dd/MM/yyyy" FocusClass="NOMECSS" AltFormats="ddMMyyyy" 
                             Width="177"
                             >
						</ext:DateField>


                        <ext:ComboBox ID="cboSexo" runat="server" FieldLabel="Sexo" Width="100" BlankText="O campo Sexo é Obrigatório." AllowBlank="False">
                            <Items>                                
                                <ext:ListItem Text="Masculino"  Value="1" />
                                <ext:ListItem Text="Feminino" Value="2" />
                            </Items>
                        </ext:ComboBox>


						<ext:ComboBox ID="cboAtivo" runat="server" FieldLabel="Situação" Width="100"   BlankText="O campo Ativo é Obrigatório." AllowBlank="False"
                            DisplayField="Descricao" ValueField="IdStatus">
                           <Store>
                                <ext:Store ID="storeSituacao">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="IdStatus"  Mapping="IdStatus" Type="Int" />
                                                <ext:RecordField Name="Descricao" Mapping="Descricao" Type="String" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                           </Store>
                           
                        </ext:ComboBox>


                        
                        <ext:TextField ID="txtSenha" runat="server" FieldLabel="Senha" Width="177" MaxLength="255"   InputType="Password" 
                             BlankText="O campo Senha é Obrigatório." Disabled="False" AllowBlank="false" Hidden="true">
						</ext:TextField>

                        <ext:TextField ID="txtConfrimSenha" runat="server" FieldLabel="Confirmar Senha" Width="177" MaxLength="255"  MsgTarget="Side" 
                             BlankText="O campo Confirmar Senha é Obrigatório." Disabled="False" AllowBlank="false"   InputType="Password" Hidden="true" Vtype="password"
                              VtypeText="O Campo Senha não confere com o campo Confirmar Senha.">
						<CustomConfig>
                            <ext:ConfigItem Name="initialPassField" Value="#{txtSenha}" Mode="Value"/>
                        </CustomConfig>   
                        
                        </ext:TextField>

                        <ext:LinkButton ID="lkbAlterarSenha" runat="server" FieldLabel="Senha" Text="Alterar Senha" Hidden="true">
                            <DirectEvents>
                                <Click OnEvent="lkbAlterarSenha_Click">
                                    <EventMask ShowMask="true"/>
                                </Click>
                            </DirectEvents>
                        </ext:LinkButton>

                        <ext:LinkButton ID="lkbCancelar" runat="server" FieldLabel="Senha" Text="Cancelar" Hidden="true">
                            <DirectEvents>
                                <Click OnEvent="lkbCancelar_Click">
                                    <EventMask ShowMask="true"/>
                                </Click>
                            </DirectEvents>
                        </ext:LinkButton>


                        <ext:Container ID="container1" runat="server" Layout="FormLayout" AnchorHorizontal="100%" LabelAlign="Left" Hidden="false" Height="200">
                            <Items>
                            <ext:FieldSet ID="fdsTipoPessoa" runat="server" Title="Atividades"  Layout="HBoxLayout" AnchorHorizontal="100%" Collapsible="true" Hidden="false" >
                                <Items>                                                                                                       
                                
                                </Items>
                            </ext:FieldSet>

                                <ext:FieldSet ID="fdsEndereco" runat="server" Title="Endereço"  AnchorHorizontal="100%" LabelAlign="Left" LabelWidth="107" Collapsible="true">
                                    <Items>
                                            <ext:TextField ID="txtCEP" runat="server" FieldLabel="CEP" AnchorHorizontal="25%" MaxLength="9" AllowBlank="false"
                                                 BlankText="O campo CEP é Obrigatório." Disabled="False" EmptyText="_____-___">
						                        <Plugins>
                                                    <ux:InputTextMask Id="InputTextMask0" runat="server" Mask="99999-999"></ux:InputTextMask>
                                                </Plugins> 
                                            </ext:TextField>

                                            <ext:Container ID="container5" runat="server" Layout="ColumnLayout" Height="25">
                                                <Items>
                                                    <ext:Container ID="container6" runat="server" Layout="FormLayout" ColumnWidth="0.7" LabelWidth="107"  >
                                                        <Items>
                                                            <ext:TextField ID="txtLogradouro" runat="server" FieldLabel="Logradouro" AnchorHorizontal="95%" MaxLength="255"  
                                                                AllowBlank="false" BlankText="O campo Logradouro é Obrigatório." Disabled="False">
						                                    </ext:TextField>
                                                        </Items>
                                                    </ext:Container>
                                                    <ext:Container ID="container7" runat="server" Layout="FormLayout" ColumnWidth="0.3" LabelWidth="71"  >
                                                        <Items>
                                                            <ext:TextField ID="txtNumero" runat="server" FieldLabel="Numero" AnchorHorizontal="100%" MaxLength="255"
                                                             AllowBlank="false" BlankText="O campo Numero é Obrigatório." Disabled="False">
						                                    </ext:TextField>
                                                        </Items>
                                                    </ext:Container>
                                            
                                                </Items>
                                            </ext:Container>

                                              <ext:TextField ID="txtBairro" runat="server" FieldLabel="Bairro"  MaxLength="255" AllowBlank="False" Width="500"
                                                    BlankText="O campo Bairro é Obrigatório." Disabled="False">
						                    </ext:TextField>

                                            <ext:Container ID="container8" runat="server" Layout="ColumnLayout" Height="25">
                                                <Items>
                                                    <ext:Container ID="container9" runat="server" Layout="FormLayout" ColumnWidth="0.376" LabelWidth="107" >
                                                        <Items>		
                                                            
						                                    <ext:ComboBox ID="txtPais" runat="server" FieldLabel="País" Width="127" MaxLength="255" AllowBlank="False"
                                                                    BlankText="O campo País é Obrigatório." Disabled="False">
						                                        <Items>
                                                                    <ext:ListItem Text="Brasil" Value="1" />
                                                                </Items>
                                                                <SelectedItem Value="1" />
                                                            </ext:ComboBox>                                                        					                    
                                                        </Items>
                                                    </ext:Container>  

                                                    <ext:Container ID="container12" runat="server" Layout="FormLayout" ColumnWidth="0.34" LabelWidth="70" >
                                                            <Items>	

                                                                <ext:ComboBox ID="txtEstado" runat="server" FieldLabel="Estado" Width="139" MaxLength="255" AllowBlank="False"
                                                                    BlankText="O campo Estado é Obrigatório." Disabled="False" DisplayField="nome" ValueField="id" TypeAhead="true" Mode="Local" ForceSelection="true">
                                                                        <Store>
                                                                            <ext:Store ID="storeEstado" runat="server">
                                                                                <Reader>
                                                                                    <ext:JsonReader>
                                                                                        <Fields>
                                                                                            <ext:RecordField Name="id"  Mapping="id"    Type="Int" />
                                                                                            <ext:RecordField Name="nome" Mapping="nome" Type="String" />
                                                                                        </Fields>
                                                                                    </ext:JsonReader>
                                                                                </Reader>
                                                                            </ext:Store>
                                                                        </Store>
                                                                    <DirectEvents>
                                                                        <Select OnEvent="PopularCidade">
                                                                            <EventMask ShowMask="true" />
                                                                        </Select>
                                                                    </DirectEvents>
                                                                </ext:ComboBox>	
                                                        </Items>
                                                    </ext:Container>	                    
                                                    

                                                    <ext:Container ID="container10" runat="server" Layout="FormLayout" ColumnWidth="0.34" LabelWidth="60"  >
                                                        <Items>			
                                                         		  <ext:ComboBox ID="txtCidade" runat="server" FieldLabel="Cidade" Width="150" MaxLength="255" AllowBlank="False"
                                                                        BlankText="O campo Cidade é Obrigatório." Disabled="False" DisplayField="nome" ValueField="id" TypeAhead="true" Mode="Local" ForceSelection="true">
                                                                    <Store>
                                                                        <ext:Store ID="storeCidade" runat="server">
                                                                            <Reader>
                                                                                <ext:JsonReader>
                                                                                    <Fields>
                                                                                        <ext:RecordField Name="id"  Mapping="id" Type="Int" />
                                                                                        <ext:RecordField Name="nome" Mapping="nome" Type="String" />
                                                                                    </Fields>
                                                                                </ext:JsonReader>
                                                                            </Reader>
                                                                        </ext:Store>
                                                                    </Store>
                                                                </ext:ComboBox>                    
                                                        </Items>
                                                    </ext:Container>


                                                   

                                                </Items>
                                            </ext:Container>  
                                            
                                            <ext:TextField ID="txtComplemento" runat="server" FieldLabel="Complemento" MaxLength="255"  Width="753"
                                                AllowBlank="true" BlankText="O campo Complemento é Obrigatório." Disabled="False">
						                    </ext:TextField>  
                                            
                                             
                                            <ext:TextField ID="txtURL" runat="server" FieldLabel="URL" MaxLength="255"  Width="753"
                                                AllowBlank="true" BlankText="O campo URL é Obrigatório." Disabled="False">
						                    </ext:TextField>                                         

                                    </Items>
                                </ext:FieldSet>
                            </Items>
						</ext:Container>

                       

					</Items>							

            </ext:Panel>
             
             <ext:Panel ID="PanelResponsaveis"         runat="server" Title="Responsáveis"        Frame="true" Border="true" PaddingSummary="10px 10px 10px 10px"  Disabled="true" AutoHeight="true" >
                <Items>
                
                    <ext:GridPanel ID="GridResponsaveis" runat="server" StripeRows="true" Title="Responsáveis" Icon="Table" TrackMouseOver="true"
                        AnchorHorizontal="100%" Height="350" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:10px;">
                    <TopBar>
                        <ext:Toolbar ID="topbarResponsavel" runat="server">
                            <Items>

                                <ext:ComboBox ID="cboPessoaResponsavel" runat="server" width="630"  DisplayField="Nome" ValueField="IdPessoa" 
                                     FieldLabel="" TypeAhead="true" Mode="Local" EmptyText="Selecione uma pessoa e clique em adicionar."
                                             ForceSelection="false" Resizable="true" HideTrigger="false">                                        
                                        <Store>
                                            <ext:Store ID="StorePessoaResponsavel" runat="server">
                                                <Reader>
                                                    <ext:ArrayReader>
                                                        <Fields>                                          
                                                            <ext:RecordField Name="IdPessoa"              Mapping="IdPessoa" />
                                                            <ext:RecordField Name="Nome"                  Mapping="Nome" />
                                                        </Fields>
                                                    </ext:ArrayReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>                                        
                                    </ext:ComboBox>

                                    <ext:ToolbarSpacer />
                                     <ext:ToolbarSpacer />

                                    <ext:Button ID="btnAddResponsavel" runat="server" Text="Adicionar" Icon="Accept" Width="100">
                                        <DirectEvents>
                                            <Click OnEvent="btnAddResponsavel_Click">
                                                <EventMask ShowMask="true" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
				    <Store>
					    <ext:Store ID="StoreResponsaveis" runat="server" >
						    <Reader>
							    <ext:JsonReader>
								    <Fields>
									    <ext:RecordField Name="IdResponsavelXAluno"        Mapping="IdResponsavelXAluno"          Type="Int" />
                                        <ext:RecordField Name="IdPessoa"        Mapping="IdPessoa"          Type="Int" />									  
									    <ext:RecordField Name="Nome"            Mapping="Nome"              Type="String" />
									    <ext:RecordField Name="Sexo"            Mapping="SexoDescricao"     Type="String" />
									    <ext:RecordField Name="Email"           Mapping="Email"             Type="String" />																		   
									    <ext:RecordField Name="Telefone"        Mapping="Telefone"          Type="String" />
									    <ext:RecordField Name="Celular"         Mapping="Celular"           Type="String" />
									   									   
								    </Fields>
							    </ext:JsonReader>
						    </Reader>
					    </ext:Store>
				    </Store>


				    <ColumnModel ID="ColumnModel1" runat="server">
					    <Columns>
                    
                    	    <ext:Column ColumnID="Nome"         Header="Nome"       DataIndex="Nome"        Width="100" Align="Left"/>                        						
                            				
                            <ext:Column ColumnID="Email"        Header="Email"      DataIndex="Email"       Align="Left" Width="70" />	
                            <ext:Column ColumnID="Sexo"         Header="Sexo"       DataIndex="Sexo"        Align="Center" Width="70" Fixed="true" />	
                            <ext:Column ColumnID="Telefone"     Header="Telefone"   DataIndex="Telefone"    Align="Center" Width="100" Fixed="true" />	
                            <ext:Column ColumnID="Celular"      Header="Celular"    DataIndex="Celular"     Align="Center" Width="100" Fixed="true" />	
						
						    <ext:ImageCommandColumn Width="25" ColumnID="BotaoRemover">
							    <Commands>
								    <ext:ImageCommand CommandName="btnRemover" Icon="Delete" Text="">
									    <ToolTip Title="Exclusão:" Text="Remove o Registro Selecionado." />
								    </ext:ImageCommand>
							    </Commands>
						    </ext:ImageCommandColumn>

					    </Columns>
				    </ColumnModel>

				    <SelectionModel>
					    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
				    </SelectionModel>

                    <View>
                        <ext:GridView ID="GridViewDependentes" runat="server" ForceFit="true"></ext:GridView>
                    </View>

				    <DirectEvents>
					    <Command OnEvent="LinhaGrid_DirectClick">
						    <EventMask ShowMask="true" MinDelay="10" />
						    <ExtraParams>
							    <ext:Parameter Value="record.data.IdResponsavelXAluno" Mode="Raw" Name="IdentificadorRegistroTabela"></ext:Parameter>
							    <ext:Parameter Value="command" Mode="Raw" Name="IDObjeto"></ext:Parameter>
						    </ExtraParams>
					    </Command>
				    </DirectEvents>				

			    </ext:GridPanel>

                </Items>
             </ext:Panel>             
                                                                                                                                                              
             <ext:Panel ID="PanelCadastroDependentes"    runat="server" Title="Dependentes"  Frame="true" Border="true" PaddingSummary="10px 10px 10px 10px" Disabled="true" AutoHeight="true" >
                <Items>
                
                    <ext:GridPanel ID="GridPanelDependentes" runat="server" StripeRows="true" Title="Dependentes" Icon="Table" TrackMouseOver="true"
                        AnchorHorizontal="100%" Height="350" Frame="true" ButtonAlign="Right" StyleSpec="margin-top:10px;">
                        <TopBar>
                        <ext:Toolbar ID="ToolbarDependenes" runat="server">
                            <Items>

                                <ext:ComboBox ID="cboPessoaDependente" runat="server" width="630"  DisplayField="Nome" ValueField="IdAluno" 
                                     FieldLabel="" TypeAhead="true" Mode="Local" EmptyText="Selecione um aluno para adicionar como dependente."
                                             ForceSelection="false" Resizable="true" HideTrigger="false">                                        
                                        <Store>
                                            <ext:Store ID="StorePessoaDependente" runat="server">
                                                <Reader>
                                                    <ext:ArrayReader>
                                                        <Fields>                                          
                                                            <ext:RecordField Name="IdAluno"               Mapping="IdAluno" />
                                                            <ext:RecordField Name="Nome"                  Mapping="Nome" />
                                                        </Fields>
                                                    </ext:ArrayReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>                                        
                                    </ext:ComboBox>

                                    <ext:ToolbarSpacer />
                                     <ext:ToolbarSpacer />
                                    

                                    <ext:Button ID="btnAddDependente" runat="server" Text="Adicionar" Icon="Accept" Width="100">
                                        <DirectEvents>
                                            <Click OnEvent="btnAddDependente_Click">
                                                <EventMask ShowMask="true" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
				    <Store>
					    <ext:Store ID="StoreDependentes" runat="server" >
						    <Reader>
							    <ext:JsonReader>
								    <Fields>

									    <ext:RecordField Name="IdResponsavelXAluno"        Mapping="IdResponsavelXAluno"          Type="Int" />
                                        <ext:RecordField Name="IdPessoa"        Mapping="IdPessoa"          Type="Int" />									  
									    <ext:RecordField Name="Nome"            Mapping="Nome"              Type="String" />
									    <ext:RecordField Name="Sexo"            Mapping="SexoDescricao"     Type="String" />
									    <ext:RecordField Name="Email"           Mapping="Email"             Type="String" />																		   
									    <ext:RecordField Name="Telefone"        Mapping="Telefone"          Type="String" />
									    <ext:RecordField Name="Celular"         Mapping="Celular"           Type="String" />
									   									   
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
						
						    <ext:ImageCommandColumn Width="25" ColumnID="BotaoRemover">
							    <Commands>
								    <ext:ImageCommand CommandName="btnRemover" Icon="Delete" Text="">
									    <ToolTip Title="Exclusão:" Text="Remove o Registro Selecionado." />
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
							    <ext:Parameter Value="record.data.IdResponsavelXAluno" Mode="Raw" Name="IdentificadorRegistroTabela"></ext:Parameter>
							    <ext:Parameter Value="command" Mode="Raw" Name="IDObjeto"></ext:Parameter>
						    </ExtraParams>
					    </Command>
				    </DirectEvents>				

			    </ext:GridPanel>
                                                                                                                                                                      
                </Items>                                                                                                                                                 
             </ext:Panel>                                                                                                                                                     
          
             
			</Items> 
            <Buttons>
                
                   <ext:Button ID="btnConsultarCartao" runat="server" Icon="Money" Text="Cartão" Height="25" Width="110" ToolTip="Consultar cartão" >
				    <DirectEvents>
                        <Click OnEvent="btnConsultarCartao_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>

                <ext:Button ID="btnCancelar" runat="server" Icon="PageCancel" Text="Cancelar" Height="25" Width="110" ToolTip="Cancelar a alteração e voltar para pesquisa." >
				    <DirectEvents>
                        <Click OnEvent="btnCancelar_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>

						<ext:Button ID="btnGravar" runat="server" Icon="Disk" Text="Salvar" Height="25" Width="110" ToolTip="Salvar dados e voltar para pesquisa.">
							<DirectEvents>
								<Click OnEvent="btnGravar_Click" Before="var valid= #{FormPanelCadastro}.getForm().isValid(); return valid;">
									<EventMask ShowMask="true" MinDelay="1000" Target="CustomTarget" CustomTarget="={#{FormPanelCadastro}.getEl()}"/>
									<ExtraParams>
										<ext:Parameter Value="#{FormPanelCadastro}.getForm().isValid()" Mode="Raw" Name="FormularioValido"></ext:Parameter>
									</ExtraParams>
								</Click>
							</DirectEvents>
						</ext:Button>
            </Buttons>                    
        </ext:TabPanel>
            
            
             </Items>
        </ext:FormPanel>
        </Items>
        <BottomBar>
				<ext:StatusBar ID="FormStatusBar" runat="server" DefaultText="." Flat="true">
					<Plugins>
						<ext:ValidationStatus ID="ValidationStatus1"
							runat="server"
							FormPanelID="FormPanelCadastro"
							ValidIcon="Accept"
							ErrorIcon="Exclamation"
							ShowText="<b>ATENÇÃO: Existem campos que possuem informações inconsistentes. Clique aqui para saber quais são.</b>"
							HideText="<b>Clique aqui para ocultar a lista de campos com informações inconsistentes.</b>"
						/>
					</Plugins>
				</ext:StatusBar>
			</BottomBar>   
    </ext:Panel>

    <ext:Window ID="ModalCadastro" runat="server" BodyStyle="background-color: #FFFFFF;" Padding="10" Hidden="true">
		<Content>

		</Content>
		<%--<DirectEvents>
			<BeforeHide OnEvent="btnPesquisar_DirectClick"></BeforeHide>
		</DirectEvents>--%>
	</ext:Window>


</asp:Content>
