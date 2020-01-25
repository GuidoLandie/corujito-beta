
DELIMITER //

CREATE PROCEDURE STPCRJStatus()
BEGIN

	SELECT 
		IdStatus,
		Descricao
	FROM 
		CRJStatus;

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:23
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJStatus02
(
	IdStatus Int
)
BEGIN

	SELECT 
		IdStatus,
		Descricao
	FROM 
		CRJStatus
	WHERE 
		IdStatus = @IdStatus;

/************************************************************************************************************************/


END;
//

DELIMITER ;


