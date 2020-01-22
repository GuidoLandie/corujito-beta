
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJUsuarios]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJUsuarios

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Inserir um registro na tabela CRJUsuarios
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJUsuarios;01
(  
	@pUsuario		VARCHAR(255), 
	@pIdPessoa		int,	
	@pSenha			VARCHAR(50),
	@pAtivo			bit 
)
AS

	INSERT INTO CRJUsuarios
	(
		Usuario, 
		IdPessoa,		
		Senha, 
		Ativo
	)
	VALUES
	(
		@pUsuario, 
		@pIdPessoa,	
		@pSenha,
		@pAtivo
	)	

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guido landie
* Data de Criação: 29/05/2012 
* Objetivo.......: Alterar um registro na tabela CRJUsuarios
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJUsuarios;02
(   
		@pUsuario VARCHAR(255), 		
		@pSenha VARCHAR(50),
		@pAtivo bit 
)
AS	

	UPDATE CRJUsuarios SET			 		
		Senha = @pSenha, 
		Ativo = @pAtivo
	WHERE 
		Usuario = @pUsuario
		
/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Procedure para efetuar o login
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJUsuarios;03 
(	
	@pUsuario VARCHAR(255), 	
	@pSenha VARCHAR(50)	
)
AS
SET NOCOUNT ON

		SELECT u.Ativo,
		       u.IdPessoa,
		       u.Usuario
		       
		FROM   CRJUsuarios u
		WHERE  u.Usuario COLLATE Latin1_General_CS_AS = @pUsuario
		  AND  u.Senha  COLLATE Latin1_General_CS_AS = @pSenha
				
/************************************************************************************************************************/
GO
/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Procedure para efetuar o login
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJUsuarios;04
(		
	@pIdGrupo int
)
AS
SET NOCOUNT ON

		SELECT u.Ativo,
		       u.IdPessoa,
		       u.Usuario
		       
		FROM   CRJUsuarios u
			INNER JOIN CRJGrupoPermissaoUsuarios pu
			ON pu.IdGrupo = @pIdGrupo
			AND u.Usuario = pu.Usuario 	
		GROUP BY
			   u.Ativo,
		       u.IdPessoa,
		       u.Usuario				
				
/************************************************************************************************************************/