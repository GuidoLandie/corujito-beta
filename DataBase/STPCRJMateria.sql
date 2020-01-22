
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJMateria]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJMateria
	
GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Inserir um registro na tabela CRJMateria
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJMateria;01
(			
	@idMateria int  = null
)
AS	
	SELECT 
		a.IdMateria,
		a.Descricao,
		a.TipoMateria
	FROM   CRJMateria a
	where a.idMateria = ISNULL(@idMateria,a.Idmateria)
/************************************************************************************************************************/

GO