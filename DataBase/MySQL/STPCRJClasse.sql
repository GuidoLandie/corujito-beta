
DELIMITER //

CREATE PROCEDURE STPCRJClasse01
(
	idClasse int 
)
begin

	SELECT 
			 IdClasse,
			 IdEnsino,			 
			 IdSerie,			 
			 IdTurno,
			 NomeTurma
	FROM   CRJClasse 
	WHERE IdClasse = ifnull(@idClasse,IdClasse);
	
	
/************************************************************************************************************************/





END;
//

DELIMITER ;

