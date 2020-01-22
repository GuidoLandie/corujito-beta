

IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJAtividade]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJAtividade

GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Inserir um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @Descricao = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJAtividade;01
(
	--@IdAtividade		   INTEGER,
	@IdProfXMatXClasse      int,
	@Nomeatividade		VARCHAR(500),
	@IdTipoAtividade       int,
	@DataInicial		   Datetime,
	@DataFinal			   Datetime,
	@Descricao			   VARCHAR(500)
)
AS

	INSERT INTO  CRJAtividade
	(
	--IdAtividade	,	  
	IdProfXMatXClasse,
	NomeAtividade,
	IdTipoAtividade,     
	DataInicial,	   
	DataFinal,		   
	Descricao			  
	)
	VALUES
	(
	--@IdAtividade,		   
	@IdProfXMatXClasse,  
    @NomeAtividade	,
	@IdTipoAtividade,   
	@DataInicial,	  
	@DataFinal,		  
	@Descricao		  
	)
	
	SELECT @@identity

/************************************************************************************************************************/


GO




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Alterar um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @Descricao = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJAtividade;02
(
	@IdAtividade		   INTEGER,	
	@NomeAtividade			VARCHAR(500),
	@IdTipoAtividade       int,
	@DataInicial		   DateTime,
	@DataFinal			   DateTime,
	@Descricao			   VARCHAR(500),
	@IdProfXMatXClasse		int
)
AS

	if not exists ( select 1 from crjatividade where IdAtividade = @IdAtividade)
	begin
		insert into CRJAtividade (IdProfXMatXClasse)values(@IdProfXMatXClasse)
		select @IdAtividade = @@identity
	end

	UPDATE CRJAtividade SET    
		NomeAtividade = @NomeAtividade,
		IdTipoAtividade = @IdTipoAtividade,
		DataInicial = @DataInicial,			  
		DataFinal = @DataFinal,			  
		Descricao = @Descricao
	WHERE 
		IdAtividade = @IdAtividade
		
		
	select @IdAtividade

/************************************************************************************************************************/




GO




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Remover um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJAtividade;03
(
	@IdAtividade int
)
AS

	DELETE FROM CRJATividade
	WHERE IdAtividade = @IdAtividade

/************************************************************************************************************************/




GO




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJAtividade;05
(
	@IdProfXMatXClasse  Int,
	@IdTipoAtividade int
)
AS
SET NOCOUNT ON

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
		IdTipoAtividade = @IdTipoAtividade

/************************************************************************************************************************/


GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJAtividade;06
(
	@IdClasse int
)
AS
SET NOCOUNT ON

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
		and p.IdClasse = @IdClasse
				
/************************************************************************************************************************/

go


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: STPCRJAtividade;07 4
************************************************************************************************************************/
CREATE PROCEDURE STPCRJAtividade;07
(
	@IdAluno int
)
AS
SET NOCOUNT ON

	SELECT 
	a.IdAtividade,
	a.IdProfXMatXClasse,  
    a.NomeAtividade,    
	a.IdTipoAtividade,	
	a.DataInicial,		   
	a.DataFinal,			   
	a.Descricao,
	mat.Descricao + ' - Prof(a). ' + prof.Nome as NomeMateria
	
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
		and m.IdAluno = @IdAluno
	
	
	
				
/************************************************************************************************************************/


