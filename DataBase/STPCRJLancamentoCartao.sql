USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJLancamentoCartao]    Script Date: 12/09/2012 22:04:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[pjs0105].[STPCRJLancamentoCartao]') AND type in (N'P', N'PC'))
DROP PROCEDURE [pjs0105].[STPCRJLancamentoCartao]
GO

USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJLancamentoCartao]    Script Date: 12/09/2012 22:04:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [pjs0105].[STPCRJLancamentoCartao]
(
	@IdLancador Int,
	@IdCartao Int,
	@Valor Money,
	@DataLancamento DateTime,
	@Descricao varchar(255)
)
AS

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
		@IdLancador,
		@IdCartao,
		@Valor,
		@DataLancamento,
		@Descricao
	)

/************************************************************************************************************************/










GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];2    Script Date: 12/09/2012 22:04:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [pjs0105].[STPCRJLancamentoCartao];2
(
	@IdLancamentoCartao Int,
	@IdLancador Int,
	@IdCartao Int,
	@Valor Money,
	@DataLancamento DateTime
)
AS

	UPDATE CRJLancamentoCartao SET
		IdLancador = @IdLancador,
		IdCartao = @IdCartao,
		Valor = @Valor,
		DataLancamento = @DataLancamento
	WHERE 
		IdLancamentoCartao = @IdLancamentoCartao





GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];3    Script Date: 12/09/2012 22:04:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [pjs0105].[STPCRJLancamentoCartao];3
(
	@IdLancamentoCartao Int
)
AS

	DELETE FROM CRJLancamentoCartao
	WHERE IdLancamentoCartao = @IdLancamentoCartao





GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];4    Script Date: 12/09/2012 22:04:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [pjs0105].[STPCRJLancamentoCartao];4
AS
SET NOCOUNT ON

	SELECT 
		IdLancamentoCartao,
		IdLancador,
		IdCartao,
		Valor,
		DataLancamento
	FROM 
		CRJLancamentoCartao





GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];5    Script Date: 12/09/2012 22:04:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [pjs0105].[STPCRJLancamentoCartao];5
(
	@IdLancamentoCartao Int
)
AS
SET NOCOUNT ON

	SELECT 
		IdLancamentoCartao,
		IdLancador,
		IdCartao,
		Valor,
		DataLancamento
	FROM 
		CRJLancamentoCartao
	WHERE 
		IdLancamentoCartao = @IdLancamentoCartao




GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];6    Script Date: 12/09/2012 22:04:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [pjs0105].[STPCRJLancamentoCartao];6
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
			o.IdLancamentoCartao,
			o.Valor,
			o.DataLancamento
			
			
	FROM 
			CRJPessoa p, CRJLancamentoCartao o, CRJCartao a	
	Where  p.IdPessoa = a.IdPessoa AND o.IdCartao = a.IdCartao AND p.Nome = ISNULL(@pNome,p.Nome) AND p.Email = ISNULL(@pEmail,p.Email) AND p.CPF = ISNULL(@pCPF,p.CPF) AND p.Telefone = ISNULL(@pTelefone,p.Telefone)
			


GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];7    Script Date: 12/09/2012 22:04:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [pjs0105].[STPCRJLancamentoCartao];7 1
(		
	@idCartao		int


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
			o.IdLancamentoCartao,
			o.Valor,
			o.DataLancamento,
			o.Descricao
			
	FROM 
			CRJPessoa p, CRJLancamentoCartao o, CRJCartao a	
	Where  p.IdPessoa = a.IdPessoa AND o.IdCartao = a.IdCartao AND a.IdCartao = @idCartao
	
	order by o.DataLancamento asc
	
	SET ANSI_NULLS ON


GO

/****** Object:  NumberedStoredProcedure [pjs0105].[STPCRJLancamentoCartao];8    Script Date: 12/09/2012 22:04:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [pjs0105].[STPCRJLancamentoCartao];8
(
	@IdLancamentoCartao Int,
	@DataInicial Date,
	@DataFinal Date
)
AS
SET NOCOUNT ON

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
	order by DataLancamento asc
	


GO


