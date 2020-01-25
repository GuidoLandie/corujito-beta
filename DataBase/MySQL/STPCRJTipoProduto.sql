
DELIMITER //

CREATE PROCEDURE STPCRJTipoProduto01()
BEGIN

	SELECT 
		IdTipoProduto,
		Nome
	FROM 
		CRJTipoProduto;


END;
//

DELIMITER ;



GO


DELIMITER //

CREATE PROCEDURE STPCRJTipoProduto02
(
	IdTipoProduto Int
)
BEGIN

	SELECT 
		IdTipoProduto,
		Nome
	FROM 
		CRJTipoProduto
	WHERE 
		IdTipoProduto = @IdTipoProduto;


END;
//

DELIMITER ;



