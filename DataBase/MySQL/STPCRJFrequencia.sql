
DELIMITER //

CREATE PROCEDURE STPCRJFrequencia01
(		
	IdProfMatClasse int,
	DataAula	datetime,
	IdLancador int				
)
begin

	insert into CRJFrequencia (IdCRJMatricula,DataAula,IdLancador,IdProfXMatXClasse,Presente)
	
	select m.idCRJMatricula,@DataAula,@IdLancador,@IdProfMatClasse,1 from CRJProfXMatXClasse p
		
		inner join CRJClasse c
		on c.IdClasse = p.IdClasse
		
		inner join CRJMatricula m
		on m.idClasse = c.IdClasse
	where p.IdProfXMatXClasse = @IdProfMatClasse;		
	
	
/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Alterar um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @IdEscola = 
*          
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJFrequencia02
(
	IdFrequencia int,
	Presente	bit,
	IdLancador int
			
)
begin
	update CRJFrequencia
	set Presente = @Presente,
	IdLancador = @IdLancador
	where IdFrequencia = @IdFrequencia;	
	
	
	

/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Remover um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJFrequencia03
(
	IdProMatClasse int
)
begin
	select 
		 f.IdFrequencia
		,f.IdCRJMatricula
		,f.IdProfXMatXClasse
		,f.DataAula
		,f.Presente
		,f.IdLancador
		,p.Nome
		
	 from CRJFrequencia f
	 inner join CRJMatricula m
		on m.idCRJMatricula = f.IdCRJMatricula
		
		inner join CRJAluno a
		on a.IdAluno = m.IdAluno		
		
		inner join CRJPessoa p
		on p.IdPessoa = a.IdPessoa
		
	where f.IdProfXMatXClasse = @IdProMatClasse;


/************************************************************************************************************************/


END;
//

DELIMITER ;



/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Remover um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJFrequencia04 
(
	IdAluno int
)
begin
	select 
		 f.IdFrequencia
		,f.IdCRJMatricula
		,f.IdProfXMatXClasse
		,f.DataAula
		,f.Presente
		,f.IdLancador
		,p.Nome
	 from CRJFrequencia f
		inner join CRJMatricula m
		on m.idCRJMatricula = f.IdCRJMatricula
		
		inner join CRJAluno a
		on a.IdAluno = m.IdAluno
		and a.IdAluno = @IdAluno
		
		inner join CRJPessoa p
		on p.IdPessoa = a.IdPessoa;


/************************************************************************************************************************/


end;
//

delimiter ;



DELIMITER //

CREATE PROCEDURE STPCRJFrequencia05
(
	IdAluno int
)
begin
	select

			p.Nome,
			mat.Descricao,
			count(f.presente) as Frequentadas,
			(select COUNT(*) from CRJFrequencia f2 where f2.IdProfXMatXClasse = pfm.IdProfXMatXClasse and f2.IdCRJMatricula = m.idCRJMatricula) as Total,
			(count(f.Presente) * 100)/(select COUNT(*) from CRJFrequencia f2 where f2.IdProfXMatXClasse = pfm.IdProfXMatXClasse and f2.IdCRJMatricula = m.idCRJMatricula) AS Porcentagem
			
			

		 from 

		CRJFrequencia f
		inner join CRJMatricula m
		on m.idCRJMatricula = f.IdCRJMatricula

		inner join CRJAluno a 
		on a.IdAluno =m.IdAluno

		inner join CRJPessoa p
		on p.IdPessoa = a.IdPessoa

		inner join CRJProfXMatXClasse pfm
		on pfm.IdProfXMatXClasse = f.IdProfXMatXClasse

		inner join CRJMateria mat
		on mat.IdMateria = pfm.IdMateria

		where a.IdAluno = @idaluno
			and f.Presente = 1
		group by 
			p.Nome,		
			pfm.IdProfXMatXClasse,
			m.idCRJMatricula,
			mat.Descricao
		order by p.Nome;
		
/************************************************************************************************************************/


end;
//

delimiter ;



