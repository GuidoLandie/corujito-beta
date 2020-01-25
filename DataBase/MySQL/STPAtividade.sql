
DELIMITER //

CREATE PROCEDURE STPCRJAtividade01
(
	-- @IdAtividade		   INTEGER,
	IdProfXMatXClasse      int,
	Nomeatividade		VARCHAR(500),
	IdTipoAtividade       int,
	DataInicial		   Datetime,
	DataFinal			   Datetime,
	Descricao			   VARCHAR(500)
)
begin

	INSERT INTO  CRJAtividade
	(
	-- IdAtividade	,	  
	IdProfXMatXClasse,
	NomeAtividade,
	IdTipoAtividade,     
	DataInicial,	   
	DataFinal,		   
	Descricao			  
	)
	VALUES
	(
	-- @IdAtividade,		   
	@IdProfXMatXClasse,  
    @NomeAtividade	,
	@IdTipoAtividade,   
	@DataInicial,	  
	@DataFinal,		  
	@Descricao		  
	);
	
	SELECT @@identity;

/************************************************************************************************************************/



END;
//

DELIMITER ;






/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Alterar um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @Descricao = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJAtividade02
(
	IdAtividade		   INTEGER,	
	NomeAtividade			VARCHAR(500),
	IdTipoAtividade       int,
	DataInicial		   DateTime,
	DataFinal			   DateTime,
	Descricao			   VARCHAR(500),
	IdProfXMatXClasse		int
)
begin

	if not exists ( select 1 from crjatividade where IdAtividade = @IdAtividade)
	then
		insert into CRJAtividade (IdProfXMatXClasse)values(@IdProfXMatXClasse);
		set @IdAtividade = @@identity;
	end if;

	UPDATE CRJAtividade SET    
		NomeAtividade = @NomeAtividade,
		IdTipoAtividade = @IdTipoAtividade,
		DataInicial = @DataInicial,			  
		DataFinal = @DataFinal,			  
		Descricao = @Descricao
	WHERE 
		IdAtividade = @IdAtividade;
		
		
	select @IdAtividade;

/************************************************************************************************************************/





END;
//

DELIMITER ;






/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Remover um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJAtividade03
(
	IdAtividade int
)
begin

	DELETE FROM CRJATividade
	WHERE IdAtividade = @IdAtividade;

/************************************************************************************************************************/





END;
//

DELIMITER ;






/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJAtividade05
(
	IdProfXMatXClasse  Int,
	IdTipoAtividade int
)
begin

	SELECT 
	IdProfXMatXClasse,   
	NomeAtividade,	
	IdTipoAtividade,     
	DataInicial,		   
	DataFinal,			   
	Descricao
	FROM 
		CRJAtividade
	WHERE 
		IdProfXMatXClasse = @IdProfXMatXClasse and
		IdTipoAtividade = @IdTipoAtividade;

/************************************************************************************************************************/



END;
//

DELIMITER ;




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJAtividade06
(
	IdClasse int
)
begin

	SELECT 
	a.IdAtividade,
	a.IdProfXMatXClasse,  
    a.NomeAtividade,    
	a.IdTipoAtividade,	
	a.DataInicial,		   
	a.DataFinal,			   
	a.Descricao
	FROM 
		CRJAtividade a
	inner join CRJProfXMatXClasse p
	on p.IdProfXMatXClasse = a.IdProfXMatXClasse
		and p.IdClasse = @IdClasse;
				
/************************************************************************************************************************/


end;
//

delimiter ;




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: STPCRJAtividade;07 4
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJAtividade07
(
	IdAluno int
)
begin

	SELECT 
	a.IdAtividade,
	a.IdProfXMatXClasse,  
    a.NomeAtividade,    
	a.IdTipoAtividade,	
	a.DataInicial,		   
	a.DataFinal,			   
	a.Descricao,
	CONCAT(mat.Descricao , ' - Prof(a). ' , prof.Nome) as NomeMateria
	
	FROM  CRJAtividade a
	
	inner join CRJProfXMatXClasse p		
		on p.IdProfXMatXClasse = a.IdProfXMatXClasse
	
	inner join CRJMateria mat
		on mat.IdMateria = p.IdMateria
	
	inner join CRJPessoa prof
		on prof.IdPessoa = p.IdPessoa
	
	inner join CRJClasse c
		on c.IdClasse = p.IdClasse
		
	inner join CRJMatricula m
		on m.idClasse = c.IdClasse
		and m.IdAluno = @IdAluno;
END;
//

DELIMITER ;


	
	
	
				
/************************************************************************************************************************/


