
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJSerie]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJSerie
GO





GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter todos os registros da tabela CRJTipoProduto
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJSerie;01
AS
SET NOCOUNT ON

	SELECT IdSerie
		  ,Descricao
    FROM CRJSerie
		  

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter um registro da tabela CRJTipoProduto
* Parâmetros.....: @IdTipoProduto = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJSerie;02
(
	@IdSerie Int
)
AS
SET NOCOUNT ON

	SELECT 
		IdSerie,
	    Descricao	
	FROM 
		CRJSerie
	WHERE IdSerie = @IdSerie






GO

