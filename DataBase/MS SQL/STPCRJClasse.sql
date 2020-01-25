

----------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[STPCRJClasse]')
        AND  type IN (N'P', N'PC')
   )
    	
    	
    	DROP PROCEDURE STPCRJClasse
    	
----------------------------------------------------------------------------------------------------------------------------

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:36:59
* Objetivo.......: Obter um registro da tabela CRJOcorrencia
* Parâmetros.....: pString = String para consulta
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJClasse;01
(
	@idClasse int = NULL
)
AS
SET NOCOUNT ON

	SELECT 
			 IdClasse,
			 IdEnsino,			 
			 IdSerie,			 
			 IdTurno,
			 NomeTurma
	FROM   CRJClasse 
	WHERE IdClasse = isnull(@idClasse,IdClasse)
	
	
/************************************************************************************************************************/




GO