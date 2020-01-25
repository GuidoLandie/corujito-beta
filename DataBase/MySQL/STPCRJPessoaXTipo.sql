
DELIMITER //

CREATE PROCEDURE STPCRJPessoaXTipo01
(
	pIdPessoa int,
	pIdTipoPessoa int		
)
begin

	insert into CRJPessoaXTipo (IdPessoa,IdTipoPessoa) values (@pIdPessoa,@pIdTipoPessoa);
	
	SELECT @@identity;

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Remover todos os tipos de uma pessoa a partir de uma pessoa
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJPessoaXTipo02
(
	pIdPessoa	int
)
begin
	delete from CRJPessoaXTipo where IdPessoa = @pIdPessoa;

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Remover um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJPessoaXTipo03
(
	pIdPessoa int
)
begin

	select	t.IdTipoPessoa,
			t.IdPessoa,
			t.IdPessoaXTipo
			
	  from CRJPessoaXTipo t;
	
	
/************************************************************************************************************************/



END;
//

DELIMITER ;


