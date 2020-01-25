
DELIMITER //

CREATE PROCEDURE STPCRJProduto01
(
	IdTipoProduto  INTEGER,
	Cod_Barra      VARCHAR(500),
	Nome           VARCHAR(250),
	Descricao      VARCHAR(500),
	Quantidade     INTEGER,
	Preco          float,
	IdStatus       INT
)
begin

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
	);
	
	SELECT @@identity;

/************************************************************************************************************************/





END;
//

DELIMITER ;






/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Alterar um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @Descricao = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJProduto();02
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
		idProduto = @IdProduto;

/************************************************************************************************************************/





END;
//

DELIMITER ;






/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Remover um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJProduto();03
(
	@IdProduto int
)
AS

	DELETE FROM CRJProduto
	WHERE IdProduto = @IdProduto;

/************************************************************************************************************************/





END;
//

DELIMITER ;






/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter todos os registros da tabela CRJStatus
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJProduto();04
(@Nome VARCHAR(100) = NULL, 
 @IdStatus INT = NULL,
 @IdTipoProduto INT = NULL
)
AS

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
 
 c.Nome LIKE isnull;(@Nome,c.Nome) + '%'
 AND c.IdStatus = ifnull(@IdStatus, c.IdStatus)
 AND c.IdTipoProduto = ifnull(@IdTipoProduto, c.IdTipoProduto)

/************************************************************************************************************************/





END;
//

DELIMITER ;






/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJProduto();05
(
	@IdProduto Int
)
AS

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
		 c.IdProduto = @IdProduto;

/************************************************************************************************************************/



END;
//

DELIMITER ;

