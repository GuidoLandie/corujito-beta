
DELIMITER //

CREATE PROCEDURE STPCRJMatricula
(
	p_idCRJMatricula int 
)
BEGIN

	SELECT 
			m.idCRJMatricula,
			m.CRJSeriesXEnsino_idSerieXEnsino,
			m.idClasses,
			m.CRJEscola_idEscola,
			m.CRJAluno_RA,
			m.DateMatricula
	FROM   CRJMatricula m
	WHERE 
		m.idCRJMatricula = ifnull(p_idCRJMatricula,idCRJMatricula);
		

/************************************************************************************************************************/




END;
//

DELIMITER ;




