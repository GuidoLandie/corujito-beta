
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCidade]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCidade
GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter todos os registros da tabela CRJTipoProduto
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCidade;01
(
	@idEstado int = null
)
AS
SET NOCOUNT ON

	select 
			id,
			nome,
			estado 
	from cidade
	where
		  estado = isnull(@idEstado,estado)

/************************************************************************************************************************/

go

