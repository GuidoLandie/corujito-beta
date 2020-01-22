IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[STPCRJEscola]')
        AND  type IN (N'P', N'PC')
   )     	
    	DROP PROCEDURE STPCRJEscola    	
----------------------------------------------------------------------------------------------------------------------------


go


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:26:28
* Objetivo.......: Alterar um registro na tabela CRJEscola
* Parâmetros.....: @idEscola = 
*              
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJEscola;01
(
	@idEscola Int,
	@RazaoSocial VarChar(250),
	@Nome VarChar(250),
	@CNPJ VarChar(20),
	@InscEstadual VarChar(20),
	@Logradouro VarChar(250),
	@Bairro VarChar(250),
	@Cidade VarChar(250),
	@Estado VarChar(250),
	@CEP VarChar(250),
	@TelefonePrincipal VarChar(250),
	@TelefoneSecundario VarChar(250),
	@Email VarChar(250),
	@DataAbertura DateTime,
	@Missao VarChar(250),
	@IdStatus Int,
	@Observacao VarChar(250)
)
AS

	UPDATE CRJEscola SET
		RazaoSocial = @RazaoSocial,		
		Nome = @Nome,
		CNPJ = @CNPJ,
		InscEstadual = @InscEstadual,
		Logradouro = @Logradouro,
		Bairro = @Bairro,
		Cidade = @Cidade,
		Estado = @Estado,
		CEP = @CEP,
		TelefonePrincipal = @TelefonePrincipal,
		TelefoneSecundario = @TelefoneSecundario,
		Email = @Email,
		DataAbertura = @DataAbertura,
		Missao = @Missao,
		IdStatus = @IdStatus,
		Observacao = @Observacao
	WHERE 
		idEscola = @idEscola

/************************************************************************************************************************/




GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:26:28
* Objetivo.......: Obter todos os registros da tabela CRJEscola
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJEscola;02
(
	@IdEscola int
)
AS
SET NOCOUNT ON

	SELECT 
		idEscola,
		RazaoSocial,
		Nome,
		CNPJ,
		InscEstadual,
		Logradouro,
		Bairro,
		Cidade,
		Estado,
		CEP,
		TelefonePrincipal,
		TelefoneSecundario,
		Email,
		DataAbertura,
		Missao,
		IdStatus,
		Observacao
	FROM 
		CRJEscola
	where @IdEscola = @IdEscola
	

/************************************************************************************************************************/




