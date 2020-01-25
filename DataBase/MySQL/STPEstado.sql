DELIMITER //

CREATE PROCEDURE STPEstado
(
	idPais int
)
BEGIN

	select 
			id,
			nome,
			uf,
			pais
	
	 from estado
	 where pais = @idPais;

END //
delimiter ;



