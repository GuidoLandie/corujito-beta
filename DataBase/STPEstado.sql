
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPEstado]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPEstado
GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter todos os registros da tabela CRJTipoProduto
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPEstado;01
(
	@idPais int = null
)
AS
SET NOCOUNT ON

	select 
			id,
			nome,
			uf,
			pais
	
	 from estado
	 where pais = isnull(@idPais,pais)

/************************************************************************************************************************/

go

