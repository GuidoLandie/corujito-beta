
DELIMITER //

CREATE PROCEDURE STPCRJGrupoPermissao01
(   
	pIdEscola	INT,
    pNome		VARCHAR(255),
    pDescricao VARCHAR(255),
    pIdTipoPessoa int	
)
begin

	

	INSERT INTO CRJGrupoPermissao
	(
		IdEscola ,
		Nome,		
		Descricao,
		IdTipoPessoa 
	)
	VALUES
	(
		@pIdEscola	,
		@pNome		,
		@pDescricao,
		@pIdTipoPessoa
	);

	SELECT @@IDENTITY;
/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....:guidolandie
* Data de Criação: alterar um grupo de permssao
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJGrupoPermissao02
(   
	pIdGrupo INT,
    pNome		VARCHAR(255),
    pDescricao VARCHAR(255),
    pIdTipoPessoa int	
)
begin
	

	UPDATE CRJGrupoPermissao SET
	     Nome	   = @pNome,
	     Descricao = @pDescricao,
	     IdTipoPessoa = @pIdTipoPessoa
	WHERE 
		IdGrupo  = @pIdGrupo;

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: Delete
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJGrupoPermissao03
(
	pIdGrupo int
)
begin

	DELETE 
	FROM   CRJGrupoPermissao
	WHERE  IdGrupo = @pIdGrupo;
	
	
/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter todos os registros da tabela CRJGrupoPermissao
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJGrupoPermissao04
(
	pIdEscola	int,
	pIdGrupo	INT ,
	pNome		VARCHAR(255) ,		
	pDescricao VARCHAR(255) 
)
begin

	SELECT 
			gp.IdGrupo,		
			gp.IdEscola,	
			gp.Nome,		
			gp.Descricao,
			gp.IdTipoPessoa
	FROM   CRJGrupoPermissao gp
	WHERE
			gp.IdEscola = ifnull(@pIdEscola,gp.IdEscola)	
		AND	gp.IdGrupo = ifnull(@pIdGrupo,gp.IdGrupo)		
		AND gp.Nome LIKE concat('%',ifnull(@pNome,gp.Nome) , '%')
		AND gp.Descricao LIKE Concat('%' , ifnull(@pDescricao,gp.Descricao) , '%');
	
	
	
/************************************************************************************************************************/

END;
//

DELIMITER ;




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Inserir um registro na tabela CRJGrupoPermissao
* Parâmetros.....:
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJGrupoPermissao05
(   
	IdGrupo	int,
    pUsuario	VARCHAR(255)
    
)
begin

	INSERT INTO CRJGrupoPermissaoUsuarios 	
	(
		IdGrupo,
		Usuario 			
	)
	VALUES
	(
		@IdGrupo,
		@pUsuario
	);
	
/************************************************************************************************************************/


END;
//

DELIMITER ;




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Inserir um registro na tabela CRJGrupoPermissao
* Parâmetros.....:
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJGrupoPermissao06
(   
	IdGrupo	int,
    pUsuario	VARCHAR(255)
    
)
begin

	DELETE FROM CRJGrupoPermissaoUsuarios 	
	WHERE	
		IdGrupo = @IdGrupo
	AND Usuario = @pUsuario;
	
	
/************************************************************************************************************************/


END;
//

DELIMITER ;

