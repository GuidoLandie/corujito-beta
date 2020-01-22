USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJMatricula]    Script Date: 11/29/2012 19:39:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[pjs0105].[STPCRJMatricula]') AND type in (N'P', N'PC'))
DROP PROCEDURE [pjs0105].[STPCRJMatricula]
GO

USE [pjs0105]
GO

/****** Object:  StoredProcedure [pjs0105].[STPCRJMatricula]    Script Date: 11/29/2012 19:39:14 ******/
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
CREATE PROCEDURE [pjs0105].[STPCRJMatricula]
(
	@idCRJMatricula int = null
)
AS
SET NOCOUNT ON

	SELECT 
			m.idCRJMatricula,
			m.CRJSeriesXEnsino_idSerieXEnsino,
			m.idClasses,
			m.CRJEscola_idEscola,
			m.CRJAluno_RA,
			m.DateMatricula
	FROM   CRJMatricula m
	WHERE 
		m.idCRJMatricula = isnull(@idCRJMatricula,idCRJMatricula)
		

/************************************************************************************************************************/



GO


