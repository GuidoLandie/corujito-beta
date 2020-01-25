DELIMITER //

CREATE PROCEDURE STPCRJTipoAtividade()
BEGIN

	SELECT Descricao
	      ,IdTipoAtividade
    FROM 
		  CRJTipoAtividade;

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter um registro da tabela CRJTipoProduto
* Parâmetros.....: @IdTipoProduto = .
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJTipoAtividade02
(
	IdTipoAtividade Int
)
BEGIN

	SELECT 
		IdTipoAtividade,
		Descricao	
	FROM 
		CRJTipoAtividade 
	WHERE 
		IdTipoAtividade = @IdTipoAtividade;
		
		
		

end;
//

delimiter ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 23/8/2012 12:25:58
* Objetivo.......: Obter um registro da tabela CRJTipoProduto
* Parâmetros.....: @IdTipoProduto = .
* Alterações.....: 
************************************************************************************************************************/

DELIMITER //

CREATE PROCEDURE STPCRJTipoAtividade03
(
	Descricao varchar(200),
	IdTipoAtividade int
)
BEGIN

	SELECT 
		IdTipoAtividade,
		Descricao	
	FROM 
		CRJTipoAtividade 
	WHERE 
		Descricao = ifnull(@Descricao,Descricao)
	and IdTipoAtividade = ifnull(@IdTipoAtividade,IdTipoAtividade);


END;
//

DELIMITER ;



