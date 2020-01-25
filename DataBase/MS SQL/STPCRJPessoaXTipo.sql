

IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJPessoaXTipo]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJPessoaXTipo

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Inserir um registro na tabela STPCRJPessoaXTipo
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJPessoaXTipo;01
(
	@pIdPessoa int,
	@pIdTipoPessoa int		
)
AS

	insert into CRJPessoaXTipo (IdPessoa,IdTipoPessoa) values (@pIdPessoa,@pIdTipoPessoa)
	
	SELECT @@identity

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Remover todos os tipos de uma pessoa a partir de uma pessoa
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJPessoaXTipo;02
(
	@pIdPessoa	int
)
AS
	delete from CRJPessoaXTipo where IdPessoa = @pIdPessoa

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Remover um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJPessoaXTipo;03
(
	@pIdPessoa int
)
AS

	select	t.IdTipoPessoa,
			t.IdPessoa,
			t.IdPessoaXTipo
			
	  from CRJPessoaXTipo t
	
	
/************************************************************************************************************************/


GO
