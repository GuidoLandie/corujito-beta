
DELIMITER //

CREATE PROCEDURE STPCRJProdutoVendido01
(
	
	IdPessoa int,		
	ValorTotal  float,
	v_IdVendaProduto int,
	v_IdCartao int
)
begin

	INSERT INTO  CRJVendaProduto
	(		
		IdPessoa
		,DataVenda
		,ValorTotal         
	)
	VALUES
	(
		
		@IdPessoa,
		now(),
		@ValorTotal  
	);
	
	
	
	
	set v_IdVendaProduto = @@identity;
	select c.IdCartao into v_IdCartao from CRJCartao c where  c.IdPessoa = @IdPessoa;
	
	
	
	
	
	insert into CRJLancamentoCartao (			
		IdLancador
		,IdCartao
		,Valor
		,DataLancamento
		,Descricao
	)values(
		@IdPessoa
		,v_IdCartao
		,(@ValorTotal * -1)
		,now()
		,'Compra na cantina'
        /*,concat(cast(v_IdVendaProduto as varchar(1)) , ' - Compra na cantina em ' , date_format(now(),'%d/%m/%Y'))*/
        
	);
	
	
	select v_IdVendaProduto;
	

/************************************************************************************************************************/





END;
//

DELIMITER ;






/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Alterar um registro na tabela CRJStatus
* Parâmetros.....: @IdStatus = 
*                  @Descricao = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJProdutoVendido02
(
	IdProdutoVendido  INTEGER,
	IdVendaProduto    INTEGER,
	IdProduto         INTEGER,
	Valor             FLOAT 
)
begin

	UPDATE CRJProdutoVendido SET
		
		IdVendaProduto = @IdVendaProduto,
	    IdProduto = @IdProduto,
		Valor = @Valor
	
	WHERE 
		IdProdutoVendido = @IdProdutoVendido;

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

CREATE PROCEDURE STPCRJProdutoVendido03
(
	IdProdutoVendido int
)
begin

	DELETE FROM CRJProdutoVendido
	WHERE IdProdutoVendido = @IdProdutoVendido;

/************************************************************************************************************************/





END;
//

DELIMITER ;






/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter todos os registros da tabela CRJStatus
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJProdutoVendido04()

	-- @IdPessoa INTEGER = NULL



begin

 SELECT c.IdProdutoVendido,
        c.IdVendaProduto,
        c.IdProduto,
        c.Valor
       
 FROM   CRJProdutoVendido c;
 
 
 


/************************************************************************************************************************/





END;
//

DELIMITER ;






/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJProdutoVendido05
(
	IdProdutoVendido Int
)
begin

	SELECT 
		c.IdProdutoVendido,
        c.IdVendaProduto,
        c.IdProduto,
        c.Valor
	FROM 
		CRJprodutoVendido c
	WHERE 
		 c.IdProdutoVendido = @IdProdutoVendido;

/************************************************************************************************************************/



END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJProdutoVendido06
(
	
	IdVendaProduto int,
	IdProduto	int,
	Valor	float,
	Quantidade int,
    v_IdProdutoVendito int
	
)
begin

	
	insert into CRJProdutoVendido (	
	
		 IdVendaProduto
		,IdProduto
		,Valor
	)values
	(
		@IdVendaProduto,
		@IdProduto,	
		@Valor	
	);

	
	
	set v_IdProdutoVendito = @@identity;
	
	-- remover do total dos produtos
	update CRJProduto
		set
			Quantidade = (Quantidade  - @Quantidade)
	where IdProduto = @IdProduto;


end;
//

delimiter ;





/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 18/5/2012 16:44:17
* Objetivo.......: Obter um registro da tabela CRJStatus
* Parâmetros.....: @IdStatus = .
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJProdutoVendido07
(
	
	IdPessoa int
	
)
begin


	select 
		
		 pv.IdProdutoVendido
		,pv.IdVendaProduto
		,pv.IdProduto
		,pv.Valor
		,vp.DataVenda
		,p.Nome
		
	 from 
	 
	CRJProdutoVendido pv
	
	inner join CRJProduto p
	on p.IdProduto = pv.IdProduto
	
	inner join CRJVendaProduto vp
	on vp.IdVendaProduto = pv.IdVendaProduto
	and vp.IdPessoa = @IdPessoa;
END;
//

DELIMITER ;


	
	
