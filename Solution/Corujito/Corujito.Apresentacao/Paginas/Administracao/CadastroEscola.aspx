<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroEscola.aspx.cs" Inherits="Corujito.Apresentacao.Paginas.Administracao.CadastroEscola" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Assembly="Ext.Net.UX"  Namespace="Ext.Net.UX"  TagPrefix="ux" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    	<ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <u>Home > Acadêmico > Dados Escolar </u>


        <br />
        <br />
    

		<ext:Panel ID="PanelCadastro" runat="server" Title="Dados da Escola" Icon="Application" AnchorHorizontal="100%" Frame="true" >

			<Items>

				<ext:FormPanel ID="FormPanelCadastro" runat="server" LabelWidth="130" ButtonAlign="Right" Border="false" LabelAlign="Left" PaddingSummary="10px 15px 20px" >

	    			<Items>
						<ext:NumberField ID="txtIdEscola" runat="server" FieldLabel="IdEscola" AnchorHorizontal="30%" MaxLength="4" AllowBlank="true"
                             BlankText="O campo IdEscola é Obrigatório." Disabled="True" Hidden="true">
						</ext:NumberField>

                                                
						<ext:TextField ID="txtRazaoSocial" runat="server" FieldLabel="Razão Social" AnchorHorizontal="70%" MaxLength="250" 
                             AllowBlank="False" BlankText="O campo Razão Social é Obrigatório." Disabled="False">
						</ext:TextField>
                                              
                        <ext:TextField ID="txtNome" runat="server" FieldLabel="Nome" AnchorHorizontal="70%" MaxLength="250" Truncate="true" AllowBlank="False" 
                            BlankText="O campo Nome é Obrigatório." Disabled="False">
						</ext:TextField>

					
						<ext:TextField ID="txtCNPJ" runat="server" FieldLabel="CNPJ"  Width="130" MaxLength="20" AllowBlank="False" 
                            BlankText="O campo CNPJ é Obrigatório." Disabled="False" EmptyText="__.___.___/____-__">
                            <Plugins>
                                <ux:InputTextMask Id="InputTextMask1" runat="server" Mask="99.999.999/9999-99"></ux:InputTextMask>
                            </Plugins> 
                            <DirectEvents>
                                <Change OnEvent="txtCNPJ_Change"></Change>
                            </DirectEvents>
						</ext:TextField>

						<%--<ext:TextField ID="txtInscEstadual" runat="server" FieldLabel="Inscrição Estadual"  Width="130" MaxLength="8" 
                            AllowBlank="False" BlankText="O campo Inscrição Estadual é Obrigatório." Disabled="False">
						    <Plugins>
                                <ux:InputTextMask Id="InputTextMask2" runat="server" Mask="99999999"></ux:InputTextMask>
                            </Plugins>
                        </ext:TextField>--%>

                        
                        <ext:TextField ID="txtCEP" runat="server" FieldLabel="CEP" Width="120" MaxLength="9" AllowBlank="false"
                                BlankText="O campo CEP é Obrigatório." Disabled="False" EmptyText="_____-___">
						    <Plugins>
                                <ux:InputTextMask Id="InputTextMask0" runat="server" Mask="99999-999"></ux:InputTextMask>
                            </Plugins> 
                        </ext:TextField>

						<ext:TextField ID="txtLogradouro" runat="server" FieldLabel="Logradouro" AnchorHorizontal="70%" MaxLength="250" 
                            AllowBlank="false" BlankText="O campo Logradouro é Obrigatório." Disabled="False">
						</ext:TextField>

						<ext:TextField ID="txtBairro" runat="server" FieldLabel="Bairro" AnchorHorizontal="70%" MaxLength="250" 
                                AllowBlank="false" BlankText="O campo Bairro é Obrigatório." Disabled="False">
						</ext:TextField>
					
                        <ext:Container ID="container8" runat="server" Layout="ColumnLayout" Height="25">
                            <Items>
                                <ext:Container ID="container9" runat="server" Layout="FormLayout" ColumnWidth="0.376" LabelWidth="130" >
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



                        <ext:TextField ID="txtTelefonePrincipal" runat="server" FieldLabel="Telefone principal" 
                           Width="100" MaxLength="255"  AllowBlank="false" EmptyText="(__)____-____"
                             BlankText="O campo Telefone principal é Obrigatório." Disabled="False">
                               <Plugins>
                                    <ux:InputTextMask Id="InputTextMask3" runat="server" Mask="(99)9999-9999"></ux:InputTextMask>
                                </Plugins> 
						</ext:TextField>

						<ext:TextField ID="txtTelefoneSecundario" runat="server" FieldLabel="Telefone secundário" 
                              Width="100" MaxLength="255"  AllowBlank="false"  EmptyText="(__)____-____"
                                 BlankText="O campo Telefone secundário é Obrigatório." Disabled="False">
                                <Plugins>
                                    <ux:InputTextMask Id="InputTextMask4" runat="server" Mask="(99)9999-9999"></ux:InputTextMask>
                                </Plugins> 
						</ext:TextField>

						<ext:TextField ID="txtEmail" runat="server" FieldLabel="E-mail" AnchorHorizontal="70%"
                                 MaxLength="250" Truncate="true" AllowBlank="false" BlankText="O campo E-mail é Obrigatório." 
                                Disabled="False" Vtype="email">
						</ext:TextField>

						<ext:DateField ID="txtDataAbertura" runat="server" FieldLabel="Data de abertura" Width="177" 
                            MaxLength="10" MaxLengthText="10" Format="dd/MM/yyyy" TodayText="Hoje" 
                            InvalidText="Digite uma data válida no formato dd/MM/yyyy" 
                            DisabledDaysText="Data Desabilitada."  AllowBlank="false" 
                            BlankText="O campo DataAbertura é Obrigatório." EmptyText="dd/MM/yyyy" 
                            FocusClass="NOMECSS" AltFormats="ddMMyyyy"  Disabled="False">
						</ext:DateField>

						<ext:TextArea ID="txtMissao" runat="server" FieldLabel="Missão" AnchorHorizontal="95%" MaxLength="250" 
                            Truncate="true" AllowBlank="false" BlankText="O campo Missão é Obrigatório." Disabled="False">
						</ext:TextArea>
						
						<ext:TextArea ID="txtObservacao" runat="server" FieldLabel="Observações" AnchorHorizontal="95%" 
                            MaxLength="250" Truncate="true" AllowBlank="false" BlankText="O campo Observações é Obrigatório."
                                 Disabled="False">
						</ext:TextArea>

                     <%--   <ext:ComboBox ID="cboSitucao" runat="server" FieldLabel="Situação" AllowBlank="false" BlankText="O campo Situação é obrigatório."
                            AnchorHorizontal="30%">
                            <Items>
                                <ext:ListItem Text="Ativa"      Value="1" />
                                <ext:ListItem Text="Inativa"    Value="0" />
                            </Items>    
                        </ext:ComboBox>--%>


					</Items>

					<Buttons>
								                                                               
                        <ext:Button ID="btnCancelar" runat="server" Icon="PageBack" Text="Cancelar" Height="25" Width="110" 
                            ToolTip="Cancelar edição e voltar para a pagina de pesquisa.">
							<DirectEvents>
								<Click OnEvent="btnCancelar_Click">
									<EventMask ShowMask="true" />									
								</Click>
							</DirectEvents>
						</ext:Button>
                                                        	
						<ext:Button ID="btnGravar" runat="server" Icon="Disk" Text="Gravar" Height="25" Width="110" ToolTip="Gravar dados.">
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



</asp:Content>
