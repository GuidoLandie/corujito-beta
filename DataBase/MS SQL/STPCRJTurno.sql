
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJTurno]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJTurno
GO





GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter todos os registros da tabela CRJTipoProduto
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJTurno;01
AS
SET NOCOUNT ON

	SELECT
	IdTurno
	,Descricao
	 
    FROM CRJTurno
		  

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter um registro da tabela CRJTipoProduto
* Parâmetros.....: @IdTipoProduto = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJTurno;02
(
	@IdTurno Int
)
AS
SET NOCOUNT ON

	SELECT 
		IdTurno,
	    Descricao	
	FROM 
		CRJTurno
	WHERE IdTurno = @IdTurno

/************************************************************************************************************************/




GO

