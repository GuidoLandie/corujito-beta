
DELIMITER //

CREATE PROCEDURE STPCRJNotaAluno01
(		
	IdProfMatClasse	int,
	IdAtividade		int,
	IdLancador			int				
)
begin

	insert into CRJNotaAluno(IdAtividade,IdMatricula,IdProfXMatXClasse,Atribuidor)	
		select @IdAtividade, m.idCRJMatricula,@IdProfMatClasse,@IdLancador 
			from CRJProfXMatXClasse p		
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

CREATE PROCEDURE STPCRJNotaAluno02
(
	IdNotaAluno	int,
	Nota			float,
	IdLancador		int
			
)
begin
	update CRJNotaAluno
	set 
		Nota	 = @Nota,
		DataNota = now()
	where
		IdNotaAluno = @IdNotaAluno;
	

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
*************************************** *********************************************************************************/
DELIMITER //

CREATE PROCEDURE STPCRJNotaAluno03
(
	IdProMatClasse int
)
begin
	select 
		 f.IdNotaAluno
		,f.IdMatricula
		,f.IdProfXMatXClasse
		,f.DataNota
		,f.Nota
		,f.Atribuidor
		,p.Nome
		,CONCAT(ta.Descricao ,' - ',at.Nomeatividade , ' de  ' , date_format(at.DataInicial,'%d/%m/%Y') ,' até ', date_format(at.Datafinal,'%d/%m/%Y')) as Atividade
		
	 from CRJNotaAluno f
	 inner join CRJMatricula m
		on m.idCRJMatricula = f.IdMatricula
		
		inner join CRJAluno a
		on a.IdAluno = m.IdAluno		
		
		inner join CRJPessoa p
		on p.IdPessoa = a.IdPessoa
	
		inner join CRJAtividade at
		on at.IdAtividade = f.IdAtividade
		
		inner join CRJTipoAtividade ta
		on ta.IdTipoAtividade = at.IdTipoAtividade
		
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

CREATE PROCEDURE STPCRJNotaAluno04 
(
	IdAluno int
)
begin
	select 
		 f.IdNotaAluno
		,f.IdMatricula
		,f.IdProfXMatXClasse
		,f.DataNota
		,f.Nota
		,f.Atribuidor
		,p.Nome
		,mt.Descricao AS Materia
		
	 from CRJNotaAluno f
		inner join CRJMatricula m
		on m.idCRJMatricula = f.IdMatricula
		
		inner join CRJAluno a
		on a.IdAluno = m.IdAluno
		and a.IdAluno = @IdAluno
		
		inner join CRJPessoa p
		on p.IdPessoa = a.IdPessoa
		
		inner join CRJProfXMatXClasse pmc
		on pmc.IdProfXMatXClasse = f.IdProfXMatXClasse
		
		inner join CRJMateria mt
		on mt.IdMateria = pmc.IdMateria
	Order by mt.Descricao;
		
		
		
		


/************************************************************************************************************************/


end;
//

delimiter ;



DELIMITER //

CREATE PROCEDURE STPCRJNotaAluno05
(
	IdAtividade int,
	IdLancador	 int
)
begin
	delete from CRJNotaAluno where IdAtividade = @IdAtividade;
END;
//

DELIMITER ;


	
/************************************************************************************************************************/	