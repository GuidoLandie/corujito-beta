USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJOcorrencia]    Script Date: 11/29/2012 19:40:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[pjs0105].[STPCRJOcorrencia]') AND type in (N'P', N'PC'))
DROP PROCEDURE [pjs0105].[STPCRJOcorrencia]
GO

USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJOcorrencia]    Script Date: 11/29/2012 19:40:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJOcorrencia]
(
	@IdLancador Int,
	@IdAluno Int,
	@Natureza VarChar(100),
	@Ocorrencia VarChar(5000),
	@Providencias VarChar(5000),
	@DataOcorrencia DateTime
)
AS

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
		@IdLancador,
		@IdAluno,
		@Ocorrencia,
		@Providencias,
		@DataOcorrencia
	)

/************************************************************************************************************************/








GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJOcorrencia];2    Script Date: 11/29/2012 19:40:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJOcorrencia];2
(
	@IdOcorrencia Int,
	@IdLancador Int,
	@IdAluno Int,
	@Natureza VarChar(100),
	@Ocorrencia VarChar(5000),
	@Providencias VarChar(5000),
	@DataOcorrencia DateTime
)
AS

	UPDATE CRJOcorrencia SET
		IdLancador = @IdLancador,
		IdAluno = @IdAluno,
		Ocorrencia = @Ocorrencia,
		Providencias = @Providencias,
		DataOcorrencia = @DataOcorrencia
	WHERE 
		IdOcorrencia = @IdOcorrencia



GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJOcorrencia];3    Script Date: 11/29/2012 19:40:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJOcorrencia];3
(
	@IdOcorrencia Int
)
AS

	DELETE FROM CRJOcorrencia
	WHERE IdOcorrencia = @IdOcorrencia



GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJOcorrencia];4    Script Date: 11/29/2012 19:40:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJOcorrencia];4
AS
SET NOCOUNT ON

	SELECT 
		IdOcorrencia,
		IdLancador,
		IdAluno,
		Ocorrencia,
		Providencias,
		DataOcorrencia
	FROM 
		CRJOcorrencia



GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJOcorrencia];5    Script Date: 11/29/2012 19:40:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJOcorrencia];5
(
	@IdOcorrencia Int
)
AS
SET NOCOUNT ON

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
		IdOcorrencia = @IdOcorrencia

GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJOcorrencia];6    Script Date: 11/29/2012 19:40:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJOcorrencia];6
(		
	@pNome		varchar(255) = NULL,
	@pEmail		varchar(255) = NULL,
	@pCPF		varchar(255) = NULL,
	@pTelefone	varchar(255) = NULL,	
	@pRA		varchar(255) = NULL

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
			o.IdOcorrencia,
			o.Ocorrencia,
			o.Providencias,
			o.DataOcorrencia,
			a.RA
			
			
	FROM 
			CRJPessoa p, CRJOcorrencia o, CRJAluno a	
	Where  p.IdPessoa = a.IdPessoa AND o.IdAluno = a.IdAluno AND p.Nome = ISNULL(@pNome,p.Nome) AND p.Email = ISNULL(@pEmail,p.Email) AND p.CPF = ISNULL(@pCPF,p.CPF) AND p.Telefone = ISNULL(@pTelefone,p.Telefone) AND a.RA = ISNULL(@pRA,a.RA)
			

GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJOcorrencia];7    Script Date: 11/29/2012 19:40:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJOcorrencia];7
(
	@IdAluno Int
)
AS
SET NOCOUNT ON

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
		AND a.IdAluno = @IdAluno

GO


