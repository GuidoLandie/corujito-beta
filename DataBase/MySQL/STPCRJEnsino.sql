/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:36:59
* Objetivo.......: Obter um registro da tabela CRJOcorrencia
* Parâmetros.....: pString = String para consulta
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJEnsino01
(
	pidEnsino int
)
begin

	SELECT 
		idEnsino,
		idEscola,
		Descricao
	 FROM CRJEnsino
	 where idEnsino = ifnull(@pidEnsino,idEnsino);
	
	
/************************************************************************************************************************/





END;
//

DELIMITER ;

