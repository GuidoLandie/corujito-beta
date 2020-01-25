
DELIMITER //

CREATE PROCEDURE STPCRJFuncionalidadeAplicacao01 
(
	IdGrupo int
)
BEGIN

	
	SELECT 
		 CASE WHEN  ifnull(ag.IdGrupo,'') = '' THEN 0 ELSE 1 END  PossuiPermissao,
		-- ag.IdGrupo,
		fa.IdFuncionalidade,
		ap.Descricao as NomeAplicacao,
		fa.IdAplicacao ,
		fa.Descricao
		
	FROM CRJFuncionalidadeAplicacao fa
	
	INNER JOIN CRJAplicacoes ap
	ON ap.IdAplicacao = fa.IdAplicacao 
	
	LEFT JOIN CRJAplicacaoGrupo ag
	ON ag.IdFuncionalidade = fa.IdFuncionalidade 	
	AND ag.IdGrupo = @IdGrupo;		


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: PROCEDURE QUE RETORNA TODBEGIN BEGIN APLICAÇÕES DE UMA DETERMINADO GRUPO E SE ELA ESTA OU NÃO SELECIONADA
* Parâmetros.....: 
* Alterações.....: STPCRJFuncionalidadeAplicacao;01 2
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJFuncionalidadeAplicacao02
(
	Usuario varchar(50)
)
BEGIN

	
	SELECT 
		case WHEN  ifnull(au.Usuario,'') = '' THEN 0 ELSE 1 END  as PossuiPermissao,
		-- au.Usuario,
		fa.IdFuncionalidade,
		ap.Nome as NomeAplicacao,
		fa.IdAplicacao ,
		fa.Descricao
		
	FROM CRJFuncionalidadeAplicacao fa
	
	INNER JOIN CRJAplicacoes ap
	ON ap.IdAplicacao = fa.IdAplicacao 
	
	LEFT JOIN CRJAplicacaoUsuario au
	ON au.IdFuncionalidade = fa.IdFuncionalidade 
	AND au.Usuario = @Usuario;

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: PROCEDURE QUE INSERE UMA FUNCIONALIDADE PARA UM GRUPO
* Parâmetros.....: 
* Alterações.....: STPCRJFuncionalidadeAplicacao;01 2
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJFuncionalidadeAplicacao03
(
	IdGrupo			int,
	IdFuncionalidade	int,
	IdAplicacao		int
)
BEGIN

	INSERT INTO CRJAplicacaoGrupo
	(
	    IdFuncionalidade, IdAplicacao, IdGrupo
	)
	VALUES
	(
	    @IdFuncionalidade, @IdAplicacao, @IdGrupo
	);
	

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: PROCEDURE QUE INSERE UMA FUNCIONALIDADE PARA UM usuarios
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJFuncionalidadeAplicacao04
(
	Usuario			varchar(50),
	IdFuncionalidade	int,
	IdAplicacao		int
)
BEGIN

	INSERT INTO CRJAplicacaoUsuario 	
	(
	    IdFuncionalidade, IdAplicacao, Usuario 
	)
	VALUES
	(
	    @IdFuncionalidade, @IdAplicacao, @Usuario
	);
	

/************************************************************************************************************************/


END;
//

DELIMITER ;


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: PROCEDURE QUE REMOVE UMA FUNCIONALIDADE DE UM usuarios
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJFuncionalidadeAplicacao05
(
	Usuario			varchar(50)
)
BEGIN

	DELETE 
	FROM   CRJAplicacaoUsuario
	WHERE  Usuario = @Usuario;
	 
	

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: PROCEDURE QUE REMOVE UMA FUNCIONALIDADE DE UM grupo
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJFuncionalidadeAplicacao06
(
	IdGrupo	int	
)
BEGIN

	DELETE 
	FROM   CRJAplicacaoGrupo 
	WHERE  
		   IdGrupo = @IdGrupo;	
	
/************************************************************************************************************************/	


END;
//

DELIMITER ;

