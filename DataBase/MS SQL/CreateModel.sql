
--Drop das tabelas




------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (

       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJNotaAluno]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJNotaAluno
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (

       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJFrequencia]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJFrequencia
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (

       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJMatricula]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJMatricula
------------------------------------------------------------------------------------------------------------------------------

GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (

       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJLancamentoCartao]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJLancamentoCartao
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (

       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJCartao]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJCartao
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (

       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJMensagem]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJMensagem
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (

       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJAluno]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJAluno
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (

       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJResponsavelXAluno]')
              AND TYPE IN (N'U')
   )

    DROP TABLE CRJResponsavelXAluno
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (

       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJAtividade]')
              AND TYPE IN (N'U')
   )

    DROP TABLE CRJAtividade
------------------------------------------------------------------------------------------------------------------------------
GO
-------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJProfXMatXClasse]')
        AND  type IN (N'U')
   )    
    DROP TABLE CRJProfXMatXClasse
-------------------------------------------------------------------------------------------------------------------------------    
GO
-------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJClasse]')
        AND  type IN (N'U')
   )    
    DROP TABLE CRJClasse    
-------------------------------------------------------------------------------------------------------------------------------    
go

-------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJProdutoVendido]')
        AND  type IN (N'U')
   )    
    DROP TABLE CRJProdutoVendido    
-------------------------------------------------------------------------------------------------------------------------------    
go

-------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJVendaProduto]')
        AND  type IN (N'U')
   )    
    DROP TABLE CRJVendaProduto    
-------------------------------------------------------------------------------------------------------------------------------    
go
-------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJOcorrencia]')
        AND  type IN (N'U')
   )    
    DROP TABLE CRJOcorrencia    
-------------------------------------------------------------------------------------------------------------------------------    
go

------------------------------------------------------------------------------------------------------------------------------- 
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJProduto]')
        AND  type IN (N'U')
   )    
    DROP TABLE CRJProduto
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS ( Select * 
            FROM sys.objects
            WHERE object_id = OBJECT_ID(N'[CRJTipoProduto]')
               AND type IN (N'U')               
            )            
            DROP TABLE CRJTipoProduto 
-------------------------------------------------------------------------------------------------------------------------------     
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS ( Select * 
            FROM sys.objects
            WHERE object_id = OBJECT_ID(N'[CRJGrupoPermissaoUsuarios]')
               AND type IN (N'U')               
            )            
            DROP TABLE CRJGrupoPermissaoUsuarios 
-------------------------------------------------------------------------------------------------------------------------------    
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJAplicacaoGrupo]')
        AND  type IN (N'U')
   )    
    DROP TABLE CRJAplicacaoGrupo
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJGrupoPermissao]')
        AND  type IN (N'U')
   )    
    DROP TABLE CRJGrupoPermissao
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJAplicacaoUsuario]')
        AND  type IN (N'U')
   )    
    DROP TABLE CRJAplicacaoUsuario
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJFuncionalidadeAplicacao]')
        AND  type IN (N'U')
   )
    
    DROP TABLE CRJFuncionalidadeAplicacao
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJAplicacoes]')
        AND  type IN (N'U')
   )
    
    DROP TABLE CRJAplicacoes
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[CRJUsuarios]')
        AND  type IN (N'U')
   )    
    DROP TABLE CRJUsuarios
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJPessoaXTipo]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJPessoaXTipo
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJPessoa]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJPessoa
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJEnsino]')
              AND TYPE IN (N'U')
   )

    DROP TABLE CRJEnsino
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------ 

IF EXISTS (
       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJEscola]')
              AND TYPE IN (N'U')
   )

    DROP TABLE CRJEscola

------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------ 
IF EXISTS (
       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJStatus]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJStatus
------------------------------------------------------------------------------------------------------------------------------    
GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (
       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJSerie]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJSerie
------------------------------------------------------------------------------------------------------------------------------    
GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (
       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJMateria]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJMateria
------------------------------------------------------------------------------------------------------------------------------    
GO
------------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJTurno]')
              AND TYPE IN (N'U')
   )

    DROP TABLE CRJTurno
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (
       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJTipoAtividade]')
              AND TYPE IN (N'U')
   )

    DROP TABLE CRJTipoAtividade
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------    
IF EXISTS (
       SELECT *
       FROM   sys.objects
       WHERE  OBJECT_ID = OBJECT_ID(N'[CRJTipoPessoa]')
              AND TYPE IN (N'U')
   )
    DROP TABLE CRJTipoPessoa
------------------------------------------------------------------------------------------------------------------------------ 
GO

------------------------------------------------------------------------------------------------------------------------------
-------------------------------		CRIAÇÃO DAS TABELAS
------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJStatus
(
    IdStatus INT IDENTITY NOT NULL,
    Descricao varchar(50) NOT NULL
    PRIMARY KEY(IdStatus) 
);
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJTipoPessoa
(
	IdTipoPessoa  INT NOT NULL IDENTITY,
	Descricao    VARCHAR(255) NOT NULL,
	PRIMARY KEY(IdTipoPessoa)
);
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJEscola
(
    idEscola INTEGER		NOT NULL identity,
    IdStatus INTEGER		NOT NULL,
    Nome VARCHAR(255)				NULL,    
    RazaoSocial	VARCHAR(255)		NULL,
    Missao		VARCHAR(255)		NULL,
    Logradouro		VARCHAR(255)	NULL,
    CNPJ VARCHAR(255)				NULL,
    Rua VARCHAR(255)				NULL,
    CEP VARCHAR(255)				NULL,
    Bairro VARCHAR(255)				NULL,
    Cidade VARCHAR(255)				NULL,
    Pais VARCHAR(255)				NULL,
    Estado VARCHAR(255)				NULL,
    DataAbertura DATETIME			NULL,
    InscEstadual VARCHAR(255)		NULL,
    TelefonePrincipal VARCHAR (255) NULL,
    TelefoneSecundario VARCHAR(255) NULL,
    Email  VARCHAR(255)				NULL,
    Observacao VARCHAR(250)			NULL,
    PRIMARY KEY(idEscola),
    FOREIGN KEY(IdStatus)REFERENCES CRJStatus(IdStatus)
);
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJPessoa
(
    IdPessoa INTEGER NOT NULL IDENTITY,
    IdStatus INTEGER NOT NULL,    
    Nome VARCHAR(255)	NOT NULL,
    CPF VARCHAR(255)	NULL,
    RG VARCHAR(255)		NULL,
    Sexo VARCHAR(255)	NOT NULL,
    Email VARCHAR(255)  NOT NULL,
    DataNascimento DATETIME  NOT NULL,
    Telefone VARCHAR(255)		NOT NULL,
    Celular VARCHAR(255)		NULL,
    CEP VARCHAR(255)			NOT NULL,
    Logradouro VARCHAR(255)		NULL,
    Numero VARCHAR(255)			NULL,
    Bairro VARCHAR(255)			NULL,
    Cidade VARCHAR(255)			NULL,
    Estado VARCHAR(255)			NULL,
    Pais VARCHAR(255)			NULL,
    Complemento VARCHAR(255)	NULL,
    URL VARCHAR(255)			NULL,
    PRIMARY KEY(IdPessoa),
     FOREIGN KEY(IdStatus)REFERENCES CRJStatus(IdStatus)
);
---------------------------------------------------------------------------------------------------------------------------------
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJGrupoPermissao
(
    IdGrupo		INTEGER Identity  NOT NULL,
    IdEscola	INTEGER			  NOT NULL,
    Nome		VARCHAR(255)	  NULL,
    Descricao	VARCHAR(255)      NULL,
    IdTipoPessoa INTEGER		  NULL
    PRIMARY KEY(IdGrupo),
    FOREIGN KEY(IdEscola)REFERENCES CRJEscola(IdEscola),    
    FOREIGN KEY(IdTipoPessoa)REFERENCES CRJTipoPessoa(IdTipoPessoa)    
);
-----------------------------------------------------------------------------------------------------------------------------------------------------
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJAplicacoes
(
    IdAplicacao		INTEGER			  NOT NULL,
    Nome			VARCHAR(20)		  NOT NULL,
    Descricao		VARCHAR(255)	  NULL,
    Caminho			VARCHAR(255)	  NOT NULL,
    AplicacaoPai	INTEGER			  NOT NULL,    
    PRIMARY KEY(IdAplicacao)
);
-----------------------------------------------------------------------------------------------------------------------------------------------------
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJFuncionalidadeAplicacao
(
    IdFuncionalidade INTEGER		    NOT NULL,
    IdAplicacao		 INTEGER			NOT NULL,
    Descricao		 VARCHAR(50)		NULL,
    PRIMARY KEY(IdFuncionalidade),
    FOREIGN KEY(IdAplicacao)REFERENCES CRJAplicacoes(IdAplicacao)      
);
-----------------------------------------------------------------------------------------------------------------------------------------------------
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJUsuarios
(
    Usuario			VARCHAR(255)  NOT NULL,
    IdPessoa		INTEGER		 NOT NULL,
    Senha			VARCHAR(50)  NOT NULL,
    Ativo			BIT			 NOT NULL,
    PRIMARY KEY(Usuario),
    FOREIGN KEY(IdPessoa)REFERENCES CRJPessoa(IdPessoa),
    UNIQUE(Usuario)
);
-----------------------------------------------------------------------------------------------------------------------------------------------------
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJAplicacaoGrupo
(
    IdAplicacao				INTEGER   NOT NULL,
    IdGrupo					INTEGER   NOT NULL,
    IdFuncionalidade		INTEGER	  NOT NULL,
    FOREIGN KEY(IdAplicacao)		REFERENCES CRJAplicacoes(IdAplicacao),
    FOREIGN KEY(IdGrupo)			REFERENCES CRJGrupoPermissao(IdGrupo),
    FOREIGN KEY(IdFuncionalidade)	REFERENCES CRJFuncionalidadeAplicacao(IdFuncionalidade)
);
-----------------------------------------------------------------------------------------------------------------------------------------------------
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJAplicacaoUsuario
(
    Usuario VARCHAR(255)  NOT NULL,
    IdAplicacao INTEGER  NOT NULL,
    IdFuncionalidade INTEGER NOT NULL,
    
    FOREIGN KEY(Usuario)REFERENCES CRJUsuarios(Usuario),
    FOREIGN KEY(IdAplicacao)REFERENCES CRJAplicacoes(IdAplicacao),   
    FOREIGN KEY(IdFuncionalidade)REFERENCES CRJFuncionalidadeAplicacao(IdFuncionalidade)      
);
-----------------------------------------------------------------------------------------------------------------------------------------------------
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJGrupoPermissaoUsuarios
(
    Usuario VARCHAR(255) NOT NULL,
    IdGrupo INTEGER		NOT NULL,
	FOREIGN KEY(Usuario)REFERENCES CRJUsuarios(Usuario),
    FOREIGN KEY(IdGrupo)REFERENCES CRJGrupoPermissao(IdGrupo)      
)
-----------------------------------------------------------------------------------------------------------------------------------------------------
GO
CREATE TABLE CRJOcorrencia (
  IdOcorrencia INTEGER   NOT NULL   identity,
  IdLancador INTEGER   NOT NULL  ,
  IdAluno INTEGER   NULL  ,
  Ocorrencia VARCHAR(500)  NULL  ,
  Providencias VARCHAR(500)  NULL  ,
  DataOcorrencia DATETIME  NULL    ,
PRIMARY KEY(IdOcorrencia)  ,
FOREIGN KEY(IdLancador)REFERENCES CRJPessoa(IdPessoa)
)      

-------------------------------------------------------------------------------------------------------------------------------
GO
------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJSerie
(
	IdSerie    INT NOT NULL IDENTITY,
	Descricao  VARCHAR(45) NOT NULL,
	PRIMARY KEY(idSerie)
);
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJMateria
(
	IdMateria INTEGER		NOT NULL identity,
	Descricao VARCHAR(255)  NOT NULL,
	TipoMateria VARCHAR(1)  NOT NULL,
	PRIMARY KEY(IdMateria)
);
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJTurno
(
    idTurno INTEGER   NOT NULL IDENTITY,
    Descricao varchar(255) NULL,
    PRIMARY KEY(idTurno)
);
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJTipoAtividade
(
    IdTipoAtividade INTEGER NOT NULL IDENTITY,
    Descricao varchar(255) NOT NULL,
    PRIMARY KEY(IdTipoAtividade)
);
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJEnsino
(
    idEnsino INTEGER NOT NULL identity,
    idEscola INTEGER NOT NULL,
    Descricao VARCHAR(45)  NOT NULL,
    PRIMARY KEY(idEnsino),
    FOREIGN KEY(idEscola)REFERENCES CRJEscola(idEscola)
)
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJPessoaXTipo
(
    IdPessoaXTipo INTEGER NOT NULL IDENTITY,
    IdPessoa INTEGER NOT NULL,
    IdTipoPessoa INTEGER  NOT NULL,
    PRIMARY KEY(IdPessoaXTipo),
    FOREIGN KEY(IdPessoa)REFERENCES CRJPessoa(IdPessoa),
    FOREIGN KEY(IdTipoPessoa)REFERENCES CRJTipoPessoa(IdTipoPessoa)
);
---------------------------------------------------------------------------------------------------------------------------------
GO

CREATE TABLE CRJTipoProduto
(
	IdTipoProduto  INTEGER  NOT NULL,
	Nome           VARCHAR(200) NULL,
	PRIMARY KEY(IdTipoProduto)
);


---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJProduto
(
	IdProduto      INTEGER NOT NULL IDENTITY,
	IdTipoProduto  INTEGER NOT NULL,
	Cod_Barra      VARCHAR(500) NULL,
	Nome           VARCHAR(250) NULL,
	Descricao      VARCHAR(500) NULL,
	Quantidade     INTEGER NULL,
	Preco          MONEY NULL,
	IdStatus     INTEGER NOT NULL,
	PRIMARY KEY(IdProduto),
	FOREIGN KEY(IdTipoProduto)REFERENCES CRJTipoProduto (IdTipoProduto),
	FOREIGN KEY(IdStatus)REFERENCES CRJStatus(IdStatus)	
);
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJVendaProduto
(
	IdVendaProduto  INTEGER NOT NULL IDENTITY,
	IdPessoa        INTEGER NOT NULL,
	DataVenda       DATETIME NULL,
	ValorTotal      FLOAT NULL,
	PRIMARY KEY(IdVendaProduto),
	FOREIGN KEY (IdPessoa) REFERENCES  CRJPessoa(IdPessoa)
);
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJProdutoVendido
(
	IdProdutoVendido  INTEGER  NOT NULL identity,
	IdVendaProduto    INTEGER  NOT NULL,
	IdProduto         INTEGER  NOT NULL,
	Valor             FLOAT NULL,
	PRIMARY KEY(IdProdutoVendido),
	FOREIGN KEY (IdVendaProduto) REFERENCES  CRJVendaProduto(IdVendaProduto)	
);
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJClasse
(
    IdClasse	INTEGER		NOT NULL   IDENTITY,
    IdSerie		INTEGER		NOT NULL,
    IdEnsino	INTEGER		NOT NULL,
    IdTurno		INTEGER		NOT NULL,
    NomeTurma	VARCHAR(20)		NULL,
    PRIMARY KEY(IdClasse),
    FOREIGN KEY (IdSerie) REFERENCES	CRJSerie (IdSerie),
    FOREIGN KEY (IdEnsino) REFERENCES	CRJEnsino(IdEnsino),
    FOREIGN KEY (IdTurno) REFERENCES	CRJTurno(IdTurno)	
);
---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJProfXMatXClasse
(
    IdProfXMatXClasse INTEGER NOT NULL   IDENTITY,
    IdPessoa INTEGER   NOT NULL,
    IdClasse INTEGER   NOT NULL,
    IdMateria INTEGER   NOT NULL,
    PRIMARY KEY(idProfXMatXClasse),
    FOREIGN KEY (IdPessoa) REFERENCES	CRJPessoa (IdPessoa),
    FOREIGN KEY (IdClasse) REFERENCES	CRJClasse (IdClasse),
    FOREIGN KEY (IdMateria) REFERENCES	CRJMateria (IdMateria),    
);

---------------------------------------------------------------------------------------------------------------------------------

GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJAtividade
(
    IdAtividade INTEGER identity,
    IdProfXMatXClasse INTEGER,
    Nomeatividade varchar(250),
    IdTipoAtividade INTEGER,
    DataInicial datetime,
    Datafinal datetime,
    descricao varchar(500)
    PRIMARY KEY(IdAtividade),
    FOREIGN KEY (IdTipoAtividade) REFERENCES CRJTipoAtividade(IdTipoAtividade),
    FOREIGN KEY (IdProfXMatXClasse) REFERENCES CRJProfXMatXClasse(IdProfXMatXClasse)
);

---------------------------------------------------------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJResponsavelXAluno
(
    IdResponsavelXAluno		INTEGER	NOT NULL   IDENTITY,
    IdAluno					INTEGER	NOT NULL UNIQUE,
    IdResponsavel			INTEGER NOT NULL UNIQUE,
	DataAtribuicao			datetime
    PRIMARY KEY(IdResponsavelXAluno),
    FOREIGN KEY (IdResponsavel) REFERENCES	CRJPessoa (IdPessoa),
    FOREIGN KEY (IdAluno)		REFERENCES	CRJAluno (IdAluno)
);
--------------------------------------------------------------------------------------------------------------------
GO
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJAluno (
  IdAluno 	INTEGER NOT NULL IDENTITY,  
  IdPessoa 	INTEGER NOT NULL,
  RA 		VARCHAR(10)  NOT NULL,
  PRIMARY KEY(IdAluno)  ,
  FOREIGN KEY (IdPessoa) REFERENCES	CRJPessoa (IdPessoa)  
);
--------------------------------------------------------------------------------------------------------------------
GO
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJMensagem(
  IdMensagem 	INTEGER   NOT NULL IDENTITY,
  IdLancador 	INTEGER   NOT NULL,
  IdAluno 		INTEGER   NULL,
  Mensagem 		VARCHAR   NULL,
  DataMensagem  DATETIME  NULL,

  PRIMARY KEY(IdMensagem),
  FOREIGN KEY (IdLancador) REFERENCES	CRJPessoa (IdPessoa) 
)  
--------------------------------------------------------------------------------------------------------------------
GO
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJCartao (
  IdCartao 	   INTEGER   NOT NULL IDENTITY,
  IdPessoa 	  INTEGER   NOT NULL,
  DataEmissao DATETIME  NOT NULL
  PRIMARY KEY(IdCartao)
  FOREIGN KEY (IdPessoa) REFERENCES	CRJPessoa (IdPessoa) 
);

--------------------------------------------------------------------------------------------------------------------
go
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJLancamentoCartao (
  IdLancamentoCartao INTEGER NOT NULL identity,
  IdLancador 		 INTEGER NOT NULL,
  IdCartao 			 INTEGER NOT NULL,
  Valor 			 MONEY  NULL,
  Descricao			 varchar(255),
  DataLancamento 	 DATETIME  NULL
 
  PRIMARY KEY(IdLancamentoCartao)
  FOREIGN KEY (IdLancador) REFERENCES	CRJPessoa (IdPessoa), 
  FOREIGN KEY (IdCartao)   REFERENCES	CRJCartao (IdCartao)
);
--------------------------------------------------------------------------------------------------------------------
GO
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJMatricula (
  idCRJMatricula 	INTEGER NOT NULL IDENTITY,
  IdAluno 			INTEGER  NOT NULL,
  idEscola 			INTEGER  NOT NULL,
  idClasse 		INTEGER  NOT NULL,
  DataMatricula 	DATETIME NOT NULL
PRIMARY KEY(idCRJMatricula)
FOREIGN KEY (IdAluno) REFERENCES	CRJAluno  (IdAluno),
FOREIGN KEY (idClasse)   REFERENCES	CRJClasse (IdClasse)
);
--------------------------------------------------------------------------------------------------------------------
GO
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJFrequencia (
	  IdFrequencia 			INTEGER  NOT NULL IDENTITY,
	  IdCRJMatricula 		INTEGER  NOT NULL,
	  IdProfXMatXClasse 	INTEGER  NOT NULL,
	  DataAula 				DATETIME NOT NULL,
	  Presente 				BIT      NOT NULL,
	  IdLancador 			INTEGER NOT NULL
	PRIMARY KEY(IdFrequencia)
	FOREIGN KEY (IdLancador) REFERENCES	CRJPessoa (IdPessoa), 
	FOREIGN KEY (IdCRJMatricula) REFERENCES	CRJMatricula (idCRJMatricula), 
	FOREIGN KEY (IdProfXMatXClasse) REFERENCES	CRJProfXMatXClasse (IdProfXMatXClasse), 	
);
--------------------------------------------------------------------------------------------------------------------

go
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJNotaAluno (
  IdNotaAluno		INTEGER NOT NULL identity,
  IdAtividade		INTEGER NOT NULL,
  IdMatricula	    INTEGER NOT NULL,
  IdProfXMatXClasse INTEGER NOT NULL,
  Nota				float	NULL,
  DataNota			Datetime NULL,
  Atribuidor		INTEGER NOT NULL
  PRIMARY KEY(IdNotaAluno)
  FOREIGN KEY (IdAtividade)		REFERENCES	CRJAtividade (IdAtividade), 
  FOREIGN KEY (IdMatricula)	REFERENCES	CRJMatricula (IdCRJMatricula), 
  FOREIGN KEY (IdProfXMatXClasse)	REFERENCES	CRJProfXMatXClasse (IdProfXMatXClasse),
  FOREIGN KEY (Atribuidor) REFERENCES	CRJPessoa (IdPessoa)	
);
--------------------------------------------------------------------------------------------------------------------
