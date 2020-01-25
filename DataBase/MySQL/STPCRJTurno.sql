
DELIMITER //

CREATE PROCEDURE STPCRJTurno01()
begin

	SELECT
	IdTurno
	,Descricao
	 
    FROM CRJTurno;
END;
//
DELIMITER ;

GO

DELIMITER //

CREATE PROCEDURE STPCRJTurno02
(
	IdTurno Int
)
begin

	SELECT 
		IdTurno,
	    Descricao	
	FROM 
		CRJTurno
	WHERE IdTurno = @IdTurno;

END; //
DELIMITER;

GO


