
DELIMITER //

CREATE PROCEDURE STPCRJMateria01
(			
	idMateria int  
)
begin
	SELECT 
		a.IdMateria,
		a.Descricao,
		a.TipoMateria
	FROM   CRJMateria a
	where a.idMateria = IFNULL(@idMateria,a.Idmateria);
/************************************************************************************************************************/


END;
//

DELIMITER ;

