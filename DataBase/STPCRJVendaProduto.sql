

IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJProduto]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJProduto

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
CREATE PROCEDURE STPCRJProduto;01
(
	@IdTipoProduto  INTEGER,
	@Cod_Barra      VARCHAR(500),
	@Nome           VARCHAR(250),
	@Descricao      VARCHAR(500),
	@Quantidade     INTEGER,
	@Preco          MONEY,
	@IdStatus       INT
)
AS

	INSERT INTO  CRJProduto
	(
		IdTipoProduto,
		Cod_Barra,
		Nome,
		Descricao,
		Quantidade,
		Preco,
		IdStatus
	)
	VALUES
	(
	    @IdTipoProduto,
	    @Cod_Barra,
	    @Nome,
	    @Descricao,
	    @Quantidade,
	    @Preco,
	    @IdStatus
	)
	
	SELECT @@identity

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
CREATE PROCEDURE STPCRJProduto;02
(
	@IdProduto      integer,
	@IdTipoProduto  INTEGER,
	@Cod_Barra      VARCHAR(500),
	@Nome           VARCHAR(250),
	@Descricao      VARCHAR(500),
	@Quantidade     INTEGER,
	@Preco          MONEY,
	@IdStatus       INTEGER
)
AS

	UPDATE CRJProduto SET
		IdTipoProduto = @IdTipoProduto,
		Cod_Barra = @Cod_Barra,
		Nome = @Nome,
		Descricao = @Descricao,
		Quantidade = @Quantidade,
		Preco = @Preco,
		IdStatus = @IdStatus
	WHERE 
		idProduto = @IdProduto

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
CREATE PROCEDURE STPCRJProduto;03
(
	@IdProduto int
)
AS

	DELETE FROM CRJProduto
	WHERE IdProduto = @IdProduto

/************************************************************************************************************************/




GO




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter todos os registros da tabela CRJStatus
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJProduto;04
(@Nome VARCHAR(100) = NULL, 
 @IdStatus INT = NULL,
 @IdTipoProduto INT = NULL
)
AS
SET NOCOUNT ON

 SELECT c.IdProduto,
        c.IdTipoProduto,
        c.Cod_Barra,
        c.Nome,
        c.Descricao,
        c.Quantidade,
        c.Preco,
        c.IdStatus
 FROM   CRJProduto c
 
 WHERE 
 
 c.Nome LIKE isnull(@Nome,c.Nome) + '%'
 AND c.IdStatus = isnull(@IdStatus, c.IdStatus)
 AND c.IdTipoProduto = isnull(@IdTipoProduto, c.IdTipoProduto)

/************************************************************************************************************************/




GO




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJProduto;05
(
	@IdProduto Int
)
AS
SET NOCOUNT ON

	SELECT 
		c.IdProduto,
        c.IdTipoProduto,
        c.Cod_Barra,
        c.Nome,
        c.Descricao,
        c.Quantidade,
        c.Preco,
        c.IdStatus
	FROM 
		CRJProduto c
	WHERE 
		 c.IdProduto = @IdProduto

/************************************************************************************************************************/


GO