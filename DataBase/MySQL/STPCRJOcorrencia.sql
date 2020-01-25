 

DELIMITER //

CREATE PROCEDURE STPCRJOcorrencia
(
	p_IdLancador Int,
	p_IdAluno Int,
	p_Natureza VarChar(100),
	p_Ocorrencia VarChar(5000),
	p_Providencias VarChar(5000),
	p_DataOcorrencia DateTime(3)
)
BEGIN

	INSERT INTO CRJOcorrencia
	(
		IdLancador,
		IdAluno,
		Ocorrencia,
		Providencias,
		DataOcorrencia
	)
	VALUES
	(
		p_IdLancador,
		p_IdAluno,
		p_Ocorrencia,
		p_Providencias,
		p_DataOcorrencia
	);

/************************************************************************************************************************/









END;
//

DELIMITER ;




DELIMITER //

CREATE PROCEDURE STPCRJOcorrencia2
(
	IdOcorrencia Int,
	IdLancador Int,
	IdAluno Int,
	Natureza VarChar(100),
	Ocorrencia VarChar(5000),
	Providencias VarChar(5000),
	DataOcorrencia DateTime
)
begin

	UPDATE CRJOcorrencia SET
		IdLancador = @IdLancador,
		IdAluno = @IdAluno,
		Ocorrencia = @Ocorrencia,
		Providencias = @Providencias,
		DataOcorrencia = @DataOcorrencia
	WHERE 
		IdOcorrencia = @IdOcorrencia;




END;
//

DELIMITER ;



DELIMITER //

CREATE PROCEDURE STPCRJOcorrencia3
(
	IdOcorrencia Int
)
begin

	DELETE FROM CRJOcorrencia
	WHERE IdOcorrencia = @IdOcorrencia;




END;
//

DELIMITER ;




DELIMITER //

CREATE PROCEDURE STPCRJOcorrencia4()
begin

	SELECT 
		IdOcorrencia,
		IdLancador,
		IdAluno,
		Ocorrencia,
		Providencias,
		DataOcorrencia
	FROM 
		CRJOcorrencia;




END;
//

DELIMITER ;



DELIMITER //

CREATE PROCEDURE STPCRJOcorrencia5
(
	IdOcorrencia Int
)
begin

	SELECT 
		IdOcorrencia,
		IdLancador,
		IdAluno,
		Ocorrencia,
		Providencias,
		DataOcorrencia
	FROM 
		CRJOcorrencia
	WHERE 
		IdOcorrencia = @IdOcorrencia;


END;
//

DELIMITER ;




DELIMITER //

CREATE PROCEDURE STPCRJOcorrencia6
(		
	pNome		varchar(255) ,
	pEmail		varchar(255) ,
	pCPF		varchar(255) ,
	pTelefone	varchar(255) ,	
	pRA		varchar(255) 

)
begin

	SELECT 
			p.IdPessoa,			
			p.Nome,
			p.Sexo,
			p.Email,
			p.DataNascimento,
			p.CPF,
			p.Telefone,
			p.Celular,
			p.CEP,
			p.Logradouro,
			p.Numero,
			p.Bairro,
			p.Cidade,
			p.Estado,
			p.Pais,
			o.IdOcorrencia,
			o.Ocorrencia,
			o.Providencias,
			o.DataOcorrencia,
			a.RA
			
			
	FROM 
			CRJPessoa p, CRJOcorrencia o, CRJAluno a	
	Where  p.IdPessoa = a.IdPessoa AND o.IdAluno = a.IdAluno AND p.Nome = IFNULL(@pNome,p.Nome) AND p.Email = IFNULL(@pEmail,p.Email) AND p.CPF = IFNULL(@pCPF,p.CPF) AND p.Telefone = IFNULL(@pTelefone,p.Telefone) AND a.RA = IFNULL(@pRA,a.RA);
			


END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJOcorrencia];7    Script Date: 11/29/2012 19:40:32 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

DELIMITER //

CREATE PROCEDURE STPCRJOcorrencia7
(
	IdAluno Int
)
begin

	SELECT 
		IdOcorrencia,
		IdLancador,
		a.IdAluno,
		Ocorrencia,
		Providencias,
		DataOcorrencia,
		a.RA,
		p.Nome
	FROM
			CRJPessoa p, CRJOcorrencia o, CRJAluno a	
	Where  p.IdPessoa = a.IdPessoa AND o.IdAluno = a.IdAluno
		AND a.IdAluno = @IdAluno;


END;
//

DELIMITER ;




