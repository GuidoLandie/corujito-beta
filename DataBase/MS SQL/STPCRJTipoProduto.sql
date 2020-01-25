
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJTipoProduto]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJTipoProduto

GO





GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter todos os registros da tabela CRJTipoProduto
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJTipoProduto;01
AS
SET NOCOUNT ON

	SELECT 
		IdTipoProduto,
		Nome
	FROM 
		CRJTipoProduto

/************************************************************************************************************************/




GO




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter um registro da tabela CRJTipoProduto
* Parâmetros.....: @IdTipoProduto = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJTipoProduto;02
(
	@IdTipoProduto Int
)
AS
SET NOCOUNT ON

	SELECT 
		IdTipoProduto,
		Nome
	FROM 
		CRJTipoProduto
	WHERE 
		IdTipoProduto = @IdTipoProduto

/************************************************************************************************************************/




GO

