USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJMensagem]    Script Date: 11/29/2012 19:40:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[pjs0105].[STPCRJMensagem]') AND type in (N'P', N'PC'))
DROP PROCEDURE [pjs0105].[STPCRJMensagem]
GO

USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJMensagem]    Script Date: 11/29/2012 19:40:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJMensagem]
(
	@IdLancador Int,
	@IdAluno Int,
	@Mensagem VarChar(5000),
	@DataMensagem DateTime
)
AS

	INSERT INTO CRJMensagem
	(
		IdLancador,
		IdAluno,
		Mensagem,
		DataMensagem
	)
	VALUES
	(
		@IdLancador,
		@IdAluno,
		@Mensagem,
		@DataMensagem
	)

/************************************************************************************************************************/







GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJMensagem];2    Script Date: 11/29/2012 19:40:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJMensagem];2
(
	@IdMensagem Int,
	@IdLancador Int,
	@IdAluno Int,
	@Mensagem VarChar(5000),
	@DataMensagem DateTime
)
AS

	UPDATE CRJMensagem SET
		IdLancador = @IdLancador,
		IdAluno = @IdAluno,
		Mensagem = @Mensagem,
		DataMensagem = @DataMensagem
	WHERE 
		IdMensagem = @IdMensagem


GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJMensagem];3    Script Date: 11/29/2012 19:40:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJMensagem];3
(
	@IdMensagem Int
)
AS

	DELETE FROM CRJMensagem
	WHERE IdMensagem = @IdMensagem


GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJMensagem];4    Script Date: 11/29/2012 19:40:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJMensagem];4
AS
SET NOCOUNT ON

	SELECT 
		IdMensagem,
		IdLancador,
		IdAluno,
		Mensagem,
		DataMensagem
	FROM 
		CRJMensagem


GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJMensagem];5    Script Date: 11/29/2012 19:40:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJMensagem];5
(
	@IdMensagem Int
)
AS
SET NOCOUNT ON

	SELECT 
		IdMensagem,
		IdLancador,
		IdAluno,
		Mensagem,
		DataMensagem
	FROM 
		CRJMensagem
	WHERE 
		IdMensagem = @IdMensagem

GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJMensagem];6    Script Date: 11/29/2012 19:40:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pjs0105].[STPCRJMensagem];6
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
			o.IdMensagem,
			o.Mensagem,
			o.DataMensagem,
			a.RA
			
			
	FROM 
			CRJPessoa p, CRJMensagem o, CRJAluno a	
	Where  p.IdPessoa = a.IdPessoa AND o.IdAluno = a.IdAluno AND p.Nome = ISNULL(@pNome,p.Nome) AND p.Email = ISNULL(@pEmail,p.Email) AND p.CPF = ISNULL(@pCPF,p.CPF) AND p.Telefone = ISNULL(@pTelefone,p.Telefone) AND a.RA = ISNULL(@pRA,a.RA)
			
GO


