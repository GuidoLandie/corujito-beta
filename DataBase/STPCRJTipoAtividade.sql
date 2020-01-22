
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJTipoAtividade]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJTipoAtividade

GO





GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter todos os registros da tabela CRJTipoProduto
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJTipoAtividade;01
AS
SET NOCOUNT ON

	SELECT Descricao
	      ,IdTipoAtividade
    FROM 
		  CRJTipoAtividade

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter um registro da tabela CRJTipoProduto
* Parâmetros.....: @IdTipoProduto = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJTipoAtividade;02
(
	@IdTipoAtividade Int
)
AS
SET NOCOUNT ON

	SELECT 
		IdTipoAtividade,
		Descricao	
	FROM 
		CRJTipoAtividade 
	WHERE 
		IdTipoAtividade = @IdTipoAtividade
		
		
		
go

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter um registro da tabela CRJTipoProduto
* Parâmetros.....: @IdTipoProduto = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJTipoAtividade;03
(
	@Descricao varchar(200) = null,
	@IdTipoAtividade int = null
)
AS
SET NOCOUNT ON

	SELECT 
		IdTipoAtividade,
		Descricao	
	FROM 
		CRJTipoAtividade 
	WHERE 
		Descricao = isnull(@Descricao,Descricao)
	and IdTipoAtividade = isnull(@IdTipoAtividade,IdTipoAtividade)

GO

