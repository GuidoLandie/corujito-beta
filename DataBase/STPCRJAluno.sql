USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJAluno]    Script Date: 11/29/2012 19:25:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[pjs0105].[STPCRJAluno]') AND type in (N'P', N'PC'))
DROP PROCEDURE [pjs0105].[STPCRJAluno]
GO

USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJAluno]    Script Date: 11/29/2012 19:25:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:28:05
* Objetivo.......: Obter um registro da tabela CRJTipoPessoa
* Parâmetros.....: pString = String para consulta
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE [pjs0105].[STPCRJAluno]
(
	@IdPessoa int = null
)
AS
SET NOCOUNT ON


	SELECT 
			RA
			IdPessoa 
	FROM CRJAluno 
	WHERE IdPessoa = @IdPessoa
	


/************************************************************************************************************************/



GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJAluno];6    Script Date: 11/29/2012 19:25:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJAluno];6
(		
	@pNome		varchar(255) = NULL,
	@pEmail		varchar(255) = NULL,
	@pCPF		varchar(255) = NULL,
	@pTelefone	varchar(255) = NULL,	
	@pRA		varchar(255) = NULL,
	@pIdAluno   varchar(255) = NULL

)
AS
SET NOCOUNT ON

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
	Where  p.IdPessoa = a.IdPessoa AND p.Nome = ISNULL(@pNome,p.Nome) AND p.Email = ISNULL(@pEmail,p.Email) AND p.CPF = ISNULL(@pCPF,p.CPF) AND p.Telefone = ISNULL(@pTelefone,p.Telefone) AND a.RA = ISNULL(@pRA,a.RA) AND a.IdAluno = ISNULL(@pIdAluno,a.IdAluno)
GO


