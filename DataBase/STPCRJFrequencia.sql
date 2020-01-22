
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJFrequencia]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJFrequencia
	
GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Inserir um registro na tabela STPCRJFrequencia
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJFrequencia;01
(		
	@IdProfMatClasse int,
	@DataAula	datetime,
	@IdLancador int				
)
AS

	insert into CRJFrequencia (IdCRJMatricula,DataAula,IdLancador,IdProfXMatXClasse,Presente)
	
	select m.idCRJMatricula,@DataAula,@IdLancador,@IdProfMatClasse,1 from CRJProfXMatXClasse p
		
		inner join CRJClasse c
		on c.IdClasse = p.IdClasse
		
		inner join CRJMatricula m
		on m.idClasse = c.IdClasse
	where p.IdProfXMatXClasse = @IdProfMatClasse		
	
	
/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Alterar um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @IdEscola = 
*          
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJFrequencia;02
(
	@IdFrequencia int,
	@Presente	bit,
	@IdLancador int
			
)
AS
	update CRJFrequencia
	set Presente = @Presente,
	IdLancador = @IdLancador
	where IdFrequencia = @IdFrequencia	
	
	
	

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Remover um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJFrequencia;03
(
	@IdProMatClasse int
)
AS
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
		
	where f.IdProfXMatXClasse = @IdProMatClasse


/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Remover um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJFrequencia;04 
(
	@IdAluno int
)
AS
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
		on p.IdPessoa = a.IdPessoa


/************************************************************************************************************************/

go

CREATE PROCEDURE STPCRJFrequencia;05
(
	@IdAluno int
)
AS
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
		order by p.Nome
		
/************************************************************************************************************************/

go

