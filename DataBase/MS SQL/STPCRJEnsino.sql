

----------------------------------------------------------------------------------------------------------------------------
IF EXISTS (
      SELECT *
      FROM   sys.objects
      WHERE  object_id = OBJECT_ID(N'[STPCRJEnsino]')
        AND  type IN (N'P', N'PC')
   )
    	
    	
    	DROP PROCEDURE STPCRJEnsino
    	
----------------------------------------------------------------------------------------------------------------------------

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Cria��o: 23/8/2012 12:36:59
* Objetivo.......: Obter um registro da tabela CRJOcorrencia
* Par�metros.....: pString = String para consulta
* Altera��es.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJEnsino;01
(
	@pidEnsino int = NULL
)
AS
SET NOCOUNT ON

	SELECT 
		idEnsino,
		idEscola,
		Descricao
	 FROM CRJEnsino
	 where idEnsino = isnull(@pidEnsino,idEnsino)
	
	
/************************************************************************************************************************/




GO