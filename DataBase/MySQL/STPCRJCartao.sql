
DELIMITER //

CREATE PROCEDURE STPCRJCartao
(
	IdPessoa Int,
	DataEmissao DateTime(3)
)
BEGIN

	INSERT INTO CRJCartao
	(
		IdPessoa,
		DataEmissao
	)
	VALUES
	(
		@IdPessoa,
		@DataEmissao
	);

END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJCartao];2    Script Date: 11/29/2012 19:30:46 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

DELIMITER //

CREATE PROCEDURE STPCRJCartao2
(
	IdCartao Int,
	IdPessoa Int,	
	DataEmissao DateTime
)
begin

	UPDATE CRJCartao SET
		IdPessoa = @IdPessoa,
		DataEmissao = @DataEmissao
	WHERE 
		IdCartao = @IdCartao;




END;
//

DELIMITER ;


DELIMITER //

CREATE PROCEDURE STPCRJCartao3
(
	IdCartao Int
)
begin

	DELETE FROM CRJCartao
	WHERE IdCartao = @IdCartao;




END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJCartao];4    Script Date: 11/29/2012 19:30:46 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

DELIMITER //

CREATE PROCEDURE STPCRJCartao4()
begin

	SELECT 
		IdCartao,
		IdPessoa,
		DataEmissao
	FROM 
		CRJCartao;




END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJCartao];5    Script Date: 11/29/2012 19:30:46 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

DELIMITER //

CREATE PROCEDURE STPCRJCartao5
(
	IdCartao Int
)
begin

	SELECT 
		IdCartao,
		IdPessoa,
		DataEmissao
	FROM 
		CRJCartao
	WHERE 
		IdCartao = @IdCartao;



END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJCartao];6    Script Date: 11/29/2012 19:30:46 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

DELIMITER //

CREATE PROCEDURE STPCRJCartao6
(		
	pNome		varchar(255) ,
	pEmail		varchar(255) ,
	pCPF		varchar(255) ,
	pTelefone	varchar(255) 

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
			o.IdCartao,
			o.DataEmissao
			
			
	FROM 
			CRJPessoa p, CRJCartao o, CRJAluno a	
	Where  p.IdPessoa = o.IdPessoa AND p.Nome = IFNULL(@pNome,p.Nome) AND p.Email = IFNULL(@pEmail,p.Email) AND p.CPF = IFNULL(@pCPF,p.CPF) AND p.Telefone = IFNULL(@pTelefone,p.Telefone);
			

END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJCartao];7    Script Date: 11/29/2012 19:30:46 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

DELIMITER //

CREATE PROCEDURE STPCRJCartao7
(		
	idPessoa		int

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
			o.IdCartao,
			o.DataEmissao
			
			
	FROM 
			CRJPessoa p, CRJCartao o
	Where  p.IdPessoa = o.IdPessoa AND p.IdPessoa = @idPessoa;
			

END;
//

DELIMITER ;




