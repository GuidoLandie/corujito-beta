
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJProfxMatXClasse]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJProfxMatXClasse
	
GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Inserir um registro na tabela CRJPessoa
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJProfxMatXClasse;01
(		
		@idProfXMatXClasse integer,
		@IdPessoa integer,
		@IdClasse integer,    
	    @IdMateria integer
)
AS
	
	INSERT INTO CRJProfxMatXClasse 
	(					
		
	
		IdPessoa,
		IdClasse,    
	    IdMateria
		
	)
	VALUES
	(					
		
		@IdPessoa,
		@IdClasse,    
	    @IdMateria
	)
	
	SELECT @@IDENTITY

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Alterar um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @IdEscola = 
*                  @Nome = 
*                  @Sexo = 
*                  @Email = 
*                  @DataNascimento = 
*                  @CPF = 
*                  @Telefone = 
*                  @Celular = 
*                  @CEP = 
*                  @Logradouro = 
*                  @Numero = 
*                  @Bairro = 
*                  @Estado = 
*                  @Pais = 
*                  @Ativo = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJProfxMatXClasse;02
(
	
		@idProfXMatXClasse integer,
		@IdPessoa integer,
		@IdClasse integer,    
	    @IdMateria integer
	
)


AS
	select * from CRJProfxMatXClasse
	UPDATE CRJProfxMatXClasse
	SET    			
	
		IdPessoa = @IdPessoa ,
		IdClasse = @IdClasse ,    
	    IdMateria= @IdMateria 		
	       
	WHERE idProfXMatXClasse = @idProfXMatXClasse

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Remover um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/

CREATE PROCEDURE STPCRJProfxMatXClasse;03
(		
		
		@IdPessoa integer = null,
		@IdClasse integer,    
	    @IdMateria integer
)
AS
SET NOCOUNT ON

	SELECT  IdProfXMatXClasse ,
		IdPessoa ,
		IdClasse ,    
	    IdMateria
			
	FROM   CRJProfXMatXClasse
	
where IdPessoa = isnull(@IdPessoa,IdPessoa)
	

	
	

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Remover um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/

CREATE PROCEDURE STPCRJProfxMatXClasse;04
(		
	@IdProfessor int
)
AS
SET NOCOUNT ON

	SELECT  
			IdProfXMatXClasse ,
			IdPessoa ,
			IdClasse ,    
			IdMateria
			
	FROM   CRJProfXMatXClasse
	where IdPessoa = @IdProfessor

	
	

/************************************************************************************************************************/
