
GO

------------------------------------------------------------------------------------------------------------------------
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJTipoPessoa]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJTipoPessoa

GO
------------------------------------------------------------------------------------------------------------------------

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter todos os registros da tabela CRJTipoProduto
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJTipoPessoa;01
AS
SET NOCOUNT ON

	select 
			p.IdTipoPessoa
			,p.Descricao
	 from CRJTipoPessoa p
	order by p.Descricao

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter um registro da tabela CRJTipoProduto
* Parâmetros.....: @IdTipoProduto = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJTipoPessoa;02
(
	@pIdTipoPessoa Int
)
AS
SET NOCOUNT ON

	select 
	         p.IdTipoPessoa
			,p.Descricao			
	 from CRJTipoPessoa p
	 where p.IdTipoPessoa = @pIdTipoPessoa
/************************************************************************************************************************/

go

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter um registro da tabela CRJTipoProduto
* Parâmetros.....: @IdTipoProduto = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJTipoPessoa;03
(
	@pIdPessoa Int
)
AS
SET NOCOUNT ON

	select 
	         p.IdTipoPessoa
			,p.Descricao			
	 from CRJTipoPessoa p
	 INNER JOIN CRJPessoaXTipo cpt
		on cpt.IdTipoPessoa = p.IdTipoPessoa
		and cpt.IdPessoa = @pIdPessoa
		
	order by p.Descricao
	 
/************************************************************************************************************************/




GO

