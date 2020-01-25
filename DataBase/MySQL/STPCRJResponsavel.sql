
DELIMITER //

CREATE PROCEDURE STPCRJResponsavel01
(	
	pidResponsavel	int
)
begin

	SELECT 
		p.idResponsavel,
		p.idAluno,
		p.IdPai
	FROM 
		CRJResponsavel  p			
					
	WHERE 				
			p.idResponsavel = ifnull(@pidResponsavel,p.idResponsavel);
END;
//

DELIMITER ;


		
/************************************************************************************************************************/