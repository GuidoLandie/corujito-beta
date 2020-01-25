USE rodrigo_martines_crj;


go


CREATE TABLE CRJStatus
(
    IdStatus INT AUTO_INCREMENT NOT NULL,
    Descricao varchar(50) NOT null,
    PRIMARY KEY(IdStatus)
);
-- -------------------------------------------------------------------------------------------------------------------------------
GO
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJTipoPessoa
(
	IdTipoPessoa  INT NOT NULL AUTO_INCREMENT,
	Descricao    VARCHAR(255) NOT NULL,
	PRIMARY KEY(IdTipoPessoa)
);
-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
 
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJEscola
(
    idEscola INTEGER		NOT NULL auto_increment,
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
    DataAbertura DATETIME(3)		NULL,
    InscEstadual VARCHAR(255)		NULL,
    TelefonePrincipal VARCHAR (255) NULL,
    TelefoneSecundario VARCHAR(255) NULL,
    Email  VARCHAR(255)				NULL,
    Observacao VARCHAR(250)			NULL,
    PRIMARY KEY(idEscola),
    FOREIGN KEY(IdStatus)REFERENCES CRJStatus(IdStatus)
);
-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJPessoa
(
    IdPessoa INTEGER NOT NULL AUTO_INCREMENT,
    IdStatus INTEGER NOT NULL,    
    Nome VARCHAR(255)	NOT NULL,
    CPF VARCHAR(255)	NULL,
    RG VARCHAR(255)		NULL,
    Sexo VARCHAR(255)	NOT NULL,
    Email VARCHAR(255)  NOT NULL,
    DataNascimento DATETIME(3)  NOT NULL,
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
-- -------------------------------------------------------------------------------------------------------------------------------
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJGrupoPermissao
(
    IdGrupo		INTEGER Auto_increment  NOT NULL,
    IdEscola	INTEGER			  NOT NULL,
    Nome		VARCHAR(255)	  NULL,
    Descricao	VARCHAR(255)      NULL,
    IdTipoPessoa INTEGER		  null,
    PRIMARY KEY(IdGrupo),
    FOREIGN KEY(IdEscola)REFERENCES CRJEscola(IdEscola),    
    FOREIGN KEY(IdTipoPessoa)REFERENCES CRJTipoPessoa(IdTipoPessoa)    
);
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
GO
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJAplicacoes
(
    IdAplicacao		INTEGER			  NOT NULL,
    Nome			VARCHAR(20)		  NOT NULL,
    Descricao		VARCHAR(255)	  NULL,
    Caminho			VARCHAR(255)	  NOT NULL,
    AplicacaoPai	INTEGER			  NOT NULL,    
    PRIMARY KEY(IdAplicacao)
);
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJFuncionalidadeAplicacao
(
    IdFuncionalidade INTEGER		    NOT NULL,
    IdAplicacao		 INTEGER			NOT NULL,
    Descricao		 VARCHAR(50)		NULL,
    PRIMARY KEY(IdFuncionalidade),
    FOREIGN KEY(IdAplicacao)REFERENCES CRJAplicacoes(IdAplicacao)      
);
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJUsuarios
(
    Usuario			VARCHAR(255)  NOT NULL,
    IdPessoa		INTEGER		 NOT NULL,
    Senha			VARCHAR(50)  NOT NULL,
    Ativo			TINYINT			 NOT NULL,
    PRIMARY KEY(Usuario),
    FOREIGN KEY(IdPessoa)REFERENCES CRJPessoa(IdPessoa),
    UNIQUE(Usuario)
);
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJAplicacaoGrupo
(
    IdAplicacao				INTEGER   NOT NULL,
    IdGrupo					INTEGER   NOT NULL,
    IdFuncionalidade		INTEGER	  NOT NULL,
    FOREIGN KEY(IdAplicacao)		REFERENCES CRJAplicacoes(IdAplicacao),
    FOREIGN KEY(IdGrupo)			REFERENCES CRJGrupoPermissao(IdGrupo),
    FOREIGN KEY(IdFuncionalidade)	REFERENCES CRJFuncionalidadeAplicacao(IdFuncionalidade)
);
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJAplicacaoUsuario
(
    Usuario VARCHAR(255)  NOT NULL,
    IdAplicacao INTEGER  NOT NULL,
    IdFuncionalidade INTEGER NOT NULL,
    
    FOREIGN KEY(Usuario)REFERENCES CRJUsuarios(Usuario),
    FOREIGN KEY(IdAplicacao)REFERENCES CRJAplicacoes(IdAplicacao),   
    FOREIGN KEY(IdFuncionalidade)REFERENCES CRJFuncionalidadeAplicacao(IdFuncionalidade)      
);
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJGrupoPermissaoUsuarios
(
    Usuario VARCHAR(255) NOT NULL,
    IdGrupo INTEGER		NOT NULL,
	FOREIGN KEY(Usuario)REFERENCES CRJUsuarios(Usuario),
    FOREIGN KEY(IdGrupo)REFERENCES CRJGrupoPermissao(IdGrupo)      
);
-- ---------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJOcorrencia (
  IdOcorrencia INTEGER   NOT NULL   auto_increment,
  IdLancador INTEGER   NOT NULL  ,
  IdAluno INTEGER   NULL  ,
  Ocorrencia VARCHAR(500)  NULL  ,
  Providencias VARCHAR(500)  NULL  ,
  DataOcorrencia DATETIME(3)  NULL    ,
PRIMARY KEY(IdOcorrencia)  ,
FOREIGN KEY(IdLancador)REFERENCES CRJPessoa(IdPessoa)
);      

-- -----------------------------------------------------------------------------------------------------------------------------
-- ----------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJSerie
(
	IdSerie    INT NOT NULL AUTO_INCREMENT,
	Descricao  VARCHAR(45) NOT NULL,
	PRIMARY KEY(idSerie)
);
-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJMateria
(
	IdMateria INTEGER		NOT NULL auto_increment,
	Descricao VARCHAR(255)  NOT NULL,
	TipoMateria VARCHAR(1)  NOT NULL,
	PRIMARY KEY(IdMateria)
);
-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJTurno
(
    idTurno INTEGER   NOT NULL AUTO_INCREMENT,
    Descricao varchar(255) NULL,
    PRIMARY KEY(idTurno)
);
-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJTipoAtividade
(
    IdTipoAtividade INTEGER NOT NULL AUTO_INCREMENT,
    Descricao varchar(255) NOT NULL,
    PRIMARY KEY(IdTipoAtividade)
);
-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJEnsino
(
    idEnsino INTEGER NOT NULL auto_increment,
    idEscola INTEGER NOT NULL,
    Descricao VARCHAR(45)  NOT NULL,
    PRIMARY KEY(idEnsino),
    FOREIGN KEY(idEscola)REFERENCES CRJEscola(idEscola)
);
-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJPessoaXTipo
(
    IdPessoaXTipo INTEGER NOT NULL AUTO_INCREMENT,
    IdPessoa INTEGER NOT NULL,
    IdTipoPessoa INTEGER  NOT NULL,
    PRIMARY KEY(IdPessoaXTipo),
    FOREIGN KEY(IdPessoa)REFERENCES CRJPessoa(IdPessoa),
    FOREIGN KEY(IdTipoPessoa)REFERENCES CRJTipoPessoa(IdTipoPessoa)
);
-- -------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE CRJTipoProduto
(
	IdTipoProduto  INTEGER  NOT NULL,
	Nome           VARCHAR(200) NULL,
	PRIMARY KEY(IdTipoProduto)
);


-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJProduto
(
	IdProduto      INTEGER NOT NULL AUTO_INCREMENT,
	IdTipoProduto  INTEGER NOT NULL,
	Cod_Barra      VARCHAR(500) NULL,
	Nome           VARCHAR(250) NULL,
	Descricao      VARCHAR(500) NULL,
	Quantidade     INTEGER NULL,
	Preco          DECIMAL(15,4) NULL,
	IdStatus     INTEGER NOT NULL,
	PRIMARY KEY(IdProduto),
	FOREIGN KEY(IdTipoProduto)REFERENCES CRJTipoProduto (IdTipoProduto),
	FOREIGN KEY(IdStatus)REFERENCES CRJStatus(IdStatus)	
);
-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJVendaProduto
(
	IdVendaProduto  INTEGER NOT NULL AUTO_INCREMENT,
	IdPessoa        INTEGER NOT NULL,
	DataVenda       DATETIME(3) NULL,
	ValorTotal      DOUBLE NULL,
	PRIMARY KEY(IdVendaProduto),
	FOREIGN KEY (IdPessoa) REFERENCES  CRJPessoa(IdPessoa)
);
-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJProdutoVendido
(
	IdProdutoVendido  INTEGER  NOT NULL auto_increment,
	IdVendaProduto    INTEGER  NOT NULL,
	IdProduto         INTEGER  NOT NULL,
	Valor             DOUBLE NULL,
	PRIMARY KEY(IdProdutoVendido),
	FOREIGN KEY (IdVendaProduto) REFERENCES  CRJVendaProduto(IdVendaProduto)	
);
-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJClasse
(
    IdClasse	INTEGER		NOT NULL   AUTO_INCREMENT,
    IdSerie		INTEGER		NOT NULL,
    IdEnsino	INTEGER		NOT NULL,
    IdTurno		INTEGER		NOT NULL,
    NomeTurma	VARCHAR(20)		NULL,
    PRIMARY KEY(IdClasse),
    FOREIGN KEY (IdSerie) REFERENCES	CRJSerie (IdSerie),
    FOREIGN KEY (IdEnsino) REFERENCES	CRJEnsino(IdEnsino),
    FOREIGN KEY (IdTurno) REFERENCES	CRJTurno(IdTurno)	
);
-- -------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJProfXMatXClasse
(
    IdProfXMatXClasse INTEGER NOT NULL   AUTO_INCREMENT,
    IdPessoa INTEGER   NOT NULL,
    IdClasse INTEGER   NOT NULL,
    IdMateria INTEGER   NOT NULL,
    PRIMARY KEY(idProfXMatXClasse),
    FOREIGN KEY (IdPessoa) REFERENCES	CRJPessoa (IdPessoa),
    FOREIGN KEY (IdClasse) REFERENCES	CRJClasse (IdClasse),
    FOREIGN KEY (IdMateria) REFERENCES	CRJMateria (IdMateria)    
);

-- -------------------------------------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJAtividade
(
    IdAtividade INTEGER auto_increment,
    IdProfXMatXClasse INTEGER,
    Nomeatividade varchar(250),
    IdTipoAtividade INTEGER,
    DataInicial datetime(3),
    Datafinal datetime(3),
    descricao varchar(500),
    PRIMARY KEY(IdAtividade),
    FOREIGN KEY (IdTipoAtividade) REFERENCES CRJTipoAtividade(IdTipoAtividade),
    FOREIGN KEY (IdProfXMatXClasse) REFERENCES CRJProfXMatXClasse(IdProfXMatXClasse)
);

-- -------------------------------------------------------------------------------------------------------------------------------
GO
-- -------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJAluno (
  IdAluno 	INTEGER NOT NULL AUTO_INCREMENT,  
  IdPessoa 	INTEGER NOT NULL,
  RA 		VARCHAR(10)  NOT NULL,
  PRIMARY KEY(IdAluno)  ,
  FOREIGN KEY (IdPessoa) REFERENCES	CRJPessoa (IdPessoa)  
);

GO

CREATE TABLE CRJResponsavelXAluno
(
    IdResponsavelXAluno		INTEGER	NOT NULL   AUTO_INCREMENT,
    IdAluno					INTEGER	NOT NULL UNIQUE,
    IdResponsavel			INTEGER NOT NULL UNIQUE,
	DataAtribuicao			datetime(3),
    PRIMARY KEY(IdResponsavelXAluno),
    FOREIGN KEY (IdResponsavel) REFERENCES	CRJPessoa (IdPessoa),
    FOREIGN KEY (IdAluno)		REFERENCES	CRJAluno (IdAluno)
);
-- ------------------------------------------------------------------------------------------------------------------
GO
-- ------------------------------------------------------------------------------------------------------------------

-- ------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJMensagem(
  IdMensagem 	INTEGER   NOT NULL AUTO_INCREMENT,
  IdLancador 	INTEGER   NOT NULL,
  IdAluno 		INTEGER   NULL,
  Mensagem 		VARCHAR(1)   NULL,
  DataMensagem  DATETIME(3)  NULL,

  PRIMARY KEY(IdMensagem),
  FOREIGN KEY (IdLancador) REFERENCES	CRJPessoa (IdPessoa) 
);  
-- ------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJCartao (
  IdCartao 	   INTEGER   NOT NULL AUTO_INCREMENT,
  IdPessoa 	  INTEGER   NOT NULL,
  DataEmissao DATETIME(3)  NOT null,
  PRIMARY KEY(IdCartao),
  FOREIGN KEY (IdPessoa) REFERENCES	CRJPessoa (IdPessoa) 
);

-- ------------------------------------------------------------------------------------------------------------------
go
-- ------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJLancamentoCartao (
  IdLancamentoCartao INTEGER NOT NULL auto_increment,
  IdLancador 		 INTEGER NOT NULL,
  IdCartao 			 INTEGER NOT NULL,
  Valor 			 DECIMAL(15,4)  NULL,
  Descricao			 varchar(255),
  DataLancamento 	 DATETIME(3)  null,
 
  PRIMARY KEY(IdLancamentoCartao),
  FOREIGN KEY (IdLancador) REFERENCES	CRJPessoa (IdPessoa), 
  FOREIGN KEY (IdCartao)   REFERENCES	CRJCartao (IdCartao)
);
-- ------------------------------------------------------------------------------------------------------------------
GO
-- ------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJMatricula (
  idCRJMatricula 	INTEGER NOT NULL AUTO_INCREMENT,
  IdAluno 			INTEGER  NOT NULL,
  idEscola 			INTEGER  NOT NULL,
  idClasse 		INTEGER  NOT NULL,
  DataMatricula 	DATETIME(3) NOT null,
PRIMARY KEY(idCRJMatricula),
FOREIGN KEY (IdAluno) REFERENCES	CRJAluno  (IdAluno),
FOREIGN KEY (idClasse)   REFERENCES	CRJClasse (IdClasse)
);
-- ------------------------------------------------------------------------------------------------------------------
GO
-- ------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJFrequencia (
	  IdFrequencia 			INTEGER  NOT NULL AUTO_INCREMENT,
	  IdCRJMatricula 		INTEGER  NOT NULL,
	  IdProfXMatXClasse 	INTEGER  NOT NULL,
	  DataAula 				DATETIME(3) NOT NULL,
	  Presente 				TINYINT      NOT NULL,
	  IdLancador 			INTEGER NOT null,
	PRIMARY KEY(IdFrequencia),
	FOREIGN KEY (IdLancador) REFERENCES	CRJPessoa (IdPessoa), 
	FOREIGN KEY (IdCRJMatricula) REFERENCES	CRJMatricula (idCRJMatricula), 
	FOREIGN KEY (IdProfXMatXClasse) REFERENCES	CRJProfXMatXClasse (IdProfXMatXClasse)	
);
-- ------------------------------------------------------------------------------------------------------------------

go
-- ------------------------------------------------------------------------------------------------------------------
CREATE TABLE CRJNotaAluno (
  IdNotaAluno		INTEGER NOT NULL auto_increment,
  IdAtividade		INTEGER NOT NULL,
  IdMatricula	    INTEGER NOT NULL,
  IdProfXMatXClasse INTEGER NOT NULL,
  Nota				double	NULL,
  DataNota			Datetime(3) NULL,
  Atribuidor		INTEGER NOT null,
  PRIMARY KEY(IdNotaAluno),
  FOREIGN KEY (IdAtividade)		REFERENCES	CRJAtividade (IdAtividade), 
  FOREIGN KEY (IdMatricula)	REFERENCES	CRJMatricula (IdCRJMatricula), 
  FOREIGN KEY (IdProfXMatXClasse)	REFERENCES	CRJProfXMatXClasse (IdProfXMatXClasse),
  FOREIGN KEY (Atribuidor) REFERENCES	CRJPessoa (IdPessoa)	
);
-- ------------------------------------------------------------------------------------------------------------------
