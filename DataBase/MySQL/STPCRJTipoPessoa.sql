
DELIMITER //

CREATE PROCEDURE STPCRJTipoPessoa()
BEGIN

	select 
			p.IdTipoPessoa
			,p.Descricao
	 from CRJTipoPessoa p
	order by p.Descricao;

END;
//

DELIMITER ;



DELIMITER //

CREATE PROCEDURE STPCRJTipoPessoa02
(
	pIdTipoPessoa Int
)
BEGIN

	select 
	         p.IdTipoPessoa
			,p.Descricao			
	 from CRJTipoPessoa p
	 where p.IdTipoPessoa = @pIdTipoPessoa;
/************************************************************************************************************************/


end;
//

delimiter ;


GO


DELIMITER //

CREATE PROCEDURE STPCRJTipoPessoa03
(
	pIdPessoa Int
)
BEGIN

	select 
	         p.IdTipoPessoa
			,p.Descricao			
	 from CRJTipoPessoa p
	 INNER JOIN CRJPessoaXTipo cpt
		on cpt.IdTipoPessoa = p.IdTipoPessoa
		and cpt.IdPessoa = @pIdPessoa
		
	order by p.Descricao;
	 






END;
//

DELIMITER ;



