
DELIMITER //

CREATE PROCEDURE STPCRJSerie01()
BEGIN

	SELECT IdSerie
		  ,Descricao
    FROM CRJSerie;
		  

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter um registro da tabela CRJTipoProduto
* Parâmetros.....: @IdTipoProduto = .
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJSerie02
(
	IdSerie Int
)
BEGIN

	SELECT 
		IdSerie,
	    Descricao	
	FROM 
		CRJSerie
	WHERE IdSerie = @IdSerie;







END;
//

DELIMITER ;



