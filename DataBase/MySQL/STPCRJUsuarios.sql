DELIMITER //

CREATE PROCEDURE STPCRJUsuarios01
(  
	pUsuario		VARCHAR(255), 
	pIdPessoa		int,	
	pSenha			VARCHAR(50),
	pAtivo			bit 
)
begin
	INSERT INTO CRJUsuarios
	(
		Usuario, 
		IdPessoa,		
		Senha, 
		Ativo
	)
	VALUES
	(
		@pUsuario, 
		@pIdPessoa,	
		@pSenha,
		@pAtivo
	);	

END;
//

DELIMITER ;




DELIMITER //

CREATE PROCEDURE STPCRJUsuarios02
(   
		pUsuario VARCHAR(255), 		
		pSenha VARCHAR(50),
		pAtivo bit 
)

begin
	UPDATE CRJUsuarios SET			 		
		Senha = @pSenha, 
		Ativo = @pAtivo
	WHERE 
		Usuario = @pUsuario;
		
END;
//

DELIMITER ;



DELIMITER //

CREATE PROCEDURE STPCRJUsuarios03 
(	
	pUsuario VARCHAR(255), 	
	pSenha VARCHAR(50)	
)
begin
		SELECT u.Ativo,
		       u.IdPessoa,
		       u.Usuario
		       
		FROM   CRJUsuarios u
		WHERE  u.Usuario COLLATE Latin1_General_CS_AS = @pUsuario
		  AND  u.Senha  COLLATE Latin1_General_CS_AS = @pSenha;				
END;
//

DELIMITER ;

DELIMITER //

CREATE PROCEDURE STPCRJUsuarios04
(		
	pIdGrupo int
)
begin

		SELECT u.Ativo,
		       u.IdPessoa,
		       u.Usuario
		       
		FROM   CRJUsuarios u
			INNER JOIN CRJGrupoPermissaoUsuarios pu
			ON pu.IdGrupo = @pIdGrupo
			AND u.Usuario = pu.Usuario 	
		GROUP BY
			   u.Ativo,
		       u.IdPessoa,
		       u.Usuario;
END;
//

DELIMITER ;

				
				
