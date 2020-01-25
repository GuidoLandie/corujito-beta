
DELIMITER //

CREATE PROCEDURE STPCRJPessoa01
(		
		IdStatus        int,
		Nome            varchar(255),
		CPF             varchar(255),
		RG              varchar(255),
		Sexo            varchar(1),
		Email           varchar(255),
		DataNascimento  DateTime,
		Telefone        varchar(255),
		Celular         varchar(255),
		CEP             varchar(255),
		Logradouro      varchar(255),
		Numero          varchar(255),
		Bairro          varchar(255),
		Cidade          varchar(255),
		Estado          varchar(255),
		Pais            varchar(255),
		Complemento     varchar(255),
		URL             varchar(255)
	
)
begin
	
	INSERT INTO CRJPessoa
	(					
		IdStatus     ,
		Nome         ,
		CPF          ,
		RG           ,
		Sexo         ,
		Email        ,
		DataNascimento,
		Telefone     ,
		Celular      ,
		CEP          ,
		Logradouro   ,
		Numero       ,
		Bairro       ,
		Cidade       ,
		Estado       ,
		Pais         ,
		Complemento  ,
		URL          

		
	)
	VALUES
	(					
		@IdStatus      ,
		@Nome          ,
		@CPF           ,
		@RG            ,
		@Sexo          ,
		@Email         ,
		@DataNascimento,
		@Telefone      ,
		@Celular       ,
		@CEP           ,
		@Logradouro    ,
		@Numero        ,
		@Bairro        ,
		@Cidade        ,
		@Estado        ,
		@Pais          ,
		@Complemento   ,
		@URL		   
	);
	
	SELECT @@IDENTITY;

/************************************************************************************************************************/


END;
//

DELIMITER ;



DELIMITER //

CREATE PROCEDURE STPCRJPessoa02
(
	
	IdPessoa        int,	
	IdStatus        int,
	Nome            varchar(255),
	CPF             varchar(255),
	RG              varchar(255),
	Sexo            varchar(1),
	Email           varchar(255),
	DataNascimento  DateTime,
	Telefone        varchar(255),
	Celular         varchar(255),
	CEP             varchar(255),
	Logradouro      varchar(255),
	Numero          varchar(255),
	Bairro          varchar(255),
	Cidade          varchar(255),
	Estado          varchar(255),
	Pais            varchar(255),
	Complemento     varchar(255),
	URL             varchar(255)
	
)


begin
	
	UPDATE CRJPessoa
	SET    			
		IdStatus 		= @IdStatus     ,
		Nome			= @Nome         ,
		CPF				= @CPF          ,
		RG				= @RG           ,
		Sexo			= @Sexo         ,
		Email			= @Email        ,
		DataNascimento	= @DataNascimento,
		Telefone		= @Telefone     ,
		Celular			= @Celular      ,
		CEP				= @CEP          ,
		Logradouro		= @Logradouro   ,
		Numero			= @Numero       ,
		Bairro			= @Bairro       ,
		Cidade			= @Cidade       ,
		Estado			= @Estado       ,
		Pais			= @Pais         ,
		Complemento		= @Complemento  ,
		URL				= @URL			
	       
	WHERE  IdPessoa = @IdPessoa;

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

CREATE PROCEDURE STPCRJPessoa03
(
	IdPessoa Int,
	RUUsuarioLogado VarChar(10)
)
begin
	
	DELETE FROM CRJPessoa
	WHERE IdPessoa = @IdPessoa;

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Obter um registro da tabela CRJPessoa
* Parâmetros.....: @IdPessoa = .
* Alterações.....: 
************************************************************************************************************************/


DELIMITER //

CREATE PROCEDURE STPCRJPessoa04
(		
	pIdPessoa	int ,
	pNome		varchar(255) ,
	pEmail		varchar(255) ,
	pCPF		varchar(255) ,
	pTelefone	varchar(255) 
)
begin

	SELECT p.IdPessoa,	       
	       p.IdStatus,
	       p.Nome,
	       p.CPF,
	       p.RG,
	       p.Sexo,
	       p.Email,
	       p.DataNascimento,
	       p.Telefone,
	       p.Celular,
	       p.CEP,
	       p.Logradouro,
	       p.Numero,
	       p.Bairro,
	       p.Cidade,
	       p.Estado,
	       p.Pais,
	       p.Complemento,
	       p.URL
	       ,a.IdAluno
	FROM   CRJPessoa p
		left join CRJAluno a
		on a.IdPessoa = p.IdPessoa
		
	
	WHERE  ifnull(p.IdPessoa,'')	= ifnull(@pIdPessoa,ifnull(p.IdPessoa,''))
	  /*AND  ifnull(p.Nome,'')		like '%'; + concat(ifnull(@pNome,ifnull(p.Nome,''))		, '%')
	  AND  ifnull(p.Email,'')		like Concat('%' ,  ifnull(@pEmail,ifnull(p.Email,''))	, '%')
	  AND  ifnull(p.CPF,'')			= ifnull(@pCPF, ifnull(p.CPF,''))
	  AND  ifnull(p.Telefone,'')	= ifnull(@pTelefone,ifnull(p.Telefone,''))*/
	
	ORDER BY
	       p.Nome;
	
	




END;
//

DELIMITER;






/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Obeter os responsaveis de um aluno atraves do aluno
* Alterações.....: STPCRJPessoa;05 4
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJPessoa05
(		
	pIdAluno	int	
)
begin

	SELECT p2.IdPessoa,	       
	       p2.IdStatus,
	       p2.Nome,
	       p2.CPF,
	       p2.RG,
	       p2.Sexo,
	       p2.Email,
	       p2.DataNascimento,
	       p2.Telefone,
	       p2.Celular,
	       p2.CEP,
	       p2.Logradouro,
	       p2.Numero,	
	       p2.Bairro,
	       p2.Cidade,
	       p2.Estado,
	       p2.Pais,
	       p2.Complemento,
	       p2.URL,
	       r.IdResponsavelXAluno,
	       r.IdAluno
	FROM   CRJResponsavelXAluno r
		
		inner join CRJPessoa p2
		on r.IdResponsavel = p2.IdPessoa
		
		
		inner join CRJAluno a
			on a.IdAluno = r.IdAluno			
			and a.IdAluno = @pIdAluno
			
		inner join CRJPessoa p		
		on a.IdPessoa = p.IdPessoa;
	
	 
	
/************************************************************************************************************************/	


end;
//

delimiter ;




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Obeter os os dependentes de um responsavel
* Alterações.....: STPCRJPessoa;06 4 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJPessoa06
(		
	pIdResponsavel	int	
)
begin

	
	SELECT p.IdPessoa,	       
	       p.IdStatus,
	       p.Nome,
	       p.CPF,
	       p.RG,
	       p.Sexo,
	       p.Email,
	       p.DataNascimento,
	       p.Telefone,
	       p.Celular,
	       p.CEP,
	       p.Logradouro,
	       p.Numero,
	       p.Bairro,
	       p.Cidade,
	       p.Estado,
	       p.Pais,
	       p.Complemento,
	       p.URL,
	       r.IdResponsavelXAluno,
	       r.IdAluno
	       
	FROM   CRJResponsavelXAluno r
	
		inner join CRJPessoa p2
		on r.IdResponsavel = p2.IdPessoa
		and r.IdResponsavel = @pIdResponsavel
		
		inner join CRJAluno a
			on a.IdAluno = r.IdAluno			
			
		inner join CRJPessoa p		
		on a.IdPessoa = p.IdPessoa;
		
	
	
/************************************************************************************************************************/	


end;
//

delimiter ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: insere /  altera um registro na tabela responsavel aluno
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJPessoa07
(			
	IdAluno int,
	IdResponsvel int
)
begin


	insert into CRJResponsavelXAluno (IdResponsavel,IdAluno,dataatribuicao) values (@IdResponsvel,@IdAluno, now());
	
/************************************************************************************************************************/

end;
//

delimiter ;


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: insere /  altera um registro na tabela responsavel aluno
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJPessoa08
(		
	IdResponsavelAluno int	
)
begin

	delete from CRJResponsavelXAluno where IdResponsavelXAluno = @IdResponsavelAluno;
	
/************************************************************************************************************************/


end;
//

delimiter ;




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Obter responsaveis
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJPessoa09()
begin

	SELECT p.IdPessoa,	       
	       p.IdStatus,
	       p.Nome,
	       p.CPF,
	       p.RG,
	       p.Sexo,
	       p.Email,
	       p.DataNascimento,
	       p.Telefone,
	       p.Celular,
	       p.CEP,
	       p.Logradouro,
	       p.Numero,
	       p.Bairro,
	       p.Cidade,
	       p.Estado,
	       p.Pais,
	       p.Complemento,
	       p.URL
	FROM   CRJPessoa p
		inner join CRJPessoaXTipo t
			on p.IdPessoa = t.IdPessoa
			and t.IdTipoPessoa = 6; -- Responsaveis
	
/************************************************************************************************************************/	

end;
//

delimiter ;




/**********	**************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Obter alunos / depdentes
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJPessoa10()
begin

	SELECT p.IdPessoa,	       
	       p.IdStatus,
	       p.Nome,
	       p.CPF,
	       p.RG,
	       p.Sexo,
	       p.Email,
	       p.DataNascimento,
	       p.Telefone,
	       p.Celular,
	       p.CEP,
	       p.Logradouro,
	       p.Numero,
	       p.Bairro,
	       p.Cidade,
	       p.Estado,
	       p.Pais,
	       p.Complemento,
	       p.URL,
	       a.IdAluno
	       
	FROM   CRJPessoa p
		inner join CRJAluno a
		on p.IdPessoa = a.IdPessoa;
END;
//

DELIMITER ;


	
	
/************************************************************************************************************************/	

