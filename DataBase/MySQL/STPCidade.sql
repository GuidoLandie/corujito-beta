DELIMITER //

CREATE PROCEDURE STPCidade01
(
	idEstado int
)
begin

	select 
			id,
			nome,
			estado 
	from cidade
	where
		  estado = ifnull(@idEstado,estado);

/************************************************************************************************************************/


end;
//

delimiter ;


