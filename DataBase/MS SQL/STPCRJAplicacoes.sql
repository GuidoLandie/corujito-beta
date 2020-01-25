
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJAplicacoes]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJAplicacoes

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação:
* Objetivo.......: Metodo que Obtem todas as aplicações
* Parâmetros.....: 
* Alterações.....: STPCRJAplicacoes;01 2
************************************************************************************************************************/
CREATE PROCEDURE STPCRJAplicacoes;01 
(
	@pIdAplicacao int = null,
	@pAplicacaoPai int = NULL,
	@pUsuario varchar(50) = null
)
AS
SET NOCOUNT ON

	select 
		 a.IdAplicacao,
		 a.Nome,
		 a.Descricao,
		 a.Caminho,
		 a.AplicacaoPai
		
		 
	from CRJAplicacoes a		
		
	WHERE 
	
		a.IdAplicacao  = isnull(@pIdAplicacao,a.IdAplicacao)
	AND a.AplicacaoPai = isnull(@pAplicacaoPai,a.AplicacaoPai)
	
	GROUP BY
		 a.IdAplicacao,
		 a.Nome,
		 a.Descricao,
		 a.Caminho,
		 a.AplicacaoPai
		


/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: Obtem todas as aplicações que um usuario Possui ( Somente Aplicações que possuem Links
* Objetivo.......: 
* Parâmetros.....: 
* Alterações.....: STPCRJAplicacoes;02 'joao@hotmail.com'
************************************************************************************************************************/
CREATE PROCEDURE STPCRJAplicacoes;02
(
	@pLogin varchar(50),
	@pAplicacaoPai int = null
)
AS
SET NOCOUNT ON


	SELECT a.IdAplicacao,
	       a.Nome,
	       a.Descricao,
	       a.Caminho,
	       a.AplicacaoPai
	     
	
	FROM   CRJAplicacoes a

	WHERE	
	a.IdAplicacao IN (						
						SELECT au.IdAplicacao FROM   CRJAplicacaoUsuario au WHERE  au.Usuario = @pLogin 
						UNION 
						SELECT ag.IdAplicacao FROM   CRJAplicacaoGrupo ag 
							INNER JOIN CRJGrupoPermissaoUsuarios gpu											
							  ON   gpu.IdGrupo = ag.IdGrupo
							 AND   gpu.Usuario = @pLogin
						
						UNION
						
						SELECT distinct ag.IdAplicacao FROM   CRJAplicacaoGrupo ag 							
							INNER JOIN CRJGrupoPermissao gp
								ON ag.IdGrupo = gp.IdGrupo											
							
							INNER JOIN CRJPessoaXTipo ct
								on ct.IdTipoPessoa = gp.IdTipoPessoa
							
							INNER JOIN CRJUsuarios u
							on u.IdPessoa = ct.IdPessoa
							and u.Usuario = @pLogin
							
					 )	
	AND a.AplicacaoPai = isnull(@pAplicacaoPai,a.AplicacaoPai)	
	
	GROUP BY
		 a.IdAplicacao,
		 a.Nome,
		 a.Descricao,
		 a.Caminho,
		 a.AplicacaoPai
		
		 
/************************************************************************************************************************/

GO

 