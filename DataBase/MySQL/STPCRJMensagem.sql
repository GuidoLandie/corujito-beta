DELIMITER //

CREATE PROCEDURE STPCRJMensagem
(
	p_IdLancador Int,
	p_IdAluno Int,
	p_Mensagem VarChar(5000),
	p_DataMensagem DateTime(3)
)
BEGIN

	INSERT INTO CRJMensagem
	(
		IdLancador,
		IdAluno,
		Mensagem,
		DataMensagem
	)
	VALUES
	(
		p_IdLancador,
		p_IdAluno,
		p_Mensagem,
		p_DataMensagem
	);

/************************************************************************************************************************/








END;
//

DELIMITER ;

DELIMITER //

CREATE PROCEDURE STPCRJMensagem2
(
	IdMensagem Int,
	IdLancador Int,
	IdAluno Int,
	Mensagem VarChar(5000),
	DataMensagem DateTime
)
begin

	UPDATE CRJMensagem SET
		IdLancador = @IdLancador,
		IdAluno = @IdAluno,
		Mensagem = @Mensagem,
		DataMensagem = @DataMensagem
	WHERE 
		IdMensagem = @IdMensagem;



END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJMensagem];3    Script Date: 11/29/2012 19:40:10 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

DELIMITER //

CREATE PROCEDURE STPCRJMensagem3
(
	IdMensagem Int
)
begin

	DELETE FROM CRJMensagem
	WHERE IdMensagem = @IdMensagem;



END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJMensagem];4    Script Date: 11/29/2012 19:40:10 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

DELIMITER //

CREATE PROCEDURE STPCRJMensagem4()
begin

	SELECT 
		IdMensagem,
		IdLancador,
		IdAluno,
		Mensagem,
		DataMensagem
	FROM 
		CRJMensagem;



END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJMensagem];5    Script Date: 11/29/2012 19:40:10 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

DELIMITER //

CREATE PROCEDURE STPCRJMensagem5
(
	IdMensagem Int
)
begin

	SELECT 
		IdMensagem,
		IdLancador,
		IdAluno,
		Mensagem,
		DataMensagem
	FROM 
		CRJMensagem
	WHERE 
		IdMensagem = @IdMensagem;


END;
//

DELIMITER ;



/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJMensagem];6    Script Date: 11/29/2012 19:40:10 ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

DELIMITER //

CREATE PROCEDURE STPCRJMensagem6
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
			o.IdMensagem,
			o.Mensagem,
			o.DataMensagem,
			a.RA
			
			
	FROM 
			CRJPessoa p, CRJMensagem o, CRJAluno a	
	Where  p.IdPessoa = a.IdPessoa AND o.IdAluno = a.IdAluno AND p.Nome = IFNULL(@pNome,p.Nome) AND p.Email = IFNULL(@pEmail,p.Email) AND p.CPF = IFNULL(@pCPF,p.CPF) AND p.Telefone = IFNULL(@pTelefone,p.Telefone) AND a.RA = IFNULL(@pRA,a.RA);
			

END;
//

DELIMITER ;




