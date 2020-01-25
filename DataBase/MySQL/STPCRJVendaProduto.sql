
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

end; //
DELIMITER ;


DELIMITER //

CREATE PROCEDURE STPCRJProduto02
(
	IdProduto      integer,
	IdTipoProduto  INTEGER,
	Cod_Barra      VARCHAR(500),
	Nome           VARCHAR(250),
	Descricao      VARCHAR(500),
	Quantidade     INTEGER,
	Preco          float,
	IdStatus       INTEGER
)
begin

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

END; //
DELIMITER ;
DELIMITER //

CREATE PROCEDURE STPCRJProduto03
(
	IdProduto int
)
begin

	DELETE FROM CRJProduto
	WHERE IdProduto = @IdProduto;

END; //
DELIMITER ;

DELIMITER //

CREATE PROCEDURE STPCRJProduto04
(
	Nome VARCHAR(100) , 
	IdStatus INT ,
	IdTipoProduto INT 
)
begin

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
	 c.Nome LIKE concat(ifnull(@Nome,c.Nome) ,'%')
 AND c.IdStatus = ifnull(@IdStatus, c.IdStatus)
 AND c.IdTipoProduto = ifnull(@IdTipoProduto, c.IdTipoProduto);

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

CREATE PROCEDURE STPCRJProduto05
(
	IdProduto Int
)

begin
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
END;
//
DELIMITER ;

