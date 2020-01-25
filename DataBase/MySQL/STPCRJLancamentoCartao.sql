

DELIMITER //

CREATE PROCEDURE STPCRJLancamentoCartao
(
	p_IdLancador Int,
	p_IdCartao Int,
	p_Valor Decimal(15,4),
	p_DataLancamento DateTime(3),
	p_Descricao varchar(255)
)
BEGIN

	INSERT INTO CRJLancamentoCartao
	(
		IdLancador,
		IdCartao,
		Valor,
		DataLancamento,
		Descricao
	)
	VALUES
	(
		p_IdLancador,
		p_IdCartao,
		p_Valor,
		p_DataLancamento,
		p_Descricao
	);

/************************************************************************************************************************/











END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];2    Script Date: 12/09/2012 22:04:53 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 


DELIMITER //

CREATE PROCEDURE STPCRJLancamentoCartao2
(
	IdLancamentoCartao Int,
	IdLancador Int,
	IdCartao Int,
	Valor float,
	DataLancamento DateTime
)
begin

	UPDATE CRJLancamentoCartao SET
		IdLancador = @IdLancador,
		IdCartao = @IdCartao,
		Valor = @Valor,
		DataLancamento = @DataLancamento
	WHERE 
		IdLancamentoCartao = @IdLancamentoCartao;






END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];3    Script Date: 12/09/2012 22:04:53 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 


DELIMITER //

CREATE PROCEDURE STPCRJLancamentoCartao3
(
	IdLancamentoCartao Int
)
begin

	DELETE FROM CRJLancamentoCartao
	WHERE IdLancamentoCartao = @IdLancamentoCartao;






END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];4    Script Date: 12/09/2012 22:04:53 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 


DELIMITER //

CREATE PROCEDURE STPCRJLancamentoCartao4()
begin

	SELECT 
		IdLancamentoCartao,
		IdLancador,
		IdCartao,
		Valor,
		DataLancamento
	FROM 
		CRJLancamentoCartao;






END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];5    Script Date: 12/09/2012 22:04:54 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 


DELIMITER //

CREATE PROCEDURE STPCRJLancamentoCartao5
(
	IdLancamentoCartao Int
)
begin

	SELECT 
		IdLancamentoCartao,
		IdLancador,
		IdCartao,
		Valor,
		DataLancamento
	FROM 
		CRJLancamentoCartao
	WHERE 
		IdLancamentoCartao = @IdLancamentoCartao;





END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];6    Script Date: 12/09/2012 22:04:54 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 


DELIMITER //

CREATE PROCEDURE STPCRJLancamentoCartao6
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
			o.IdLancamentoCartao,
			o.Valor,
			o.DataLancamento
			
			
	FROM 
			CRJPessoa p, CRJLancamentoCartao o, CRJCartao a	
	Where  p.IdPessoa = a.IdPessoa AND o.IdCartao = a.IdCartao AND p.Nome = IFNULL(@pNome,p.Nome) AND p.Email = IFNULL(@pEmail,p.Email) AND p.CPF = IFNULL(@pCPF,p.CPF) AND p.Telefone = IFNULL(@pTelefone,p.Telefone);
			



END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];7    Script Date: 12/09/2012 22:04:54 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 


DELIMITER //

CREATE PROCEDURE STPCRJLancamentoCartao7 
(		
	idCartao		int
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
			o.IdLancamentoCartao,
			o.Valor,
			o.DataLancamento,
			o.Descricao
			
	FROM 
			CRJPessoa p, CRJLancamentoCartao o, CRJCartao a	
	Where  p.IdPessoa = a.IdPessoa AND o.IdCartao = a.IdCartao AND a.IdCartao = @idCartao
	
	order by o.DataLancamento asc;
	
 
END;
//

DELIMITER ;




DELIMITER //

CREATE PROCEDURE STPCRJLancamentoCartao8
(
	IdLancamentoCartao Int,
	DataInicial Date,
	DataFinal Date
)
begin

	SELECT 
		IdLancamentoCartao,
		IdLancador,
		IdCartao,
		Valor,
		DataLancamento,
		Descricao
	FROM 
		CRJLancamentoCartao
	WHERE 
		IdLancamentoCartao = @IdLancamentoCartao
		and DataLancamento >= @DataInicial AND DataLancamento <= @DataFinal
	order by DataLancamento asc;
	



END;
//

DELIMITER ;




