USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJCartao]    Script Date: 11/29/2012 19:30:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[pjs0105].[STPCRJCartao]') AND type in (N'P', N'PC'))
DROP PROCEDURE [pjs0105].[STPCRJCartao]
GO

USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJCartao]    Script Date: 11/29/2012 19:30:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJCartao]
(
	@IdPessoa Int,
	@DataEmissao DateTime
)
AS

	INSERT INTO CRJCartao
	(
		IdPessoa,
		DataEmissao
	)
	VALUES
	(
		@IdPessoa,
		@DataEmissao
	)

/************************************************************************************************************************/








GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJCartao];2    Script Date: 11/29/2012 19:30:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJCartao];2
(
	@IdCartao Int,
	@IdPessoa Int,
	
	@DataEmissao DateTime
)
AS

	UPDATE CRJCartao SET
		IdPessoa = @IdPessoa,
		DataEmissao = @DataEmissao
	WHERE 
		IdCartao = @IdCartao



GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJCartao];3    Script Date: 11/29/2012 19:30:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJCartao];3
(
	@IdCartao Int
)
AS

	DELETE FROM CRJCartao
	WHERE IdCartao = @IdCartao



GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJCartao];4    Script Date: 11/29/2012 19:30:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJCartao];4
AS
SET NOCOUNT ON

	SELECT 
		IdCartao,
		IdPessoa,
		DataEmissao
	FROM 
		CRJCartao



GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJCartao];5    Script Date: 11/29/2012 19:30:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJCartao];5
(
	@IdCartao Int
)
AS
SET NOCOUNT ON

	SELECT 
		IdCartao,
		IdPessoa,
		DataEmissao
	FROM 
		CRJCartao
	WHERE 
		IdCartao = @IdCartao


GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJCartao];6    Script Date: 11/29/2012 19:30:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJCartao];6
(		
	@pNome		varchar(255) = NULL,
	@pEmail		varchar(255) = NULL,
	@pCPF		varchar(255) = NULL,
	@pTelefone	varchar(255) = NULL

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
			o.IdCartao,
			o.DataEmissao
			
			
	FROM 
			CRJPessoa p, CRJCartao o, CRJAluno a	
	Where  p.IdPessoa = o.IdPessoa AND p.Nome = ISNULL(@pNome,p.Nome) AND p.Email = ISNULL(@pEmail,p.Email) AND p.CPF = ISNULL(@pCPF,p.CPF) AND p.Telefone = ISNULL(@pTelefone,p.Telefone)
			
GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJCartao];7    Script Date: 11/29/2012 19:30:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJCartao];7
(		
	@idPessoa		int

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
			o.IdCartao,
			o.DataEmissao
			
			
	FROM 
			CRJPessoa p, CRJCartao o
	Where  p.IdPessoa = o.IdPessoa AND p.IdPessoa = @idPessoa
			
GO


