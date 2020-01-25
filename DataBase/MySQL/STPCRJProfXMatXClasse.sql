
DELIMITER //

CREATE PROCEDURE STPCRJProfxMatXClasse01
(		
		idProfXMatXClasse integer,
		IdPessoa integer,
		IdClasse integer,    
	    IdMateria integer
)
begin
	
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
	);
	
	SELECT @@IDENTITY;

/************************************************************************************************************************/


END;
//

DELIMITER ;



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
DELIMITER //

CREATE PROCEDURE STPCRJProfxMatXClasse02
(
	
		idProfXMatXClasse integer,
		IdPessoa integer,
		IdClasse integer,    
	    IdMateria integer
	
)


begin
	select * from CRJProfxMatXClasse;
	UPDATE CRJProfxMatXClasse
	SET    			
	
		IdPessoa = @IdPessoa ,
		IdClasse = @IdClasse ,    
	    IdMateria= @IdMateria 		
	       
	WHERE idProfXMatXClasse = @idProfXMatXClasse;

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Remover um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/

DELIMITER //

CREATE PROCEDURE STPCRJProfxMatXClasse03
(		
		
		IdPessoa integer ,
		IdClasse integer,    
	    IdMateria integer
)
begin

	SELECT  IdProfXMatXClasse ,
		IdPessoa ,
		IdClasse ,    
	    IdMateria
			
	FROM   CRJProfXMatXClasse
	
where IdPessoa = ifnull(@IdPessoa,IdPessoa);
	

	
	

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Remover um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/

DELIMITER //

CREATE PROCEDURE STPCRJProfxMatXClasse04
(		
	IdProfessor int
)
begin

	SELECT  
			IdProfXMatXClasse ,
			IdPessoa ,
			IdClasse ,    
			IdMateria
			
	FROM   CRJProfXMatXClasse
	where IdPessoa = @IdProfessor;
END;
//

DELIMITER ;



	
	

/************************************************************************************************************************/
