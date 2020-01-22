
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJFuncionalidadeAplicacao]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJFuncionalidadeAplicacao
------------------------------------------------------------------------------------------------------------------------
GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: PROCEDURE QUE RETORNA TODAS AS APLICAÇÕES DE UMA DETERMINADO GRUPO E SE ELA ESTA OU NÃO SELECIONADA
* Parâmetros.....: 
* Alterações.....: STPCRJFuncionalidadeAplicacao;01 2
************************************************************************************************************************/
CREATE PROCEDURE STPCRJFuncionalidadeAplicacao;01 
(
	@IdGrupo int
)
AS
SET NOCOUNT ON

	
	SELECT 
		 CASE WHEN  isnull(ag.IdGrupo,'') = '' THEN 0 ELSE 1 END  AS PossuiPermissao,
		--ag.IdGrupo,
		fa.IdFuncionalidade,
		ap.Descricao AS NomeAplicacao,
		fa.IdAplicacao ,
		fa.Descricao
		
	FROM CRJFuncionalidadeAplicacao fa
	
	INNER JOIN CRJAplicacoes ap
	ON ap.IdAplicacao = fa.IdAplicacao 
	
	LEFT JOIN CRJAplicacaoGrupo ag
	ON ag.IdFuncionalidade = fa.IdFuncionalidade 	
	AND ag.IdGrupo = @IdGrupo		

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: PROCEDURE QUE RETORNA TODAS AS APLICAÇÕES DE UMA DETERMINADO GRUPO E SE ELA ESTA OU NÃO SELECIONADA
* Parâmetros.....: 
* Alterações.....: STPCRJFuncionalidadeAplicacao;01 2
************************************************************************************************************************/
CREATE PROCEDURE STPCRJFuncionalidadeAplicacao;02
(
	@Usuario varchar(50)
)
AS
SET NOCOUNT ON

	
	SELECT 
		CASE WHEN  isnull(au.Usuario,'') = '' THEN 0 ELSE 1 END  AS PossuiPermissao,
		--au.Usuario,
		fa.IdFuncionalidade,
		ap.Nome AS NomeAplicacao,
		fa.IdAplicacao ,
		fa.Descricao
		
	FROM CRJFuncionalidadeAplicacao fa
	
	INNER JOIN CRJAplicacoes ap
	ON ap.IdAplicacao = fa.IdAplicacao 
	
	LEFT JOIN CRJAplicacaoUsuario au
	ON au.IdFuncionalidade = fa.IdFuncionalidade 
	AND au.Usuario = @Usuario

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: PROCEDURE QUE INSERE UMA FUNCIONALIDADE PARA UM GRUPO
* Parâmetros.....: 
* Alterações.....: STPCRJFuncionalidadeAplicacao;01 2
************************************************************************************************************************/
CREATE PROCEDURE STPCRJFuncionalidadeAplicacao;03
(
	@IdGrupo			int,
	@IdFuncionalidade	int,
	@IdAplicacao		int
)
AS
SET NOCOUNT ON

	INSERT INTO CRJAplicacaoGrupo
	(
	    IdFuncionalidade, IdAplicacao, IdGrupo
	)
	VALUES
	(
	    @IdFuncionalidade, @IdAplicacao, @IdGrupo
	)
	

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: PROCEDURE QUE INSERE UMA FUNCIONALIDADE PARA UM usuarios
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJFuncionalidadeAplicacao;04
(
	@Usuario			varchar(50),
	@IdFuncionalidade	int,
	@IdAplicacao		int
)
AS
SET NOCOUNT ON

	INSERT INTO CRJAplicacaoUsuario 	
	(
	    IdFuncionalidade, IdAplicacao, Usuario 
	)
	VALUES
	(
	    @IdFuncionalidade, @IdAplicacao, @Usuario
	)
	

/************************************************************************************************************************/

GO
/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: PROCEDURE QUE REMOVE UMA FUNCIONALIDADE DE UM usuarios
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJFuncionalidadeAplicacao;05
(
	@Usuario			varchar(50)
)
AS
SET NOCOUNT ON

	DELETE 
	FROM   CRJAplicacaoUsuario
	WHERE  Usuario = @Usuario
	 
	

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: PROCEDURE QUE REMOVE UMA FUNCIONALIDADE DE UM grupo
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJFuncionalidadeAplicacao;06
(
	@IdGrupo	int	
)
AS
SET NOCOUNT ON

	DELETE 
	FROM   CRJAplicacaoGrupo 
	WHERE  
		   IdGrupo = @IdGrupo	
	
/************************************************************************************************************************/	

GO