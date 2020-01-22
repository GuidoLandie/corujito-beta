

----------------------------------------------------------------------------------------------------------------------------
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJStatus]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJStatus
----------------------------------------------------------------------------------------------------------------------------
GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:23
* Objetivo.......: Obter todos os registros da tabela CRJStatus
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJStatus;01
AS
SET NOCOUNT ON

	SELECT 
		IdStatus,
		Descricao
	FROM 
		CRJStatus

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:23
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJStatus;02
(
	@IdStatus Int
)
AS
SET NOCOUNT ON

	SELECT 
		IdStatus,
		Descricao
	FROM 
		CRJStatus
	WHERE 
		IdStatus = @IdStatus

/************************************************************************************************************************/

GO
