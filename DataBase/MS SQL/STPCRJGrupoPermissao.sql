
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJGrupoPermissao]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJGrupoPermissao

GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Inserir um registro na tabela CRJGrupoPermissao
* Parâmetros.....:
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJGrupoPermissao;01
(   
	@pIdEscola	INT,
    @pNome		VARCHAR(255),
    @pDescricao VARCHAR(255),
    @pIdTipoPessoa int	= null
)
AS

	

	INSERT INTO CRJGrupoPermissao
	(
		IdEscola ,
		Nome,		
		Descricao,
		IdTipoPessoa 
	)
	VALUES
	(
		@pIdEscola	,
		@pNome		,
		@pDescricao,
		@pIdTipoPessoa
	)

	SELECT @@IDENTITY
/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....:guidolandie
* Data de Criação: alterar um grupo de permssao
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJGrupoPermissao;02
(   
	@pIdGrupo INT,
    @pNome		VARCHAR(255),
    @pDescricao VARCHAR(255),
    @pIdTipoPessoa int	= null
)
AS
	

	UPDATE CRJGrupoPermissao SET
	     Nome	   = @pNome,
	     Descricao = @pDescricao,
	     IdTipoPessoa = @pIdTipoPessoa
	WHERE 
		IdGrupo  = @pIdGrupo

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: Delete
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJGrupoPermissao;03
(
	@pIdGrupo int
)
AS

	DELETE 
	FROM   CRJGrupoPermissao
	WHERE  IdGrupo = @pIdGrupo
	
	IF @@ERROR > 0
	BEGIN 
		SELECT 'Erro'
	END
	

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter todos os registros da tabela CRJGrupoPermissao
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJGrupoPermissao;04
(
	@pIdEscola	int,
	@pIdGrupo	INT = NULL,
	@pNome		VARCHAR(255) = NULL,		
	@pDescricao VARCHAR(255) = NULL
)
AS
SET NOCOUNT ON

	SELECT 
			gp.IdGrupo,		
			gp.IdEscola,	
			gp.Nome,		
			gp.Descricao,
			gp.IdTipoPessoa
	FROM   CRJGrupoPermissao gp
	WHERE
			gp.IdEscola = isnull(@pIdEscola,gp.IdEscola)	
		AND	gp.IdGrupo = isnull(@pIdGrupo,gp.IdGrupo)		
		AND gp.Nome LIKE '%' + isnull(@pNome,gp.Nome) + '%'
		AND gp.Descricao LIKE '%' + isnull(@pDescricao,gp.Descricao) + '%'	
	
	
	
/************************************************************************************************************************/
GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Inserir um registro na tabela CRJGrupoPermissao
* Parâmetros.....:
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJGrupoPermissao;05
(   
	@IdGrupo	int,
    @pUsuario	VARCHAR(255)
    
)
AS

	INSERT INTO CRJGrupoPermissaoUsuarios 	
	(
		IdGrupo,
		Usuario 			
	)
	VALUES
	(
		@IdGrupo,
		@pUsuario
	)
	
/************************************************************************************************************************/

GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Inserir um registro na tabela CRJGrupoPermissao
* Parâmetros.....:
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJGrupoPermissao;06
(   
	@IdGrupo	int,
    @pUsuario	VARCHAR(255)
    
)
AS

	DELETE FROM CRJGrupoPermissaoUsuarios 	
	WHERE	
		IdGrupo = @IdGrupo
	AND Usuario = @pUsuario
	
	
/************************************************************************************************************************/

GO