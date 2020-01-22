

IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJProdutoVendido]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJProdutoVendido

GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Inserir um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @Descricao = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJProdutoVendido;01
(
	
	@IdPessoa int,		
	@ValorTotal  float
	 	
)
AS

	INSERT INTO  CRJVendaProduto
	(		
		IdPessoa
		,DataVenda
		,ValorTotal         
	)
	VALUES
	(
		
		@IdPessoa,
		getdate(),
		@ValorTotal  
	)
	
	declare @IdVendaProduto int
	declare @IdCartao int
	
	
	select @IdVendaProduto = @@identity
	select @IdCartao = c.IdCartao from CRJCartao c where  c.IdPessoa = @IdPessoa
	
	
	
	
	
	insert into CRJLancamentoCartao (			
		IdLancador
		,IdCartao
		,Valor
		,DataLancamento
		,Descricao
	)values(
		@IdPessoa
		,@IdCartao
		,(@ValorTotal * -1)
		,getdate()
		, cast(@IdVendaProduto as varchar) + ' - Compra na cantina em ' + convert(varchar,getdate(),103)
	)
	
	
	select @IdVendaProduto
	

/************************************************************************************************************************/




GO




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Alterar um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @Descricao = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJProdutoVendido;02
(
	@IdProdutoVendido  INTEGER,
	@IdVendaProduto    INTEGER,
	@IdProduto         INTEGER,
	@Valor             FLOAT 
)
AS

	UPDATE CRJProdutoVendido SET
		
		IdVendaProduto = @IdVendaProduto,
	    IdProduto = @IdProduto,
		Valor = @Valor
	
	WHERE 
		IdProdutoVendido = @IdProdutoVendido

/************************************************************************************************************************/




GO




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Remover um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJProdutoVendido;03
(
	@IdProdutoVendido int
)
AS

	DELETE FROM CRJProdutoVendido
	WHERE IdProdutoVendido = @IdProdutoVendido

/************************************************************************************************************************/




GO




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter todos os registros da tabela CRJStatus
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJProdutoVendido;04

	--@IdPessoa INTEGER = NULL



AS
SET NOCOUNT ON

 SELECT c.IdProdutoVendido,
        c.IdVendaProduto,
        c.IdProduto,
        c.Valor
       
 FROM   CRJProdutoVendido c
 
 
 


/************************************************************************************************************************/




GO




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJProdutoVendido;05
(
	@IdProdutoVendido Int
)
AS
SET NOCOUNT ON

	SELECT 
		c.IdProdutoVendido,
        c.IdVendaProduto,
        c.IdProduto,
        c.Valor
	FROM 
		CRJprodutoVendido c
	WHERE 
		 c.IdProdutoVendido = @IdProdutoVendido

/************************************************************************************************************************/


GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJProdutoVendido;06
(
	
	@IdVendaProduto int,
	@IdProduto	int,
	@Valor	float,
	@Quantidade int
	
)
AS
SET NOCOUNT ON

	
	insert into CRJProdutoVendido (	
	
		 IdVendaProduto
		,IdProduto
		,Valor
	)values
	(
		@IdVendaProduto,
		@IdProduto,	
		@Valor	
	)

	
	declare @IdProdutoVendito int
	select @IdProdutoVendito = @@identity
	
	--remover do total dos produtos
	update CRJProduto
		set
			Quantidade = (Quantidade  - @Quantidade)
	where IdProduto = @IdProduto
	
	
	
	
/************************************************************************************************************************/

go



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJProdutoVendido;07
(
	
	@IdPessoa int
	
)
AS
SET NOCOUNT ON


	select 
		
		 pv.IdProdutoVendido
		,pv.IdVendaProduto
		,pv.IdProduto
		,pv.Valor
		,vp.DataVenda
		,p.Nome
		
	 from 
	 
	CRJProdutoVendido pv
	
	inner join CRJProduto p
	on p.IdProduto = pv.IdProduto
	
	inner join CRJVendaProduto vp
	on vp.IdVendaProduto = pv.IdVendaProduto
	and vp.IdPessoa = @IdPessoa
	
	
