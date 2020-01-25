
DELIMITER //

CREATE PROCEDURE STPCRJAplicacoes01 
(
	pIdAplicacao int ,
	pAplicacaoPai int,
	pUsuario varchar(50) 
)
begin

	select 
		 a.IdAplicacao,
		 a.Nome,
		 a.Descricao,
		 a.Caminho,
		 a.AplicacaoPai
		
		 
	from CRJAplicacoes a		
		
	WHERE 
	
		a.IdAplicacao  = ifnull(@pIdAplicacao,a.IdAplicacao)
	AND a.AplicacaoPai = ifnull(@pAplicacaoPai,a.AplicacaoPai)
	
	GROUP BY
		 a.IdAplicacao,
		 a.Nome,
		 a.Descricao,
		 a.Caminho,
		 a.AplicacaoPai;
		


/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: Obtem todas as aplicações que um usuario Possui ( Somente Aplicações que possuem Links
* Objetivo.......: 
* Parâmetros.....: 
* Alterações.....: STPCRJAplicacoes;02 'joao@hotmail.com'
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJAplicacoes02
(
	pLogin varchar(50),
	pAplicacaoPai int 
)
begin


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
	AND a.AplicacaoPai = ifnull(@pAplicacaoPai,a.AplicacaoPai)	
	
	GROUP BY
		 a.IdAplicacao,
		 a.Nome,
		 a.Descricao,
		 a.Caminho,
		 a.AplicacaoPai;
		
		 
/************************************************************************************************************************/


END;
//

DELIMITER ;



 