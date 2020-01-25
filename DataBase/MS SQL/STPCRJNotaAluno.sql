
IF  EXISTS (
			SELECT * FROM sys.objects 
			WHERE	object_id = OBJECT_ID(N'[STPCRJNotaAluno]') 
			AND		type in (N'P', N'PC')
		)	
		
	DROP PROCEDURE STPCRJNotaAluno
	
GO


/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Inserir um registro na tabela CRJNotaAluno
* Parâmetros.....: 
* Alterações.....: 
************************************************************************************************************************/
CREATE PROCEDURE STPCRJNotaAluno;01
(		
	@IdProfMatClasse	int,
	@IdAtividade		int,
	@IdLancador			int				
)
AS

	insert into CRJNotaAluno(IdAtividade,IdMatricula,IdProfXMatXClasse,Atribuidor)	
		select @IdAtividade, m.idCRJMatricula,@IdProfMatClasse,@IdLancador 
			from CRJProfXMatXClasse p		
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
CREATE PROCEDURE STPCRJNotaAluno;02
(
	@IdNotaAluno	int,
	@Nota			float,
	@IdLancador		int
			
)
AS
	update CRJNotaAluno
	set 
		Nota	 = @Nota,
		DataNota = getdate()
	where
		IdNotaAluno = @IdNotaAluno
	

/************************************************************************************************************************/

GO

/************************************************************************************************************************
* Criado Por.....: guidolandie
* Data de Criação: 14/6/2012 11:51:27
* Objetivo.......: Remover um registro na tabela CRJPessoa
* Parâmetros.....: @IdPessoa = 
*                  @RUUsuarioLogado = RU do Usuário Logado. Utilizado para armazenamento do LOG.
* Alterações.....: 
*************************************** *********************************************************************************/
CREATE PROCEDURE STPCRJNotaAluno;03
(
	@IdProMatClasse int
)
AS
	select 
		 f.IdNotaAluno
		,f.IdMatricula
		,f.IdProfXMatXClasse
		,f.DataNota
		,f.Nota
		,f.Atribuidor
		,p.Nome
		,ta.Descricao +' - '+at.Nomeatividade + ' de  ' + convert(varchar,at.DataInicial,103) +' até '+ convert(varchar,at.Datafinal,103) as Atividade
		
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
CREATE PROCEDURE STPCRJNotaAluno;04 
(
	@IdAluno int
)
AS
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
	Order by mt.Descricao
		
		
		
		


/************************************************************************************************************************/

go

CREATE PROCEDURE STPCRJNotaAluno;05
(
	@IdAtividade int,
	@IdLancador	 int
)
AS
	delete from CRJNotaAluno where IdAtividade = @IdAtividade
	
/************************************************************************************************************************/	