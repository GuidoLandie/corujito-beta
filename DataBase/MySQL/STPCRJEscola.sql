DELIMITER //

CREATE PROCEDURE STPCRJEscola01
(
	idEscola Int,
	RazaoSocial VarChar(250),
	Nome VarChar(250),
	CNPJ VarChar(20),
	InscEstadual VarChar(20),
	Logradouro VarChar(250),
	Bairro VarChar(250),
	Cidade VarChar(250),
	Estado VarChar(250),
	CEP VarChar(250),
	TelefonePrincipal VarChar(250),
	TelefoneSecundario VarChar(250),
	Email VarChar(250),
	DataAbertura DateTime,
	Missao VarChar(250),
	IdStatus Int,
	Observacao VarChar(250)
)
begin

	UPDATE CRJEscola SET
		RazaoSocial = @RazaoSocial,		
		Nome = @Nome,
		CNPJ = @CNPJ,
		InscEstadual = @InscEstadual,
		Logradouro = @Logradouro,
		Bairro = @Bairro,
		Cidade = @Cidade,
		Estado = @Estado,
		CEP = @CEP,
		TelefonePrincipal = @TelefonePrincipal,
		TelefoneSecundario = @TelefoneSecundario,
		Email = @Email,
		DataAbertura = @DataAbertura,
		Missao = @Missao,
		IdStatus = @IdStatus,
		Observacao = @Observacao
	WHERE 
		idEscola = @idEscola;

END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:26:28
* Objetivo.......: Obter todos os registros da tabela CRJEscola
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJEscola02
(
	IdEscola int
)
begin

	SELECT 
		idEscola,
		RazaoSocial,
		Nome,
		CNPJ,
		InscEstadual,
		Logradouro,
		Bairro,
		Cidade,
		Estado,
		CEP,
		TelefonePrincipal,
		TelefoneSecundario,
		Email,
		DataAbertura,
		Missao,
		IdStatus,
		Observacao
	FROM 
		CRJEscola
	where @IdEscola = @IdEscola;
END;
//

DELIMITER ;


	

/************************************************************************************************************************/




