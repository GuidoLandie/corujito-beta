
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJPessoa]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJPessoa
	
GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Inserir um registro na tabela CRJPessoa
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJPessoa;01
(		
		@IdStatus        int,
		@Nome            varchar(255),
		@CPF             varchar(255),
		@RG              varchar(255),
		@Sexo            varchar(1),
		@Email           varchar(255),
		@DataNascimento  DateTime,
		@Telefone        varchar(255),
		@Celular         varchar(255),
		@CEP             varchar(255),
		@Logradouro      varchar(255),
		@Numero          varchar(255),
		@Bairro          varchar(255),
		@Cidade          varchar(255),
		@Estado          varchar(255),
		@Pais            varchar(255),
		@Complemento     varchar(255),
		@URL             varchar(255)
	
)
AS
	
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
CREATE PROCEDURE STPCRJPessoa;02
(
	
	@IdPessoa        int,	
	@IdStatus        int,
	@Nome            varchar(255),
	@CPF             varchar(255),
	@RG              varchar(255),
	@Sexo            varchar(1),
	@Email           varchar(255),
	@DataNascimento  DateTime,
	@Telefone        varchar(255),
	@Celular         varchar(255),
	@CEP             varchar(255),
	@Logradouro      varchar(255),
	@Numero          varchar(255),
	@Bairro          varchar(255),
	@Cidade          varchar(255),
	@Estado          varchar(255),
	@Pais            varchar(255),
	@Complemento     varchar(255),
	@URL             varchar(255)
	
)


AS
	
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
	       
	WHERE  IdPessoa = @IdPessoa

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
CREATE PROCEDURE STPCRJPessoa;03
(
	@IdPessoa Int,
	@RUUsuarioLogado VarChar(10)
)
AS
	
	DELETE FROM CRJPessoa
	WHERE IdPessoa = @IdPessoa

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Obter um registro da tabela CRJPessoa
* Parâmetros.....: @IdPessoa = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJPessoa;04
(		
	@pIdPessoa	int = null,
	@pNome		varchar(255) = NULL,
	@pEmail		varchar(255) = NULL,
	@pCPF		varchar(255) = NULL,
	@pTelefone	varchar(255) = NULL
)
AS
SET NOCOUNT ON

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
		
	
	WHERE  isnull(p.IdPessoa,'')	= isnull(@pIdPessoa,isnull(p.IdPessoa,''))
	  AND  isnull(p.Nome,'')		like '%' + isnull(@pNome,isnull(p.Nome,''))		+ '%'
	  AND  isnull(p.Email,'')		like '%' +  isnull(@pEmail,isnull(p.Email,''))	+ '%'
	  AND  isnull(p.CPF,'')			= isnull(@pCPF, isnull(p.CPF,''))
	  AND  isnull(p.Telefone,'')	= isnull(@pTelefone,isnull(p.Telefone,''))
	
	ORDER BY
	       p.Nome
	
	

/************************************************************************************************************************/

GO




/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Obeter os responsaveis de um aluno atraves do aluno
* Alterações.....: STPCRJPessoa;05 4
************************************************************************************************************************/
CREATE PROCEDURE STPCRJPessoa;05
(		
	@pIdAluno	int	
)
AS
SET NOCOUNT ON

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
		on a.IdPessoa = p.IdPessoa
	
	 
	
/************************************************************************************************************************/	

go


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Obeter os os dependentes de um responsavel
* Alterações.....: STPCRJPessoa;06 4 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJPessoa;06
(		
	@pIdResponsavel	int	
)
AS
SET NOCOUNT ON

	
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
		on a.IdPessoa = p.IdPessoa
		
	
	
/************************************************************************************************************************/	

go

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: insere /  altera um registro na tabela responsavel aluno
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJPessoa;07
(			
	@IdAluno int,
	@IdResponsvel int
)
AS
SET NOCOUNT ON


	insert into CRJResponsavelXAluno (IdResponsavel,IdAluno,dataatribuicao) values (@IdResponsvel,@IdAluno, getdate())
	
/************************************************************************************************************************/
go
/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: insere /  altera um registro na tabela responsavel aluno
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJPessoa;08
(		
	@IdResponsavelAluno int	
)
AS
SET NOCOUNT ON

	delete from CRJResponsavelXAluno where IdResponsavelXAluno = @IdResponsavelAluno
	
/************************************************************************************************************************/

go


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Obter responsaveis
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJPessoa;09
AS
SET NOCOUNT ON

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
			and t.IdTipoPessoa = 6 --Responsaveis
	
/************************************************************************************************************************/	
go


/**********	**************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Obter alunos / depdentes
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJPessoa;10
AS
SET NOCOUNT ON

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
		on p.IdPessoa = a.IdPessoa
	
	
/************************************************************************************************************************/	

