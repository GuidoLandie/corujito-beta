
DELIMITER //

CREATE PROCEDURE STPCRJAluno
(
	p_IdPessoa int 
)
BEGIN


	SELECT 
			RA
			IdPessoa 
	FROM CRJAluno 
	WHERE IdPessoa = p_IdPessoa;
	


/************************************************************************************************************************/




END;
//

DELIMITER ;




DELIMITER //

CREATE PROCEDURE STPCRJAluno06
(		
	pNome		varchar(255) ,
	pEmail		varchar(255) ,
	pCPF		varchar(255) ,
	pTelefone	varchar(255) ,	
	pRA		varchar(255) ,
	pIdAluno   varchar(255) 

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
			a.RA,
			a.IdAluno
			
			
	FROM 
			CRJPessoa p, CRJAluno a	
	Where  p.IdPessoa = a.IdPessoa AND p.Nome = IFNULL(@pNome,p.Nome) AND p.Email = IFNULL(@pEmail,p.Email) AND p.CPF = IFNULL(@pCPF,p.CPF) AND p.Telefone = IFNULL(@pTelefone,p.Telefone) AND a.RA = IFNULL(@pRA,a.RA) AND a.IdAluno = IFNULL(@pIdAluno,a.IdAluno);

END;
//

DELIMITER ;




