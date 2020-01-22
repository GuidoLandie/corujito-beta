
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJResponsavel]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJResponsavel
	
GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Obter um registro da tabela CRJPessoa
* Parâmetros.....: @IdPessoa = .
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJResponsavel;01
(	
	@pidResponsavel	int
)
AS
SET NOCOUNT ON

	SELECT 
		p.idResponsavel,
		p.idAluno,
		p.IdPai
	FROM 
		CRJResponsavel  p			
					
	WHERE 				
			p.idResponsavel = isnull(@pidResponsavel,p.idResponsavel)
		
/************************************************************************************************************************/